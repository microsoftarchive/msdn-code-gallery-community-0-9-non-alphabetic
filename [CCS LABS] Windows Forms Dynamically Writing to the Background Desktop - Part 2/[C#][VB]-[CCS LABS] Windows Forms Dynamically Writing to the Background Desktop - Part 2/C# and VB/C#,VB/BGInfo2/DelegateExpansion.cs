using System;
using System.Windows.Forms;

namespace BGInfo2
{
    public static class DelegateExpansion
    {
        // Prevent CrossThreadException by invoking delegate through target control's thread.
        public static object CrossInvoke(this Delegate delgt, object sender, EventArgs e)
        {
            if (delgt.Target is Control && ((Control)delgt.Target).InvokeRequired)
            {
                return ((Control)delgt.Target).Invoke(delgt, new object[]
                {
                    sender,
                    e
                });
            }
            return delgt.Method.Invoke(delgt.Target, new object[]
            {
                sender,
                e
            });
        }
    }
}