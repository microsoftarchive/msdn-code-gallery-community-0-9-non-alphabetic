#pragma once
#include <windows.h>
#include "IProgressObserver.h"
#include "MmioMessage.h"

#define MMIO_SUFFICIENT_SIZE_FOR_FIELD(size, field) \
    (m_dwDataSize >= (offsetof(MmioDataStructure, field) + sizeof(MmioDataStructure().field)))
#define MMIO_SUFFICIENT_SIZE_FOR_ARRAYFIELD(size, field, fieldCount) \
    (m_dwDataSize >= (offsetof(MmioDataStructure, field) + sizeof(MmioDataStructure().field) * fieldCount))

namespace ChainerSample
{
    // MMIO Data Structure for inter process communication
    struct MmioDataStructure
    {
        bool m_downloadFinished;               // download done yet?
        bool m_installFinished;                // install done yet?
        bool m_downloadAbort;                  // set downloader to abort
        bool m_installAbort;                   // set installer to abort
        HRESULT m_hrDownloadFinished;          // resultant HRESULT for download
        HRESULT m_hrInstallFinished;           // resultant HRESULT for install
        HRESULT m_hrInternalError;
        WCHAR m_szCurrentItemStep[MAX_PATH];
        unsigned char m_downloadSoFar;         // download progress 0 - 255 (0 to 100% done) 
        unsigned char m_installSoFar;          // install progress 0 - 255 (0 to 100% done)
        WCHAR m_szEventName[MAX_PATH];         // event that chainer 'creates' and chainee 'opens'to sync communications

        BYTE m_version;                        // version of the data structure, set by chainer.
                                               // 0x0 : .Net 4.0 
                                               // 0x1 : .Net 4.5

        DWORD m_messageCode;                   // current message being sent by the chainee, 0 if no message is active
        DWORD m_messageResponse;               // chainer's response to current message, 0 if not yet handled
        DWORD m_messageDataLength;             // length of the m_messageData field in bytes
        BYTE m_messageData[1];                 // variable length buffer, content depends on m_messageCode
    };

    //  MmioChainerBase class manages the communication and synchronization data 
    //  datastructures. It also implements common Getters (for chainer) and 
    //  Setters(for chainee).
    class MmioChainerBase
    {
        HANDLE m_hSection;

        HANDLE m_hEventChaineeSend;
        HANDLE m_hEventChainerSend;
        HANDLE m_hMutex;

        MmioDataStructure* m_pData;
        DWORD m_dwDataSize;

        class LockMutex
        {
            HANDLE m_hMutex;

        public:
            LockMutex(HANDLE hMutex)
                : m_hMutex(NULL)
            {
                Lock(hMutex);
            }

            ~LockMutex()
            {
                Release();
            }

            void Lock(HANDLE hMutex)
            {
                if (NULL != hMutex)
                {
                    DWORD dwResult = WaitForSingleObject(m_hMutex, INFINITE);
                    if (WAIT_OBJECT_0 == dwResult || WAIT_ABANDONED == dwResult)
                    {
                        m_hMutex = hMutex;
                    }
                }
            }

            void Release()
            {
                if (NULL != m_hMutex)
                {
                    ReleaseMutex(m_hMutex);
                    m_hMutex = NULL;
                }
            }
        };

    protected:
        MmioChainerBase(HANDLE hSection)
            : m_hSection(hSection)
            , m_hEventChaineeSend(NULL)
            , m_hEventChainerSend(NULL)
            , m_hMutex(NULL)
            , m_pData(MapView(hSection))
            , m_dwDataSize((DWORD)GetRegionSize(m_pData))
        {
        }

        virtual ~MmioChainerBase()
        {
            if (m_pData)
            {
                ::UnmapViewOfFile(m_pData);
            }
            
            if (m_hEventChaineeSend)
            {
                ::CloseHandle(m_hEventChaineeSend);
            }

            if (m_hEventChainerSend)
            {
                ::CloseHandle(m_hEventChainerSend);
            }

            if (m_hMutex)
            {
                ::CloseHandle(m_hMutex);
            }
        }

    public:
        HANDLE GetChaineeEventHandle() const { return m_hEventChaineeSend; }
        HANDLE GetChainerEventHandle() const { return m_hEventChainerSend; }
        HANDLE GetMmioHandle()  const { return m_hSection; }
        MmioDataStructure* GetData() { return m_pData; }

