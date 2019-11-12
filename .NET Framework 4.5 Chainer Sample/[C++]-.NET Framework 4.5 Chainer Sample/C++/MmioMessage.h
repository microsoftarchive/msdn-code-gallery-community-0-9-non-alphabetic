#ifndef MMIOMESSAGE_H
#define MMIOMESSAGE_H

#define MMIO_SIZE           65536

#define MMIO_V40            0
#define MMIO_V45            1

#define MMIO_MESSAGE(version, defaultResponse, messageCode) \
    ((((DWORD)version & 0xFF) << 24) | (((DWORD)defaultResponse & 0xFF) << 16) | ((DWORD)messageCode & 0xFFFF))
#define MMIO_MESSAGE_CODE(messageId) \
    (messageId & 0xFFFF)
#define MMIO_MESSAGE_DEFAULT_RESONSE(messageId) \
    ((messageId >> 16) & 0xFF)
#define MMIO_MESSAGE_VERSION(messageId) \
    ((messageId >>24) & 0xFF)

#define MMIO_NO_MESSAGE    0


//------------------------------------------------------------------------------
// MMIO_CLOSE_APPS
//
// Sent by the chainee when it detects that applications are holding files in 
// use.  Respond to this message in order to tell the chainee to close the 
// applications to prevent a reboot.
//
// pData : MmioCloseApplications : The list of applications
// Acceptable responses:
//   IDYES   : Indicates that the chainee should attempt to shutdown the apps.
//             If all apps do not successfully close the message may be sent again.
//   IDNO    : Indicates that the chainee should not attempt to close apps.
//   IDRETRY : Indicates that the chainee should refresh the list of apps.
//             Another MMIO_CLOSE_APPS message will be sent asynchronously with
//             the new list of apps.
//------------------------------------------------------------------------------
#define MMIO_CLOSE_APPS    MMIO_MESSAGE(MMIO_V45, IDNO, 1)

namespace IronMan
{
    struct MmioApplication
    {
        WCHAR m_szName[MAX_PATH];
        DWORD m_dwPid;
    };

    struct MmioCloseApplications
    {
        DWORD m_dwApplicationsSize;
        MmioApplication m_applications[1];
    };
}
#endif // NETFXMMIOMESSAGE_H
