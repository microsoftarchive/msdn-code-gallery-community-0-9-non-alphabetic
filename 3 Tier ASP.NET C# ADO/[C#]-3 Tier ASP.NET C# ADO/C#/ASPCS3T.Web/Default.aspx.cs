namespace ASPCS3T.Web
{
    using ASPCS3T.Business;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Default : System.Web.UI.Page
    {
        ProductBusiness productManager = new ProductBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadProducts();
            }

            btnDelete.Visible = false;
        }

        private void LoadProducts()
        {
            gvProducts.DataSource = this.productManager.GetAll();
            gvProducts.DataBind();
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = gvProducts.SelectedIndex.Equals(-1) ? false : true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(gvProducts.Rows[gvProducts.SelectedIndex].Cells[1].Text);            
            
            this.productManager.Delete(id);
            this.LoadProducts();

            btnDelete.Visible = false;
        }
    }
}