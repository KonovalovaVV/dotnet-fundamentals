using System.Collections;
using System.Collections.Generic;

namespace CsvEnumerable
{
    public class CsvEnumerable : IEnumerable<string>
    {
        private readonly string _filePath;
        private readonly List<string> _csvStrings;

        public CsvEnumerable(string filePath)
        {
            _filePath = filePath;
            _csvStrings = CsvGetter.ReadInCSV(_filePath);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _csvStrings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
