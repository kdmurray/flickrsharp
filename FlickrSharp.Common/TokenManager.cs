using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlickrSharp
{
    public class TokenManager
    {
        public static string[] GetTokenFiles(string SearchPath)
        {
            return Directory.GetFiles(SearchPath, "*.ftkn");
        }

        public static string LoadTokenFromFile(string TokenFile)
        {
            StreamReader sr = new StreamReader(TokenFile);
            string token = sr.ReadToEnd();
            sr.Close();
            return token;
        }
    }
}
