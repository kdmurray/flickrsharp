using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlickrUploadManager
{
    public partial class NewSetDialog : Form
    {
        public FlickrSet newSet;

        public NewSetDialog()
        {
            InitializeComponent();
            newSet = new FlickrSet();
        }

        private void cmdCreateSet_Click(object sender, EventArgs e)
        {
            if (txtSetTitle.Text == "")
            {
                MessageBox.Show("Your set must have a title.");
            }
            else
            {
                newSet.Title = txtSetTitle.Text;
                newSet.Description = txtSetDescription.Text;
                newSet.PrimaryPhotoId = "";
                this.Close();
            }
        }

    }
}
