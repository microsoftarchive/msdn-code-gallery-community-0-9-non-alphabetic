namespace ASPCS3T.Data.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data.SqlClient;
    using System.Diagnostics;
    
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetAllProductsTest()
        {
            var connection = DatabaseTests.GetConnection();

            var command = new SqlCommand("sp_Product_GetAll", connection);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Trace.WriteLine(reader.GetString(1));
                }

                connection.Close();

                Assert.IsTrue(true);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [TestMethod]
        public void GetProductTests()
        {
            var data = new ProductData();

            var list = data.GetAll();

            var product = data.Get(109);
        }
    }
}
