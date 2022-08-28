using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines Article filter request.
    /// </summary>
    public class ArticleFilterRequest
    {
        private int takeFirst = 10;
        public int? TakeFirst {

            get
            {
                return takeFirst;
            }
            set
            {
                if (value is not null)
                {
                    takeFirst = (int)value;
                }
            }
        }

        public string CodeSupplier { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? ExitMax { get; set; }
        public decimal? ExitMin { get; set; }
        public decimal? ExitEqual { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceEqual { get; set; }
        public decimal? DemandMax { get; set; }
        public decimal? DemandMin { get; set; }
        public decimal? DemandEqual { get; set; }
        public double? TariffEqual { get; set; }
        public string Pay { get; set; }
        public int? Operator { get; set; }
        public decimal? RebateMax { get; set; }
        public decimal? RebateMin { get; set; }
        public decimal? RebateEqual { get; set; }
        public decimal? BuyPriceMax { get; set; }
        public decimal? BuyPriceMin { get; set; }
        public decimal? BuyPriceEqual { get; set; }
        public DateTime? AfterMonth { get; set; }
        public DateTime? BeforeMonth { get; set; }
        public DateTime? ExactMonth { get; set; }
        public List<string> StoreIdList { get; set; }
    }

    /// <summary>
    ///  Defines Article show request.
    /// </summary>
    public class ArticleShowRequest
    {
        public string ArticleFilterRequestJson { get; set; }
        public bool Exit { get; set; }
        public bool Price { get; set; }
        public bool Demand { get; set; }
        public bool BuyPrice { get; set; }
    }

    /// <summary>
    /// Defines dbf file upload request.
    /// </summary>
    public class ArticleDbfFileUploadRequest
    {
        public IFormFile DbfFile { get; set; }
        public Guid StoreId { get; set; }
        public DateTime DbfMonth { get; set; }
    }
}
