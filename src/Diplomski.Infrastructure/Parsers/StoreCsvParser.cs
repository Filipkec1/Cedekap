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
        public List<Article> Read(Guid storeId)
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

                        newArticle.CodeDob = csv.GetField<string>(2);
                        newArticle.Code = csv.GetField<string>(3);
                        newArticle.Name = FixName(csv.GetField<string>(4));
                        newArticle.Entry = Convert.ToDecimal(csv.GetField<string>(5));
                        newArticle.Exit = Convert.ToDecimal(csv.GetField<string>(6));
                        newArticle.SingularPrice = Convert.ToDecimal(csv.GetField<string>(7));
                        newArticle.Owe = Convert.ToDecimal(csv.GetField<string>(8));
                        newArticle.Demand = Convert.ToDecimal(csv.GetField<string>(9));
                        newArticle.Tariff = Convert.ToDecimal(csv.GetField<string>(10));
                        newArticle.Pla = csv.GetField<string>(11);
                        newArticle.Op = Convert.ToDecimal(csv.GetField<string>(12));
                        newArticle.Rebate = Convert.ToDecimal(csv.GetField<string>(13));
                        newArticle.BuyPrice = Convert.ToDecimal(csv.GetField<string>(15));
                        newArticle.Tax = Convert.ToDecimal(csv.GetField<string>(16));
                        newArticle.StoreId = storeId;
                        articleList.Add(newArticle);
                    }
                }

                return articleList;
            }
        }

        /// <summary>
        /// Replace non alphabetic characters with croatina characters in <see cref="Article.Name"/>.
        /// </summary>
        /// <param name="name">Name of article.</param>
        /// <returns>A string with croatina characters.</returns>
        private string FixName(string name)
        {
            var specialCharacters = new (string specialChar, string croatianChar)[]
            {
                ("[", "Š"),
                (@"\", "Đ"),
                ("^", "Č"),
                ("]", "Ć"),
                ("@", "Ž")
            };

            foreach (var set in specialCharacters)
            {
                name = name.Replace(set.specialChar, set.croatianChar);
            }

            return name;
        }
    }
}
