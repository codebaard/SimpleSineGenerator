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
        private static int SampleRate = 48000;
        private static int length = 2; //seconds
        private static int f = 1000; //frequency [Hz]
        //private static int bitDepth = 24; //bit only 8 Bit :-(
        private static MemoryStream MemoryStream;
        private static double[] buffer = new double[length * SampleRate];

        private static SoundPlayer AudioAPI;

        public static void PlayBuffer()
        {
            //AudioAPI.Stream.Position = 0;
            AudioAPI.Play();
        }

        public static void FillBuffer()
        {
            double t = 1/ Convert.ToDouble(SampleRate); // used to create the sine wave
            for (int i = 0; i< buffer.Length; ++i) {
                buffer[i] = Math.Sin(2 * Math.PI * f * t);
                t += 1 / Convert.ToDouble(SampleRate);
            }
            
            PrepareDevice();
        }

        private static void PrepareDevice()
        {
            //MemoryStream = new MemoryStream(buffer, false);
            MemoryStream = new MemoryStream();
            WriteWavHeader(MemoryStream, false, 1, 8, SampleRate, buffer.Length);
            //MemoryStream.Write(buffer, 0, buffer.Length);
            AudioAPI = new SoundPlayer(MemoryStream);
        }

        private static byte[] ConvertFloatToByteArray(float[] floats)
        {
            byte[] temp = new byte[buffer.Length * sizeof(double)];// a single float is 4 bytes/32 bits

            for (int i = 0; i < buffer.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(buffer[i]), 0, temp, i * sizeof(double),sizeof(double));
            }
            return temp;
        }

        // totalSampleCount needs to be the combined count of samples of all channels. So if the left and right channels contain 1000 samples each, then totalSampleCount should be 2000.
        // isFloatingPoint should only be true if the audio data is in 32-bit floating-point format.

        private static void WriteWavHeader(MemoryStream stream, bool isFloatingPoint, ushort channelCount, ushort bitDepth, int sampleRate, int totalSampleCount)
        {
            stream.Position = 0;

            // RIFF header.
            // Chunk ID.
            stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

            // Chunk size.
            stream.Write(BitConverter.GetBytes(((bitDepth / 8) * totalSampleCount) + 36), 0, 4);

            // Format.
            stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);



            // Sub-chunk 1.
            // Sub-chunk 1 ID.
            stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

            // Sub-chunk 1 size.
            stream.Write(BitConverter.GetBytes(16), 0, 4);

            // Audio format (floating point (3) or PCM (1)). Any other format indicates compression.
            stream.Write(BitConverter.GetBytes((ushort)(isFloatingPoint ? 3 : 1)), 0, 2);

            // Channels.
            stream.Write(BitConverter.GetBytes(channelCount), 0, 2);

            // Sample rate.
            stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);

            // Bytes rate.
            stream.Write(BitConverter.GetBytes(sampleRate * channelCount * (bitDepth / 8)), 0, 4);

            // Block align.
            stream.Write(BitConverter.GetBytes((ushort)channelCount * (bitDepth / 8)), 0, 2);

            // Bits per sample.
            stream.Write(BitConverter.GetBytes(bitDepth), 0, 2);



            // Sub-chunk 2.
            // Sub-chunk 2 ID.
            stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);

            // Sub-chunk 2 size.
            stream.Write(BitConverter.GetBytes((bitDepth / 8) * totalSampleCount), 0, 4);
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