
/*
	math.h
*/

#pragma once
#include <cmath>


namespace dfx {
	// constants
	const float PI = 3.1415926535897932384626433832795f;
	const float PI2 = 6.283185307179586476925286766559f;
	const float EPSILON = 0.000001f;

	// dfx::vector<>
	template< class T = float >
	class vector {
	public:
		union {
			struct { T x, y, z; };
			T v[ 3 ];
		};

		vector()
			:x( T( 0 ) ), y( T( 0 ) ), z( T( 0 ) ) {}

		vector( T nx, T ny, T nz )
			:x( nx ), y( ny ), z( nz ) {}

		vector( const T *nv )
			:x( nv[ 0 ] ), y( nv[ 1 ] ), z( nv[ 2 ] ) {}

		
		// Assignment ops
		vector &operator=( const vector &v ) {
			x = v.x;
			y = v.y;
			z = v.z;
			
			return *this;
		}

	

		// Setters
		void set( const T *v ) {
			x = v[ 0 ];
			y = v[ 1 ];
			z = v[ 2 ];
		}

	

		void lerp( const vector &a, const vector &b, T t ) {
			x = a.x + ( b.x - a.x ) * t;
			y = a.y + ( b.y - a.y ) * t;
			z = a.z + ( b.z - a.z ) * t;
		}

		void normalize() {
			T s = T(1) / ( T )sqrt( x*x + y*y + z*z );

			x *= s;
			y *= s;
			z *= s;
		}
	};

	// dfx::matrix<>
	template< class T = float >
	class matrix {
	public:
		union {
			struct {
				float m11, m12, m13, m14;
				float m21, m22, m23, m24;
				float m31, m32, m33, m34;
				float m41, m42, m43, m44;
			};
			T m[ 16 ];
		};

		// Constructors
		matrix()
			:m11( 1 ), m21( 0 ), m31( 0 ), m41( 0 ), 
			 m12( 0 ), m22( 1 ), m32( 0 ), m42( 0 ), 
			 m13( 0 ), m23( 0 ), m33( 1 ), m43( 0 ), 
			 m14( 0 ), m24( 0 ), m34( 0 ), m44( 1 ) 
		{
		int ttt=0;	 
		}

		matrix( T nm11, T nm21, T nm31,
			    T nm12, T nm22, T nm32,
				T nm13, T nm23, T nm33 )
			:m11( nm11 ), m21( nm21 ), m31( nm31 ), m41(   0  ),
			 m12( nm12 ), m22( nm22 ), m32( nm32 ), m42(   0  ),
			 m13( nm13 ), m23( nm23 ), m33( nm33 ), m43(   0  ),
			 m14(   0  ), m24(   0  ), m34(   0  ), m44(   1 ) 
		{
		int ttt=0;
		}



		matrix( T *newM )
			:m11( newM[  0 ] ), m21( newM[  4 ] ), m31( newM[  8 ] ), m41( newM[ 12 ] ), 
			 m12( newM[  1 ] ), m22( newM[  5 ] ), m32( newM[  9 ] ), m42( newM[ 13 ] ), 
			 m13( newM[  2 ] ), m23( newM[  6 ] ), m33( newM[ 10 ] ), m43( newM[ 14 ] ), 
			 m14( newM[  3 ] ), m24( newM[  7 ] ), m34( newM[ 11 ] ), m44( newM[ 15 ] ) 
		{
		int tttt=0;
		}



		matrix( const matrix &newMatrix )
			:m11( newMatrix.m11 ), m21( newMatrix.m21 ), m31( newMatrix.m31 ), m41( newMatrix.m41 ), 
			 m12( newMatrix.m12 ), m22( newMatrix.m22 ), m32( newMatrix.m32 ), m42( newMatrix.m42 ), 
			 m13( newMatrix.m13 ), m23( newMatrix.m23 ), m33( newMatrix.m33 ), m43( newMatrix.m43 ), 
			 m14( newMatrix.m14 ), m24( newMatrix.m24 ), m34( newMatrix.m34 ), m44( newMatrix.m44 ) {}

