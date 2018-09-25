using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itlezy.Common
{
    public class ExceptionHandler
    {
        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Error");
            Console.WriteLine(e.ExceptionObject.ToString());

            try
            {
                System.IO.File.WriteAllText("UnhandledExceptionTrapper.txt", e.ExceptionObject.ToString());
            }
            catch { }

            Environment.Exit(1);
        }
    }
}
