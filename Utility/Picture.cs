using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
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
        /// Delete a GDI object: Refere to http://www.emgu.com/wiki/index.php/WPF_in_CSharp
        /// </summary>
        /// <param name="o">The poniter to the GDI object to be deleted</param>
        /// <returns></returns>
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

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
        public static Bitmap ConvertBitmapImageToImage(BitmapImage bitmapImage)
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

        /// <summary>
        /// Method saves a bitmap image as a JPEG
        /// </summary>
        /// <param name="path">Path to which the image should be saved</param>
        /// <param name="img">The bitmap image to be saved</param>
        /// <param name="quality">The quality in which it should be stored. Default to 100%</param>
        public static void SaveJpeg(string path, Bitmap img, long quality = 100)
        {
            // Encoder parameter for image quality

            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = EncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        /// <summary>
        /// Specifies the encoding. Used to convert an image to a type.
        /// </summary>
        /// <param name="mimeType">Contains the type of the encoding</param>
        /// <returns></returns>
        private static ImageCodecInfo EncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
        
        /// <summary>
        /// Calculate the proportion of an image with a fix ratio.
        /// The Ratio can calculate with original height / original width
        /// The function for the proportion calculation is proportion (original height / original width) x new width = new height
        /// </summary>
        /// <param name="ratio">Contains the ratio for the calucation</param>
        /// <param name="height">Contains the target size of the new image</param>
        /// <returns></returns>
        public static System.Windows.Point ScaleImageByHeight(double ratio , int height)
        {
            double newWidth = ratio * height;

            return new System.Windows.Point(newWidth, height);
        }
        
        /// <summary>
        /// Convert a BitmapSource mmage to Bitmap
        /// </summary>
        /// <param name="srs">Contains the BitmapSource image</param>
        /// <returns>Return a image of type Bitmap</returns>
        public static System.Drawing.Bitmap BitmapSourceToBitmap(BitmapSource bitmapSource)
        {
            int width = bitmapSource.PixelWidth;
            int height = bitmapSource.PixelHeight;
            int stride = width * ((bitmapSource.Format.BitsPerPixel + 7) / 8);
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(height * stride);
                bitmapSource.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
                using (var btm = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr))
                {
                    // Clone the bitmap so that we can dispose it and
                    // release the unmanaged memory at ptr
                    return new System.Drawing.Bitmap(btm);
                }
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
