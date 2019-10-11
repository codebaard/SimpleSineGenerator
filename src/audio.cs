using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSineGenerator
{
    class audio
    {
        // other stuff happening here...


        //singleton
        private static audio singleton;
        private audio() { }

        private static audio instance
        {
            get
            {
                if (singleton == NULL)
                {
                    singleton = new audio();
                }
                return singleton;
            }
            private set;
        }
    }
}