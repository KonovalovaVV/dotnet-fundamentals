using CsvHelper;
using System.Collections;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable : IEnumerable
    {
        private CsvReader _csv;

        public CsvEnumerable(string fileName)
        {
            TextReader fileReader = File.OpenText(fileName);
            _csv = new CsvReader(fileReader);
            _csv.Configuration.HasHeaderRecord = false;
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CsvEnum GetEnumerator()
        {
            return new CsvEnum(_csv);
        }
    }
}