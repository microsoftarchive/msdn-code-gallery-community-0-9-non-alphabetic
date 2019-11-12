//-----------------------------------------------------------------------
// <copyright file="ProductBusiness.cs" company="Edson Castañeda">
//     Copyright © Edson Castañeda. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ASPCS3T.Business
{
    using ASPCS3T.Common;
    using ASPCS3T.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The 'ProductBusiness' class
    /// </summary>
    public class ProductBusiness
    {
        private ProductData manager = new ProductData();

        public List<Product> GetAll()
        {
            return this.manager.GetAll();
        }

        public Product Get(int id)
        {
            return this.manager.Get(id);
        }

        public void Save(Product product)
        {
            this.manager.Save(product);
        }

        public void Delete(int id)
        {
            this.manager.Delete(id);
        }
    }
}