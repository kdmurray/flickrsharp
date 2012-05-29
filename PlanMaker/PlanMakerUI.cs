using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using FlickrNet;

namespace FlickrSharp
{
    public partial class PlanMakerUI : Form
    {
        delegate void AddItemToSetsListCallback(string value);
        delegate void UpdateStatusLabelCallback(string value);
        delegate void SetProgressMaxCallback(int value);
        delegate void SetProgressValueCallback(int value);
        delegate void IncrementProgressCallback(int value);



        string currentPhoto = "";
        ImageList imgList;
        PictureBox lastSelectedImage;
        Dictionary<string, FlickrImage> photoCollection = new Dictionary<string, FlickrImage>();
        Dictionary<string, FlickrSet> photoSetCollection = new Dictionary<string, FlickrSet>();

        public PlanMakerUI()
        {
            InitializeComponent();

            InitializeUIComponentValues();
        }

        private void cboIdentities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Refactor the "new identity" string into a variable/const
            if (cboIdentities.Text != "" && cboIdentities.Text != "New Identity...")
            {
                Thread userLoad = new Thread(new ParameterizedThreadStart(LoadUserData));
                userLoad.Start(cboIdentities.SelectedItem);

                ReadyToGenerate();
            }
        }

        private void flowImages_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void flowImages_DragDrop(object sender, DragEventArgs e)
        {
            //TODO: This entire method will need to be re-worked when adding other mechanisms for adding files.

            //NOTE: Can't remember why I did this as a "stringCollection" instead of just iterating thru the array...
            StringCollection files = Util.ConvertToStringCollection((string[])e.Data.GetData(DataFormats.FileDrop));

            foreach (string imageFileName in files)
            {
                FileInfo fi = new FileInfo(imageFileName);
                if (fi.Extension.ToLower() == ".jpg")
                {
                    photoCollection.Add(Guid.NewGuid().ToString(), new FlickrImage(imageFileName));
                }
            }
            UpdateImagePreview();
            ReadyToGenerate();
        }

        //TODO: It would probably be smarter to create a custom event handler and apply it to all three controls...
        private void txtPhotoTitle_KeyUp(object sender, KeyEventArgs e)
        {
            UpdatePhotoInfo();
        }

        private void txtPhotoDesc_KeyUp(object sender, KeyEventArgs e)
        {
            UpdatePhotoInfo();
        }

        private void txtPhotoTags_KeyUp(object sender, KeyEventArgs e)
        {
            UpdatePhotoInfo();
        }

        private void cmdNewSet_Click(object sender, EventArgs e)
        {
            NewSetDialog nsd = new NewSetDialog();
            nsd.ShowDialog();

            if (nsd.NewSet.Title != "")
            {
                photoSetCollection.Add(nsd.NewSet.Title, nsd.NewSet);
                lstSets.Items.Insert(0, nsd.NewSet.Title);
                lstSets.SelectedItems.Add(lstSets.Items[0]);
            }
        }
        
        void ImageSelected(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = SystemColors.Highlight;
            if (lastSelectedImage != null)
            {
                lastSelectedImage.BackColor = SystemColors.Control;
            }
            lastSelectedImage = (PictureBox)sender;
            LoadImageDetails(pb.Name);
        }

        /// <summary>
        /// Initialize all UI components
        /// </summary>
        private void InitializeUIComponentValues()
        {
            cmdBuildPlan.Enabled = false;

            imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(128, 128);
            imgList.ColorDepth = ColorDepth.Depth24Bit;

            cboIdentities.Items.Insert(0, "New Identity...");
            cboIdentities.Items.AddRange(IdentityManager.GetIdentities(TokenManager.GetTokenFiles(ConfigInfo.ApplicationDataFolder)));

            cboContentType.Items.AddRange(Enum.GetNames(typeof(FlickrNet.ContentType)));
            cboPrivacy.Items.AddRange(Enum.GetNames(typeof(FlickrNet.PrivacyFilter)));
            cboHidePublic.Items.AddRange(Enum.GetNames(typeof(FlickrNet.HiddenFromSearch)));
            cboSafety.Items.AddRange(Enum.GetNames(typeof(FlickrNet.SafetyLevel)));
        }

        /// <summary>
        /// Load user data for the selected user.
        /// </summary>
        private void LoadUserData(object userid)
        {
            UpdateStatusLabel("Retrieving user data from Flickr...");
            SetProgressMax(3);

            Identity id = (Identity)userid;
            ConfigInfo.FlickrApiToken = IdentityManager.GetUserToken(id.TokenFile);
            Flickr flickr = new Flickr(ConfigInfo.FlickrApiKey, ConfigInfo.FlickrApiSecret, ConfigInfo.FlickrApiToken);
            IncrementProgress(1);

            UpdateStatusLabel("Downloading Sets...");
            PhotosetCollection sets = flickr.PhotosetsGetList();
            IncrementProgress(1);

            SetProgressMax((sets.Count) * 3);
            SetProgressValue((sets.Count) * 2);

            UpdateStatusLabel("Loading Set Info...");
            foreach (Photoset p in sets)
            {
                AddItemToSetsList(p.Title);
                photoSetCollection.Add(p.Title, new FlickrSet(p));
                IncrementProgress(1);
            }

            SetProgressValue(0);
            UpdateStatusLabel("Identity Loaded.");
        }


