using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSineGenerator
{
    class cli
    {
        //user interface goes here

        public static bool repeat()
        {
            Console.WriteLine("Want to continue? y/n : ");
            try
            {
                ConsoleKey temp = Console.ReadKey();
                if (temp == ConsoleKey.Y) return true;
                else if (temp == ConsoleKey.N) return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured : " + e.Message);
                return false;
            }
        }

        //singleton stuff
        private static cli singleton;
        private cli() { }
        public static cli instance
        {
            get {
                if (singleton == NULL)
                {
                    singleton = new cli();
                }
                return singleton;
            }
            private set {}            
        }

    }
}
