using System;
using System.Windows.Forms;
using System.Collections;

namespace TBAuction
{
    public partial class PropertyList : Form
    {
        public PropertyList()
        {
            InitializeComponent();
            propertyString = string.Empty;
        }

        private ArrayList pts;

        public ArrayList Pts
        {
            get { return pts; }
            set { 
                pts = value;

                float tableHeight = 0F;

                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                this.Controls.Add(tableLayoutPanel);
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,60F));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,560F));
                tableLayoutPanel.Width = 620;
                tableLayoutPanel.Top = 10;
                tableLayoutPanel.Left = 10;
                tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                
                for (int i = 0; i < pts.Count; i++)
                {

                    float lines = 0F;
                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    flowLayoutPanel.Dock = DockStyle.Fill;                     

                    ProductPageHandle.PropertyType property = (ProductPageHandle.PropertyType)pts[i];
                    
                    Label label = new Label();
                    label.Name = "label_" + property.Name;
                    label.Text = property.Name;
                    label.Anchor = AnchorStyles.Right;                    
                    

                    for (int j = 0; j < property.PropertyList.Count; j++)
                    {
                        ProductPageHandle.TitleValuePair tvp = (ProductPageHandle.TitleValuePair)property.PropertyList[j];
                        RadioButton rb = new RadioButton();
                        rb.Name = "rb_" + tvp.Value;
                        rb.Text = tvp.Title;
                        flowLayoutPanel.Controls.Add(rb);                        
                    }

                    lines = (float)Math.Ceiling(property.PropertyList.Count / 5D);
                    tableHeight += 30F * lines;

                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F * lines));
                    tableLayoutPanel.Controls.Add(flowLayoutPanel);
                    tableLayoutPanel.SetCellPosition(flowLayoutPanel, new TableLayoutPanelCellPosition(1, i));

                    tableLayoutPanel.Controls.Add(label);
                    tableLayoutPanel.SetCellPosition(label, new TableLayoutPanelCellPosition(0, i));

                }

                tableLayoutPanel.Height = (int)tableHeight + 10;

                tableLayoutPanel.Refresh();

                btnOk.Top = (int)tableHeight + 35;

                this.Height = (int)tableHeight + 100;
            }
        }

        private string propertyString;

        public string PropertiesString
        { 
            get { return propertyString;} 
            set { propertyString  = value;} 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                if (con is TableLayoutPanel)
                {
                    foreach (Control control in con.Controls)
                    {
                        if (control is FlowLayoutPanel)
                        {
                            foreach (Control ctrl in control.Controls)
                            {
                                if (ctrl is RadioButton)
                                {
                                    if ((ctrl as RadioButton).Checked)
                                    {
                                        propertyString += ctrl.Text + ";";
                                    }
                                }
                            }
                        }
                    }
                }
            }            

            if(propertyString.EndsWith(";"))
            {
                propertyString = propertyString.Substring(0,propertyString.Length -1);
            }

            this.Hide();
        }
       
    }
}