        //------------------------------------------------------------------------------
        // InitializeChainer
        //
        // Called by the chainer to create events based on the passed in event name and
        // initialize the shared memory structure to defaults.
        //------------------------------------------------------------------------------
        void InitializeChainer(CString eventName)
        {
            //Don't do anything if it is invalid.
            if (NULL == m_pData)
            {
                return;
            }

            m_hEventChaineeSend = CreateEvent(eventName);
            m_hEventChainerSend = CreateEvent(eventName + L"_send");
            m_hMutex = CreateMutex(eventName + L"_mutex");

            LockMutex lock(m_hMutex);

            // Common items for download and install
            wcscpy_s(m_pData->m_szEventName, MAX_PATH, eventName);

            // Download specific data
            m_pData->m_downloadFinished = false;
            m_pData->m_downloadSoFar = 0;
            m_pData->m_hrDownloadFinished = E_PENDING;
            m_pData->m_downloadAbort = false;

            // Install specific data
            m_pData->m_installFinished = false;
            m_pData->m_installSoFar = 0;
            m_pData->m_hrInstallFinished = E_PENDING;
            m_pData->m_installAbort = false;

            m_pData->m_hrInternalError = S_OK;

            m_pData->m_version = MMIO_V45;
            m_pData->m_messageCode = 0;
            m_pData->m_messageResponse = 0;
            m_pData->m_messageDataLength = 0;
        }

        void SignalChainee()
        {
            if (m_hEventChainerSend)
            {
                ::SetEvent(m_hEventChainerSend);
            }
        }

        bool WaitForChainee()
        {
            if (m_hEventChaineeSend && WAIT_OBJECT_0 == ::WaitForSingleObject(m_hEventChaineeSend, INFINITE))
            {
                return true;
            }
            return false;
        }