        /// <summary>
        /// Thread-safe method for adding items to the sets list.
        /// </summary>
        private void AddItemToSetsList(string value)
        {
            if (this.lstSets.InvokeRequired)
            {
                AddItemToSetsListCallback setCallback = new AddItemToSetsListCallback(AddItemToSetsList);
                this.Invoke(setCallback, new object[] { value } );
            }
            else
            {
                lstSets.Items.Add(value);
            }
        }

        /// <summary>
        /// Thread-safe method for setting the max value of the progress bar.
        /// </summary>
        private void SetProgressMax(int value)
        {
            if (this.prgUpdate.InvokeRequired)
            {
                SetProgressMaxCallback prgCallback = new SetProgressMaxCallback(SetProgressMax);
                this.Invoke(prgCallback, new object[] { value });
            }
            else
            {
                prgUpdate.Maximum = value;
            }
        }

        /// <summary>
        /// Thread-safe method for setting the current value of the progress bar.
        /// </summary>
        private void SetProgressValue(int value)
        {
            if (this.prgUpdate.InvokeRequired)
            {
                SetProgressValueCallback prgCallback = new SetProgressValueCallback(SetProgressValue);
                this.Invoke(prgCallback, new object[] { value });
            }
            else
            {
                prgUpdate.Value = value;
                prgUpdate.Refresh();
            }
        }

        /// <summary>
        /// Thread-safe method for incrementing (or decrementing) the progress bar.
        /// </summary>
        private void IncrementProgress(int value)
        {
            if (this.prgUpdate.InvokeRequired)
            {
                IncrementProgressCallback prgCallback = new IncrementProgressCallback(IncrementProgress);
                this.Invoke(prgCallback, new object[] { value });
            }
            else
            {
                prgUpdate.Value += value;
                prgUpdate.Refresh();
            }
        }

        /// <summary>
        /// Thread-safe method for updating the status label.
        /// </summary>
        private void UpdateStatusLabel(string value)
        {
            if (this.lblStatus.InvokeRequired)
            {
                UpdateStatusLabelCallback statusCallback = new UpdateStatusLabelCallback(UpdateStatusLabel);
                this.Invoke(statusCallback, new object[] { value });
            }
            else
            {
                lblStatus.Text = value;
                lblStatus.Refresh();
            }
        }

        /// <summary>
        /// Update the flowLayoutPanel with the current set of images in the photoCollection.
        /// </summary>
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
                pb.Height = thumbNail.Height;
                pb.Width = thumbNail.Width;
                pb.Image = thumbNail;
                pb.Name = photoKey;
                pb.Padding = new Padding(4);
                pb.BackColor = SystemColors.Control;
                pb.SizeMode = PictureBoxSizeMode.AutoSize;
                pb.Click += new EventHandler(ImageSelected);
                flowImages.Controls.Add(pb);
            }
        }

        /// <summary>
        /// Pulls the details of the selected image from the photoCollection and displays them in the UI
        /// </summary>
        void LoadImageDetails(string PhotoKey)
        {
            // NOTE: Would it make sense to think about refactoring the UI and using a ViewModel in the future?
            FlickrImage flickrImage = photoCollection[PhotoKey];
            currentPhoto = PhotoKey;
            txtPhotoTitle.Text = flickrImage.Title;
            txtPhotoDesc.Text = flickrImage.Description;
            txtPhotoTags.Text = flickrImage.Tags;
        }

        /// <summary>
        /// Construct a thumbnail of a specified image in the photoCollection.
        /// </summary>
        Image BuildThumbnailImage(string photoKey)
        {
            Image original = new Bitmap(photoCollection[photoKey].ImagePath);

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

        /// <summary>
        /// Delegate required by GDI in the Image.GetThumbnailImage method. The delegate is not used.
        /// </summary>
        bool ThumbnailCallback()
        {
            return true;
        }

        /// <summary>
        /// Update the textbox content into the active FlickrImage item in the collection
        /// </summary>
        private void UpdatePhotoInfo()
        {
            if (lastSelectedImage != null)
            {
                string photoKey = lastSelectedImage.Name;

                photoCollection[photoKey].Title = txtPhotoTitle.Text;
                photoCollection[photoKey].Description = txtPhotoDesc.Text;
                photoCollection[photoKey].Tags = txtPhotoTags.Text;
            }
        }

        /// <summary>
        /// Verify that all necessary criteria are met before enabling the Build button
        /// </summary>
        private void ReadyToGenerate()
        {
            cmdBuildPlan.Enabled = cboIdentities.Text != "" && 
                                   photoCollection.Count > 0;
        }

        private void cmdBuildPlan_Click(object sender, EventArgs e)
        {
            FlickrPlan plan = new FlickrPlan();

            plan.User = (Identity)cboIdentities.SelectedItem;

            foreach (FlickrImage image in photoCollection.Values)
            {
                plan.Images.Add(image);
            }

            foreach (string s in lstSets.SelectedItems)
            {
                plan.Sets.Add(photoSetCollection[s]);
            }

            plan.HideFromSearch = (HiddenFromSearch)Enum.Parse(typeof(HiddenFromSearch), cboHidePublic.Text);
            plan.Privacy = (PrivacyFilter)Enum.Parse(typeof(PrivacyFilter), cboPrivacy.Text);
            plan.Safety = (SafetyLevel)Enum.Parse(typeof(SafetyLevel), cboSafety.Text);
            plan.Type = (ContentType)Enum.Parse(typeof(ContentType), cboContentType.Text);

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "XML Plan File (*.xplan)|*.xplan|All Files (*.*)|*.*";
            dlgSave.ShowDialog();

            plan.WriteToFile(dlgSave.FileName);
        }

    }
}