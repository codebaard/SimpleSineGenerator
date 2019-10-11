using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace SimpleSineGenerator
{
    public class audio
    {
        // other stuff happening here...
        private static long SampleRate = 48000;
        private static int length = 2; //seconds
        //private static int bitDepth = 24; //bit only 8 Bit :-(
        private static MemoryStream MemoryStream;
        private static byte[] buffer = new byte[length * SampleRate];

        private static SoundPlayer AudioAPI;

        public static void PlayBuffer()
        {
            AudioAPI.Play();
        }

        public static void FillBuffer()
        {
            float t = 1/SampleRate; // used to create the sine wave
            for (int i = 0; i< buffer.Length; ++i) {
                buffer[i] = Convert.ToByte(Math.Floor(Math.Sin(2 * Math.PI * t)));
                t += 1 / SampleRate;
            }

            PrepareDevice();
        }

        private static void PrepareDevice()
        {
            MemoryStream = new MemoryStream(buffer, false);
            AudioAPI = new SoundPlayer(MemoryStream);
        }

        //singleton
        private static audio singleton;
        private audio() { }

        public static audio instance
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new audio();
                }
                return singleton;
            }
            private set { }
        }
    }
}