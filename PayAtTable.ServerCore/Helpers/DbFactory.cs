namespace PayAtTable.API.Helpers
{
    /// <summary>
    /// Factory that wraps creation of database connections
    /// </summary>
    public class DbFactory
    {
        protected DbFactory()
        {
        }

        /// <summary>
        /// Creates a new SqlConnection for the POS database
        /// </summary>
        /// <returns></returns>
        public static System.Data.IDbConnection CreatePosDb()
        {
            return null;
            //string connectionString = Settings.Default.DbConnectionString;
            //return new System.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}