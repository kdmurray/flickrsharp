using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FlickrNet;

namespace FlickrUploadManager
{
    public partial class AuthorizeDialog : Form
    {
        public bool AuthStarted = false;

        public AuthorizeDialog()
        {
            InitializeComponent();
        }

        private void Authorize_Load(object sender, EventArgs e)
        {
            txtAuthorizeMessage.Text = "FlickrSharp requires your authorization before it can interact with and upload files to your account." +
                System.Environment.NewLine + System.Environment.NewLine +
                "Clicking the button below will launch the Flickr website to securely authorize FlickrSharp to interact with your account. "+
                "Afterward, return to FlickrSharp to complete the process.";

        }

        private void cmdAuthorize_Click(object sender, EventArgs e)
        {
            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret);
            string AuthorizationMessage = "";

            if (!AuthStarted)
            {
                ConfigInfo.FlickrTempFrob = flickr.AuthGetFrob();
                string flickrUrl = flickr.AuthCalcUrl(ConfigInfo.FlickrTempFrob, AuthLevel.Write);

                System.Diagnostics.Process.Start(flickrUrl);

                cmdAuthorize.Text = "Complete Authorization";

                AuthStarted = true;
            }
            else
            {
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
                    MessageBox.Show(auth.Token);
                    MessageBox.Show(ConfigInfo.FlickrApiToken);
                    MessageBox.Show(tokenFile);
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(tokenFile);
                    sw.Write(ConfigInfo.FlickrApiToken);
                    sw.Close();
                    AuthorizationMessage = "Authorization completed for " + auth.User.UserName;

                }
                catch (FlickrApiException ex)
                {
                    AuthorizationMessage = "Flickr Authorization was not completed.";
                    Debug.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    AuthorizationMessage = "Authorization failed with the error: " + ex.Message;
                }
                finally
                {
                    MessageBox.Show(AuthorizationMessage);
                    this.Close();
                }
            }
        }
    }
}
