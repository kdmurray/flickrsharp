using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlickrSharp
{
    public class Identity
    {
        public string Username { get; set; }
        public string TokenFile { get; set; }

        // Empty constructor required for serialization operation
        public Identity()
        {
        }

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