		// Assignment operators
		matrix &operator=( const matrix &M ) {
			m11 = M.m11; m21 = M.m21; m31 = M.m31; m41 = M.m41;
			m12 = M.m12; m22 = M.m22; m32 = M.m32; m42 = M.m42;
			m13 = M.m13; m23 = M.m23; m33 = M.m33; m43 = M.m43;
			m14 = M.m14; m24 = M.m24; m34 = M.m34; m44 = M.m44;

			return *this;
		}


		friend vector< T > operator*( const matrix< T > &A, const vector< T > &V ) {
			return vector< T >(	A.m11 * V.x + A.m21 * V.y + A.m31 * V.z + A.m41,
								A.m12 * V.x + A.m22 * V.y + A.m32 * V.z + A.m42,
								A.m13 * V.x + A.m23 * V.y + A.m33 * V.z + A.m43 );
		}



		// WARNING: Specialized for use with skeletal animation code
		friend matrix< T > operator*( const matrix< T > &a, const matrix< T > &b ) {
			float newMatrix[16];
			const float *m1 = a.m, *m2 = b.m;

			//[0 4 8  12]    [0 4 8  12]  [0*0+4*1+8*2+12*3
			//[1 5 9  13] *  [1 5 9  13]= [1*0+5*1+9*2+13*3
			//[2 6 10 14]    [2 6 10 14]  [
			//[3 7 11 15]    [3 7 11 15]  [
			
			newMatrix[0] = m1[0]*m2[0] + m1[4]*m2[1] + m1[8]*m2[2];
			newMatrix[1] = m1[1]*m2[0] + m1[5]*m2[1] + m1[9]*m2[2];
			newMatrix[2] = m1[2]*m2[0] + m1[6]*m2[1] + m1[10]*m2[2];
			newMatrix[3] = 0;

			newMatrix[4] = m1[0]*m2[4] + m1[4]*m2[5] + m1[8]*m2[6];
			newMatrix[5] = m1[1]*m2[4] + m1[5]*m2[5] + m1[9]*m2[6];
			newMatrix[6] = m1[2]*m2[4] + m1[6]*m2[5] + m1[10]*m2[6];
			newMatrix[7] = 0;

			newMatrix[8] = m1[0]*m2[8] + m1[4]*m2[9] + m1[8]*m2[10];
			newMatrix[9] = m1[1]*m2[8] + m1[5]*m2[9] + m1[9]*m2[10];
			newMatrix[10] = m1[2]*m2[8] + m1[6]*m2[9] + m1[10]*m2[10];
			newMatrix[11] = 0;

			newMatrix[12] = m1[0]*m2[12] + m1[4]*m2[13] + m1[8]*m2[14] + m1[12];
			newMatrix[13] = m1[1]*m2[12] + m1[5]*m2[13] + m1[9]*m2[14] + m1[13];
			newMatrix[14] = m1[2]*m2[12] + m1[6]*m2[13] + m1[10]*m2[14] + m1[14];
			newMatrix[15] = 1;
			
			
			return matrix( newMatrix );
			
		}

		// Setters
//		void setGLMatrix( GLenum mat ) {
//			glGetFloatv( mat, m );
//		}

