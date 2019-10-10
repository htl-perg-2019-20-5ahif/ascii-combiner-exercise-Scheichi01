using AsciiArtCombinerLibrary;
using System;
using System.Collections;
using System.IO;

namespace AsciiArtCombiner
{
    class Program
    {
        

        static void Main(string[] args)
        {
            

            if (args.Length < 2)
            {
                Console.WriteLine("You need to specify at least 2 files!");
                return;
            }

            string[] textFiles = new string[args.Length];

            readFiles(textFiles, args);

            AsciiCombiner combiner = new AsciiCombiner();
            string result = combiner.combineTexts(textFiles);
            Console.WriteLine("\n" + result);
        }

        private static void readFiles(string[] textFiles, string[] fileNames)
        {
            for(int i = 0; i < fileNames.Length; i++)
            {
                textFiles[i] = File.ReadAllText(fileNames[i]);
            }
        }
    }
}
