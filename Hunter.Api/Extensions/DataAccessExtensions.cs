using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hunter.Api.Database.Engine;

namespace Hunter.Api.Extensions
{
    public static class DataAccessExtensions
    {
        public static string createGetQuery(this IDataAccess accesor, string tableName)
        {
            string sql = $"select * from {tableName}s";
            return sql;
        }
        public static string createUpdateQuery(this IDataAccess accesor, string tableName, Dictionary<string, string> fieldUpdate, Dictionary<string, string> whereFilter)
        {
            return $"update {tableName}s set {accesor.createWhereFilter(fieldUpdate, true)} where {accesor.createWhereFilter(whereFilter)}";
        }

        public static string createDeleteQuery(this IDataAccess accesor, string tableName, Dictionary<string, string> whereFilter)
        {
            return $"delete from {tableName}s where {accesor.createWhereFilter(whereFilter)}";
        }

        public static string createInsertQuery(this IDataAccess accesor, string tableName,List<string> values)
        {
            string str = "";
            foreach (string field in values)
            {
                str += $"{field}";
                if (field != values.Last()) str += ",";
            }
            return $"insert into {tableName}s values ({str})";
        }

        public static string createGetQueryWithJoin(this IDataAccess accesor, string tableName ,List<string> fields ,Dictionary<string, string> joinTables)
        {
            tableName = tableName + "s";
            string str = "select ", lastTable = tableName;

            foreach (string field in fields)
            {
                str += $"{field}";
                if (field != fields.Last()) str += ",";
            }

            str += $" from {tableName} ";

            foreach (var join in joinTables)
            {
                str += $"inner join {join.Key} on {lastTable}.{join.Key.Substring(0, join.Key.Length - 1)}{join.Value} = {join.Key}.{join.Value} ";
                lastTable = join.Key;
            }
            return str;
        }

        public static string createWhereFilter(this IDataAccess accesor, Dictionary<string, string> whereFilter, bool isUpdate = false)
        {
            string str = "";
            string separate = isUpdate ? "," : "and";

            foreach (var where in whereFilter)
            {
                if (where.Key == whereFilter.Last().Key) separate = "";

                str += $" {where.Key} = {where.Value} {separate}";
            }

            return str;
        }
    }
}
