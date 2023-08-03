using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheVulnBank.Controllers
{
    public class ShowController : Controller
    {
        public ActionResult Img(string file, int? width, int? height)
        {
            if (width == null || height == null) 
            {
                return ShowImage(file);
            }
            else 
            {
                return ResizeImage(file, (int)width, (int)height);
            }
        }

        private ActionResult ShowImage(string file)
        {
            var dir = Server.MapPath("/Resources/Images/Stock");
            var path = Path.Combine(dir, file);
            return base.File(path, MimeMapping.GetMimeMapping(file));
        }

        private ActionResult ResizeImage(string file, int width, int height)
        {
            var dir = Server.MapPath("/Resources/Images/Stock");
            var path = Path.Combine(dir, file);

            Image image = Image.FromFile(path);
            Bitmap resizedImage = ResizeImage(image, width, height);

            FileContentResult result;

            using (var memStream = new System.IO.MemoryStream())
            {
                resizedImage.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                result = this.File(memStream.GetBuffer(), "image/jpeg");
            }

            return result;
        }


        // http://stackoverflow.com/a/24199315
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

    }
}
