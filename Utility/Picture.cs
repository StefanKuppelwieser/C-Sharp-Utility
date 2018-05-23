using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Utility
{
    /// <summary>
    /// The class contains utility functions for pictures
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
        /// <returns>It returns the same image with the new size</returns>
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
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
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
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
    }
}
