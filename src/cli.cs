using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSineGenerator
{
    public class cli
    {
        //user interface goes here

        public static bool repeat()
        {
            Console.WriteLine("Want to continue? y/n : ");
            try
            {
                ConsoleKeyInfo temp = Console.ReadKey();
                if (temp.Key == ConsoleKey.Y) return true;
                else if (temp.Key == ConsoleKey.N) return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured : " + e.Message);
                return false;
            }

            return false;
        }

        public static bool start()
        {
            Console.WriteLine("Want to start? y/n : ");
            try
            {
                ConsoleKeyInfo temp = Console.ReadKey();
                if (temp.Key == ConsoleKey.Y) {
                    Console.WriteLine("Alright...here we go!");
                    Console.WriteLine("");
                    return true;
                }
                else if (temp.Key == ConsoleKey.N) {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured : " + e.Message);
                return false;
            }

            return false;
        }

        //singleton stuff
        private static cli singleton;
        private cli() { }
        public static cli instance
        {
            get {
                if (singleton == null)
                {
                    singleton = new cli();
                }
                return singleton;
            }
            private set {}            
        }

    }
}
