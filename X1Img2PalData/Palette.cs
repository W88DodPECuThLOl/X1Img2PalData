using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace X1Img2PalData
{
	internal class Palette
    {
        internal static void Convert(string InSourceFilename, string InOutputFilename, int InColorSize = 16)
        {
            List<byte> data = new List<byte>();

            // イメージからパレットを抜き出す
            List<Color> palette;
            using(var tmp = new Bitmap(InSourceFilename)) {
                palette = tmp.Palette.Entries.ToList();
            }

            // パレット情報(GRB444)
            //Console.WriteLine("// format GRB444");
            for(int i = 0; i < InColorSize; i++) {
                //int a = (i != 0) ? 0xF : 0;
                int c = (palette[i].B >> 4)
                    | (((palette[i].R >> 4) & 0xF) << 4)
                    | (((palette[i].G >> 4) & 0xF) << 8);
                //Console.WriteLine("0x" + a.ToString("X1") + c.ToString("X3") + ",");
                data.Add((byte)( c       & 0xff)); // 下位
                data.Add((byte)((c >> 8) & 0xff)); // 上位
            }

            File.WriteAllBytes(InOutputFilename, data.ToArray());
        }
    }
}
