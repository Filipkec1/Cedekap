using Microsoft.AspNetCore.Http;
using System;

namespace Diplomski.Core.Requests
{
    /// <summary>
    /// Defines Article filter request.
    /// </summary>
    public class ArticleFilterRequest
    {
        public string CodeSupplier { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? ExitMax { get; set; }
        public double? ExitMin { get; set; }
        public double? ExitEqual { get; set; }
        public double? PriceMax { get; set; }
        public double? PriceMin { get; set; }
        public double? PriceEqual { get; set; }
        public double? DemandMax { get; set; }
        public double? DemandMin { get; set; }
        public double? DemandEqual { get; set; }
        public double? TariffMax { get; set; }
        public double? TariffMin { get; set; }
        public double? TariffEqual { get; set; }
        public string Pay { get; set; }
        public int? Operator { get; set; }
        public double? RebateMax { get; set; }
        public double? RebateMin { get; set; }
        public double? RebateEqual { get; set; }
        public double? BuyPriceMax { get; set; }
        public double? BuyPriceMin { get; set; }
        public double? BuyPriceEqual { get; set; }
        public DateTime? AfterMonth { get; set; }
        public DateTime? BeforeMonth { get; set; }
        public DateTime? ExactlMonth { get; set; }
        public Guid? StoreId { get; set; }
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
