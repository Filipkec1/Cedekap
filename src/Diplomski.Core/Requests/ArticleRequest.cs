using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Diplomski.Core.Requests
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

    public class ArticleCombineRequest
    {
        public bool BuyPriceShow { get; set; }
        public bool DemandShow { get; set; }
        public bool ExitShow { get; set; }
        public bool PriceShow { get; set; }
        public int Show { get; set; }
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
        public List<string> StoreIdList { get; set; }
        public double? TariffEqual { get; set; }
    }

    /// <summary>
    /// Defines Article filter request.
    /// </summary>
    public class ArticleFilterRequest
    {
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
        public List<string> StoreIdList { get; set; }
        public double? TariffEqual { get; set; }

        public ArticleFilterRequest()
        { }

        public ArticleFilterRequest(ArticleCombineRequest articleCombine)
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
            this.StoreIdList = articleCombine.StoreIdList;
            this.TariffEqual = articleCombine.TariffEqual;
        }
    }

    /// <summary>
    ///  Defines Article show request.
    /// </summary>
    public class ArticleShowRequest
    {
        public bool BuyPriceShow { get; set; }

        public bool DemandShow { get; set; }

        public bool ExitShow { get; set; }

        public bool PriceShow { get; set; }

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
    }
}