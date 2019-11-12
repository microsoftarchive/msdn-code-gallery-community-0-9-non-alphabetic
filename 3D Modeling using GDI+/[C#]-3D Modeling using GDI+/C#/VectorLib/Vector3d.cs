using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLib
{
    public class Vector3d:Point3d
    {
        #region Properties
        public static Vector3d XAxis
        {
            get
            {
                return new Vector3d(1, 0, 0);
            }
        }

        public static Vector3d YAxis
        {
            get
            {
                return new Vector3d(0, 1, 0);
            }
        }

        public static Vector3d ZAxis
        {
            get
            {
                return new Vector3d(0, 0, 1);
            }
        }
        public double Length
        {
            get
            {
                return Utility.Round(Math.Sqrt(X*X+Y*Y+Z*Z));
            }
        }
        public static Vector3d Add(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3d Subtract(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3d Subtract(Point3d a, Point3d b)
        {
            return new Vector3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3d Add(Point3d a, Point3d b)
        {
            return new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3d Add(Point3d a, Vector3d b)
        {
            return new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3d CrossProduct(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        public static Vector3d CrossProduct(Point3d a, Point3d b)
        {
            return new Vector3d(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        public static double DotProduct(Vector3d a, Vector3d b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public static double DotProduct(Point3d a, Vector3d b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public Vector3d GetNormalVector()
        {
            double val = this.Length;
            return new Vector3d(X / val, Y / val, Z / val);
        }
        public void Normalize()
        {
            double val = this.Length;
            base.X = X / val;
            base.Y = Y / val;
            base.Z = Z / val;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public double AngleToR( Vector3d b)
        {
            double angle = (this * b) / (this.Length * b.Length);
            return Math.Acos(angle);
        }
        public double AngleToD(Vector3d b)
        { 
            return AngleBetWeenR(this,b)*180/Math.PI;
        }


        public static double AngleBetWeenR(Vector3d a, Vector3d b)
        {
            double angle = (a * b) / (a.Length * b.Length);
            return Math.Acos(angle);
        }
        public static double AngleBetWeenD(Vector3d a, Vector3d b)
        {
            return AngleBetWeenR(a, b) * 180 / Math.PI;
        }
        public Vector3d NormalVector(Point3d origin, Point3d a, Point3d b)
        {
           Vector3d u= new Vector3d(origin , a);
           Vector3d v =new Vector3d(origin , b);
           return Vector3d.CrossProduct(u, v);
        }
        public Vector3d CrossProduct(Vector3d v)
        {
            return CrossProduct(this, v);
        }

        public double DotProduct(Vector3d v)
        {
            return DotProduct(this, v);
        }
        public static bool VisibleNormal(Point3d pt1, Point3d pt2, Point3d pt3,Vector3d v4) 
        {
            Vector3d v1 = new Vector3d(pt2, pt1);
            Vector3d v2 = new Vector3d(pt2, pt3);
            Vector3d v3 = v1.CrossProduct(v2);
            return v3.DotProduct(v4) < 0;
        }

       
       #endregion

        #region Operator Overloading
        public static Vector3d operator +(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3d operator /(Vector3d v, double s)
        {
            return new Vector3d(v.X / s, v.Y / s, v.Z / s);
        }

        public static Vector3d operator *(double s, Vector3d v)
        {
            return new Vector3d(s * v.X, s * v.Y, s * v.Z);
        }

        public static Vector3d operator *(Vector3d v, double s)
        {
            return new Vector3d(s * v.X, s * v.Y, s * v.Z);
        }

        public static double operator *(Vector3d u, Vector3d v)
        {
            return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
        }

        public static Vector3d operator -(Vector3d v1, Vector3d v2)
        {
            return new Vector3d(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

       #endregion

        #region Constructor
        public Vector3d()
        {
        }

        public Vector3d(double x, double y, double z)
            : base(x, y, z)
        {
        }
        public Vector3d(Point3d a, Point3d b)
        {
            base.X = a.X - b.X;
            base.Y = a.Y - b.Y;
            base.Z = a.Z - b.Z;
        }
        #endregion


    }
}
