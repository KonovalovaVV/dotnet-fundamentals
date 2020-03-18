using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CsvEnumerable
{
    public class CsvEnum : IEnumerator
    {
        public List<string> _records = new List<string>();
        private CsvReader _csv;
        int position = -1;

        public CsvEnum(CsvReader csv)
        {
            _csv = csv;
        }

        public bool MoveNext()
        {
            string result = "";
            string value;
            if (_csv.Read())
            {
                for (int i = 0; _csv.TryGetField<string>(i, out value); i++)
                {
                    result += value;
                }
                _records.Add(result);
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
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
                    return _records[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
