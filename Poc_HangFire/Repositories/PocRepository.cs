using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Poc_HangFire.Repositories
{
    public class PocRepository : IPocRepository
    {
        public bool Salvar(DateTime date, string value)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                const string query = "insert into PocValor (Data, Valor) values (@date, @value)";

                var result = conn.ExecuteScalar<int>(query, new { date, value });

                return result > 0;
            }
        }
    }
}