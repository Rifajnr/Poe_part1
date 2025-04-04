using System.IO;
using System;
using System.Drawing;

namespace Poe_part1
{
    public class logo
    {
        public logo()
        { 
            string path_project = AppDomain.CurrentDomain.BaseDirectory;
            string new_path_projectn = path_project.Replace("bin\\Debug", "");
            string full_path = Path.Combine(new_path_projectn, "logo.jpeg");

            
            //then start working on the logo
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(100, 110));

            for (int height = 0; height < image.Height; height++)
            {

                for (int width = 0; width < image.Width; width++)
                {

                    //now lets work on the ascii design
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                    Console.Write(ascii_design);

                }
                Console.WriteLine();

            }// end of loop outer



        }
    }
}