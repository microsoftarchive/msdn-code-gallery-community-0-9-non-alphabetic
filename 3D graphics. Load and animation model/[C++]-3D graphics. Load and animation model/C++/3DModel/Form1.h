#pragma once
#include "CountS.h"

int InitGL(GLvoid);
GLvoid ReSizeGLScene(GLsizei , GLsizei );	
int DrawGLScene(GLvoid);
BOOL LoadVdlFile (const char *);

//#define Rectangle RectangleA

namespace My3DModel {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
   ///////////////////////////////////////////////
 


  /////////////////////////////////////////////////
	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:IntPtr hwnd;
	//public:IntPtr hDC;
	public: HDC hDC;
	public:	GLuint PixelFormat;
	public:	HGLRC	hRC;		// Permanent Rendering Context
	public: static	GLfloat	rtri;				// Angle For The Triangle ( NEW )
	public:	static GLfloat	rquad;				// Angle For The Quad ( NEW )
	public: static CountS *pCountSS;
	public: static double gdAngleX,gdAngleY,gdTransX,gdTransY,gdTransZ;
	private:  double	giX, giY, m_dx,m_dy;
	public: static int keys;
	
	public:
		Form1(void)
		{
			InitializeComponent();
			this->Show();
            gdAngleX=0;
			gdAngleY=0;
			gdTransX,gdTransY,gdTransZ=-5.;
			giX, giY=0;
            keys=0;
			//
			//TODO: Add the constructor code here
			//
			hwnd = this->Handle;
			Graphics ^GL_Graphics = Graphics::FromHwnd(hwnd);
			//hDC =GL_Graphics->GetHdc();

			
			//hDC=GetDC((HWND)hwnd.ToPointer());

			static	PIXELFORMATDESCRIPTOR pfd=				// pfd Tells Windows How We Want Things To Be
	{
		sizeof(PIXELFORMATDESCRIPTOR),				// Size Of This Pixel Format Descriptor
		1,											// Version Number
		PFD_DRAW_TO_WINDOW |						// Format Must Support Window
		PFD_SUPPORT_OPENGL |						// Format Must Support OpenGL
		PFD_DOUBLEBUFFER,							// Must Support Double Buffering
		PFD_TYPE_RGBA,								// Request An RGBA Format
		16,										    // Select Our Color Depth
		0, 0, 0, 0, 0, 0,							// Color Bits Ignored
		0,											// No Alpha Buffer
		0,											// Shift Bit Ignored
		0,											// No Accumulation Buffer
		0, 0, 0, 0,									// Accumulation Bits Ignored
		16,											// 16Bit Z-Buffer (Depth Buffer)  
		0,											// No Stencil Buffer
		0,											// No Auxiliary Buffer
		PFD_MAIN_PLANE,								// Main Drawing Layer
		0,											// Reserved
		0, 0, 0										// Layer Masks Ignored
	};



         if (!(hDC=GetDC((HWND)hwnd.ToPointer())))
			MessageBox::Show( "Can't Create A GL Device Context.","ERROR");
				
		 if (!(PixelFormat=ChoosePixelFormat(hDC,&pfd)))	// Did Windows Find A Matching Pixel Format?
			MessageBox::Show( "Can't Find A Suitable PixelFormat.","ERROR");


		 if(!SetPixelFormat(hDC,PixelFormat,&pfd))		// Are We Able To Set The Pixel Format?
	        MessageBox::Show( "Can't Set The PixelFormat.","ERROR");

		 if (!(hRC=wglCreateContext(hDC)))				// Are We Able To Get A Rendering Context?
	         MessageBox::Show("Can't Create A GL Rendering Context.","ERROR");

		 if(!wglMakeCurrent(hDC,hRC))					// Try To Activate The Rendering Context
			MessageBox::Show("Can't Activate The GL Rendering Context.","ERROR");
		 if ( LoadVdlFile ("data/Stoun.vdl")== false )
			MessageBox::Show("Couldn't load the HL model data.","ERROR");
		  

			InitGL();
			ReSizeGLScene((GLsizei)Form1::Width , (GLsizei)Form1::Height );
			
			
			
			/*DrawGLScene();
			SwapBuffers((HDC)hDC->ToPointer());*/
			

		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->SuspendLayout();
			// 
			// Form1
			// 
			this->ClientSize = System::Drawing::Size(640, 480);
			this->Name = L"Form1";
			this->Text = L"Vsoft";
			this->SizeChanged += gcnew System::EventHandler(this, &Form1::Form1_SizeChanged);
			this->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::Form1_MouseDown);
			this->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &Form1::Form1_KeyPress);
			this->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::Form1_MouseMove);
			this->ResumeLayout(false);

		}
		#pragma endregion
	
		private: System::Void Form1_SizeChanged(System::Object^  sender, System::EventArgs^  e) {

				 ReSizeGLScene((GLsizei)Form1::Width , (GLsizei)Form1::Height );
				 
			 }
	

			 public: System::Void GLDraw(){
                        DrawGLScene();
						SwapBuffers(hDC);
					  }


	

private: System::Void Form1_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
		 
		 if( e->Button==Windows::Forms::MouseButtons::Left)
				 {
                   short x =  e->X ;
				short y =  e->Y ;					
					 gdAngleX += (y - giY)/10.f; 
					gdAngleY += (x - giX)/10.f;
					giX = x ;
					giY = y;
					}

		 if( e->Button==Windows::Forms::MouseButtons::Right)
				 {
				short x =  e->X ;
				short y =  e->Y ;
				double dx = (x - giX)/20.f;
				double dy = (y - giY)/20.f;
				gdTransZ += (dx + dy)/2.f;
				giX = x; 
				giY = y; 
					}
		 
		 if( e->Button==Windows::Forms::MouseButtons::Middle)
				 {
					 short x =  e->X ;
					short y =  e->Y ;
					m_dy = float (y  - giY) /40.f ; 
					m_dx = float (x - giX) /40.f ;
					gdTransY-= m_dy;
					gdTransX+= m_dx;
					giX = x ;
					giY = y;
					}

		 }
private: System::Void Form1_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
		 
		  if( e->Button==Windows::Forms::MouseButtons::Left)
				 {
					 giX = e->X ;
					 giY = e->Y;
                  
					}

		 if( e->Button==Windows::Forms::MouseButtons::Right)
				 {
					 giX = e->X ;
					 giY = e->Y;
				
					}
		 
		 if( e->Button==Windows::Forms::MouseButtons::Middle)
				 {
					 m_dx = 0.0f;
				    m_dy = 0.0f;
					giX = e->X ;
					 giY = e->Y;

					}
		 
		 }
private: System::Void Form1_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
			 
			 if(e->KeyChar==(char)Keys::D1)
             keys=1;
			if(e->KeyChar==(char)Keys::D2)
             keys=2;
			if(e->KeyChar==(char)Keys::D3)
             keys=3;
			if(e->KeyChar==(char)Keys::D4)
             keys=4;
			if(e->KeyChar==(char)Keys::D5)
             keys=5;
			if(e->KeyChar==(char)Keys::D6)
             keys=6;
			if(e->KeyChar==(char)Keys::D7)
             keys=7;
			 

			 
		 
		 
		 }
};
}

