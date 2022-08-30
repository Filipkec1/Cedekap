using Diplomski.Core.Models.Entities;
using System;

namespace Diplomski.Core.Results
{
    /// <summary>
    /// Defines article result class.
    /// </summary>
    public class ArticleResult
    {
        public Guid Id { get; set; }
        public string CodeSupplier { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Exit { get; set; }
        public decimal Price { get; set; }
        public decimal Demand { get; set; }
        public double Tariff { get; set; }
        public string Pay { get; set; }
        public int Operator { get; set; }
        public decimal Rebate { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime Month { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ArticleResult"/>.
        /// </summary>s
        /// <param name="article">Article.</param>
        public ArticleResult(Article article)
        {
            Id = article.Id;
            CodeSupplier = article.CodeSupplier;
            Code = article.Code;
            Name = article.Name;
            Exit = article.Exit;
            Price = article.Price;
            Demand = article.Demand;
            Tariff = article.Tariff;
            Pay = article.Pay;
            Operator = article.Operator;
            Rebate = article.Rebate;
            BuyPrice = article.BuyPrice;
            Month = article.Month;
        }
    }
}
