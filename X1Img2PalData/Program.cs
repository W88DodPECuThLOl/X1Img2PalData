using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X1Img2PalData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0) {
                printUsage();
                Environment.Exit(1);
            }

            string sourceFilename = args[0];
            string outputFilename;
            if(args.Length > 1) {
                outputFilename = args[1];
            } else {
                outputFilename = Path.ChangeExtension(sourceFilename, ".PAL");
            }

            if(sourceFilename == outputFilename) {
                Environment.Exit(2);
            }

            Palette.Convert(sourceFilename, outputFilename);
        }
        static private void printUsage()
        {
            System.Console.WriteLine("Palette conversion tool for X1turboZ.");
            System.Console.WriteLine("X1Img2PalData.exe <sourceImageFilename> [<outputFilename>]");
            System.Console.WriteLine("    <sourceImageFilename> : Image source file. The extension is png, bmp, etc.");
            System.Console.WriteLine("    <outputFilename>      : Output file.");
            System.Console.WriteLine("                            If omitted, the extension of the image source");
            System.Console.WriteLine("                            source file is changed to 'PAL'.");
        }
    }
}
