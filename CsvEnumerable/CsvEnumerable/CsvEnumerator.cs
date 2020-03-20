using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CsvEnumerable
{
    public class CsvEnumerator<T> : IEnumerator 
    {
        private List<T> _records = new List<T>();
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
                if (!TryGetNextLine(out T nextLine))
                    return false;
                _records.Add(nextLine);
                currentPosition++;
                return true;
            }
            return false;
        }

        private bool TryGetNextLine(out T nextLine)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;

            while (csvReader.TryGetField(i++, out string value))
            {
                result.Append(value);
            }
            nextLine = csvReader.GetRecord<T>();
            return !string.IsNullOrEmpty(result.ToString());
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

        public T Current
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
