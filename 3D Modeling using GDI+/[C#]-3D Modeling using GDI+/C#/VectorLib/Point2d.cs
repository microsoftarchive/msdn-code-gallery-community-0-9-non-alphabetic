using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLib
{
    public class Point2d:ICloneable
    {

        #region Members
        private double m_x;
        private double m_backX;
        private double m_y;
        private double m_backY;
        #endregion

        #region Properties

        public double X
        {
            get { return m_x; }
            set {
                m_backX = value;
                m_x = Utility.Round(value);
                }
        }
        public double Y
        {
            get { return m_y; }
            set {
                m_backY = value;
                m_y = Utility.Round(value);
                }
        }

        public static Point2d Origin
        {
            get { return new Point2d(0, 0); }
        }
        public double MaxCoordinate
        {
            get { return Math.Max(Math.Abs(X), Math.Abs(Y)); }
        }
        internal double BackX
        {
            get { return m_backX; }
        }
        internal double BackY
        {
            get { return m_backY; }
        }
        #endregion

        #region Methods

        public double DistanceTo(Point2d b)
        {
            return Point2d.Distance(this, b);
        }

        public static double Distance(Point2d a, Point2d b)
        {

            return Utility.Round(Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2)));
        }


        public static bool IsEqual(Point2d a, Point2d b)
        {
            return (Point2d.Distance(a, b) <= Utility.Domain);
        }

        public Point2d PointClone()
        {
            return new Point2d(this.m_backX, this.m_backY);
        }
        public virtual object Clone()
        {
            return PointClone();
        }
        public double[] ToArray()
        {
            return new double[] { this.X, this.Y };
        }
        
        #endregion 

        #region Override Methods
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            else
                return Utility.IsEqual(this.X, ((Point2d)obj).X) && Utility.IsEqual(this.Y, ((Point2d)obj).Y);
        }
        public override string ToString()
        {
            return (X.ToString() + "," + Y.ToString());
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() * 397 ^ Y.GetHashCode();
        }
        
        #endregion

        #region Constructor
        public Point2d()
        {
        }
        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point2d(double[] args)
        {
            try
            {
                if (args.Length == 2)
                {
                    X = args[0];
                    Y = args[1];
                }
                else
                {
                    throw new Exception("Invalid array length");
                }
            }
            catch (Exception e)
            {
                //todo
            }
        }

        public Point2d(Point2d otherPoint)
        {
            X = otherPoint.X;
            Y = otherPoint.Y;
        }
        #endregion

        #region Operator OverLoading
        public static Point2d operator +(Point2d a, Point2d b)
        {
            return new Point2d(a.m_backX + b.m_backX, a.m_backY + b.m_backY);
        }

        public static Point2d operator -(Point2d a, Point2d b)
        {
            return new Point2d(a.m_backX - b.m_backX, a.m_backY - b.m_backY);
        }

        public static Point2d operator /(Point2d a, double factor)
        {
            return new Point2d(a.m_backX /factor, a.m_backY /factor);
        }

        public static Point2d operator *(Point2d a, double factor)
        {
            return new Point2d(a.m_backX *factor, a.m_backY* factor);
        }
        public static Point2d operator *(double factor, Point2d a)
        {
            return new Point2d(a.m_backX * factor, a.m_backY * factor);
        }

        public static bool operator ==(Point2d a, Point2d b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point2d a, Point2d b)
        {
            return !a.Equals(b);
        }
        #endregion


    }

    
}
