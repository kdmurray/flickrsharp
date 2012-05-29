using System;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FlickrNet;

namespace FlickrUploadManager
{
    public partial class UploadManager : Form
    {
        Dictionary<string, FlickrImage> photoCollection = new Dictionary<string, FlickrImage>();
        Dictionary<string, FlickrSet> photoSetCollection = new Dictionary<string,FlickrSet>();

        ArrayList photoIdCollection = new ArrayList();

        string currentPhoto = "";

        public UploadManager()
        {
            InitializeComponent();
        }

        private void cmdAddPhotos_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "JPEG files|*.jpg;*.jpeg|PNG files|*.png|All Image Files|*.jpg;*.jpeg;*.png";
            ofd.ShowDialog();

            string[] imageFiles = ofd.FileNames;

            foreach (string imageFileName in imageFiles)
            {
                photoCollection.Add(Guid.NewGuid().ToString(), new FlickrImage(imageFileName));
            }

            UpdateImagePreview();
        }

        private void UpdateImagePreview()
        {
            foreach (Control c in flowImages.Controls)
            {
                flowImages.Controls.Remove(c);
            }

            foreach (string photoKey in photoCollection.Keys)
            {
                PictureBox pb = new PictureBox();
                Image thumbNail = BuildThumbnailImage(photoKey);
                pb.Height = thumbNail.Height + 4;
                pb.Width = thumbNail.Width + 4;
                pb.Image = thumbNail;
                pb.Name = photoKey;
                pb.Click += new EventHandler(ImageSelected);
                flowImages.Controls.Add(pb);
            }
        }

        Image BuildThumbnailImage(string photoKey)
        {
            Image original = photoCollection[photoKey].BaseImage;

            float height = original.Height;
            float width = original.Width;

            if (height > width)
            {
                width = (ConfigInfo.MaxThumbnailHeight / height * width);
                height = ConfigInfo.MaxThumbnailHeight;
            }
            else
            {
                height = ConfigInfo.MaxThumbnailWidth / width * height;
                width = ConfigInfo.MaxThumbnailWidth;
            }

            Image thumbnail = original.GetThumbnailImage((int)width, (int)height, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            return thumbnail;
        }

        void ImageSelected(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            LoadImageDetails(pb.Name);
        }

        void LoadImageDetails(string PhotoKey)
        {
            FlickrImage fi = photoCollection[PhotoKey];
            currentPhoto = PhotoKey;
            txtPhotoTitle.Text = fi.Title;
            txtPhotoDesc.Text = fi.Description;
            txtPhotoTags.Text = fi.Tags;
        }

        bool ThumbnailCallback()
        {
            return true;
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            foreach (FlickrImage fi in photoCollection.Values)
            {
                photoIdCollection.Add(UploadImage(fi));
            }
            if (photoIdCollection.Count > 0)
            {
                foreach (object set in lstSets.SelectedItems)
                {
                    string setName = (string)set;
                    FlickrSet newSet = new FlickrSet();
                    newSet.Title = setName;
                    AddImageToSet(setName);
                }
            }
        }

        string UploadImage(FlickrImage fi)
        {
            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret, ConfigInfo.FlickrApiToken);
            return flickr.UploadPicture(fi.ImagePath, fi.Title, fi.Description, fi.Tags);
        }

        void AddImageToSet(string setName)
        {
            if (photoSetCollection.Keys.Contains(setName))
            {
                Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret, ConfigInfo.FlickrApiToken);

            }
        }

        private void txtPhotoTitle_Leave(object sender, EventArgs e)
        {
            photoCollection[currentPhoto].Title = txtPhotoTitle.Text;
        }

        private void txtPhotoDesc_Leave(object sender, EventArgs e)
        {
            photoCollection[currentPhoto].Description = txtPhotoDesc.Text;
        }

        private void txtPhotoTags_Leave(object sender, EventArgs e)
        {
            photoCollection[currentPhoto].Tags = txtPhotoTags.Text;
        }

        private void UploadManager_Load(object sender, EventArgs e)
        {
            cboIdentities.Items.AddRange(IdentityManager.GetIdentities(TokenManager.GetTokenFiles(ConfigInfo.ApplicationDataFolder)));
        }

        private void LoadUserData()
        {
            Identity id = (Identity)cboIdentities.SelectedItem;
            ConfigInfo.FlickrApiToken = IdentityManager.GetUserToken(id.TokenFile);

            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret, ConfigInfo.FlickrApiToken);
            PhotosetCollection sets = flickr.PhotosetsGetList();

            foreach (Photoset p in sets)
            {
                lstSets.Items.Add(p.Title);
            }
        }

        private void cboIdentities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboIdentities.Text != "")
            {
                LoadUserData();
            }
        }

        private void cmdNewSet_Click(object sender, EventArgs e)
        {
            NewSetDialog nsd = new NewSetDialog();
            nsd.ShowDialog();

            if (nsd.newSet.Title != "")
            {
                photoSetCollection.Add(nsd.newSet.Title, nsd.newSet);
                lstSets.Items.Insert(0, nsd.newSet.Title);
                lstSets.SelectedItems.Add(lstSets.Items[0]);
            }
        }

    }
}
