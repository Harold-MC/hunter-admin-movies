using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace Hunter.Api.Database.Engine
{
    public interface IDataAccess
    {
        SqlConnection GetConnection();
        DbCommand GetCommand(string commandText, CommandType commandType = CommandType.Text);
        void CloseConnection();
    }
}
