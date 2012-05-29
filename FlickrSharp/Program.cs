using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FlickrNet;

namespace FlickrSharp
{
    //TODO: This entire class needs comments/docs.  I'll get to it after testing.
    class Program
    {

        static string[] planFiles;
        static Flickr flickr;
        static Dictionary<string, Photoset> allSets;


        static void Main(string[] args)
        {
            allSets = new Dictionary<string, Photoset>();

            ParseParams(args);

            foreach (string file in planFiles)
            {
                ProcessPlan(file);
            }

        }

        static void ParseParams(string[] args)
        {
            foreach (string param in args)
            {
                if (param.StartsWith("-p=") || param.StartsWith("--plan="))
                {
                    string fullpath = param.Substring(param.IndexOf("=") + 1);
                    string dir = ".";
                    string file = fullpath;
                    if (fullpath.Contains("\\"))
                    {
                        dir = fullpath.Substring(0, fullpath.LastIndexOf("\\"));
                        file = fullpath.Substring(fullpath.LastIndexOf("\\") + 1);
                    }

                    planFiles = Directory.GetFiles(dir, file);
                }
            }
        }

        static void ProcessPlan(string Filename)
        {
            float pctComplete = 0;

            FlickrPlan plan = new FlickrPlan(Filename);

            ConfigInfo.FlickrApiToken = IdentityManager.GetUserToken(plan.User.TokenFile);
            flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret, ConfigInfo.FlickrApiToken);

            bool isPublic;
            bool isFriends;
            bool isFamily;

            switch (plan.Privacy)
            {
                case PrivacyFilter.CompletelyPrivate:
                    isPublic = false;
                    isFriends = false;
                    isFamily = false;
                    break;
                case PrivacyFilter.PrivateVisibleToFamily:
                    isPublic = false;
                    isFriends = false;
                    isFamily = true;
                    break;
                case PrivacyFilter.PrivateVisibleToFriends:
                    isPublic = false;
                    isFriends = true;
                    isFamily = false;
                    break;
                case PrivacyFilter.PrivateVisibleToFriendsFamily:
                    isPublic = false;
                    isFriends = true;
                    isFamily = true;
                    break;
                case PrivacyFilter.PublicPhotos:
                    isPublic = true;
                    isFriends = true;
                    isFamily = true;
                    break;
                default:
                    isPublic = false;
                    isFriends = false;
                    isFamily = false;
                    break;
            }

            Console.WriteLine("\nBeginning Upload...");

            pctComplete = 0;

            Console.Write(String.Format("{0:F2} %".PadLeft(8), pctComplete));
            
            for(int i = 0; i < plan.Images.Count; i++)
            {
                try
                {
                    FlickrImage image = plan.Images[i];
                    string imageID = flickr.UploadPicture(new StreamReader(image.ImagePath).BaseStream,
                                                          image.ImagePath,
                                                          image.Title,
                                                          image.Description,
                                                          image.Tags,
                                                          isPublic,
                                                          isFamily,
                                                          isFriends,
                                                          plan.Type,
                                                          plan.Safety,
                                                          plan.HideFromSearch);

                    foreach (FlickrSet set in plan.Sets)
                    {
                        if (!allSets.Keys.Contains(set.Title))
                        {
                            allSets.Add(set.Title, flickr.PhotosetsCreate(set.Title, set.Description, imageID));
                        }
                        else
                        {
                            flickr.PhotosetsAddPhoto(allSets[set.Title].PhotosetId, imageID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                pctComplete = (((i + 1) / (float)plan.Images.Count) * 100);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(String.Format("{0:F2} %".PadLeft(8), pctComplete));
            }

            Console.WriteLine("Upload complete.");
        }
    }
}
