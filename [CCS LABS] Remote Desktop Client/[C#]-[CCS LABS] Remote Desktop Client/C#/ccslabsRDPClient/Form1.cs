using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSTSCLib;

namespace ccslabsRDPClient
{
    public partial class RDC : Form
    {
        public RDC()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                if (string.IsNullOrEmpty(tbtServer.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbPort.Text) || string.IsNullOrEmpty(tbUsername.Text))
                {
                    MessageBox.Show("You need to enter a valid server, port, password and username to connect", "Login Details Required", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    // for example, I have my AxMsRdpClient control named rdpClient.
                    rdpClient.Domain = "ccslabs";
                    rdpClient.Server = tbtServer.Text;
                    rdpClient.UserName = tbUsername.Text;
                    rdpClient.AdvancedSettings2.SmartSizing = true;
                    rdpClient.AdvancedSettings9.NegotiateSecurityLayer = true;

                    // Due to security reasons, you have to implement an interface (IMsTscNonScriptable) to cast it separately.
                    //     IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
                    //     secured.ClearTextPassword = tbPassword.Text;

                    rdpClient.AdvancedSettings5.ClearTextPassword = tbPassword.Text;
                    // optional 
                    rdpClient.ColorDepth = 24; // int value can be 8, 15, 16, or 24



                    rdpClient.Connect();

                    // Ok we have everything we need to continue.
                    btnConnect.Text = "Disconnect";
                    btnConnect.BackColor = Color.Red;

                }
            }
            else
            {
                btnConnect.Text = "Connect";
                btnConnect.BackColor = Color.PaleGreen;
                try
                {
                    rdpClient.Disconnect();
                }
                catch (Exception)
                {
                    // ignore
                }

                rdpClient.Refresh();
            }
        }


    }
}
