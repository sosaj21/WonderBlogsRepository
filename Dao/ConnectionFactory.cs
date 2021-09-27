using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class ConnectionFactory
    {
        #region properties
        public IConfiguration Config; 
        public static ConnectionFactory instance = null;
        private static readonly object padlock = new object();
       public IDbConnection Connection
        {
            get
            {
                return new SqlConnection (Config.GetConnectionString("SQLConnectionString"));
            }
        }
        #endregion 

        #region constructor
        public static ConnectionFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ConnectionFactory();
                    }
                    return instance;
                }
            }
        }
        #endregion 

    }
}
