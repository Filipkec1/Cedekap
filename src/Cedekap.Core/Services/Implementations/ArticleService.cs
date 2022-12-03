using Cedekap.Core.Models.Entities;
using Cedekap.Core.Requests;
using Cedekap.Core.Results;
using Cedekap.Core.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cedekap.Core.Services.Implementations
{
    /// <summary>
    /// Defines <see cref="Store"/> service.
    /// </summary>
    public class ArticleService : ServiceBase, IArticleService
    {
        /// <summary>
        /// Initilizes new instance of <see cref="ArticleService"/>
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        public ArticleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <inheritdoc />
        public async Task AddDbfData(Guid storeId, DateTime month, IEnumerable<Article> articleList)
        {
            IEnumerable<Article> articleToDelete = await unitOfWork.Article.GetAllStoreAndMonth(storeId, month);

            if (articleToDelete.Any())
            {
                unitOfWork.Article.DeleteRange(articleToDelete);
                await unitOfWork.Commit();
            }

            await unitOfWork.Article.AddRange(articleList);
            await unitOfWork.Commit();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ArticleResult>> FilterArticle(ArticleFilterRequest request)
        {
            IEnumerable<Article> articleList = await unitOfWork.Article.FilterArticle(request);
            return articleList.Select(x => new ArticleResult(x));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Store>> GetStoreList()
        {
            return await unitOfWork.Store.GetAll();
        }

        /// <inheritdoc />
        public IEnumerable<object> SortArticle(ArticleShowRequest request, IEnumerable<ArticleResult> articleResultList)
        {
            List<object> data = new List<object>();
            List<ArticleResult> articleList = new List<ArticleResult>();
            List<double> numberList = new List<double>();
            List<string> labelList = new List<string>();
            string labelTitle = "";

            switch (request.ShowSort)
            {
                case "Exit":
                    {
                        if (request.OrderReverse == false)
                        {
                            articleList = articleResultList.OrderByDescending(x => x.Exit)
                                                           .Take(request.Show)
                                                           .ToList();
                        }
                        else
                        {
                            articleList = articleResultList.OrderBy(x => x.Exit)
                                                           .Take(request.Show)
                                                           .ToList();
                        }

                        numberList = articleList.Select(x => (double)x.Exit).ToList();
                        labelTitle = "Izlaz";

                        break;
                    }
                case "Demand":
                    {
                        if (request.OrderReverse == false)
                        {
                            articleList = articleResultList.OrderByDescending(x => x.Demand)
                                                           .Take(request.Show)
                                                           .ToList();
                        }
                        else
                        {
                            articleList = articleResultList.OrderBy(x => x.Demand)
                                                           .Take(request.Show)
                                                           .ToList();
                        }

                        numberList = articleList.Select(x => (double)x.Demand).ToList();
                        labelTitle = "Potražnja";

                        break;
                    }
                case "Price":
                    {
                        if (request.OrderReverse == false)
                        {
                            articleList = articleResultList.OrderByDescending(x => x.Price)
                                                           .Take(request.Show)
                                                           .ToList();
                        }
                        else
                        {
                            articleList = articleResultList.OrderBy(x => x.Price)
                                                           .Take(request.Show)
                                                           .ToList();
                        }

                        numberList = articleList.Select(x => (double)x.Price).ToList();
                        labelTitle = "Cijena";

                        break;
                    }
                case "BuyPrice":
                    {
                        if (request.OrderReverse == false)
                        {
                            articleList = articleResultList.OrderByDescending(x => x.BuyPrice)
                                                           .Take(request.Show)
                                                           .ToList();
                        }
                        else
                        {
                            articleList = articleResultList.OrderBy(x => x.BuyPrice)
                                                           .Take(request.Show)
                                                           .ToList();
                        }

                        numberList = articleList.Select(x => (double)x.BuyPrice).ToList();
                        labelTitle = "Nabavna cijena";

                        break;
                    }
            }

            labelList = articleList.Select(x => x.Name).ToList();

            data.Add(numberList);
            data.Add(labelList);
            data.Add(labelTitle);

            string jsonString = JsonSerializer.Serialize(articleList);
            data.Add(jsonString);

            return data;
        }
    }
}