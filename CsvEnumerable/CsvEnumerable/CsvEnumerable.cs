using CsvHelper;
using System.Collections;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable : IEnumerable
    {
        private readonly CsvReader _csv;

        public CsvEnumerable(string fileName)
        {
            CsvHelper.Configuration.Configuration configuration = new CsvHelper.Configuration.Configuration();
            configuration.HasHeaderRecord = false;
            _csv = new CsvReader(File.OpenText(fileName), configuration); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CsvEnumerator GetEnumerator()
        {
            return new CsvEnumerator(_csv);
        }
    }
}