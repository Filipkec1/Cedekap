using CsvHelper;
using CsvHelper.Configuration;
using Diplomski.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Article> articleList = new List<Article>();

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true
            };

            for (int i = 1; i < 11; i++)
            {

                if (i == 6 || i == 9)
                {
                    continue;
                }

                using (StreamReader streamReader = File.OpenText($"D:\\FAKS\\DIPLOMSKI\\CEDEKAP\\p{i}.csv"))
                {
                    using (CsvReader csv = new CsvReader(streamReader, csvConfig))
                    {
                        csv.Read();
                        while (csv.Read())
                        {
                            Article newArticle = new Article();
                            try
                            {
                                newArticle.Code = csv.GetField<string>(3);
                                newArticle.Name = csv.GetField<string>(4);
                                newArticle.Entry = csv.GetField<decimal>(5);
                                newArticle.Exit = csv.GetField<decimal>(6);
                                newArticle.SingularPrice = csv.GetField<decimal>(7);
                                newArticle.Owe = csv.GetField<decimal>(8);
                                newArticle.Demand = csv.GetField<decimal>(9);
                                newArticle.Tariff = csv.GetField<decimal>(10);
                                newArticle.PLA = csv.GetField<string>(11);
                                newArticle.OP = csv.GetField<decimal>(12);
                                newArticle.Rebate = csv.GetField<decimal>(13);
                                newArticle.N = csv.GetField<decimal>(14);
                                newArticle.BuyPrice = csv.GetField<decimal>(15);
                                newArticle.Tax = csv.GetField<decimal>(16);
                            }
                            catch (Exception E)
                            {

                            }

                            articleList.Add(newArticle);
                        }
                    }
                }
            }

            string test = "no";
        }
    }
}
