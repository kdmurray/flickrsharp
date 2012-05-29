using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlickrUploadManager
{
    class ConfigInfo
    {
        public static string FlickrApiKey = "a5eccd08a12a64adb70071a7b3ea54a8";
        public static string FlickrApiSecret = "1dbd5852947ac4c1";
        public static string FlickrApiToken = "";
        public static string FlickrTempFrob = "";

        public static string ApplicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\FlickrSharp";

        public static int MaxThumbnailHeight = 128;
        public static int MaxThumbnailWidth = 128;

        public static string ActiveIdentity = "";
    }
}
