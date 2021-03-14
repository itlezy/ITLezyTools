using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetEnv
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("P_TODAY", DateTime.Today.ToString("yyyy-MM-dd"), EnvironmentVariableTarget.Machine);
        }
    }
}
