//GenerateRoughnessMap.exe input.png output.png (R,G,B,Average)
//GenerateRoughnessMap.exe input.png output.png R
//GenerateRoughnessMap.exe input.png output.png Average

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRoughnessMap
{
    class Program
    {
        public static Color SetToRedPixel(Color pxl)
        {
            Color outpixel = Color.FromArgb(pxl.R, pxl.R, pxl.R);
            return outpixel;
        }

        
        public static Color SetToBluePixel(Color pxl)
        {
            Color outpixel = Color.FromArgb(pxl.B, pxl.B, pxl.B);
            return outpixel;
        }

        
        public static Color SetToGreenPixel(Color pxl)
        {
            Color outpixel = Color.FromArgb(pxl.G, pxl.G, pxl.G);
            return outpixel;
        }

        
        public static Color SetToAveragePixel(Color pxl)
        {
            var average = (pxl.R + pxl.G + pxl.B) / 3;
            Color outpixel = Color.FromArgb(average, average, average);
            return outpixel;
        }

        public static Color HandleSetPixle(Color pxl, string command)
        {
            if(command == "R")
            {
                return SetToRedPixel(pxl);
            }
            
            if(command == "G")
            {
                return SetToBluePixel(pxl);
            }
            
            if(command == "B")
            {
                return SetToRedPixel(pxl);
            }
            
            if(command == "Average")
            {
                return SetToAveragePixel(pxl);
            }

            return SetToAveragePixel(pxl);


        }
        public static void ProcessImage(string[] args,Image sourceImage, string Outputpath, ImageFormat imageFormat)
        {
            using (Bitmap bmp = new Bitmap(sourceImage))
            using (Bitmap redBmp = new Bitmap(sourceImage.Width, sourceImage.Height))
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color pxl = bmp.GetPixel(x, y);
                        Color outpixel = HandleSetPixle(pxl, args[2]);

                        redBmp.SetPixel(x, y, outpixel);
                    }
                }

                redBmp.Save(Outputpath, imageFormat);
            }
        }
        static void Main(string[] args)
        {

            try
            {
                var imagee = Image.FromFile(args[0]);
                var imageformat = ImageFormat.Png;
                try
                {
                    if (args[1].ToLower().Contains("jpg"))
                    {

                        imageformat = ImageFormat.Jpeg;

                    }
                    if (args[1].ToLower().Contains("tif"))
                    {

                        imageformat = ImageFormat.Tiff;

                    }
                    if (args[1].ToLower().Contains("gif"))
                    {

                        imageformat = ImageFormat.Gif;

                    }
                }
                catch
                {
                    Console.WriteLine("(Error:100033) Output Argument missing. Ex: GenerateRoughnessMap.exe input.png output.png R");

                }
                ProcessImage(args,imagee, args[1], imageformat);
             
            }
            catch
            {
                Console.WriteLine("(Error:100032) Arguments missing. Ex: GenerateRoughnessMap.exe input.png output.png R");
            }
        }
    }
}
