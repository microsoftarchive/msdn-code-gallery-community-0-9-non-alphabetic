namespace ASPCS3T.Web
{
    using ASPCS3T.Business;
    using ASPCS3T.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class AddProduct : System.Web.UI.Page
    {
        ProductBusiness manager = new ProductBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product(0, txtName.Text, decimal.Parse(txtPrice.Text), int.Parse(txtStock.Text));
                this.manager.Save(product);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Response.Redirect("Default.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}