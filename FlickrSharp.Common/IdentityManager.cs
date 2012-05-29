using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using FlickrNet;

namespace FlickrSharp
{
    public class IdentityManager
    {
        public string AuthorizationMessage { get; set; }

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

        public bool AuthorizeFinish()
        {
            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret);

            try
            {
                Auth auth = flickr.AuthGetToken(ConfigInfo.FlickrTempFrob);
                ConfigInfo.FlickrApiToken = auth.Token;
                string tokenFile = ConfigInfo.ApplicationDataFolder + @"\" + auth.User.UserName + ".ftkn";

                if (!Directory.Exists(ConfigInfo.ApplicationDataFolder))
                {
                    Directory.CreateDirectory(ConfigInfo.ApplicationDataFolder);
                }
                if (File.Exists(tokenFile))
                {
                    File.Delete(tokenFile);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(tokenFile);
                sw.Write(ConfigInfo.FlickrApiToken);
                sw.Close();
                AuthorizationMessage = "Authorization OK for " + auth.User.UserName;

            }
            catch (FlickrApiException ex)
            {
                AuthorizationMessage = "Flickr Authorization was not completed." + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                AuthorizationMessage = "Authorization failed with the error: " + ex.Message;
                return false;
            }

            return true;
        }

        public void AuthorizeStart()
        {
            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret);

            ConfigInfo.FlickrTempFrob = flickr.AuthGetFrob();
            string flickrUrl = flickr.AuthCalcUrl(ConfigInfo.FlickrTempFrob, AuthLevel.Write);

            System.Diagnostics.Process.Start(flickrUrl);

        }

        public void Authorize()
        {
            Console.WriteLine("Starting Flickr Authorization process...");
            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret);
            string AuthorizationMessage = "";

            Console.WriteLine("Getting temporary key from Flickr...");
            ConfigInfo.FlickrTempFrob = flickr.AuthGetFrob();
            string flickrUrl = flickr.AuthCalcUrl(ConfigInfo.FlickrTempFrob, AuthLevel.Write);

            Console.WriteLine("Opening browser to process Flickr authorization...");
            System.Diagnostics.Process.Start(flickrUrl);

            Console.Write("Press enter once authorization is complete.");
            Console.ReadLine();

            try
            {
                Auth auth = flickr.AuthGetToken(ConfigInfo.FlickrTempFrob);
                ConfigInfo.FlickrApiToken = auth.Token;
                string tokenFile = ConfigInfo.ApplicationDataFolder + @"\" + auth.User.UserName + ".ftkn";

                if (!Directory.Exists(ConfigInfo.ApplicationDataFolder))
                {
                    Directory.CreateDirectory(ConfigInfo.ApplicationDataFolder);
                }
                if (File.Exists(tokenFile))
                {
                    File.Delete(tokenFile);
                }
                Console.WriteLine(auth.Token);
                Console.WriteLine(ConfigInfo.FlickrApiToken);
                Console.WriteLine(tokenFile);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(tokenFile);
                sw.Write(ConfigInfo.FlickrApiToken);
                sw.Close();
                AuthorizationMessage = "Authorization completed for " + auth.User.UserName;

            }
            catch (FlickrApiException ex)
            {
                AuthorizationMessage = "Flickr Authorization was not completed.";
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                AuthorizationMessage = "Authorization failed with the error: " + ex.Message;
            }
            finally
            {
                Console.WriteLine(AuthorizationMessage);
            }
        }
    }
}

