using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VectorLib;

namespace Renderer
{
    public partial class Canvas : UserControl
    {
        Camera m_camera;
        Point m_origin;
        CoordinateAxes m_axes;
        AxesPosition m_axesPlacement;
        double m_theta;
        double m_phi;
        int m_x;
        int m_y;
        private List<Sample3DObj> m_list;
        private ActionMode m_action;
        double m_tx = 0;
        double m_ty = 0;
        double m_tz = 0;

        public ActionMode Action
        {
            get { return m_action; }
            set { m_action = value; }
        }
        

        public Canvas()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.UpdateStyles();
            m_camera = new Camera();
            m_origin = new Point();
            m_origin.X = this.Width/2;
            m_origin.Y = this.Height / 2;
            m_axes = new CoordinateAxes(m_origin);
            this.BackColor = Color.White;
            m_axesPlacement = AxesPosition.Center;
            m_list = new List<Sample3DObj>();
            m_list.Add(new Sample3DObj());
            m_action = ActionMode.Rotate;
            
        }   
        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsContainer a= e.Graphics.BeginContainer();
            e.Graphics.TranslateTransform(m_origin.X, m_origin.Y);
            m_camera.Project(m_theta,m_phi,m_tx,m_ty,m_tz);
            
            DrawData(e);
            e.Graphics.EndContainer(a);
            base.OnPaint(e);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            m_origin.X = this.Width / 2;
            m_origin.Y = this.Height / 2;
            SetAxesPosition(m_axesPlacement);
            this.Invalidate();

        }
        private void DrawData(PaintEventArgs e)
        {
            DrawAxes(e.Graphics);
            foreach (Sample3DObj obj in m_list)
            {
                obj.Render(e.Graphics,m_camera.ProjectedMatrix);
            }
            
        }

        private void DrawAxes(Graphics graphics)
        {
            m_axes.Draw(graphics, m_camera.ProjectedMatrix);
        }
        public void SetView(ViewTypes view)
        {
            m_camera.View = view;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            m_x = e.X;
            m_y = e.Y;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left && m_action==ActionMode.Rotate)
            {
                if(m_x-e.X>0)
                m_theta = m_theta + Math.Abs(m_x-e.X);
                else
                    m_theta = m_theta - Math.Abs(m_x - e.X) ;
                if (m_y - e.Y > 0)
                    m_phi = m_phi + Math.Abs(m_y - e.Y);
                else
                    m_phi = m_phi - Math.Abs(m_y - e.Y);
                m_x = e.X;
                m_y = e.Y;
                this.Invalidate();
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left && m_action == ActionMode.Pan)
            {
                if (m_x - e.X > 0)
                    m_tx = m_tx + Math.Abs(m_x - e.X);
                else
                    m_tx = m_tx - Math.Abs(m_x - e.X);
                if (m_y - e.Y > 0)
                    m_ty = m_ty + Math.Abs(m_y - e.Y);
                else
                    m_ty = m_ty - Math.Abs(m_y - e.Y);
                m_x = e.X;
                m_y = e.Y;
                this.Invalidate();
            }
        }
        public void SetAxesPosition(AxesPosition position)
        {
            m_axesPlacement = position;
            switch (m_axesPlacement)
            {

                case AxesPosition.TopLeft:
                    {
                        m_axes.SetPosition( -(this.Width/2-60), -(this.Height/2-60));
                        break;
                    }
                case AxesPosition.TopRight:
                    {
                        m_axes.SetPosition((this.Width / 2 - 60), -(this.Height / 2 - 60));
                        break;
                    }
                case AxesPosition.BottomLeft:
                    {
                        m_axes.SetPosition(-(this.Width / 2 - 60), (this.Height / 2 - 60));
                        break;
                    }
                case AxesPosition.BottomRight:
                    {
                        m_axes.SetPosition((this.Width / 2 - 60), (this.Height / 2 - 60));
                        break;
                    }
                case AxesPosition.Center:
                    {
                        m_axes.SetPosition(0,0);
                        break;
                    }
            }
        }
    }

    public enum ActionMode
    {
        Pan,
        Select,
        Rotate,
        Zoom
    }
}
