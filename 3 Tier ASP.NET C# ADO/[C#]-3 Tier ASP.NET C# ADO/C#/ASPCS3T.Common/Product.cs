//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="Edson Castañeda">
//     Copyright © Edson Castañeda. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ASPCS3T.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int stock { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, decimal price, int stock)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.stock = stock;
        }
    }
}