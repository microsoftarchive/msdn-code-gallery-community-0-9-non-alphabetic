using System;
using System.Text;

internal class Switches
{
   internal string Switch;

   public Switches(string switch1)
   {
      this.Switch = switch1;
   }

   public static int GetBufferSize(string[] args)
   {
      foreach (var arg in args) {
         if (arg.Trim().ToUpper().StartsWith("/S:")) {
            int bufferSize;
            var result = arg.Remove(0, 3);
            if (Int32.TryParse(result, out bufferSize))
               return bufferSize;
            break;
         }
      }
      return Encode64.DefaultSize;
   }

   public bool IsSwitchSet(string value)
   {
      return value.ToUpper().Equals(this.Switch.ToUpper());
   }

   public bool HasSwitch(string value)
   {
      return value.Trim().ToUpper().StartsWith(this.Switch.ToUpper());
   }
}
