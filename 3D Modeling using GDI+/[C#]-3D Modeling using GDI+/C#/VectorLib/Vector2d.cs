using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLib
{
    public class Vector2d:Point2d
    {
        #region Properties

        /// <summary>
        /// Returns Angle in Radians -pi to +pi range
        /// </summary>
        public double AngleR
        {
            get { return Math.Atan2(base.Y, base.X); }
        }
        /// <summary>
        /// Returns Angle in Degrees -180 to +180 range
        /// </summary>
        
        public double AngleD
        {
            get { return AngleR * 180 / Math.PI; }
        }

        public double Length
        {
            get
            {
                return Utility.Round(Math.Sqrt(X * X + Y * Y));
            }
            set
            {
                double val = Math.Sqrt(X * X + Y * Y);
                X = X * value / val;
                Y = Y* value / val;
            }
        }
        public static Vector2d XAxis
        {
            get
            {
                return new Vector2d(1,0);
            }
        }

         public static Vector2d YAxis
        {
            get
            {
                return new Vector2d(0,1);
            }
        }

        public bool IsUnitVector
        {
            get
            {
                return Math.Abs(this.Length-1)<=Utility.Domain;
            }
        }
        public bool IsZero
        {
            get
            {
                return this.Length<=Utility.Domain;
            }

        }

        #endregion

        #region Constructor
        public Vector2d()
        {
        }
        public Vector2d(double x, double y)
            : base(x, y)
        {
        }

        public Vector2d(Point2d a, Point2d b)
        {
            base.X = a.X - b.X;
            base.Y = a.Y - b.Y;
        }
        public Vector2d(double[] coord)
            : base(coord)
        {
        }
        public Vector2d(Vector2d otherVector):base(otherVector)
        {
         
        }

        #endregion

        #region Methods
        /// <summary>
        /// Returns the angle between a and b vector in radians
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double AngleBetweenR(Vector2d a, Vector2d b)
        {
            double val = (a * b) / (a.Length * b.Length);
            return Math.Acos(val);
        }
        public static double AngleBetweenD(Vector2d a, Vector2d b)
        {
            return AngleBetweenR(a, b) * 180 / Math.PI;
        }
        public static double operator *(Vector2d a, Vector2d b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        public static Vector2d operator *(Vector2d a, double factor)
        {
            return new Vector2d(a.X * factor, a.Y * factor);
        }
        public static Vector2d operator *(double factor,Vector2d a)
        {
            return new Vector2d(a.X * factor, a.Y * factor);
        }
        public static Vector2d operator +(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2d operator -(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.X - b.X, a.Y - b.Y);
        }

        public static double DotProduct(Vector2d a, Vector2d b)
        {
            return a * b;
        }

        public static double DotProduct(Vector2d a, Point2d b)
        {
            return a.X * b.X+a.Y*b.Y;
        }
        public static double DotProduct(Point2d b, Vector2d a)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public Vector2d GetNormal()
        {
            double val = this.Length;
            return new Vector2d(X / val,Y/val);
        }
        public void NormalizeVector()
        {
            double val= this.Length;
            X = X / val;
            Y = Y / val;
        }
        private static double PerpendicularDotProduct(Vector2d a, Vector2d b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static Vector2d Subtract(Point2d a, Point2d b)
        {
            return new Vector2d(a.X - b.X, a.Y - b.Y);
        }
        public static double SignedAngleBetweenR(Vector2d a, Vector2d b)
        {
            return Math.Atan2(Vector2d.PerpendicularDotProduct(a, b), Vector2d.DotProduct(a, b));
        }
        public static double SignedAngleBetweenD(Vector2d a, Vector2d b)
        {
            return SignedAngleBetweenR(a, b) * 180 / Math.PI;
        }
        public static double AngleBetweenIn360(Vector2d a, Vector2d b)
        {
            double val = SignedAngleBetweenD(a, b);
            if (val < 0)
                val = val + 360;
            return val;
        }

        public static double AngleBetweenIn2PI(Vector2d a, Vector2d b)
        {
            double val = SignedAngleBetweenR(a, b);
            if (val < 0)
                val = val + 2*Math.PI;
            return val;
        }

        public static Vector2d Add(Point2d a, Point2d b)
        {
            return new Vector2d(a.X + b.X, a.Y + b.Y);
        }

        public override string ToString()
        {
            return X.ToString() + "," + Y.ToString() + "," + Length.ToString() + "," + AngleD.ToString();
        }
        public static bool IsParallel(Vector2d a, Vector2d b)
        {
            return Math.Abs(1 - a * b) < Utility.Domain;
        }
        #endregion
    }
}
