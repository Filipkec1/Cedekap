namespace Diplomski.Core.Models.Entities
{
    public class Article
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Entry { get; set; }

        public decimal Exit { get; set; }

        public decimal SingularPrice { get; set; }

        public decimal Owe { get; set; }

        public decimal Demand { get; set; }

        public decimal Tariff { get; set; }

        public string PLA { get; set; }

        public decimal OP { get; set; }

        public decimal Rebate { get; set; }

        public decimal N { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal Tax { get; set; }
    }
}
