using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

using S = Squish.Squish;
using SquishFlags = Squish.SquishFlags;

using Xunit;

namespace LibSquishNet.Tests
{
    public class Squish
    {
        [Fact]
        public void Compress()
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(@"Files\errol.256x256.png");
            //Bitmap bitmap = (Bitmap)Image.FromFile(@"h:\errol.4096x4096.png");

            byte[] data = new byte[bitmap.Width * bitmap.Height * 4];

            BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(bmpdata.Scan0, data, 0, bmpdata.Stride * bmpdata.Height);
            bitmap.UnlockBits(bmpdata);

            for (uint i = 0; i < data.Length - 4; i += 4)
            {
                byte r = data[i + 0];
                data[i + 0] = data[i + 2];
                data[i + 2] = r;
            }

            byte[] dest = new byte[S.GetStorageRequirements(bitmap.Width, bitmap.Height, SquishFlags.kDxt5 | SquishFlags.kColourIterativeClusterFit)];
            S.CompressImage(data, bitmap.Width, bitmap.Height, dest, SquishFlags.kDxt5 | SquishFlags.kColourIterativeClusterFit, true);

            // Uncomment below and amend path to dump to dds
            //using (FileStream fs = new FileStream(@"h:\errol.dds", FileMode.Create))
            //using (BinaryWriter bw = new BinaryWriter(fs))
            //{
            //    // HeaderFlags.Caps | HeaderFlags.Height | HeaderFlags.Width | HeaderFlags.PixelFormat | HeaderFlags.MipMapCount | HeaderFlags.LinearSize
            //    int flags = 0x1 | 0x2 | 0x4 | 0x1000 | 0x20000 | 0x80000;

            //    bw.Write(new byte[] { 0x44, 0x44, 0x53, 0x20 });    // 'DDS '
            //    bw.Write(124);
            //    bw.Write(flags);
            //    bw.Write(bitmap.Height);
            //    bw.Write(bitmap.Width);
            //    bw.Write(dest.Length);
            //    bw.Write(0);
            //    bw.Write(1);

            //    for (int i = 0; i < 11; i++) { bw.Write(0); }

            //    // PixelFormat
            //    bw.Write(32);

            //    bw.Write(4);        // fourCC length
            //    bw.Write("DXT5".ToCharArray());
            //    bw.Write(0);
            //    bw.Write(0);
            //    bw.Write(0);
            //    bw.Write(0);
            //    bw.Write(0);

            //    bw.Write(0x1000);
            //    bw.Write(0);    // Caps 2
            //    bw.Write(0);    // Caps 3
            //    bw.Write(0);    // Caps 4
            //    bw.Write(0);    // Reserved

            //    bw.Write(dest);
            //}

            // Test assumes kDXT5 and kColourIterativeClusterFit
            Assert.True(dest.Length == 0x10000 && dest[182] == 255);
        }
    }
}
