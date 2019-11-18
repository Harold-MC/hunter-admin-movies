using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Hunter.Api.Database.Engine
{
    public class DataAccess : IDataAccess
    {
        private IConfiguration Configuration { get; set; }
        private SqlConnection Connection { get; set; }

        public DataAccess(IConfiguration _configuration)
        {
            Configuration = _configuration;
            Connection = new SqlConnection(Configuration.GetConnectionString("main"));
        }

        public SqlConnection GetConnection()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            return Connection;
        }

        public DbCommand GetCommand(string commandText, CommandType commandType = CommandType.Text)
        { 
            SqlCommand command = new SqlCommand(commandText, GetConnection());
            command.CommandType = commandType;
            return command;
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
