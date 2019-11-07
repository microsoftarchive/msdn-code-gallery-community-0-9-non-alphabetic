using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing; // Not normally used in Console Apps - so add the reference

namespace ccslabsConsoleGUI
{
    class ccslabsGUI
    {

        /// <summary>
        /// Returns a string that will be centered on the current console screen.
        /// </summary>
        /// <param name="txt">
        /// String: The text to center
        /// </param>
        internal void PrintMiddle(string txt, bool NewLine = true)
        {
            Console.SetCursorPosition((Console.WindowWidth - txt.Length) / 2, Console.CursorTop);
            if (NewLine)
            {
                Console.WriteLine(txt);
            }
            else
            {
                Console.Write(txt);
            }
        }

        internal void PrintLeft(string txt, bool NewLine = true)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            if (NewLine)
            {
                Console.WriteLine(txt);
            }
            else
            {
                Console.Write(txt);
            }
        }

        internal void PrintRight(string txt, bool NewLine = true)
        {
            Console.SetCursorPosition((Console.WindowWidth - txt.Length), Console.CursorTop);
            if (NewLine)
            {
                Console.WriteLine(txt);
            }
            else
            {
                Console.Write(txt);
            }
        }

        /// <summary>
        /// Reverses the text and prints at the current cursor position
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="NewLine"></param>
        internal void PrintReverse(string txt, bool NewLine = true)
        {
            char[] nText = new char[txt.Length];
            int idx = 1; // fixes zero initialised arrays

            foreach (char c in txt.ToCharArray())
            {
                nText[(txt.Length) - idx] = c; // Zero initialised arrays !!
                idx++;
            }

            if (NewLine)
            {
                Console.WriteLine(nText);
            }
            else
            {
                Console.Write(nText);
            }
        }

        internal void PrintHorizontalLeft(string txt)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            
            foreach (char c in txt.ToCharArray())
            {
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                Console.Write(c.ToString());
              
            }

            Console.SetCursorPosition(x, y);
        }

        internal void PrintHorizontalRight(string txt)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;


            foreach (char c in txt.ToCharArray())
            {
                Console.SetCursorPosition(Console.WindowWidth-1, Console.CursorTop);
                Console.Write(c.ToString());

            }

            Console.SetCursorPosition(x, y);
        }

        public void CLS()
        {
            Console.Clear();

        }

        public void WaitKey(string txt = "Press Any Key to continue")
        {
            Console.WriteLine(Environment.NewLine);
            Console.Write(txt);
            Console.ReadKey();
        }
    }
}
