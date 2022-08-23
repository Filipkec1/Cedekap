using DbfDataReader;
using Diplomski.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Diplomski.Infrastructure.Parsers
{
    public class ArticleDbfParser
    {
        private MemoryStream memoryStream;
        private DateTime firstDayOfMonth;

        /// <summary>
        /// Initialize a new instance of <see cref="ArticleDbfParser"/> class.
        /// </summary>
        /// <param name="stream"><see cref="MemoryStream"/> of the dbf file that is going to be parsed.</param>
        /// <param name="month"><see cref="MemoryStream"/> of the dbf file that is going to be parsed.</param>
        public ArticleDbfParser(MemoryStream stream, DateTime month)
        {
            memoryStream = stream;
            firstDayOfMonth = month;
        }

        /// <summary>
        /// Read the loaded dbf file memory stream.
        /// </summary>
        /// <param name="storeId"><see cref="Store.Id"/> that belongs that is used for the new <see cref="Article"/>s.</param>
        /// <returns>A list of <see cref="Article"/>s from the dbf file.</returns>
        public List<Article> Read(Guid storeId)
        {
            List<Article> articleList = new List<Article>();

            using (var dbfTable = new DbfTable(memoryStream, Encoding.UTF8))
            {
                var dbfRecord = new DbfRecord(dbfTable);

                while (dbfTable.Read(dbfRecord))
                {
                    Article newArticle = new Article();

                    string codeSupplier = dbfRecord.Values[2].ToString();
                    if (!codeSupplier.All(char.IsDigit))
                    {
                        continue;
                    }

                    newArticle.CodeSupplier = codeSupplier;
                    newArticle.Code = dbfRecord.Values[3].ToString();
                    newArticle.Name = FixName(dbfRecord.Values[4].ToString());
                    newArticle.Exit = Convert.ToDecimal(dbfRecord.Values[6].ToString());
                    newArticle.Price = Convert.ToDecimal(dbfRecord.Values[7].ToString());
                    newArticle.Demand = Convert.ToDecimal(dbfRecord.Values[9].ToString());
                    newArticle.Tariff = Convert.ToDouble(dbfRecord.Values[10].ToString());
                    newArticle.Pay = dbfRecord.Values[11].ToString();
                    newArticle.Rebate = Convert.ToDecimal(dbfRecord.Values[13].ToString());
                    newArticle.BuyPrice = Convert.ToDecimal(dbfRecord.Values[15].ToString());
                    newArticle.Month = firstDayOfMonth;
                    newArticle.StoreId = storeId;

                    articleList.Add(newArticle);
                }
            }

            return articleList;
        }

        /// <summary>
        /// Replace non alphabetic characters with croatian characters in <see cref="Article.Name"/>.
        /// </summary>
        /// <param name="name">Name of article.</param>
        /// <returns>A string with croatian characters.</returns>
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
