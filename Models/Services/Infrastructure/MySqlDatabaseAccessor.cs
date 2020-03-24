using System.Data;
using MySql.Data.MySqlClient;

namespace KampusStudio.Models.Services.Infrastructure
{
    public class MySqlDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(string query)
        {
            using(var conn = new MySqlConnection("Server=localhost;Database=kampus;Uid=root;Pwd=;"))
            {
                conn.Open();
                using(var cmd = new MySqlCommand(query, conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        var dataSet = new DataSet();
                        //dataSet.EnforceConstraints = false;  <-- abilita solo se non funziona il provider
                        var dataTable = new DataTable();
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);
                        return dataSet;
                    }
                }
            }
        }
    }
}