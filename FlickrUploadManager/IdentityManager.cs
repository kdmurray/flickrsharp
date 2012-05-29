using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlickrUploadManager
{
    class IdentityManager
    {
        public static Identity[] GetIdentities(string[] TokenFiles)
        {
            Identity[] identityList = new Identity[TokenFiles.Length];
            for (int i = 0; i < TokenFiles.Length; i++)
            {
                // Extricate the username from the token path, ugly, but it's what we've got for now.
                identityList[i] = new Identity(TokenFiles[i], TokenFiles[i].Substring(TokenFiles[i].LastIndexOf("\\") + 1, TokenFiles[i].LastIndexOf(".ftkn") - TokenFiles[i].LastIndexOf("\\") - 1));
            }
            return identityList;
        }

        public static string GetUserToken(string TokenFile)
        {
            StreamReader sr = new StreamReader(TokenFile);
            string token = sr.ReadToEnd();
            sr.Close();
            return token;
        }
    }
}
