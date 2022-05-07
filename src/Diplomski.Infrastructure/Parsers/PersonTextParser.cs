using System.Collections.Generic;
using System.IO;

namespace Diplomski.Infrastructure.Parsers
{
    public class PersonTextParser
    {
        private MemoryStream memoryStream;

        /// <summary>
        /// Initialize a new instance of <see cref="PersonTextParser"/> class.
        /// </summary>
        /// <param name="stream"><see cref="MemoryStream"/> of the text file that is going to be parsed.</param>
        public PersonTextParser(MemoryStream stream)
        {
            memoryStream = stream;
        }


        //public IEnumerable<Person> Read()
        //{
        //    List<Person> peopleList;
        //    using (StreamReader r = new StreamReader(memoryStream))
        //    {
        //        string json = r.ReadToEnd();
        //        peopleList = JsonConvert.DeserializeObject<List<Person>>(json);
        //    }
        //    return peopleList;
        //}
    }
}
