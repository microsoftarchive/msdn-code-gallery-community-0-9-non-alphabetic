using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorLib;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Renderer
{
    public class CoordinateAxes
    {
        Point3d m_origin;
        Point3d m_x;
        Point3d m_y;
        Point3d m_z;
        Pen m_xColor;
        Pen m_yColor;
        Pen m_zColor;
        Point m_projX;
        Point m_projY;
        Point m_projZ;
        Point m_projOrigin;
        Font m_font;
        Brush m_brush;
        Rectangle m_rect;
        Region m_region;
        Matrix m1;

        public CoordinateAxes(Point pt)
        {
            m_origin = Point3d.Origin;

            m_x = new Point3d(50, 0, 0);
            m_y = new Point3d(0, 50, 0);
            m_z = new Point3d(0, 0, 50);
            m_xColor = new Pen(Color.Red, 2f);
            m_yColor = new Pen(Color.Green, 2f);
            m_zColor = new Pen(Color.Blue, 2f);
            m_projX = new Point();
            m_projY = new Point();
            m_projZ = new Point();
            m_projOrigin = Point.Empty;
            m_font = new Font("Arial", 8, FontStyle.Bold);
            m_brush = new SolidBrush(Color.Black);
            m1 = new Matrix(1, 0, 0, 1, 0,0);

        }
        internal void SetPosition(int tx, int ty)
        {
            m1 = new Matrix(1, 0, 0, 1, tx,ty);
            
        }

        protected   void DrawAxes(Graphics g,Matrix3d ProjMatrix)
        {
           GraphicsState _s1= g.Save();
            GraphicsContainer a = g.BeginContainer();
            g.Transform = m1;
            double[] _p1 = ProjMatrix.ApplyTransform(m_x.X, m_x.Y, m_x.Z,1);
            double[] _p2 = ProjMatrix.ApplyTransform(m_y.X, m_y.Y, m_y.Z, 1);
            double[] _p3 = ProjMatrix.ApplyTransform(m_z.X, m_z.Y, m_z.Z, 1);
            double[] _p0=ProjMatrix.ApplyTransform(m_origin.X,m_origin.Y,m_origin.Z,1);
            
            m_projOrigin.X=(int)_p0[0];m_projOrigin.Y=-(int)_p0[1];
            m_projX.X = (int)_p1[0]; m_projX.Y = -(int)_p1[1];
            m_projY.X = (int)_p2[0]; m_projY.Y = -(int)_p2[1];
            m_projZ.X = (int)_p3[0]; m_projZ.Y = -(int)_p3[1];
            
            g.DrawLine(m_xColor, m_projOrigin, m_projX);
            g.DrawLine(m_yColor, m_projOrigin, m_projY);
            g.DrawLine(m_zColor, m_projOrigin, m_projZ);
                g.DrawString("X", m_font, m_brush, m_projX);
                g.DrawString("Y", m_font, m_brush, m_projY);
                g.DrawString("Z", m_font, m_brush, m_projZ);
                g.ResetTransform();  
            g.EndContainer(a);
            g.Restore(_s1);
            
        }
        public void Draw(Graphics g, Matrix3d ProjMatrix)
        {
            DrawAxes(g, ProjMatrix);
        }

    }
    public enum AxesPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center
    }
}
