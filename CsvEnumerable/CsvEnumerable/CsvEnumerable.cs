using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable : IEnumerable
    {
        private readonly string fileName;
        private readonly Configuration _csvConfiguration = new Configuration
        {
            HasHeaderRecord = false
        };

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
            CsvReader _csv = new CsvReader(File.OpenText(fileName), _csvConfiguration);
            return new CsvEnumerator(_csv);
        }
    }
}