        //------------------------------------------------------------------------------
        // Abort
        //
        // Called by the chainer to signal an abort of the installation.  The abort 
        // happens asynchronously.  Once aborted the chainee will signal the chainer.
        //------------------------------------------------------------------------------
        void Abort()
        {
            //Don't do anything if it is invalid.
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_downloadAbort) 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_installAbort))
            {
                return;
            }

            LockMutex lock(m_hMutex);
            m_pData->m_downloadAbort= true;
            m_pData->m_installAbort = true;

            lock.Release();

            SignalChainee();
        }

        //------------------------------------------------------------------------------
        // IsDone
        //
        // Called by the chainer to determine if setup is complete
        //------------------------------------------------------------------------------
        bool IsDone() const 
        { 
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_downloadFinished) 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_installFinished))
            {
                return true;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_downloadFinished && m_pData->m_installFinished; 
        }

        //------------------------------------------------------------------------------
        // GetDownloadProgress
        //
        // Called by the chainer to get the overall progress (0-255) of setup
        //------------------------------------------------------------------------------
        unsigned char GetProgress() const 
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_downloadSoFar) 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_installSoFar))
            {
                return 255;
            }
            
            LockMutex lock(m_hMutex);
            return (m_pData->m_downloadSoFar + m_pData->m_installSoFar)/2;
        }

        //------------------------------------------------------------------------------
        // GetDownloadProgress
        //
        // Called by the chainer to get the progress (0-255) of the download phase
        //------------------------------------------------------------------------------
        unsigned char GetDownloadProgress() const
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_downloadSoFar))
            {
                return 255;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_downloadSoFar;
        }

        //------------------------------------------------------------------------------
        // GetInstallProgress
        //
        // Called by the chainer to get the progress (0-255) of the installation phase
        //------------------------------------------------------------------------------
        unsigned char GetInstallProgress() const
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_installSoFar))
            {
                return 255;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_installSoFar;
        }

        //------------------------------------------------------------------------------
        // GetResult
        //
        // Called by the chainer to get the combined result of the setup operation
        //------------------------------------------------------------------------------
        HRESULT GetResult() const
        { 
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_hrInstallFinished) 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_hrDownloadFinished))
            {
                return S_FALSE;
            }

            LockMutex lock(m_hMutex);
            if (m_pData->m_hrInstallFinished != S_OK)
                return m_pData->m_hrInstallFinished;
            return m_pData->m_hrDownloadFinished;
        }

        //------------------------------------------------------------------------------
        // GetDownloadResult
        //
        // Called by the chainer to get the result of the download phase.
        //------------------------------------------------------------------------------
        HRESULT GetDownloadResult() const
        { 
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_hrDownloadFinished))
            {
                return S_FALSE;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_hrDownloadFinished;
        }

        //------------------------------------------------------------------------------
        // GetInstallResult
        //
        // Called by the chainer to get the result of the installation phase.
        //------------------------------------------------------------------------------
        HRESULT GetInstallResult() const
        { 
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_hrInstallFinished))
            {
                return S_FALSE;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_hrInstallFinished;
        }
        
        //------------------------------------------------------------------------------
        // GetsInternalResult
        //
        // Called by the chainer to get the internal result of the failing item.
        //------------------------------------------------------------------------------
        const HRESULT GetInternalResult() const
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_hrInternalError))
            {
                return S_FALSE;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_hrInternalError;
        }

        //------------------------------------------------------------------------------
        // GetCurrentItemStep
        //
        // Called by the chainer to get the current item step from chainee.
        //------------------------------------------------------------------------------
        const CString GetCurrentItemStep() const
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_szCurrentItemStep))
            {
                return L"";
            }

            LockMutex lock(m_hMutex);
            return CString(m_pData->m_szCurrentItemStep);
        }

        //------------------------------------------------------------------------------
        // Respond
        //
        // Called by chainer to respond to a message sent by chainee.
        // dwResponse : Response to the message
        //------------------------------------------------------------------------------
        void Respond(DWORD dwResponse)
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_messageResponse))
            {
                return;
            }

            LockMutex lock(m_hMutex);
            m_pData->m_messageCode = MMIO_NO_MESSAGE;
            m_pData->m_messageResponse = dwResponse;
            lock.Release();

            SignalChainee();
            return;
        }

        //------------------------------------------------------------------------------
        // Chainee Methods
        //
        // These methods should only be called by the chainee: eg. NetFx setup
        //------------------------------------------------------------------------------

        //------------------------------------------------------------------------------
        // InitializeChainee
        //
        // Called by the chainee to open the events created by the chainer
        //------------------------------------------------------------------------------
        void InitializeChainee()
        {
            if (NULL == m_pData
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_szEventName))
            {
                return;
            }

            CString eventName(m_pData->m_szEventName);
            m_hEventChaineeSend = OpenEvent(eventName);
            m_hEventChainerSend = OpenEventReadOnly(eventName + L"_send");
            m_hMutex = OpenMutex(eventName+ L"_mutex");
        }

        //------------------------------------------------------------------------------
        // SignalChainer
        //
        // Called by the chainee to signal the chainer that the data in the shared 
        // memory structure has changed
        //------------------------------------------------------------------------------
        void SignalChainer()
        {
            if (m_hEventChaineeSend)
            {
                ::SetEvent(m_hEventChaineeSend);
            }
        }

        //------------------------------------------------------------------------------
        // SignalChainer
        //
        // Called by the chainee to wait for a signal from the chainer.
        //------------------------------------------------------------------------------
        bool WaitForChainer()
        {
            if (m_hEventChainerSend && WAIT_OBJECT_0 == ::WaitForSingleObject(m_hEventChainerSend, INFINITE))
            {
                return true;
            }
            return false;
        }

        //------------------------------------------------------------------------------
        // GetChainerVersion
        //
        // Called by the chainee to get the version shared memory protocol used by the chainer
        //------------------------------------------------------------------------------
        const BYTE GetChainerVersion() const
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_version))
            {
                // MMIO 4 didn't have a version field
                return MMIO_V40;
            }

            LockMutex lock(m_hMutex);
            return m_pData->m_version;
        }

        //------------------------------------------------------------------------------
        // GetMessage
        //
        // Called by the chainee to get an entire message sent by the chainer.
        // Caller must delete *pBuffer.
        // pdwMessage : The message which was sent.
        // ppBuffer : Address of a pointer to store 
        // pdwBufferSize : The size of the 
        //------------------------------------------------------------------------------
        const void GetMessage(DWORD* pdwMessage, LPVOID* ppBuffer, DWORD* pdwBufferSize) const
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_messageCode)
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_messageDataLength))
            {
                return;
            }

            if (!pdwMessage || !ppBuffer || !pdwBufferSize)
            {
                return;
            }

            LockMutex lock(m_hMutex);

            *pdwMessage = m_pData->m_messageCode;
            *ppBuffer = NULL;
            *pdwBufferSize = 0;

            if (*pdwMessage != MMIO_NO_MESSAGE)
            {
                *ppBuffer = new BYTE[m_pData->m_messageDataLength];
                if (*ppBuffer && MMIO_SUFFICIENT_SIZE_FOR_ARRAYFIELD(m_dwDataSize, m_messageData, m_pData->m_messageDataLength))
                {
                    memcpy(*ppBuffer, m_pData->m_messageData, m_pData->m_messageDataLength);
                }
                *pdwBufferSize = m_pData->m_messageDataLength;
            }
        }
        
        //------------------------------------------------------------------------------
        // IsAborted
        //
        // Called by chainee to determine if the chainer has aborted the installation
        //------------------------------------------------------------------------------
        bool IsAborted() const 
        { 
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_installAbort) 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_installAbort))
            {
                return false;
            }
            
            LockMutex lock(m_hMutex);
            return m_pData->m_installAbort || m_pData->m_downloadAbort; 
        }

        //------------------------------------------------------------------------------
        // Finished
        //
        // Called by chainee to indicate that a portion of the installation has finished
        // hr : Result of the installation returned as an MSI error code, see 
        //      http://go.microsoft.com/fwlink/?LinkId=230781 
        // hrInternalResult : Internal result of the failing item.
        // strCurrentItemStep : The action being performed when the installation finished
        // bDownloader : Indicates if the installation or download phase just finished
        //------------------------------------------------------------------------------
        void Finished(HRESULT hr, HRESULT hrInternalResult, CString strCurrentItemStep, bool bDownloader)
        {
            if (NULL == m_pData)
            {
                SignalChainer();
                return;
            }

            LockMutex lock(m_hMutex);
            if (bDownloader)
            {
                m_pData->m_hrDownloadFinished = hr;
                m_pData->m_downloadFinished = true;
            }
            else
            {
                m_pData->m_hrInstallFinished = hr;
                m_pData->m_installFinished = true;
            }
            m_pData->m_hrInternalError = hrInternalResult;
            wcscpy_s(m_pData->m_szCurrentItemStep, MAX_PATH, strCurrentItemStep);
            lock.Release();

            SignalChainer();
        }

        //------------------------------------------------------------------------------
        // SoFar
        //
        // Called by chainee to indicate that installation has progressed.
        // soFar : The progress ticks out of 255.
        // bDownloader : Indicates if the progress is for install or download phase
        //------------------------------------------------------------------------------
        void SoFar(unsigned char soFar, bool bDownloader)
        {
            if (NULL == m_pData)
            {
                SignalChainer();
                return;
            }

            LockMutex lock(m_hMutex);
            if (bDownloader)
                m_pData->m_downloadSoFar = soFar;
            else
                m_pData->m_installSoFar = soFar;
            lock.Release();

            SignalChainer();
        }

        //------------------------------------------------------------------------------
        // SendMessage
        //
        // Sends a message from chainee to chainer and waits for the response.
        // If the chainer does not support the message, or the message cannot be sent,
        // a default response will be returned.
        // dwMessage : Message to send
        // pBuffer : The buffer to copy the data to
        // pdwBufferSize : Initially a pointer to the size of pBuffer.  Upon successful
        //                 call, the number of bytes copied to pBuffer.
        //------------------------------------------------------------------------------
        DWORD Send(DWORD dwMessage, LPVOID pData, DWORD dwDataLength)
        {
            if (NULL == m_pData 
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_messageCode)
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_messageResponse)
                || !MMIO_SUFFICIENT_SIZE_FOR_FIELD(m_dwDataSize, m_messageDataLength)
                || !MMIO_SUFFICIENT_SIZE_FOR_ARRAYFIELD(m_dwDataSize, m_messageData, dwDataLength))
            {
                return MMIO_MESSAGE_DEFAULT_RESONSE(dwMessage);
            }

            if (MMIO_MESSAGE_VERSION(dwMessage) > GetChainerVersion())
            {
                return MMIO_MESSAGE_DEFAULT_RESONSE(dwMessage);
            }

            LockMutex lock(m_hMutex);
            m_pData->m_messageCode = dwMessage;
            m_pData->m_messageResponse = MMIO_MESSAGE_DEFAULT_RESONSE(dwMessage);
            m_pData->m_messageDataLength = dwDataLength;
            memcpy(m_pData->m_messageData, pData, m_pData->m_messageDataLength);
            lock.Release();

            SignalChainer();

            if (!WaitForChainer())
            {
                return MMIO_MESSAGE_DEFAULT_RESONSE(dwMessage);
            }

            lock.Lock(m_hMutex);
            return m_pData->m_messageResponse;
        }

    protected:
        // Protected utility function to map the file into memory
        static MmioDataStructure* MapView(HANDLE section)
        {
            if (NULL == section)
            {
                return reinterpret_cast<MmioDataStructure*>(NULL);
            }

            return reinterpret_cast<MmioDataStructure*>(::MapViewOfFile(section,
                FILE_MAP_WRITE,
                0, 0, // offsets
                0 // map entire file
                ));
        }

        static SIZE_T GetRegionSize(LPCVOID lpAddress)
        {
            MEMORY_BASIC_INFORMATION info;
            if (::VirtualQuery(lpAddress, &info, sizeof(info)))
            {
                return info.RegionSize;
            }
            return 0;
        }
        
        static HANDLE CreateEvent(LPCWSTR eventName)
        {
            return ::CreateEvent(NULL, FALSE, FALSE, eventName);
        }
        
        static HANDLE OpenEvent(LPCWSTR eventName)
        {
            return ::OpenEvent(EVENT_MODIFY_STATE | SYNCHRONIZE, FALSE, eventName);
        }

        static HANDLE OpenEventReadOnly(LPCWSTR eventName)
        {
            return ::OpenEvent(SYNCHRONIZE, FALSE, eventName);
        }

        static HANDLE CreateMutex(LPCWSTR mutexName)
        {
            return ::CreateMutex(NULL, FALSE, mutexName);
        }

        static HANDLE OpenMutex(LPCWSTR mutexName)
        {
            return ::OpenMutex(SYNCHRONIZE, FALSE, mutexName);
        }
    };

    // This is the class that consumer (chainer) should derive from
    class MmioChainer : protected MmioChainerBase
    {
    public:
        // Constructor
        MmioChainer (LPCWSTR sectionName, LPCWSTR eventName)
            : MmioChainerBase(CreateSection(sectionName))
        {
            InitializeChainer(eventName);
        }

        // Destructor
        virtual ~MmioChainer ()
        {
            HANDLE hSection = GetMmioHandle();
            if (hSection)
            {
                ::CloseHandle(hSection);
            }
        }

    public: // the public methods:  Abort and Run
        using MmioChainerBase::Abort;
        using MmioChainerBase::GetInstallResult;
        using MmioChainerBase::GetInstallProgress;
        using MmioChainerBase::GetDownloadResult;
        using MmioChainerBase::GetDownloadProgress;
        using MmioChainerBase::GetCurrentItemStep;

        HRESULT GetInternalErrorCode()
        {
            return GetInternalResult();
        }

        // Called by the chainer to start the chained setup - this blocks until the setup is complete
        void Run(HANDLE process, IProgressObserver& observer)
        {
            HANDLE handles[2] = { process, GetChaineeEventHandle() };

            while(!IsDone())
            {
                DWORD ret = ::WaitForMultipleObjects(2, handles, FALSE, 100);
                switch(ret)
                {
                case WAIT_OBJECT_0:
                    {
                        // Process has exited
                        if (IsDone() == false)
                        {
                            HRESULT hr = GetResult();
                            if (hr == E_PENDING) // untouched
                                observer.Finished(E_FAIL);
                            else
                                observer.Finished(hr);

                            return;
                        }
                        break;
                    }
                case WAIT_OBJECT_0 + 1:
                    {
                        // Chainee has notified us of change.
                        // Update progress
                        observer.OnProgress(GetProgress());

                        // Check for message
                        DWORD dwMessage = MMIO_NO_MESSAGE;
                        DWORD dwBufferSize = 0;
                        LPVOID pBuffer = NULL;

                        GetMessage(&dwMessage, &pBuffer, &dwBufferSize);

                        if (MMIO_NO_MESSAGE != dwMessage)
                        {
                            Respond(observer.Send(dwMessage, pBuffer, dwBufferSize));
                        }

                        if (pBuffer)
                        {
                            delete [] pBuffer;
                        }
                        break;
                    }
                default:
                    break;
                }
            }
            observer.Finished(GetResult());
        }

    private:
        static HANDLE CreateSection(LPCWSTR sectionName)
        {
            return ::CreateFileMapping (INVALID_HANDLE_VALUE,
                NULL, // security attributes
                PAGE_READWRITE,
                0, // high-order DWORD of maximum size
                MMIO_SIZE, // low-order DWORD of maximum size
                sectionName);
        }
    };

    // This is used by the chainee
    class MmioChainee : protected MmioChainerBase
    {
    public:
        MmioChainee(LPCWSTR sectionName)
            : MmioChainerBase(OpenSection(sectionName))
        {
            InitializeChainee();
        }
        virtual ~MmioChainee() 
        {
            HANDLE hSection = GetMmioHandle();
            if (hSection)
            {
                ::CloseHandle(hSection);
            }
        }

    private:
        static HANDLE OpenSection(LPCWSTR sectionName)
        {
            return ::OpenFileMapping(FILE_MAP_WRITE, // read/write access
                FALSE,          // do not inherit the name
                sectionName);
        }
        
    };
}
