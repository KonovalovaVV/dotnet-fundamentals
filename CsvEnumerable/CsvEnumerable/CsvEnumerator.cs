using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CsvEnumerable
{
    public class CsvEnumerator<T> : IEnumerator 
    {
        private readonly List<T> _records = new List<T>();
        private readonly CsvReader _csvReader;
        private int _currentPosition = -1;

        public CsvEnumerator(CsvReader csv)
        {
            _csvReader = csv;
        }

        public bool MoveNext()
        {
            if (_csvReader.Read())
            {
                if (!TryGetNextLine(out T nextLine))
                    return false;
                _records.Add(nextLine);
                _currentPosition++;
                return true;
            }
            return false;
        }

        private bool TryGetNextLine(out T nextLine)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;

            while (_csvReader.TryGetField(i++, out string value))
            {
                result.Append(value);
            }
            nextLine = _csvReader.GetRecord<T>();
            return !string.IsNullOrEmpty(result.ToString());
        }

        public void Reset()
        {
            _currentPosition = -1;
            _records.Clear();
            _csvReader.Dispose();
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
                    return _records[_currentPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
