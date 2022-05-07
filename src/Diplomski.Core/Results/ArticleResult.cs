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
        public string CodeDob { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Entry { get; set; }
        public decimal Exit { get; set; }
        public decimal SingularPrice { get; set; }
        public decimal Owe { get; set; }
        public decimal Tariff { get; set; }
        public string Pla { get; set; }
        public decimal Op { get; set; }
        public decimal Rebate { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal Tax { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ArticleResult"/>.
        /// </summary>s
        /// <param name="article">Article.</param>
        public ArticleResult(Article article)
        {
            Id = article.Id;
            CodeDob = article.CodeDob;
            Code = article.Code;
            Name = article.Name;
            Entry = article.Entry;
            Exit = article.Exit;
            SingularPrice = article.SingularPrice;
            Owe = article.Owe;
            Tariff = article.Tariff;
            Pla = article.Pla;
            Op = article.Op;
            Rebate = article.Rebate;
            BuyPrice = article.BuyPrice;
            Tax = article.Tax;
        }
    }
}
