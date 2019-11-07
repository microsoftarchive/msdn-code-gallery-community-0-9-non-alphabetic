using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLib
{
    /*
     * According to Euler's rotation theorem, any rotation or sequence of rotations of a rigid body
     * or coordinate system about a fixed point is equivalent to a single rotation by a given angle θ 
     * about a fixed axis (called Euler axis) that runs through the fixed point. 
     * The Euler axis is typically represented by a unit vector u→. Therefore, any rotation in
     * three dimensions can be represented as a combination of a vector u→ and a scalar θ.
     * Quaternions give a simple way to encode this axis–angle representation in four numbers, 
     * and to apply the corresponding rotation to a position vector representing a point relative to the origin in R3.
     */

    public class Quaternion
    {
        private double m_x;

        public double X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        private double m_y;

        public double Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        private double m_z;

        public double Z
        {
            get { return m_z; }
            set { m_z = value; }
        }

        private double m_w;

        public double W
        {
            get { return m_w; }
            set { m_w = value; }
        }

        public static Quaternion Identity
        {
            get
            {
                return new Quaternion(0, 0, 0, 1);
            }
        }

        public Quaternion(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public Quaternion(double theta, Vector3d rotAxis)
        {
            double ang = (theta * Math.PI / 180) * 2;
            W = Math.Cos(ang);
            double rot = Math.Sin(ang);
            X = rotAxis.X*rot;
            Y = rotAxis.Y*rot;
            Z = rotAxis.Z*rot;
            this.Normalize();
        }
        public void Normalize()
        {
            double len = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
            X = X / len;
            Y = Y / len;
            Z = Z / len;
            W = W / len;
        }
        public Quaternion(double yaw, double pitch, double roll)
        {
            double pi = roll * 0.5;
            double sinChy2 = Math.Sin(pi);
            double cosChy2 = Math.Cos(pi);
            double theta = pitch * 0.5;
            double sinTheta2 = Math.Sin(theta);
            double cosTheta2 = Math.Cos(theta);
            double chy = yaw * 0.5;
            double sinPi2 = Math.Sin(chy);
            double cosPi2 = Math.Cos(chy);
            X = cosPi2 * sinTheta2 * cosChy2 + sinPi2 * cosTheta2 * sinChy2;
            Y = sinPi2 * cosTheta2 * cosChy2 - cosPi2 * sinTheta2 * sinChy2;
            Z = cosPi2 * cosTheta2 * sinChy2 - sinPi2 * sinTheta2 * cosChy2;
            W = cosPi2 * cosTheta2 * cosChy2 + sinPi2 * sinTheta2 * sinChy2;
        }


        public void Conjugate()
        {
            X = -X; Y = -Y; Z = -Z;
        }

        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return object.Equals(left, right);
        }

        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return !object.Equals(left, right);
        }

        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            double w = right.W * left.W - right.X * left.X - right.Y * left.Y - right.Z * left.Z;
            double num = right.W * left.X + right.X * left.W + right.Y * left.Z - right.Z * left.Y;
            double w1 = right.W * left.Y + right.Y * left.W + right.Z * left.X - right.X * left.Z;
            double num1 = right.W * left.Z + right.Z * left.W + right.X * left.Y - right.Y * left.X;
            return new Quaternion(num, w1, num1, w);
        }

        public static Quaternion operator *(Quaternion left, double s)
        {
            return new Quaternion(s * left.X, s * left.Y, s * left.Z, s * left.W);
        }

        public static Quaternion operator *(double s, Quaternion right)
        {
            return new Quaternion(s * right.X, s * right.Y, s * right.Z, s * right.W);
        }
        public void ToAxisAngle(out Vector3d rotAxis, out double rotAngleInDegrees)
        {
            double theta = Math.Acos(this.W);
            double pi = Math.Sin(theta);
            rotAxis = Vector3d.ZAxis;
            if (pi == 0)
            {
                rotAngleInDegrees = 0;
                rotAxis = Vector3d.ZAxis;
                return;
            }
            rotAngleInDegrees = (theta * 2)*Math.PI/180;
            rotAxis.X = this.X / pi;
            rotAxis.Y = this.Y / pi;
            rotAxis.Z = this.Z / pi;
            rotAxis.Normalize();
        }
        public Matrix3d ToMatrix()
        {
            Matrix3d m_quad = Matrix3d.IdentityMatrix();

            m_quad.Matrix[0, 0] = 1 - 2 * (this.Y * this.Y + this.Z * this.Z);
            m_quad.Matrix[0, 1] = 2 * (this.X * this.Y - this.W * this.Z);
            m_quad.Matrix[0, 2] = 2 * (this.X * this.Z + this.W * this.Y);
            m_quad.Matrix[1, 0] = 2 * (this.X * this.Y + this.W * this.Z);
            m_quad.Matrix[1, 1] = 1 - 2 * (this.X * this.X + this.Z * this.Z);
            m_quad.Matrix[1, 2] = 2 * (this.Y * this.Z - this.W * this.X);
            m_quad.Matrix[2, 0] = 2 * (this.X * this.Z - this.W * this.Y);
            m_quad.Matrix[2, 1] = 2 * (this.Y * this.Z + this.W * this.X);
            m_quad.Matrix[2, 2] = 1 - 2 * (this.X * this.X + this.Y * this.Y);
            m_quad.Matrix[3, 3] = 1;

            return m_quad;
        }
    }
}
