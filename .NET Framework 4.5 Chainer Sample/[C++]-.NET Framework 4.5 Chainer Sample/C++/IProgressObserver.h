#ifndef IPROGRESSOBSERVER_H
#define IPROGRESSOBSERVER_H

#include <oaidl.h>

namespace ChainerSample
{
    class IProgressObserver
    {
    public:
        virtual void OnProgress(unsigned char) = 0; // 0 - 255:  255 == 100%
        virtual void Finished(HRESULT) = 0;         // Called when operation is complete  
        virtual DWORD Send(DWORD dwMessage, LPVOID pData, DWORD dwDataLength) = 0; // Called when a message is sent
    };
}
#endif
