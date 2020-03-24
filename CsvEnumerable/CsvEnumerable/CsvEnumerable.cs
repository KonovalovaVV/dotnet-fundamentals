using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable<T> : IEnumerable 
    {
        private readonly string _fileName;
        private readonly Configuration _csvConfiguration = new Configuration
        {
            HasHeaderRecord = false
        };

        public CsvEnumerable(string fileName)
        {
            _fileName = fileName;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CsvEnumerator<T> GetEnumerator()
        {
            CsvReader csv = new CsvReader(File.OpenText(_fileName), _csvConfiguration);
            return new CsvEnumerator<T>(csv);
        }
    }
}