using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Security;
using System.Security.Cryptography;
using System.Text;

class Encode64
{
   public const int DefaultSize = 1024000;

   private static int BufferSize = DefaultSize;
   private static int CharsToRead = DefaultSize / 2;
   private static ResourceManager rm;

   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      rm = new ResourceManager("Example.CmdResources", Assembly.GetExecutingAssembly());
      bool toEncode = false;
      bool toDecode = false;
      
      // Display application name.
      Console.WriteLine(rm.GetString("AppName"));
            
      // Display help text if command line includes /?
      if (args.Length < 3 | Array.Exists(args, new Switches("/?").IsSwitchSet))
      {
         Console.WriteLine(rm.GetString("HelpText"));
         return;
      }

      if (Array.Exists(args, new Switches("/e").IsSwitchSet)) 
         toEncode = true;
      if (Array.Exists(args, new Switches("/d").IsSwitchSet)) 
         toDecode = true;
      if (Array.Exists(args, new Switches("/s").HasSwitch))
      {
         BufferSize = Switches.GetBufferSize(args);
         CharsToRead = BufferSize / 2;
      }

      // Make sure only an encode or a decode switch is present.
      if (toEncode & toDecode) {
         Console.WriteLine(rm.GetString("BadSwitches"));
         return;
      }
      else if (! toEncode & ! toDecode) {
         toEncode = true;
      }

      // Make sure the source file exists.
      string srcFile = args[args.Length - 2];
      string targetFile = args[args.Length - 1];
      if (! File.Exists(srcFile)) {
         Console.WriteLine(rm.GetString("FileNotFound"), srcFile);
         return;
      }

      // Perform the encoding or the decoding.
      if (toEncode)
         EncodeFile(srcFile, targetFile);
      else
         DecodeFile(srcFile, targetFile);
   }

   private static void EncodeFile(string srcFile , string targetFile)
   {
      byte[] bytes = new byte[BufferSize];
      FileStream fs = null;
      StreamWriter sw = null;
      FileStream fsOut = null;
      int bytesRead = 0;
      int totalBytesRead = 0;

      // Open srcFile in read-only mode.
      try {
         fs = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize);
         long sourceSize = new FileInfo(srcFile).Length;

         if (sourceSize <= BufferSize) {
            // Open stream writer
            sw = new StreamWriter(targetFile, false, Encoding.ASCII);
            bytesRead = fs.Read(bytes, 0, BufferSize);

            if (bytesRead > 0) {
               string base64String = Convert.ToBase64String(bytes, 0, bytesRead);
               totalBytesRead += bytesRead;
               Console.CursorLeft = 0;
               Console.Write(rm.GetString("ProgressEncodedMsg"), totalBytesRead);
               sw.Write(base64String);
            }
         }
         else {
            // Instantiate a ToBase64Transform object.
            ToBase64Transform transf = new ToBase64Transform();
            // Arrays to hold input and output bytes.
            byte[] inputBytes = new byte[transf.InputBlockSize];
            byte[] outputBytes = new byte[transf.OutputBlockSize];
            int bytesWritten;

            fsOut = new FileStream(targetFile, FileMode.Create, FileAccess.Write);

            do {
               bytesRead = fs.Read(inputBytes, 0, inputBytes.Length);
               totalBytesRead += bytesRead;
               bytesWritten = transf.TransformBlock(inputBytes, 0, bytesRead, outputBytes, 0);
               fsOut.Write(outputBytes, 0, bytesWritten);
            } while (sourceSize - totalBytesRead > transf.InputBlockSize);

            // Transform the final block of data.
            bytesRead = fs.Read(inputBytes, 0, inputBytes.Length);
            byte[] finalOutputBytes = transf.TransformFinalBlock(inputBytes, 0, bytesRead);
            fsOut.Write(finalOutputBytes, 0, finalOutputBytes.Length);

            // Clear Base64Transform object.
            transf.Clear();
         }

         Console.WriteLine();
         Console.WriteLine(rm.GetString("SuccessEncodedMsg"), srcFile, targetFile);
      }
      catch (IOException) {
         Console.WriteLine(rm.GetString("IOException"));
         return;
      }
      catch (SecurityException) {
         Console.WriteLine(rm.GetString("SecurityException"), srcFile);
         return;
      }
      catch (UnauthorizedAccessException) {
         Console.WriteLine(rm.GetString("AccessException"), srcFile);
         return;
      }
      finally {
         if (sw != null) sw.Close();
         if (fs != null) {
            fs.Dispose();
            fs.Close();
         }
         if (fsOut != null) {
            fsOut.Dispose();
            fsOut.Close();
         }
      }
   }

   private static void DecodeFile(string srcFile , string targetFile)
   {

      TextReader reader = null;
      FileStream fs = null;
      FileStream fsIn = null;
      long sourceSize = new FileInfo(srcFile).Length;

      try {
         fs = new FileStream(targetFile, FileMode.Create, FileAccess.Write);

         // Read entire file in a single operation.
         if (sourceSize <= CharsToRead) {
            reader = new StreamReader(srcFile, Encoding.ASCII);

            string encodedChars = reader.ReadToEnd();

            try {
               byte[] bytes = Convert.FromBase64String(encodedChars);
               fs.Write(bytes, 0, bytes.Length);
            }
            catch (FormatException e) {
               Console.WriteLine(e.Message);
            }

            Console.CursorLeft = 0;
         }
         else {
            // Read file as a stream into a buffer.

            // Instantiate a FromBase64Transform object.
            FromBase64Transform  transf = new FromBase64Transform();
            // Arrays to hold input and output bytes.
            byte[] inputBytes = new byte[transf.InputBlockSize];
            byte[] outputBytes = new byte[transf.OutputBlockSize];
            int bytesRead = 0;
            int bytesWritten  = 0;
            int totalBytesRead = 0;

            fsIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read);

            do {
               bytesRead = fsIn.Read(inputBytes, 0, inputBytes.Length);
               totalBytesRead += bytesRead;
               bytesWritten = transf.TransformBlock(inputBytes, 0, bytesRead, outputBytes, 0);
               fs.Write(outputBytes, 0, bytesWritten);
            } while (sourceSize - totalBytesRead > transf.InputBlockSize);

            // Transform the final block of data.
            bytesRead = fsIn.Read(inputBytes, 0, inputBytes.Length);
            byte[] finalOutputBytes = transf.TransformFinalBlock(inputBytes, 0, bytesRead);
            fs.Write(finalOutputBytes, 0, finalOutputBytes.Length);

            // Clear Base64Transform object.
            transf.Clear();
         }

         Console.WriteLine();
         Console.WriteLine(rm.GetString("SuccessDecodedMsg"), srcFile, targetFile);
      }
      catch (IOException) {
         Console.WriteLine(rm.GetString("IOException"));
         return;
      }
      finally {
         if (reader != null)
            reader.Close();
         if (fs != null) {
            fs.Close(); 
            fs.Dispose();
         }
         if (fsIn != null)
         {
            fsIn.Close();
            fs.Dispose();
         }
      }
   }
}

