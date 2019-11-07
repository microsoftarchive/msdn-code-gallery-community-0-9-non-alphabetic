using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VectorLib
{
    public class Sample3DObj
    {
        Point3d[] m_vertex;
        int[][] m_edges;
        int[][] m_face;
        Point P1;
        Point P2;
        Pen m_pen;
     
        public Sample3DObj()
        {
            m_vertex = new Point3d[8];
            m_edges = new int[12][];
            m_face = new int[6][];
            m_pen = new Pen(Color.Black,2);
            m_vertex[0] = Point3d.Origin;
            m_vertex[1] = new Point3d(100, 0, 0);
            m_vertex[2] = new Point3d(100, 100, 0);
            m_vertex[3] = new Point3d(0, 100, 0);
            m_vertex[4] = new Point3d(0, 0, 100);
            m_vertex[5] = new Point3d(100, 0, 100);
            m_vertex[6] = new Point3d(100, 100, 100);
            m_vertex[7] = new Point3d(0, 100, 100);

            m_edges[0] = new int[] { 0, 1 };
            m_edges[1] = new int[] { 1, 2 };
            m_edges[2] = new int[] { 2,3 };
            m_edges[3] = new int[] { 3, 0 };

            m_edges[4] = new int[] { 4, 5 };
            m_edges[5] = new int[] { 5, 6 };
            m_edges[6] = new int[] { 6, 7 };
            m_edges[7] = new int[] { 7, 4 };

            m_edges[8] = new int[] { 0, 4 };
            m_edges[9] = new int[] { 1, 5 };
            m_edges[10] = new int[] { 6, 2 };
            m_edges[11] = new int[] { 3, 7 };

            m_face[0] = new int[] { 0, 1, 2, 3 };
            m_face[1] = new int[] { 4, 5, 6, 7 };
            m_face[2] = new int[] { 1,9,5,10};
            m_face[3] = new int[] { 8,3,11,7 };
            m_face[4] = new int[] { 0,9,4,8 };
            m_face[5] = new int[] { 2,10,6,11};
        }
        public virtual void Render(Graphics g, Matrix3d ProjMatrix)
        {
            //Iterate each faces
            for (int i = 0; i <5; i++)
            {
                
                //iterate each edges in that face
                for (int j = 0; j <4; j++)
                {

                    int k=m_face[i][j];

                    GraphicsState _s1 = g.Save();
                    GraphicsContainer a = g.BeginContainer();
                    Point3d p1 =m_vertex[m_edges[k][0]];
                    Point3d p2 = m_vertex[m_edges[k][1]];
                    double[] _p1 = ProjMatrix.ApplyTransform(p1.X,p1.Y,p1.Z, 1);
                    double[] _p2 = ProjMatrix.ApplyTransform(p2.X, p2.Y, p2.Z, 1);
                    P1.X = (int)_p1[0]; P1.Y = -(int)_p1[1];
                    P2.X = (int)_p2[0]; P2.Y = -(int)_p2[1];
                  
                    g.DrawLine(m_pen,P1, P2);
                    g.ResetTransform();
                    g.EndContainer(a);
                    g.Restore(_s1);
                    
                  }
                 
                }
            
        }
    }
}
