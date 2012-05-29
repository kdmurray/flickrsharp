namespace FlickrSharp
{
    partial class PlanMakerUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIdentity = new System.Windows.Forms.Label();
            this.cboIdentities = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdBuildPlan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSafety = new System.Windows.Forms.Label();
            this.cboSafety = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.prgUpdate = new System.Windows.Forms.ProgressBar();
            this.cmdNewSet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPrivacy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboContentType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboHidePublic = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstSets = new System.Windows.Forms.ListBox();
            this.lblPhotoTags = new System.Windows.Forms.Label();
            this.txtPhotoTags = new System.Windows.Forms.TextBox();
            this.lblPhotoDesc = new System.Windows.Forms.Label();
            this.txtPhotoDesc = new System.Windows.Forms.TextBox();
            this.lblPhotoTitle = new System.Windows.Forms.Label();
            this.txtPhotoTitle = new System.Windows.Forms.TextBox();
            this.flowImages = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdentity
            // 
            this.lblIdentity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdentity.AutoSize = true;
            this.lblIdentity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIdentity.Location = new System.Drawing.Point(658, 13);
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Size = new System.Drawing.Size(78, 13);
            this.lblIdentity.TabIndex = 13;
            this.lblIdentity.Text = "Current Identity";
            // 
            // cboIdentities
            // 
            this.cboIdentities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIdentities.FormattingEnabled = true;
            this.cboIdentities.Location = new System.Drawing.Point(658, 29);
            this.cboIdentities.Name = "cboIdentities";
            this.cboIdentities.Size = new System.Drawing.Size(307, 21);
            this.cboIdentities.TabIndex = 0;
            this.cboIdentities.SelectedIndexChanged += new System.EventHandler(this.cboIdentities_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cmdBuildPlan);
            this.panel2.Location = new System.Drawing.Point(636, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 86);
            this.panel2.TabIndex = 11;
            // 
            // cmdBuildPlan
            // 
            this.cmdBuildPlan.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBuildPlan.Location = new System.Drawing.Point(65, 3);
            this.cmdBuildPlan.Name = "cmdBuildPlan";
            this.cmdBuildPlan.Size = new System.Drawing.Size(198, 77);
            this.cmdBuildPlan.TabIndex = 1;
            this.cmdBuildPlan.Text = "&Build Plan";
            this.cmdBuildPlan.UseVisualStyleBackColor = true;
            this.cmdBuildPlan.Click += new System.EventHandler(this.cmdBuildPlan_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblSafety);
            this.panel1.Controls.Add(this.cboSafety);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.prgUpdate);
            this.panel1.Controls.Add(this.cmdNewSet);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboPrivacy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboContentType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboHidePublic);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lstSets);
            this.panel1.Controls.Add(this.lblPhotoTags);
            this.panel1.Controls.Add(this.txtPhotoTags);
            this.panel1.Controls.Add(this.lblPhotoDesc);
            this.panel1.Controls.Add(this.txtPhotoDesc);
            this.panel1.Controls.Add(this.lblPhotoTitle);
            this.panel1.Controls.Add(this.txtPhotoTitle);
            this.panel1.Location = new System.Drawing.Point(636, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 487);
            this.panel1.TabIndex = 10;
            // 
            // lblSafety
            // 
            this.lblSafety.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSafety.AutoSize = true;
            this.lblSafety.Location = new System.Drawing.Point(9, 247);
            this.lblSafety.Name = "lblSafety";
            this.lblSafety.Size = new System.Drawing.Size(37, 13);
            this.lblSafety.TabIndex = 18;
            this.lblSafety.Text = "Safety";
            // 
            // cboSafety
            // 
            this.cboSafety.FormattingEnabled = true;
            this.cboSafety.Location = new System.Drawing.Point(10, 263);
            this.cboSafety.Name = "cboSafety";
            this.cboSafety.Size = new System.Drawing.Size(151, 21);
            this.cboSafety.TabIndex = 7;
            this.cboSafety.Text = "None";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 450);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Ready.";
            // 
            // prgUpdate
            // 
            this.prgUpdate.Location = new System.Drawing.Point(7, 469);
            this.prgUpdate.Name = "prgUpdate";
            this.prgUpdate.Size = new System.Drawing.Size(316, 15);
            this.prgUpdate.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgUpdate.TabIndex = 15;
            // 
            // cmdNewSet
            // 
            this.cmdNewSet.Location = new System.Drawing.Point(7, 419);
            this.cmdNewSet.Name = "cmdNewSet";
            this.cmdNewSet.Size = new System.Drawing.Size(75, 23);
            this.cmdNewSet.TabIndex = 10;
            this.cmdNewSet.Text = "Add New &Set";
            this.cmdNewSet.UseVisualStyleBackColor = true;
            this.cmdNewSet.Click += new System.EventHandler(this.cmdNewSet_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Privacy";
            // 
            // cboPrivacy
            // 
            this.cboPrivacy.FormattingEnabled = true;
            this.cboPrivacy.Location = new System.Drawing.Point(167, 263);
            this.cboPrivacy.Name = "cboPrivacy";
            this.cboPrivacy.Size = new System.Drawing.Size(156, 21);
            this.cboPrivacy.TabIndex = 8;
            this.cboPrivacy.Text = "None";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Content type";
            // 
            // cboContentType
            // 
            this.cboContentType.FormattingEnabled = true;
            this.cboContentType.ItemHeight = 13;
            this.cboContentType.Location = new System.Drawing.Point(167, 218);
            this.cboContentType.Name = "cboContentType";
            this.cboContentType.Size = new System.Drawing.Size(156, 21);
            this.cboContentType.TabIndex = 6;
            this.cboContentType.Text = "None";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hide from public areas?";
            // 
            // cboHidePublic
            // 
            this.cboHidePublic.FormattingEnabled = true;
            this.cboHidePublic.ItemHeight = 13;
            this.cboHidePublic.Location = new System.Drawing.Point(9, 218);
            this.cboHidePublic.Name = "cboHidePublic";
            this.cboHidePublic.Size = new System.Drawing.Size(152, 21);
            this.cboHidePublic.TabIndex = 5;
            this.cboHidePublic.Text = "None";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sets";
            // 
            // lstSets
            // 
            this.lstSets.FormattingEnabled = true;
            this.lstSets.Location = new System.Drawing.Point(7, 305);
            this.lstSets.Name = "lstSets";
            this.lstSets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSets.Size = new System.Drawing.Size(316, 108);
            this.lstSets.TabIndex = 9;
            // 
            // lblPhotoTags
            // 
            this.lblPhotoTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhotoTags.AutoSize = true;
            this.lblPhotoTags.Location = new System.Drawing.Point(7, 131);
            this.lblPhotoTags.Name = "lblPhotoTags";
            this.lblPhotoTags.Size = new System.Drawing.Size(31, 13);
            this.lblPhotoTags.TabIndex = 5;
            this.lblPhotoTags.Text = "Tags";
            // 
            // txtPhotoTags
            // 
            this.txtPhotoTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhotoTags.Location = new System.Drawing.Point(7, 148);
            this.txtPhotoTags.Multiline = true;
            this.txtPhotoTags.Name = "txtPhotoTags";
            this.txtPhotoTags.Size = new System.Drawing.Size(316, 42);
            this.txtPhotoTags.TabIndex = 4;
            this.txtPhotoTags.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhotoTags_KeyUp);
            // 
            // lblPhotoDesc
            // 
            this.lblPhotoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhotoDesc.AutoSize = true;
            this.lblPhotoDesc.Location = new System.Drawing.Point(7, 48);
            this.lblPhotoDesc.Name = "lblPhotoDesc";
            this.lblPhotoDesc.Size = new System.Drawing.Size(60, 13);
            this.lblPhotoDesc.TabIndex = 3;
            this.lblPhotoDesc.Text = "Description";
            // 
            // txtPhotoDesc
            // 
            this.txtPhotoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhotoDesc.Location = new System.Drawing.Point(7, 64);
            this.txtPhotoDesc.Multiline = true;
            this.txtPhotoDesc.Name = "txtPhotoDesc";
            this.txtPhotoDesc.Size = new System.Drawing.Size(316, 62);
            this.txtPhotoDesc.TabIndex = 3;
            this.txtPhotoDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhotoDesc_KeyUp);
            // 
            // lblPhotoTitle
            // 
            this.lblPhotoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhotoTitle.AutoSize = true;
            this.lblPhotoTitle.Location = new System.Drawing.Point(7, 6);
            this.lblPhotoTitle.Name = "lblPhotoTitle";
            this.lblPhotoTitle.Size = new System.Drawing.Size(27, 13);
            this.lblPhotoTitle.TabIndex = 1;
            this.lblPhotoTitle.Text = "Title";
            // 
            // txtPhotoTitle
            // 
            this.txtPhotoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhotoTitle.Location = new System.Drawing.Point(7, 22);
            this.txtPhotoTitle.Name = "txtPhotoTitle";
            this.txtPhotoTitle.Size = new System.Drawing.Size(316, 20);
            this.txtPhotoTitle.TabIndex = 2;
            this.txtPhotoTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhotoTitle_KeyUp);
            // 
            // flowImages
            // 
            this.flowImages.AllowDrop = true;
            this.flowImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowImages.AutoScroll = true;
            this.flowImages.BackColor = System.Drawing.SystemColors.Control;
            this.flowImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowImages.Location = new System.Drawing.Point(6, 13);
            this.flowImages.Name = "flowImages";
            this.flowImages.Size = new System.Drawing.Size(624, 620);
            this.flowImages.TabIndex = 14;
            this.flowImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowImages_DragDrop);
            this.flowImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowImages_DragEnter);
            // 
            // PlanMakerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 645);
            this.Controls.Add(this.flowImages);
            this.Controls.Add(this.lblIdentity);
            this.Controls.Add(this.cboIdentities);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PlanMakerUI";
            this.Text = "FlickrSharp - PlanMaker";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdentity;
        private System.Windows.Forms.ComboBox cboIdentities;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdBuildPlan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdNewSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPrivacy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboContentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboHidePublic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstSets;
        private System.Windows.Forms.Label lblPhotoTags;
        private System.Windows.Forms.TextBox txtPhotoTags;
        private System.Windows.Forms.Label lblPhotoDesc;
        private System.Windows.Forms.TextBox txtPhotoDesc;
        private System.Windows.Forms.Label lblPhotoTitle;
        private System.Windows.Forms.TextBox txtPhotoTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prgUpdate;
        private System.Windows.Forms.FlowLayoutPanel flowImages;
        private System.Windows.Forms.Label lblSafety;
        private System.Windows.Forms.ComboBox cboSafety;
    }
}

