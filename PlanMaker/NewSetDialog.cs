using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FlickrSharp;

namespace FlickrSharp
{
    public partial class NewSetDialog : Form
    {
        public FlickrSet NewSet;

        public NewSetDialog()
        {
            InitializeComponent();
            NewSet = new FlickrSet();
        }

        private void cmdCreateSet_Click(object sender, EventArgs e)
        {
            if (txtSetTitle.Text == "")
            {
                MessageBox.Show("Your set must have a title.");
            }
            else
            {
                NewSet.Title = txtSetTitle.Text;
                NewSet.Description = txtSetDescription.Text;
                NewSet.PrimaryPhotoId = "";
                this.Close();
            }
        }

    }
}
