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

        private int show = 10;
        public int? Show
        {
            get
            {
                return show;
            }
            set
            {
                if (value is not null)
                {
                    show = (int)value;
                }
            }
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
        public int? Show
        {
            get
            {
                return show;
            }
            set
            {
                if (value is not null)
                {
                    show = (int)value;
                }
            }
        }
    }
}