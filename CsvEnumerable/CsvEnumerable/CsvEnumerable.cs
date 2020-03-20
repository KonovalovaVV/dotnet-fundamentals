﻿using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.IO;

namespace CsvEnumerable
{
    public class CsvEnumerable<T> : IEnumerable
    {
        private readonly string fileName;
        private readonly Configuration _csvConfiguration = new Configuration
        {
            HasHeaderRecord = false
        };
        private object level;

        public CsvEnumerable(string fileName)
        {
            this.fileName = fileName;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public CsvEnumerator<T> GetEnumerator()
        {
            CsvReader _csv = new CsvReader(File.OpenText(fileName), _csvConfiguration);
            return new CsvEnumerator<T>(_csv);
        }
    }
}