namespace ASPCS3T.Data.Tests
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class DatabaseTests
    {
        private static SqlConnection connection = null;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPCS3T"].ConnectionString);                
            }
            
            return connection;
        }

        private static void CloseConnection()
        {
            if (!connection.State.Equals(ConnectionState.Closed))
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void StartConnectionTest()
        {
            var connection = GetConnection();

            try
            {
                connection.Open();

                Assert.IsTrue(true);

                CloseConnection();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
