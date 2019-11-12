using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VectorLib;


namespace Renderer
{
  
    public class Camera
    {
        private Point3d m_targetPoint;

        public Point3d TargetPoint
        {
            get { return m_targetPoint; }
            set { m_targetPoint = value; }
        }

        private Point3d m_camPosition;

        public Point3d CameraPosition
        {
            get { return m_camPosition; }
            set { m_camPosition = value; }
        }

        private double m_distance;

        public double Distance
        {
            get { return m_distance; }
            set { m_distance = value; }
        }

        private double m_zoomFactor;

        public double ZoomFactor
        {
            get { return m_zoomFactor; }
            set { m_zoomFactor = value; }
        }

        //private Quaternion m_cameraRotation;

        //public Quaternion CameraRotation
        //{
        //    get { return m_cameraRotation; }
        //    set { m_cameraRotation = value; }
        //}

        private Vector3d m_upVector;
        
        public Vector3d UpVector
        {
            get { return m_upVector; }
            set { m_upVector = value; }
        }
        private ProjectionTypes m_projType;

        public ProjectionTypes ProjectType
        {
            get { return m_projType; }
            set { m_projType = value; }
        }

        private Matrix3d m_projectedMatrix;

        public Matrix3d ProjectedMatrix
        {
            get {
                return m_projectedMatrix;
                }
            set { m_projectedMatrix = value; }
        }

        private ViewTypes m_viewType;

        public ViewTypes View
        {
            get { return m_viewType; }
            set { m_viewType = value; }
        }
        private double m_cameraPhi;

        public double Phi
        {
            get { return m_cameraPhi; }
            set { m_cameraPhi = value; }
        }

        private double m_cameraTheta;

        public double CameraTheta
        {
            get { return m_cameraTheta; }
            set { m_cameraTheta = value; }
        }

        private double m_radius;

        public double CameraRadius
        {
            get { return m_radius; }
            set { m_radius = value; }
        }

        private Point3d m_temp;

        private Matrix3d mout;

        public Camera()
        {
            m_camPosition = Point3d.Origin;
            m_camPosition.X = 0;
            m_camPosition.Y = 0;
            m_camPosition.Z=3;
            m_targetPoint = new Point3d(0,0,0);
            m_upVector = Vector3d.YAxis;
            //CameraRotation = new Quaternion(45, 30, 0);
            Distance = m_camPosition.DistanceTo(m_targetPoint);
            CameraRadius = Distance;
            Vector3d n = new Vector3d(m_camPosition, m_targetPoint);
            View = ViewTypes.Iso;
            CameraTheta = 45;
            m_cameraPhi = 30;
            this.m_camPosition.Y = Distance * Math.Sin(Math.PI * m_cameraPhi / 180);
            this.m_camPosition.X = Distance * Math.Cos(Math.PI * m_cameraTheta / 180)*Math.Cos(Math.PI * m_cameraPhi / 180);
            this.m_camPosition.Z = Distance * Math.Sin(Math.PI * m_cameraTheta / 180)*Math.Cos(Math.PI * m_cameraPhi / 180);
            m_temp = Point3d.Origin;
        
             }
       

