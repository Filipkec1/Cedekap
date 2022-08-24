using Diplomski.Core.Models.Entities;
using Diplomski.Core.Repositories;
using Diplomski.Core.Requests;
using Diplomski.Infrastructure.EfModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Infrastructure.EfRepository
{
    /// <summary>
    /// Defines repository for user.
    /// </summary>
    public class ArticleRepository : RepositoryBase<Article, Guid>, IArticleRepository
    {
        /// <summary>
        /// Initialize new instance of the <see cref="DiplomskiDbContext"/> class.
        /// </summary>
        /// <param name="context">Diplomski planning context.</param>
        public ArticleRepository(DiplomskiDbContext context) : base(context)
        { }

        /// <inheritdoc />
        public async Task<IEnumerable<Article>> FilterArticle(ArticleFilterRequest request)
        {
            ExpressionStarter<Article> predicate = PredicateBuilder.New<Article>();

            //Code Supplier
            if (!string.IsNullOrEmpty(request.CodeSupplier))
            {
                predicate = predicate.And(p => p.CodeSupplier.Contains(request.CodeSupplier.ToUpper()));
            }

            //Code
            if (!string.IsNullOrEmpty(request.Code))
            {
                predicate = predicate.And(p => p.Code.Contains(request.Code.ToUpper()));
            }

            //Name
            if (!string.IsNullOrEmpty(request.Name))
            {
                predicate = predicate.And(p => p.Name.Contains(request.Name.ToUpper()));
            }

            //Exit
            if(request.ExitMax is not null)
            {
                predicate = predicate.And(p => p.Exit <= request.ExitMax);
            }

            if (request.ExitMin is not null)
            {
                predicate = predicate.And(p => p.Exit >= request.ExitMin);
            }

            if (request.ExitEqual is not null)
            {
                predicate = predicate.And(p => p.Exit == request.ExitEqual);
            }

            //Price
            if (request.PriceMax is not null)
            {
                predicate = predicate.And(p => p.Price <= request.PriceMax);
            }

            if (request.PriceMin is not null)
            {
                predicate = predicate.And(p => p.Price >= request.PriceMin);
            }

            if (request.PriceEqual is not null)
            {
                predicate = predicate.And(p => p.Price == request.PriceEqual);
            }

            //Demand
            if (request.DemandMax is not null)
            {
                predicate = predicate.And(p => p.Demand <= request.DemandMax);
            }

            if (request.DemandMin is not null)
            {
                predicate = predicate.And(p => p.Demand >= request.DemandMin);
            }

            if (request.DemandEqual is not null)
            {
                predicate = predicate.And(p => p.Demand == request.DemandEqual);
            }

            //Tariff
            if (request.TariffEqual is not null)
            {
                predicate = predicate.And(p => p.Tariff == request.TariffEqual);
            }

            //Pay
            if (!string.IsNullOrEmpty(request.Pay))
            {
                predicate = predicate.And(p => p.Pay.Contains(request.Pay));
            }

            //Operator
            if (request.Operator is not null)
            {
                predicate = predicate.And(p => p.Operator == request.Operator);
            }

            //Rebate
            if (request.RebateMax is not null)
            {
                predicate = predicate.And(p => p.Rebate <= request.RebateMax);
            }

            if (request.RebateMin is not null)
            {
                predicate = predicate.And(p => p.Rebate >= request.RebateMin);
            }

            if (request.RebateEqual is not null)
            {
                predicate = predicate.And(p => p.Rebate == request.RebateEqual);
            }

            //BuyPrice
            if (request.BuyPriceMax is not null)
            {
                predicate = predicate.And(p => p.BuyPrice <= request.BuyPriceMax);
            }

            if (request.BuyPriceMin is not null)
            {
                predicate = predicate.And(p => p.BuyPrice >= request.BuyPriceMin);
            }

            if (request.BuyPriceEqual is not null)
            {
                predicate = predicate.And(p => p.BuyPrice == request.BuyPriceEqual);
            }

            //Month
            bool isMonthSet = false;

            if(request.AfterMonth is not null && request.BeforeMonth is not null)
            {
                DateTime afterMonth = (DateTime)request.AfterMonth;
                DateTime beforeMonth = (DateTime)request.BeforeMonth;

                predicate = predicate.And(p => p.Month.Month >= afterMonth.Month && p.Month.Month <= beforeMonth.Month
                                          &&  p.Month.Year >= afterMonth.Year && p.Month.Year <= beforeMonth.Year);
                isMonthSet = true;
            }

            if(request.ExactMonth is not null)
            {
                DateTime lastmonth = DateTime.Today.AddMonths(-1);

                predicate = predicate.And(p => p.Month.Month == lastmonth.Month && p.Month.Year == lastmonth.Year);
                isMonthSet = true;
            }

            if(isMonthSet == false)
            {
                DateTime month = DateTime.Today.AddMonths(-1);

                predicate = predicate.And(p => p.Month.Month == month.Month && p.Month.Year == month.Year);
            }


            //StoreId
            if (request.StoreId is not null)
            {
                predicate = predicate.And(p => p.StoreId == request.StoreId);
            }

            int first = (int)request.TakeFirst;
            return await GetTableQueryable()
                        .AsNoTracking()
                        .Where(predicate)
                        .Take(first)
                        .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Article>> GetAllStoreAndMonth(Guid storeId, DateTime month)
        {
            return await GetTableQueryable()
                        .AsNoTracking()
                        .Where(a => a.StoreId == storeId && a.Month == month)
                        .ToListAsync();
        }

        /// <inheritdoc />
        public async override Task<Article> GetById(Guid id)
        {
            return await GetTableQueryable().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
