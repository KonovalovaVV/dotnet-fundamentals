using CsvHelper;
using System.Collections;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable : IEnumerable
    {
        private readonly string fileName;
        public CsvEnumerable(string fileName)
        {
            this.fileName = fileName;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CsvEnumerator GetEnumerator()
        {
            CsvHelper.Configuration.Configuration configuration = new CsvHelper.Configuration.Configuration();
            configuration.HasHeaderRecord = false;
            CsvReader _csv = new CsvReader(File.OpenText(fileName), configuration);
            return new CsvEnumerator(_csv);
        }
    }
}