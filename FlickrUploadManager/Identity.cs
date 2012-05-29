using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlickrUploadManager
{
    class Identity
    {
        public string Username { get; set; }
        public string TokenFile { get; set; }

        public Identity(string tokenFile, string username)
        {
            Username = username;
            TokenFile = tokenFile;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
