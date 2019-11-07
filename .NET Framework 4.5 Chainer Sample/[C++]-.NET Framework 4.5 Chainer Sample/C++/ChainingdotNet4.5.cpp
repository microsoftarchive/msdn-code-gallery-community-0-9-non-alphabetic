#include "stdafx.h"
//------------------------------------------------------------------------------
// This file contains simple implementation showing how a chainer can launch
// the .NET 4.5 Setup.exe with /pipe command line and uses the MmioChainer class
// to listen for progress.
//------------------------------------------------------------------------------

#include "MmioChainer.h"
#include "IProgressObserver.h"

/*
The classes:

MmioChainerBase
---------------
| |  MmioChainerBase class manages the communication and synchronization data 
| |  datastructures. It also implements common Getters (for chainer) and 
| |  Setters(for chainee).
| |
| |     MmioChainer
| +----------------
|         |     Creates Mmio Section and waits (Run()) for Chainee exe to exit or Chainee to be Aborted. 
|         |     This can monitor progress and can cancel Chainee by sending Abort() message.
|         |   Server
|         +---------
|                   This code runs in the Chainer process. This object Constructs the MmioChainer object 
|                   Launches the Chainee Setup.exe and waits for it to Exit.
|     
|       MmioChainee
+-------------------
          |    Opens up the Mmio section created by MmioChainer and uses that to communicate with Chainer.
          |
          |                              
          |   MmioController 
          +---------
                    Runs in the context of the chainee process, implements  ProgressObserver
                    methods like Abort(), Finished(). The Chainee communicates with Chainer using these
                    class methods.
*/

class Server : public ChainerSample::MmioChainer, public ChainerSample::IProgressObserver
{
public:
    // Mmio chainer will create section with given name. You should make this and the event name unique.
    // Event is also created by the Mmio chainer and name is saved in the mapped data structure.
    Server():ChainerSample::MmioChainer(L"TheSectionName", L"TheEventName") //customize for your event names
    {}

    bool Launch(const CString& args)
    {
        CString cmdline = L"dotNetFx45_Full_setup /pipe <name> /chainingpackage <packageName>" + args; // Customize with name and location of setup .exe that you want to run
        STARTUPINFO si = {0};
        si.cb = sizeof(si);
        PROCESS_INFORMATION pi = {0};

        // Launch the Setup.exe which installs the .NET 4.5 Framework
        BOOL bLaunchedSetup = ::CreateProcess(NULL, 
                                 cmdline.GetBuffer(),
                                 NULL, NULL, FALSE, 0, NULL, NULL, 
                                 &si,
                                 &pi);

        // If successful 
        if (bLaunchedSetup != 0)
        {
            IProgressObserver& observer = dynamic_cast<IProgressObserver&>(*this);
            Run(pi.hProcess, observer);

            DWORD dwResult = GetResult();
            if (E_PENDING == dwResult)
            {
                ::GetExitCodeProcess(pi.hProcess, &dwResult);
            }

            printf("Result: %08X\n  ", dwResult);

            // Get internal result
            // If the failure is in a MSI/MSP payload, the internal result refers to the error messages
            // http://msdn.microsoft.com/en-us/library/aa372835(VS.85).aspx
            HRESULT hrInternalResult = GetInternalResult(); 
            printf("Internal result: %08X\n",hrInternalResult);




            ::CloseHandle(pi.hThread);
            ::CloseHandle(pi.hProcess);
        }
        else
        {
            printf("CreateProcess failed");
            ReportLastError();
        }

        return (bLaunchedSetup != 0);
    }

private: // IProgressObserver
    virtual void OnProgress(unsigned char ubProgressSoFar)
    {
        printf("Progress: %i\n  ", ubProgressSoFar);

        // Testing: BEGIN - To test Abort behavior, uncomment the folllowing code.
        //if (ubProgressSoFar > 127)
        //{
        //    printf("\rDeliberately Aborting with progress at %i  ", ubProgressSoFar);
        //    Abort();
        //}
        // Testing END
    }

    virtual void Finished(HRESULT hr)
    {
        // This HRESULT is communicated over MMIO and may be different than process
        // exit code of the Chainee Setup.exe itself.
        printf("\r\nFinished HRESULT: 0x%08X\r\n", hr);
    }
	//------------------------------------------------------------------------------
        // SendMessage
        //
        // Sends a message and wait for the response.
        // dwMessage : Message to send
        // pData : The buffer to copy the data to
        // dwDataLength : Initially a pointer to the size of pBuffer.  Upon successful
        //                 call, the number of bytes copied to pBuffer.
        //------------------------------------------------------------------------------
    virtual DWORD Send(DWORD dwMessage, LPVOID pData, DWORD dwDataLength)
    {
        DWORD dwResult = 0;
        printf("recieved message: %d\n", dwMessage);
        // Handle message
        switch (dwMessage)
        {
        case MMIO_CLOSE_APPS:
            {
                printf("    applications are holding files in use:\n");
                IronMan::MmioCloseApplications* applications = reinterpret_cast<IronMan::MmioCloseApplications*>(pData);
                for(DWORD i = 0; i < applications->m_dwApplicationsSize; i++)
                {
                    printf("      %ls (%d)\n", applications->m_applications[i].m_szName, applications->m_applications[i].m_dwPid);
                }

                printf("    should appliations be closed? (Y)es, (N)o, (R)efresh : ");
                while (dwResult == 0)
                {
                    switch (toupper(getwchar()))
                    {
                    case 'Y':
                        dwResult = IDYES;  // Close apps
                        break;
                    case 'N':
                        dwResult = IDNO;
                        break;
                    case 'R':
                        dwResult = IDRETRY;
                        break;
                    }
                }
                printf("\n");
                break;
            }
        default:
            break;
        }
        printf("  response: %d\n  ", dwResult);
        return dwResult;
    }

private:
    // Utility function to get text version of last error
    void ReportLastError(void)
    {
        DWORD dwLastError = 0;
        LPWSTR lpstrMsgBuf = NULL;
        DWORD dwMessageLength = 0;

        dwLastError = GetLastError();
        dwMessageLength = FormatMessageW( 
            FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
            NULL,
            dwLastError,
            MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), // Default language
            (LPTSTR) &lpstrMsgBuf,
            0,
            NULL );

        if ( dwMessageLength )
        {
            // Display the string
            printf("Last error: %ls",lpstrMsgBuf);
            // Free the buffer.
            LocalFree( lpstrMsgBuf );
        } 
    }

};

// Main entry point for program
int __cdecl main(int argc, _In_count_(argc) char **_argv)
{
    CString args;
    if (argc > 1)
    {
        args = CString(_argv[1]);
    }
	else
	{
		args = "/q /norestart";
	}

    return Server().Launch(args);
}
