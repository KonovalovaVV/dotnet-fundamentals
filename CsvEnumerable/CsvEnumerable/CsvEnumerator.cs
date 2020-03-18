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
        private CsvReader _csv;
        private int currentPosition = -1;

        public CsvEnumerator(CsvReader csv)
        {
            _csv = csv;
        }

        public bool MoveNext()
        {
            string nextLine;
            if (_csv.Read())
            {
                if (!TryNextLine(out nextLine))
                    return false;
                _records.Add(nextLine);
                currentPosition++;
                return true;
            }
            return false;
        }

        private bool TryNextLine(out string nextLine)
        {
            string value;
            StringBuilder result = new StringBuilder();
            int i = 0;
            while (_csv.TryGetField(i++, out value))
            {
                result.Append(value);
            }
            nextLine = result.ToString();
            if (string.IsNullOrEmpty(nextLine))
                return false;
            return true;
        }

        public void Reset()
        {

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
