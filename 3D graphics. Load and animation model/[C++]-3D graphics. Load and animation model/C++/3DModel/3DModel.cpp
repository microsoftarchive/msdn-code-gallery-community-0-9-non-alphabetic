// 3DModel.cpp : main project file.

#include "stdafx.h"
#include "Form1.h"

using namespace My3DModel;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// Enabling Windows XP visual effects before any controls are created
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// Create the main window and run it
	/*Application::Run(gcnew Form1());*/
    Form1^ form = gcnew Form1;
	while (!form->IsDisposed )
			{
				form->GLDraw();
				//form->Refresh();
				Application::DoEvents();
			}


	int tt=0;
	return 0;
}