		void setRotationRadians( const T *angles ) {
			
			//double cr = cos( angles[0] );//z
			//double sr = sin( angles[0] );
			//double cp = cos( angles[1] );//y
			//double sp = sin( angles[1] );
			//double cy = cos( angles[2] );//x
			//double sy = sin( angles[2] );

			//m[0] = ( float )( cp*cy );
			//m[1] = ( float )( cp*sy );
			//m[2] = ( float )( -sp );

			//double srsp = sr*sp;
			//double crsp = cr*sp;

			//m[4] = ( float )( srsp*cy-cr*sy );
			//m[5] = ( float )( srsp*sy+cr*cy );
			//m[6] = ( float )( sr*cp );

			//m[8] = ( float )( crsp*cy+sr*sy );
			//m[9] = ( float )( crsp*sy-sr*cy );
			//m[10] = ( float )( cr*cp );
			
			
			
			double cx = cos( angles[2] );
			double sx = sin( angles[2] );
			double cy = cos( angles[1] );
			double sy = sin( angles[1] );
			double cz = cos( angles[0] );
			double sz = sin( angles[0] );//  подготовка к расчету поворотов

			m[0] = ( float )( cx*cy );
			m[1] = ( float )( sx*cy );
			m[2] = ( float )( -sy );  
									  
			
			//[(cos(1)*cos(2))|(sin(0)*sin(1)*cos(2)-cos(0)*sin(2)|(cos(0)*sin(1)*cos(2)+sin(0)*cos(2)|x]
			//[(cos(1)*sin(2) |(sin(0)*sin(1)*sin(2)+cos(0)*cos(2)|(cos(0)*sin(1)*sin(2)-sin(0)*cos(2)|y]
			//[(-sin(1)       |(sin(0)*cos(1)                     |(cos(0)*cos(1)                     |z]
			//[(0)	          |0                                  |0                                  |0] 
// 

			m[4] = ( float )( cx*sy*sz-sx*cz );
			m[5] = ( float )(sx*sy*sz+cx*cz);
			m[6] = ( float )( cy*sz );

			m[8] = ( float )( cx*sy*cz+sx*sz);
			m[9] = ( float )( sx*sy*cz-cx*sz );
			m[10] = ( float )( cy*cz );
			
			

			
		}

		void setTranslation( const vector< T > &trans ) {
			m41 = trans.x;
			m42 = trans.y;
			m43 = trans.z;
		}
		
		

		// Transform functions
		vector< T > rotate( const vector< T > &vec ) const {
			return vector< T >( vec.x * m11 + vec.y * m21 + vec.z * m31,
								vec.x * m12 + vec.y * m22 + vec.z * m32,
								vec.x * m13 + vec.y * m23 + vec.z * m33 );
		}

		
		
		    //[(cos(1)*cos(2))|(sin(0)*sin(1)*cos(2)-cos(0)*sin(2)|(cos(0)*sin(1)*cos(2)+sin(0)*cos(2)|x]
			//[(cos(1)*sin(2) |(sin(0)*sin(1)*sin(2)+cos(0)*cos(2)|(cos(0)*sin(1)*sin(2)-sin(0)*cos(2)|y]
			//[(-sin(1)       |(sin(0)*cos(1)                     |(cos(0)*cos(1)                     |z]
			//[(0)	          |0                                  |0                                  |0] 
// это такое  абсолютной матрицы или матрицы для костей.
// последние елементы отвечают  смещение
		 
		
		vector< T > invRotate( const vector< T > &vec ) const {
			return vector< T >( vec.x * m11 + vec.y * m12 + vec.z * m13,
							    vec.x * m21 + vec.y * m22 + vec.z * m23,
								vec.x * m31 + vec.y * m32 + vec.z * m33 );
		}

		vector< T > invTranslate( const vector< T > &vec ) const {
			return vector< T >( vec.x - m41, vec.y - m42, vec.z - m43 );
		}

		
	};

	// dfx::quaternion<>
	template< class T = float >
	class quaternion {
	public:
		union {
			struct {
				T w, x, y, z;
			};
			T q[ 4 ];
		};

		// Ctor
		quaternion( ) {
			w = T( 1 );
			x = y = z = T( 0 );
		}

	

		quaternion( T nw, T nx, T ny, T nz ) {
			w = nw;
			x = nx;
			y = ny;
			z = nz;
		}

		quaternion( const T *rot ) {
			set( rot );
		}

		// Operators
		quaternion operator-() const {
			return quaternion( -w, -x, -y, -z );
		}

		quaternion &operator=( const quaternion &q ) {
			w = q.w;
			x = q.x;
			y = q.y;
			z = q.z;

			return *this;
		}



