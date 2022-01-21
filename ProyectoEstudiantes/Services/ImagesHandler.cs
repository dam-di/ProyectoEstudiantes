using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProyectoEstudiantes.Services
{
    class ImagesHandler
    {
        public static BitmapImage GetBitmapFromFile()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Elige imagen|*.jpg; *.png";

            BitmapImage btm = new BitmapImage();

            bool? dialogOk = opf.ShowDialog();

            if (dialogOk == true)
            {
                string imageName = opf.FileName;
                btm.BeginInit();
                btm.UriSource = new Uri(imageName, UriKind.Absolute);
                btm.EndInit();
                return btm;
            }

            return null;
        }

        public static byte[] EncodeImage(BitmapImage bitmapImage)
        {

            byte[] imageByte;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageByte = ms.ToArray();
            }
            return imageByte;
        }

        public static BitmapImage DecodeImage(byte[] imageData)
        {
            Console.WriteLine(imageData.GetType());
            if (imageData == null || imageData.Length == 0) return null;
            BitmapImage image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }


    }
}
