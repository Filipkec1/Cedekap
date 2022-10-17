using Microsoft.AspNetCore.Http;
using System;

namespace Cedekap.Core.Requests
{
    /// <summary>
    /// Defines dbf file upload request.
    /// </summary>
    public class ArticleDbfFileUploadRequest
    {
        public IFormFile DbfFile { get; set; }
        public DateTime DbfMonth { get; set; }
        public Guid StoreId { get; set; }
    }

    /// <summary>
    /// Defines Article filter request.
    /// </summary>
    public class ArticleFilterRequest
    {
        public ArticleFilterRequest()
        { }

        public ArticleFilterRequest(ArticleShowRequest articleCombine)
        {
            this.AfterMonth = articleCombine.AfterMonth;
            this.BeforeMonth = articleCombine.BeforeMonth;
            this.BuyPriceEqual = articleCombine.BuyPriceEqual;
            this.BuyPriceMax = articleCombine.BuyPriceMax;
            this.BuyPriceMin = articleCombine.BuyPriceMin;
            this.Code = articleCombine.Code;
            this.CodeSupplier = articleCombine.CodeSupplier;
            this.DemandEqual = articleCombine.DemandEqual;
            this.DemandMax = articleCombine.DemandMax;
            this.DemandMin = articleCombine.DemandMin;
            this.ExactMonth = articleCombine.ExactMonth;
            this.ExitEqual = articleCombine.ExitEqual;
            this.ExitMax = articleCombine.ExitMax;
            this.ExitMin = articleCombine.ExitMin;
            this.Name = articleCombine.Name;
            this.Operator = articleCombine.Operator;
            this.Pay = articleCombine.Pay;
            this.PriceEqual = articleCombine.PriceEqual;
            this.PriceMax = articleCombine.PriceMax;
            this.PriceMin = articleCombine.PriceMin;
            this.RebateEqual = articleCombine.RebateEqual;
            this.RebateMax = articleCombine.RebateMax;
            this.RebateMin = articleCombine.RebateMin;
            this.StoreId = articleCombine.StoreId;
            this.TariffEqual = articleCombine.TariffEqual;
        }

        public DateTime? AfterMonth { get; set; }
        public DateTime? BeforeMonth { get; set; }
        public decimal? BuyPriceEqual { get; set; }
        public decimal? BuyPriceMax { get; set; }
        public decimal? BuyPriceMin { get; set; }
        public string Code { get; set; }
        public string CodeSupplier { get; set; }
        public decimal? DemandEqual { get; set; }
        public decimal? DemandMax { get; set; }
        public decimal? DemandMin { get; set; }
        public DateTime? ExactMonth { get; set; }
        public decimal? ExitEqual { get; set; }
        public decimal? ExitMax { get; set; }
        public decimal? ExitMin { get; set; }
        public string Name { get; set; }
        public int? Operator { get; set; }
        public string Pay { get; set; }
        public decimal? PriceEqual { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? RebateEqual { get; set; }
        public decimal? RebateMax { get; set; }
        public decimal? RebateMin { get; set; }
        public string StoreId { get; set; }
        public double? TariffEqual { get; set; }
    }

    public class ArticleShowRequest
    {
        public DateTime? AfterMonth { get; set; }
        public DateTime? BeforeMonth { get; set; }
        public bool BottomShow { get; set; }
        public decimal? BuyPriceEqual { get; set; }
        public decimal? BuyPriceMax { get; set; }
        public decimal? BuyPriceMin { get; set; }
        public string Code { get; set; }
        public string CodeSupplier { get; set; }
        public decimal? DemandEqual { get; set; }
        public decimal? DemandMax { get; set; }
        public decimal? DemandMin { get; set; }
        public DateTime? ExactMonth { get; set; }
        public decimal? ExitEqual { get; set; }
        public decimal? ExitMax { get; set; }
        public decimal? ExitMin { get; set; }
        public string Name { get; set; }
        public int? Operator { get; set; }
        public string Pay { get; set; }
        public decimal? PriceEqual { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? RebateEqual { get; set; }
        public decimal? RebateMax { get; set; }
        public decimal? RebateMin { get; set; }

        private int show = 10;
        public int Show
        {
            get
            {
                return show;
            }
            set
            {
                if (value > show)
                {
                    show = value;
                }
            }
        }

        public string ShowSort { get; set; }
        public bool OrderReverse { get; set; }
        public string StoreId { get; set; }
        public double? TariffEqual { get; set; }
        public bool TopShow { get; set; }
    }
}