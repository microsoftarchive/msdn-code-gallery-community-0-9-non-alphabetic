using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VectorLib;
using System.Drawing;
using System.Runtime.InteropServices;
using Renderer;


namespace SampleDraw
{
    public class Form1:Form
    {
        private MenuStrip menuStrip1;
        private Renderer.Canvas canvas1;
        private ToolStripMenuItem axisPositionToolStripMenuItem;
        private ToolStripMenuItem centerToolStripMenuItem;
        private ToolStripMenuItem topLeftToolStripMenuItem;
        private ToolStripMenuItem topRightToolStripMenuItem;
        private ToolStripMenuItem bottmLeftToolStripMenuItem;
        private ToolStripMenuItem bottomRightToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem frontToolStripMenuItem;
        private ToolStripMenuItem topToolStripMenuItem;
        private ToolStripMenuItem leftSideToolStripMenuItem;
        private ToolStripMenuItem isoToolStripMenuItem;
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Sample Draw";
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
            this.Paint+=new PaintEventHandler(Form1_Paint);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ResizeRedraw = true;
            this.ResumeLayout();
            this.UpdateStyles();
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }
        

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.axisPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottmLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvas1 = new Renderer.Canvas();
            this.frontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.axisPositionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // axisPositionToolStripMenuItem
            // 
            this.axisPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerToolStripMenuItem,
            this.topLeftToolStripMenuItem,
            this.topRightToolStripMenuItem,
            this.bottmLeftToolStripMenuItem,
            this.bottomRightToolStripMenuItem});
            this.axisPositionToolStripMenuItem.Name = "axisPositionToolStripMenuItem";
            this.axisPositionToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.axisPositionToolStripMenuItem.Text = "Axis Position";
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Checked = true;
            this.centerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.centerToolStripMenuItem.Text = "Center";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // topLeftToolStripMenuItem
            // 
            this.topLeftToolStripMenuItem.CheckOnClick = true;
            this.topLeftToolStripMenuItem.Name = "topLeftToolStripMenuItem";
            this.topLeftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topLeftToolStripMenuItem.Text = "Top Left";
            this.topLeftToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // topRightToolStripMenuItem
            // 
            this.topRightToolStripMenuItem.CheckOnClick = true;
            this.topRightToolStripMenuItem.Name = "topRightToolStripMenuItem";
            this.topRightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topRightToolStripMenuItem.Text = "Top Right";
            this.topRightToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // bottmLeftToolStripMenuItem
            // 
            this.bottmLeftToolStripMenuItem.CheckOnClick = true;
            this.bottmLeftToolStripMenuItem.Name = "bottmLeftToolStripMenuItem";
            this.bottmLeftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bottmLeftToolStripMenuItem.Text = "Bottom Left";
            this.bottmLeftToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // bottomRightToolStripMenuItem
            // 
            this.bottomRightToolStripMenuItem.CheckOnClick = true;
            this.bottomRightToolStripMenuItem.Name = "bottomRightToolStripMenuItem";
            this.bottomRightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bottomRightToolStripMenuItem.Text = "Bottom Right";
            this.bottomRightToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // canvas1
            // 
            this.canvas1.Action = Renderer.ActionMode.Rotate;
            this.canvas1.BackColor = System.Drawing.Color.White;
            this.canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas1.Location = new System.Drawing.Point(0, 24);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(881, 410);
            this.canvas1.TabIndex = 2;
            this.canvas1.Load += new System.EventHandler(this.canvas1_Load);
            // 
            // frontToolStripMenuItem
            // 
            this.frontToolStripMenuItem.Name = "frontToolStripMenuItem";
            this.frontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.frontToolStripMenuItem.Text = "Front";
            this.frontToolStripMenuItem.Click += new System.EventHandler(this.frontToolStripMenuItem_Click);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.frontToolStripMenuItem_Click);
            // 
            // leftSideToolStripMenuItem
            // 
            this.leftSideToolStripMenuItem.Name = "leftSideToolStripMenuItem";
            this.leftSideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leftSideToolStripMenuItem.Text = "Left Side";
            this.leftSideToolStripMenuItem.Click += new System.EventHandler(this.frontToolStripMenuItem_Click);
            // 
            // isoToolStripMenuItem
            // 
            this.isoToolStripMenuItem.Name = "isoToolStripMenuItem";
            this.isoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.isoToolStripMenuItem.Text = "Iso";
            this.isoToolStripMenuItem.Click += new System.EventHandler(this.frontToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frontToolStripMenuItem,
            this.topToolStripMenuItem,
            this.leftSideToolStripMenuItem,
            this.isoToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(881, 434);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void frontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _item = sender as ToolStripMenuItem;
           
            switch( _item.Text)
            {
                case "Front":
                    {
                        canvas1.SetView(ViewTypes.Front);
                        break;
                    }
                case "Top":
                    {
                        canvas1.SetView(ViewTypes.Top);
                      break;
                    }
                case "Left Side":
                    {
                        canvas1.SetView(ViewTypes.Left);
                        break;
                    }
                case "Iso":
                    {
                        canvas1.SetView(ViewTypes.Iso);
                        break;
                    }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
             ToolStripMenuItem _item = sender as ToolStripMenuItem;

             topLeftToolStripMenuItem.Checked = false;
             topRightToolStripMenuItem.Checked = false;
             bottmLeftToolStripMenuItem.Checked = false;
             bottomRightToolStripMenuItem.Checked = false;
             centerToolStripMenuItem.Checked = false;
             _item.Checked = true;
             switch (_item.Text)
             {
                     
                 case "Center":
                     {
                         canvas1.SetAxesPosition(AxesPosition.Center);
                         break;
                     }
                 case "Top Left":
                     {
                         canvas1.SetAxesPosition(AxesPosition.TopLeft);
                         break;
                     }
                 case "Top Right":
                     {
                         canvas1.SetAxesPosition(AxesPosition.TopRight);
                         break;
                     }
                 case "Bottom Left":
                     {
                         canvas1.SetAxesPosition(AxesPosition.BottomLeft);
                         break;
                     }
                 case "Bottom Right":
                     {
                         canvas1.SetAxesPosition(AxesPosition.BottomRight);
                         break;
                     }
                     
             }
             canvas1.Invalidate();
        }

        private void canvas1_Load(object sender, EventArgs e)
        {

        }

        private void splineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      
       
    }
    
}
