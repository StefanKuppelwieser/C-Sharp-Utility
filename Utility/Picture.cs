using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Utility
{
    /// <summary>
    /// The class contains all helper methods that have to do with images. It also includes helper methods for the EmguCV framework.
    /// </summary>
    public static class Picture
    {

        /// <summary>
        /// The method resizes an image of type Image and returns the image. Specify the height and width of the image. By default, the aspect ratio of an image is maintained.
        /// </summary>
        /// <param name="image">Contains the image</param>
        /// <param name="size">Contains the new size of the image</param>
        /// <param name="preserveAspectRatio">It is by default true. It preserves the aspect ratio.</param>
        /// <example> This sample shows how to call the resize method.
        /// <code>
        /// 
        /// Utility.Picture.ResizeImage(img, new Size(250, 300));
        ///
        ///</code>
        /// <exception cref="System.ArgumentNullException">Thrown when a exception if image and/or size are null.</exception>
        /// <returns>It returns the same image with the new size</returns>
        public static Image ResizeImage(Image image, System.Drawing.Size size, bool preserveAspectRatio = true)
        {
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newHeight = size.Height;
                newWidth = size.Width;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        /// <summary>
        /// It convert an image of Type Image to an byte array
        /// </summary>
        /// <param name="img">Contains the image</param>
        /// <example> This sample shows how to call the ImageToByte method.
        /// <code>
        /// 
        /// Utility.Picture.ImageToByte(img);
        ///
        ///</code>
        /// <returns>Return the image as byte array</returns>
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        /// <summary>
        /// Convects an image of type BitmapImage to type Bitmap
        /// </summary>
        /// <param name="bitmapImage">Contains the image of type BitmapImage</param>
        /// <code>
        /// 
        /// Utility.Picture.convertBitmapImageToImage(bitmapImage);
        ///
        ///</code>
        /// <returns>Returns the converted image of type Bitmap</returns>
        public static Bitmap convertBitmapImageToImage(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        /// <summary>
        /// Convects an image of type Bitmap to type BitmapImage
        /// </summary>
        /// <param name="bitmap">Contains the image of type Bitmap</param>
        /// <code>
        /// 
        /// Utility.Picture.cvonertBitmapImageToBitmap(bitmap);
        ///
        ///</code>
        /// <returns>Returns the converted image of type cvonertBitmapImageToBitmap</returns>
        private static BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
