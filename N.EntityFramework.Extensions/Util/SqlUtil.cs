﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace N.EntityFramework.Extensions
{
    internal static class SqlUtil
    {
        internal static int ExecuteSql(string query, SqlConnection connection, SqlTransaction transaction)
        {
            var sqlCommand = new SqlCommand(query, connection, transaction);
            return sqlCommand.ExecuteNonQuery();
        }
        internal static int DeleteTable(string tableName, SqlConnection connection, SqlTransaction transaction)
        {
            return ExecuteSql(string.Format("DROP TABLE {0}", tableName), connection, transaction);
        }
        internal static int CloneTable(string sourceTable, string destinationTable, string[] columnNames, SqlConnection connection, SqlTransaction transaction)
        {
            string columns = columnNames != null && columnNames.Length > 0 ? string.Join(",", columnNames) : "*";
            return ExecuteSql(string.Format("SELECT TOP 0 {0} INTO {1} FROM {2}", columns, destinationTable, sourceTable), connection, transaction);
        }

        internal static string ConvertToColumnString(IEnumerable<string> columnNames)
        {
            return string.Join(",", columnNames);
        }
    }
}

