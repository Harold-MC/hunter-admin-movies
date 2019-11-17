using System;
using System.Collections.Generic;
using Hunter.Api.Database.Engine;
using System.Data.Common;
using Hunter.Api.Extensions;
using System.Reflection;

namespace Hunter.Api.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected IDataAccess DB { get; set; }
        public BaseRepository(IDataAccess _db)
        {
            DB = _db;
        }

        public List<T> Get() 
        {
            var reader = DB.GetCommand(DB.createGetQuery(typeof(T).Name)).ExecuteReader();
            //DB.CloseConnection();
            return Map<T>(reader);
        }

        public List<U> Get<U>(List<string> fields, Dictionary<string, string> joinTables)
        {
            string tableName = typeof(U).Name.Replace("Dto", "");
            var reader = DB.GetCommand(DB.createGetQueryWithJoin(tableName, fields, joinTables)).ExecuteReader();
            //DB.CloseConnection();
            return Map<U>(reader);
        }

        public int Insert(List<string> fields)
        {
            string tableName = typeof(T).Name;
            int res = DB.GetCommand(DB.createInsertQuery(tableName, fields)).ExecuteNonQuery();
            DB.CloseConnection();
            return res;
        }

        public int Update(Dictionary<string, string> fieldUpdates, Dictionary<string, string> whereFilter)
        {
            string tableName = typeof(T).Name;
            int res = DB.GetCommand(DB.createUpdateQuery(tableName,fieldUpdates,whereFilter)).ExecuteNonQuery();
            DB.CloseConnection();
            return res;
        }

        public int Delete(Dictionary<string, string> whereFilter)
        {
            string tableName = typeof(T).Name;
            int res = DB.GetCommand(DB.createDeleteQuery(tableName, whereFilter)).ExecuteNonQuery();
            DB.CloseConnection();
            return res;
        }

        private List<U> Map<U>(DbDataReader reader)
        {
            List<U> list = new List<U>();
            while (reader.Read())
            {
                U obj = default(U);
                obj = Activator.CreateInstance<U>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(reader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, reader[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

    }
}
