using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TheVulnBank.Repositories
{
    public static class SqlDataReaderExtensions
    {
        public static int SafeGetInt32(this SqlDataReader reader, string columnName, int defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetInt32(ordinal);
            }
            else
            {
                return defaultValue;
            }
        }

        public static string SafeGetString(this SqlDataReader reader, string columnName, string defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetString(ordinal);
            }
            else
            {
                return defaultValue;
            }
        }

        public static bool SafeGetBoolean(this SqlDataReader reader, string columnName, bool defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetBoolean(ordinal);
            }
            else
            {
                return defaultValue;
            }
        }
    }
}