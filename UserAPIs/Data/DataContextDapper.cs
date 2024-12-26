using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace UserAPIs
{
    class DataContextDapper
    {
        private readonly IConfiguration _config;

        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbconnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbconnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbconnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbconnection.QuerySingle<T>(sql);
        }
    }
}