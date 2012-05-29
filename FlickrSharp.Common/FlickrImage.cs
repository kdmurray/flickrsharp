using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace FlickrSharp
{
    public class FlickrImage
    {
        public string ImagePath { get; set; }
        //public Bitmap BaseImage { get; set; }

        //Flickr Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }


        // Empty constructor required for serialization operation
        public FlickrImage()
        {
        }

        public FlickrImage(string imagePath)
        {
            ImagePath = imagePath;
            //BaseImage = new Bitmap(ImagePath);
            FileInfo fi = new FileInfo(ImagePath);
            Title = fi.Name;
        }

    }
}
