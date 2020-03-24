﻿using System;
using System.Data.SqlClient;
using CsvDataBase.AppSettings;

namespace CsvDataBase.DataBase
{
    public class DbConnection
    {
        private static readonly Lazy<DbConnection> Instance =
            new Lazy<DbConnection>(() => new DbConnection());
        public readonly SqlConnection Connection;

        private DbConnection()
        {
            Connection = new SqlConnection(AppSettingsProvider.GetInstance().Settings.ConnectionString);
            TryConnect();
        }

        private void TryConnect()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Connecting)
                {
                    Connection.OpenAsync();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DbConnection GetInstance()
        {
            return Instance.Value;
        }
    }
}
