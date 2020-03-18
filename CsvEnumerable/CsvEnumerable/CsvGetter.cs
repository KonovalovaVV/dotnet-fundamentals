using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace CsvEnumerable
{
    public class CsvGetter
    {
        public static List<string> ReadInCSV(string fileName) 
        {
            List<string> result = new List<string>();
            string value;
            string record = "";
            using (TextReader fileReader = File.OpenText(fileName))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField(i, out value); i++)
                    {
                        record += value;
                    }
                    result.Add(record);
                }
            }
            return result;
        }
    }
}
