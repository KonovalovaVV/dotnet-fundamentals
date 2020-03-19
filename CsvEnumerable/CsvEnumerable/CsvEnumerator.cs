using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CsvEnumerable
{
    public class CsvEnumerator : IEnumerator
    {
        private List<string> _records = new List<string>();
        private CsvReader csvReader;
        private int currentPosition = -1;

        public CsvEnumerator(CsvReader csv)
        {
            csvReader = csv;
        }

        public bool MoveNext()
        {
            if (csvReader.Read())
            {
                if (!TryGetNextLine(out string nextLine))
                    return false;
                _records.Add(nextLine);
                currentPosition++;
                return true;
            }
            return false;
        }

        private bool TryGetNextLine(out string nextLine)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;

            while (csvReader.TryGetField(i++, out string value))
            {
                result.Append(value);
            }

            nextLine = result.ToString();

            return !string.IsNullOrEmpty(nextLine);
        }

        public void Reset()
        {
            currentPosition = -1;
            _records.Clear();
            csvReader.Dispose();
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return _records[currentPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
