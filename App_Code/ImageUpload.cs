using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

/// <summary>
/// Summary description for ImageUpload
/// </summary>
public class ImageUpload
{
	public ImageUpload()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static System.Drawing.Image ResizeImage(System.Drawing.Image sourceImage, int width, int height)
    {

        System.Drawing.Image oThumbNail = new Bitmap(sourceImage, width, height);

        Graphics oGraphic = Graphics.FromImage(oThumbNail);

        oGraphic.CompositingQuality = CompositingQuality.HighQuality;

        oGraphic.SmoothingMode = SmoothingMode.HighQuality;

        oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

        Rectangle oRectangle = new Rectangle(0, 0, width, height);

        oGraphic.DrawImage(sourceImage, oRectangle);

        return oThumbNail;

    }

    public static int imageUpload(HttpPostedFile  uploadFile)
    {
        int count=0;
        string filename = HttpUtility.HtmlEncode(uploadFile.FileName.ToLower());
        string extension = Path.GetExtension(filename);


        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".bmp" || extension == ".gif")
        {
            Image uploadedImg = Image.FromStream(uploadFile.InputStream);

            float fuWidth = uploadedImg.PhysicalDimension.Width;
            float fuHeight = uploadedImg.PhysicalDimension.Height;

            if (fuWidth < 300|| fuHeight < 200) //The max height and width
            {
                count++;
            }
      

        }
        else
        {
            count++;
        }

        return count;

    }
}