		// Setters
		void set( T xrot, T yrot, T zrot ) {
			T angle;
			T sx, sy, sz, cx, cy, cz;
//---------------------------------------------------------
			
			//------------------------------------------------
			angle = zrot * T( 0.5 );//квантерион
			if ((-PI/2)<angle||angle<= (PI/2))
			{
			sz = ( T )sin( angle );
			cz = ( T )cos( angle );
			}
			else
			{
			MessageBox(NULL,L"Math",L" ERROR zrot",MB_OK | MB_ICONINFORMATION);
			}
			
			//-----------------------------------------------------
			angle = yrot * T( 0.5 );
			if (0<=angle ||angle<= (PI/2))
			{
			
			sy = ( T )sin( angle );
			cy = ( T )cos( angle );
			}
			else
			{
			MessageBox(NULL,L"Math",L" ERROR yrot",MB_OK | MB_ICONINFORMATION);
			}
			
			//-------------------------------------------------------
			angle = xrot * T( 0.5 );
			if ((-PI/2)<angle||angle<= (PI/2))
			{
			
			sx = ( T )sin( angle );
			cx = ( T )cos( angle );
			}
			else
			{
			MessageBox(NULL,L"Math",L" ERROR xrot",MB_OK | MB_ICONINFORMATION);
			}
			
			T m[4][4];
			
			m[0][0] = ( float )( cx*cy );
			m[1][0] = ( float )( sx*cy );
			m[2][0] = ( float )( -sy );  
			m[3][0]= 0;						  
			
			//[(cos(1)*cos(2))|(sin(0)*sin(1)*cos(2)-cos(0)*sin(2)|(cos(0)*sin(1)*cos(2)+sin(0)*cos(2)|x]
			//[(cos(1)*sin(2) |(sin(0)*sin(1)*sin(2)+cos(0)*cos(2)|(cos(0)*sin(1)*sin(2)-sin(0)*cos(2)|y]
			//[(-sin(1)       |(sin(0)*cos(1)                     |(cos(0)*cos(1)                     |z]
			//[(0)	          |0                                  |0                                  |0] 
// 

			m[0][1] = ( float )( cx*sy*sz-sx*cz );
			m[1][1] = ( float )(sx*sy*sz+cx*cz);
			m[2][1] = ( float )( cy*sz );
			m[3][1] =0;
			
			
			m[0][2] = ( float )( cx*sy*cz+sx*sz);
			m[1][2] = ( float )( sx*sy*cz-cx*sz );
			m[2][2] = ( float )( cy*cz );
			m[3][2]=0;
			
			m[0][3] = 0;
			m[1][3] = 0;
			m[2][3] = 0;
			m[3][3] = 1;
			
			float  tr, s, q[4];
			int    i, j, k;

			int nxt[3] = {1, 2, 0};

			tr = m[0][0] + m[1][1] + m[2][2];

				if (tr > 0.0)
					{
				s = sqrt (tr + 1.0);
				w = s / 2.0;
				s = 0.5 / s;
				x = (m[1][2] - m[2][1]) * s;
				y = (m[2][0] - m[0][2]) * s;
				z = (m[0][1] - m[1][0]) * s;
				}
				else
				{
				i = 0;
				if (m[1][1] > m[0][0]) i = 1;
				if (m[2][2] > m[i][i]) i = 2;
				j = nxt[i];
				k = nxt[j];

				s = sqrt ((m[i][i] - (m[j][j] + m[k][k])) + 1.0);

				q[i] = s * 0.5;

				if (s != 0.0) s = 0.5 / s;

				q[3] = (m[j][k] - m[k][j]) * s;
				q[j] = (m[i][j] + m[j][i]) * s;
				q[k] = (m[i][k] + m[k][i]) * s;

				x = q[0];
				y = q[1];
				z = q[2];
				w = q[3];
  }

			
			
			
			
			
			w = ( T )( cx*cy*cz+sx*sy*sz );
			x = ( T )( sx*cy*cz-cx*sy*sz );
			y = ( T )( cx*sy*cz+sx*cy*sz );
			z = ( T )( cx*cy*sz-sx*sy*cz ); 
			
			
			
			
			//x = ( T )( sx*cy*cz-cx*sy*sz );// 
			//y = ( T )( cx*sy*cz+sx*cy*sz );// т.к. q = [x1,x2,x3,x4] = [scalar,(vector)] 
			//z = ( T )( cx*cy*sz-sx*sy*cz );
			//w = ( T )( cx*cy*cz+sx*sy*sz ); 

			//w = ( T )( cx*cy*cz-sx*cy*sz );+
			//x = ( T )( cx*sy*cz+sx*sy*sz );-
			//y = ( T )( sx*sy*cz-cx*sy*sz );
			//z = ( T )( sx*cy*cz+cx*cy*sz ); 

			normalize();
		
			
			
		}

		

