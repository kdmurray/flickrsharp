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

using FlickrSharp;

namespace PlanMaker
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
            IdentityManager mgr = new IdentityManager();
            if (!AuthStarted)
            {
                mgr.AuthorizeStart();
            }
            else
            {
                bool result = mgr.AuthorizeFinish();
                if (!result)
                {
                    MessageBox.Show(mgr.AuthorizationMessage);
                }
            }
        }
    }
}
