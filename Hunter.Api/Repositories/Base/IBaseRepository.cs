using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Api.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        public List<T> Get();
        public List<U> Get<U>(List<string> fields, Dictionary<string, string> joinTables);
        public int Insert(List<string> fields);
        public int Update(Dictionary<string, string> fieldUpdates, Dictionary<string, string> whereFilter);
        public int Delete(Dictionary<string, string> whereFilter);
    }
}