		quaternion( const dfx::vector< T > &axis, T angle ) {// quaternion
			T scale = ( T )sin( angle / T(2) );

			w = ( T )cos( angle / T(2) );

			x = axis.x * scale;
			y = axis.y * scale;
			z = axis.z * scale;
		
		
		}
		
			friend quaternion operator*( const quaternion &a, const quaternion &b ) {
			const T Qx = a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y;
			const T Qy = a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x;
			const T Qz = a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w;
			const T Qw = a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z;
			return quaternion( Qw, Qx, Qy, Qz );
		}
		
		
		
		
		void set( const T* rot ) {
			set( rot[ 0 ], rot[ 1 ], rot[ 2 ] );
		}

		// Calc rotation matrix
		matrix< T > toMatrix() {
		//	return matrix< T >( 1 - 2 * ( y * y - z * z ), 2 * ( x * y - w * z ), 2 * ( x * z + y * w ),
		//				            2 * ( x * y + z * w ),1 -2*( x * x - z * z ), 2 * ( z * y - x * w ),
		//					        2 * ( x * z - y * w ), 2 * ( y * z + x * w ), 1-2*( x * x - y * y ) );
		
		
		return matrix< T >( w*w + x*x - y*y - z*z, 2 * ( x * y - w * z ), 2 * ( x * z + y * w ),
						            2 * ( x * y + z * w ),w*w - x*x + y*y - z*z, 2 * ( z * y - x * w ),
							        2 * ( x * z - y * w ), 2 * ( y * z + x * w ), w*w - x*x - y*y + z*z );
		
		
		}

		
		
		
		
		// Misc functions
		void normalize() {
			const T s = T( 1 ) / ( T )sqrt( x*x + y*y + z*z + w*w );
			
			w *= s;
			x *= s;
			y *= s;
			z *= s;
		}

		void slerp( quaternion a, quaternion b, T t ) {
			T omega, cosom, sinom, scale0, scale1;
			// a предыдущее время
			//b текущее время

			// Calc cosine
			cosom = ( T )(a.x*b.x + a.y*b.y + a.z*b.z + a.w*b.w);
			
			if((acos(b.w))*100>=90)
				int fffff=9;
			
			
			// Adjust signs
			if( cosom < T(0) ) {
				cosom = -cosom;
				b = -b;
			}
			
			// Calc coefficients
			if( ( 1 - cosom ) > EPSILON ) {
				// Slerp
				
				if(cosom > 0.9999f )
					cosom = 0.9999f;
				
				omega = ( T )acos( cosom );
				sinom = ( T )sin( omega );
				a.w=a.w/sinom;
				a.x=a.x/sinom;
				a.y=a.y/sinom;
				a.z=a.z/sinom;

				b.w=b.w/sinom;
				b.x=b.x/sinom;
				b.y=b.y/sinom;
				b.z=b.z/sinom;

			scale0 = ( T )sin( ( T(1) - t ) * omega );
				scale1 = ( T )sin( t * omega );
			
			
			}
			else {
				// Quaternions are very close, lerp
				scale0 = 1 - t;//
				scale1 = t;//  такое приведение к lerp правильно ли ?
			}

			w = scale0 * a.w + scale1 * b.w;
			x = scale0 * a.x + scale1 * b.x;
			y = scale0 * a.y + scale1 * b.y;
			z = scale0 * a.z + scale1 * b.z;
		}


	};


}
