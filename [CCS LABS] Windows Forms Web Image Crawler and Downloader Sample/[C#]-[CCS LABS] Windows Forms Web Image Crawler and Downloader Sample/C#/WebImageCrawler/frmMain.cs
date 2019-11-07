using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using DevRain.Data.Extracting;
using System.Runtime.InteropServices;



namespace WebImageCrawler
{
    public partial class Wic : Form
    {

        public Wic()
        {
            InitializeComponent();
        }

        // Checks to see if it can start.
        private void BtnGoClick(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tbURL.Text))
            {
                // Change to Desktop View
                DesktopView();
            }
            else
            {
                MessageBox.Show("You need to add a valid starting URL");
            }


        }

        // Re-design the 
        private void DesktopView()
        {
            this.Hide();
            FrmDesktopView fdtv = new FrmDesktopView(tbURL.Text);
            fdtv.Show();


        }






    }
}
