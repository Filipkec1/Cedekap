using DbfDataReader;
using Diplomski.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Diplomski.Infrastructure.Parsers
{
    public class ArticleDbfParser
    {
        private MemoryStream memoryStream;
        private DateTime firstDayOfWeek;

        /// <summary>
        /// Initialize a new instance of <see cref="ArticleDbfParser"/> class.
        /// </summary>
        /// <param name="stream"><see cref="MemoryStream"/> of the dbf file that is going to be parsed.</param>
        /// <param name="week"><see cref="MemoryStream"/> of the dbf file that is going to be parsed.</param>
        public ArticleDbfParser(MemoryStream stream, DateTime week)
        {
            memoryStream = stream;
            firstDayOfWeek = week;
        }

        /// <summary>
        /// Read the loaded dbf file memory stream.
        /// </summary>
        /// <param name="storeId"><see cref="Store.Id"/> that belongs that is used for the new <see cref="Article"/>s.</param>
        /// <param name="week">The week that these <see cref="Article"/>s belong to.</param>
        /// <returns>A list of <see cref="Article"/>s from the dbf file.</returns>
        public List<Article> Read(Guid storeId, DateTime week)
        {
            List<Article> articleList = new List<Article>();

            using (var dbfTable = new DbfTable(memoryStream, Encoding.UTF8))
            {
                var dbfRecord = new DbfRecord(dbfTable);

                while (dbfTable.Read(dbfRecord))
                {
                    Article newArticle = new Article();

                    newArticle.CodeDob = dbfRecord.Values[2].ToString();
                    newArticle.Code = dbfRecord.Values[3].ToString();
                    newArticle.Name = FixName(dbfRecord.Values[4].ToString());
                    newArticle.Entry = Convert.ToDecimal(dbfRecord.Values[5].ToString());
                    newArticle.Exit = Convert.ToDecimal(dbfRecord.Values[6].ToString());
                    newArticle.SingularPrice = Convert.ToDecimal(dbfRecord.Values[7].ToString());
                    newArticle.Owe = Convert.ToDecimal(dbfRecord.Values[8].ToString());
                    newArticle.Demand = Convert.ToDecimal(dbfRecord.Values[9].ToString());
                    newArticle.Tariff = Convert.ToDecimal(dbfRecord.Values[10].ToString());
                    newArticle.Pla = dbfRecord.Values[11].ToString();
                    newArticle.Op = Convert.ToInt32(dbfRecord.Values[12].ToString());
                    newArticle.Rebate = Convert.ToDecimal(dbfRecord.Values[13].ToString());
                    newArticle.BuyPrice = Convert.ToDecimal(dbfRecord.Values[15].ToString());
                    newArticle.Tax = Convert.ToDecimal(dbfRecord.Values[16].ToString());
                    newArticle.Week = firstDayOfWeek;
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
