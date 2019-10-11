using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSineGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                if (cli.start()) audio.PlayBuffer();
                
            } while (cli.repeat());
        }
    }
}
