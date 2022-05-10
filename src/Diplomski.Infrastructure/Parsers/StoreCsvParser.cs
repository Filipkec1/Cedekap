using CsvHelper;
using CsvHelper.Configuration;
using Diplomski.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Diplomski.Infrastructure.Parsers
{
    public class StoreCsvParser
    {
        private MemoryStream memoryStream;

        /// <summary>
        /// Initialize a new instance of <see cref="StoreCsvParser"/> class.
        /// </summary>
        /// <param name="stream"><see cref="MemoryStream"/> of the csv file that is going to be parsed.</param>
        public StoreCsvParser(MemoryStream stream)
        {
            memoryStream = stream;
        }

        /// <summary>
        /// Read the loaded csv file memory stream.
        /// </summary>
        /// <returns>A list of <see cref="Article"/>s from the csv file.</returns>
        public List<Article> Read()
        {
            List<Article> articleList = new List<Article>();

            using (StreamReader reader = new StreamReader(memoryStream))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = true
                };

                using (CsvReader csv = new CsvReader(reader, csvConfig))
                {
                    csv.Read();
                    while (csv.Read())
                    {
                        Article newArticle = new Article();
                        try
                        {
                            newArticle.CodeDob = csv.GetField<string>(2);
                            newArticle.Code = csv.GetField<string>(3);
                            newArticle.Name = csv.GetField<string>(4);
                            newArticle.Entry = csv.GetField<decimal>(5);
                            newArticle.Exit = csv.GetField<decimal>(6);
                            newArticle.SingularPrice = csv.GetField<decimal>(7);
                            newArticle.Owe = csv.GetField<decimal>(8);
                            newArticle.Demand = csv.GetField<decimal>(9);
                            newArticle.Tariff = csv.GetField<decimal>(10);
                            newArticle.Pla = csv.GetField<string>(11);
                            newArticle.Op = csv.GetField<decimal>(12);
                            newArticle.Rebate = csv.GetField<decimal>(13);
                            newArticle.BuyPrice = csv.GetField<decimal>(15);
                            newArticle.Tax = csv.GetField<decimal>(16);
                        }
                        catch (Exception E)
                        {

                        }

                        articleList.Add(newArticle);
                    }
                }

                return articleList;
            }
        }
    }
}
