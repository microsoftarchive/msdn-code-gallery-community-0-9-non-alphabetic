#include "stdafx.h"
#include "Form1.h"

using namespace My3DModel;

//My3DModel::Form1::hwnd;
CountS rt;
float time1=0.0f;
int ev=0;
bool flgCountS=false;

int InitGL(GLvoid)										// All Setup For OpenGL Goes Here
{
   
	Form1::pCountSS->SreloadTextures ();
	
	glEnable(GL_TEXTURE_2D);										// Enable Texture Mapping ( NEW )
	glShadeModel(GL_SMOOTH);										// Enable Smooth Shading
	glClearColor(1.0f, 1.0f, 1.0f, 0.5f);							// Black Background
	glClearDepth(1.0f);												// Depth Buffer Setup
	glEnable(GL_DEPTH_TEST);										// Enables Depth Testing
	glDepthFunc(GL_LEQUAL);											// The Type Of Depth Testing To Do
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);				// Really Nice Perspective Calculations
	glHint(GL_LINE_SMOOTH_HINT, GL_NICEST);					// Set Line Antialiasing
	glHint(GL_POLYGON_SMOOTH_HINT , GL_NICEST);	
	glHint(GL_POINT_SMOOTH_HINT , GL_NICEST);	
	glEnable(GL_LINE_SMOOTH);
	return TRUE;										// Initialization Went OK
}

GLvoid ReSizeGLScene(GLsizei width, GLsizei height)		// Resize And Initialize The GL Window
{
	if (height==0)													// Prevent A Divide By Zero By
	{
		height=1;													// Making Height Equal One
	}

	glViewport(0,0,width,height);									// Reset The Current Viewport

	glMatrixMode(GL_PROJECTION);									// Select The Projection Matrix
	glLoadIdentity();												// Reset The Projection Matrix

	// Calculate The Aspect Ratio Of The Window
	gluPerspective(45.0f,(GLfloat)width/(GLfloat)height,1.0f,1000.0f);	// View Depth of 1000

	glMatrixMode(GL_MODELVIEW);										// Select The Modelview Matrix
	glLoadIdentity();												// Reset The Modelview Matrix
}

int DrawGLScene(GLvoid)									// Here's Where We Do All The Drawing
{
	glEnable(GL_MULTISAMPLE_ARB);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
	glLoadIdentity();									// Reset The View
													// Reset The Modelview Matrix
	gluLookAt( 75, 75, 75, 0, 0, 0, 0, 1, 0 );						// (3) Eye Postion (3) Center Point (3) Y-Axis Up Vector
	
	glTranslated(Form1::gdTransX, Form1::gdTransY, Form1::gdTransZ);
	glRotated(Form1::gdAngleY, 0.,1.,0.);
	glRotated(Form1::gdAngleX, 1.,0.,0.);
	
	
  
	

if (Form1::keys==1 || flgCountS ==false)
rt= Form1::pCountSS[1];
	

if (Form1::keys==2)// ACTIVATE
{
rt= Form1::pCountSS[2];
flgCountS =true;
ev= 2;
}
if (Form1::keys==3)//RELOAD
{
rt= Form1::pCountSS[3];
flgCountS =true;
ev= 3;
}
if (Form1::keys==4)//RELOAD 1
{
rt= Form1::pCountSS[4];
flgCountS =true;
ev= 4;
}
if (Form1::keys==5)//SHOT
{
rt= Form1::pCountSS[5];
flgCountS =true;
ev= 5;
}
if (Form1::keys==6)//SHOT 1
{
rt= Form1::pCountSS[6];
flgCountS =true;
ev= 6;
}
if (Form1::keys==7)//SHOT 2
{
rt= Form1::pCountSS[7];
flgCountS =true;
ev= 7;
}



int ddd =Form1::pCountSS[ev].Sjoints[Form1::pCountSS[ev].SnumJoints-1].numRotationKeyFrames  ;

      	Form1::pCountSS[0].Sdraw (&rt,time1);

	glDisable (GL_MULTISAMPLE_ARB);

if( flgCountS ==true)	
time1+=0.06f;
 else
time1=0.0f;

if (Form1::pCountSS[ev].Sjoints->rotationKeyFrames[ddd-1 ].time  <time1)
{
time1=0.0f;
flgCountS =false;
Form1::keys=1;
}


  	
	
	return TRUE;
}