        public void Project(double theta=0, double phi=0, double tx=0,double ty=0, double tz=0) 
        {   
            if (m_upVector == Vector3d.YAxis)
            {
                m_temp.Y = Distance * Math.Sin(Math.PI * (m_cameraPhi + phi) / 180);
                m_temp.X = Distance * Math.Cos(Math.PI * (m_cameraTheta + theta) / 180) * Math.Cos(Math.PI * (m_cameraPhi + phi) / 180);
                m_temp.Z = Distance * Math.Sin(Math.PI * (m_cameraTheta + theta) / 180) * Math.Cos(Math.PI * (m_cameraPhi + phi) / 180);
            }
            else
            {
                m_temp.Z = Distance * Math.Sin(Math.PI * (m_cameraPhi + phi) / 180);
                m_temp.X = Distance * Math.Cos(Math.PI * (m_cameraTheta + theta) / 180) * Math.Cos(Math.PI * (m_cameraPhi + phi) / 180);
                m_temp.Y = Distance * Math.Sin(Math.PI * (m_cameraTheta + theta) / 180) * Math.Cos(Math.PI * (m_cameraPhi + phi) / 180);
            }
            
            double _sin1, _cos1, _sin2, _cos2, _sin3, _cos3;
            double _d1,_d2,_d3;

            Matrix3d _m1 = Matrix3d.IdentityMatrix();
            _m1.Translate(-(m_temp.X), -(m_temp.Y), -(m_temp.Z));

            Point3d _dist = m_temp-TargetPoint;
             _d2 = m_temp.DistanceTo(TargetPoint);
            _d1 = Math.Sqrt((_dist.X * _dist.X) + (_dist.Z * _dist.Z));
            
            // X Axis rotation
            Matrix3d _m2 = Matrix3d.IdentityMatrix();
            if (_d1 != 0.0)
            {
                _sin1 = -_dist.X / _d1;
                _cos1 = _dist.Z / _d1;
                _m2.Matrix[0, 0] = _cos1;
                _m2.Matrix[0, 2] = -_sin1;
                _m2.Matrix[2, 0] = _sin1;
                _m2.Matrix[2, 2] = _cos1;

            }
            // Y Axis rotation
            _d2 = Math.Sqrt((_dist.X * _dist.X) + (_dist.Y * _dist.Y) + (_dist.Z * _dist.Z));
            Matrix3d _m3 = Matrix3d.IdentityMatrix();
            if (_d2 != 0.0)
            {
                _sin2 = _dist.Y / _d2;
                _cos2 = _d1 / _d2;
                _m3.Matrix[1,1] = _cos2;
                _m3.Matrix[1, 2] = _sin2;
                _m3.Matrix[2, 1] = -_sin2;
                _m3.Matrix[2, 2] = _cos2;
            }
           double[] _up2= _m2.ApplyTransform(m_upVector.X, UpVector.Y, UpVector.Z, 1);
           double[] _up1=_m3.ApplyTransform(_up2[0], _up2[1], _up2[2], _up2[3]);
           
          // Z Axis Rotation
            _d3 = Math.Sqrt((_up1[0] * _up1[0]) + (_up1[1] * _up1[1]));
           Matrix3d _m4 = Matrix3d.IdentityMatrix();
           if (_d3 != 0.0)
           {
               _sin3 = _up1[0] / _d3;
               _cos3 = _up1[1] / _d3;
               _m4.Matrix[0, 0] = _cos3;
               _m4.Matrix[0, 1] = _sin3;
               _m4.Matrix[1, 0] =-_sin3;
               _m4.Matrix[1, 1] = _cos3;
           }
            Matrix3d _m5=Matrix3d.IdentityMatrix();
            if (ProjectType == ProjectionTypes.Perspective && _d2 != 0.0)
            {
                _m5.Matrix[2, 3] = -1 / _d2;
            }
            else
            {
                _m5 = Matrix3d.IdentityMatrix();    
            }
            Matrix3d _a= Matrix3d.MatrixMultiply3D(_m1, _m2);
            Matrix3d _b =Matrix3d.MatrixMultiply3D(_m3, _m4);
            Matrix3d _res = Matrix3d.MatrixMultiply3D(_a, _b);

            // Still in progress code
            if (m_viewType == ViewTypes.Front)
            {
                Matrix3d m_view = Matrix3d.IdentityMatrix();
               
                m_view.Matrix[2, 2] = 0;
                
                ProjectedMatrix = m_view;
            }
            else if (m_viewType == ViewTypes.Top)
            {
                Matrix3d m_view = Matrix3d.IdentityMatrix();
                m_view.Matrix[1, 1] = 0;
                m_view.Matrix[2, 1] = -1;
                m_view.Matrix[2, 2] = 0;
                ProjectedMatrix = m_view;
            }
            else if (m_viewType == ViewTypes.Left)
            {
                Matrix3d m_view = Matrix3d.IdentityMatrix();
                m_view.Matrix[0, 0] = 0;
                m_view.Matrix[2, 0] = -1;
                m_view.Matrix[2, 2] = 0;
                ProjectedMatrix = m_view;
            } 
            else
            ProjectedMatrix = Matrix3d.MatrixMultiply3D(_res, _m5);
        }
       
      
        
    }

    public enum ProjectionTypes
    {
        Orthographic,
        Perspective
    }
    public enum ViewTypes
    {
        Front,
        Rear,
        Top,
        Bottom,
        Left,
        Right,
        Iso
    }
}
