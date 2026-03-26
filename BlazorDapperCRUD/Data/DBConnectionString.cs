namespace BlazorDapperCRUD.Data
{
    public class DBConnectionString
    {
        public DBConnectionString(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
