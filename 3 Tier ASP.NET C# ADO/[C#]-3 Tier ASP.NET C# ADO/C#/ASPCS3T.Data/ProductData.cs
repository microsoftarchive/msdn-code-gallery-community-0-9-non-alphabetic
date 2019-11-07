//-----------------------------------------------------------------------
// <copyright file="ProductData.cs" company="Edson Castañeda">
//     Copyright © Edson Castañeda. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ASPCS3T.Data
{
    using ASPCS3T.Common;
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The 'ProductData' class
    /// </summary>
    public class ProductData
    {
        public List<Product> GetAll()
        {
            var productList = new List<Product>();

            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("sp_Product_GetAll", connection);                
                
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product(
                            reader.GetInt32(0), 
                            reader.GetString(1), 
                            reader.GetDecimal(2), 
                            reader.GetInt32(3));
                        
                        productList.Add(product);
                    }
                }

                connection.Close();
            }

            return productList;
        }

        public Product Get(int id)
        {
            Product product = null;

            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("sp_Product_Get @id", connection);
                
                command.Parameters.Add(new SqlParameter("id", id));

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDecimal(2),
                        reader.GetInt32(3));
                    }                    
                }

                connection.Close();
            }

            return product;
        }

        public void Save(Product product)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("sp_Product_Insert @name, @price, @stock", connection);

                command.Parameters.Add(new SqlParameter("name", product.Name));
                command.Parameters.Add(new SqlParameter("price", product.Price));
                command.Parameters.Add(new SqlParameter("stock", product.stock));

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("sp_Product_Delete @id", connection);

                command.Parameters.Add(new SqlParameter("id", id));

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}