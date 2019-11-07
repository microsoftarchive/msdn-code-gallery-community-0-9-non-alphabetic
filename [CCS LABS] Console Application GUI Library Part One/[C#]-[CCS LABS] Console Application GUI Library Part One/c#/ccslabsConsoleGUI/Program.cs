using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ccslabsConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ccslabsConsoleGUI.ccslabsGUI GUI = new ccslabsGUI();

            GUI.PrintMiddle("CCS LABS GUI DEMO");

            GUI.WaitKey();

            GUI.CLS();

            GUI.PrintLeft("Writing on the Left");
            GUI.PrintRight("Writing on the Right");
            GUI.PrintMiddle("Writing in the Middle of the Line");
            GUI.PrintReverse("This text is reversed");
            GUI.PrintHorizontalLeft("Left AND Down");
            GUI.PrintHorizontalRight("Right AND Down");


            GUI.WaitKey("Press any key to exit...");
        }
    }
}
