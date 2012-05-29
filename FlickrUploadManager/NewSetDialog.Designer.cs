namespace FlickrUploadManager
{
    partial class NewSetDialog
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdCreateSet = new System.Windows.Forms.Button();
            this.txtSetTitle = new System.Windows.Forms.TextBox();
            this.txtSetDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(201, 143);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdCreateSet
            // 
            this.cmdCreateSet.Location = new System.Drawing.Point(120, 143);
            this.cmdCreateSet.Name = "cmdCreateSet";
            this.cmdCreateSet.Size = new System.Drawing.Size(75, 23);
            this.cmdCreateSet.TabIndex = 1;
            this.cmdCreateSet.Text = "Create";
            this.cmdCreateSet.UseVisualStyleBackColor = true;
            this.cmdCreateSet.Click += new System.EventHandler(this.cmdCreateSet_Click);
            // 
            // txtSetTitle
            // 
            this.txtSetTitle.Location = new System.Drawing.Point(13, 25);
            this.txtSetTitle.Name = "txtSetTitle";
            this.txtSetTitle.Size = new System.Drawing.Size(263, 20);
            this.txtSetTitle.TabIndex = 2;
            // 
            // txtSetDescription
            // 
            this.txtSetDescription.Location = new System.Drawing.Point(12, 70);
            this.txtSetDescription.Multiline = true;
            this.txtSetDescription.Name = "txtSetDescription";
            this.txtSetDescription.Size = new System.Drawing.Size(263, 67);
            this.txtSetDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Set Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Set Description";
            // 
            // NewSetDialog
            // 
            this.AcceptButton = this.cmdCreateSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(288, 178);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSetDescription);
            this.Controls.Add(this.txtSetTitle);
            this.Controls.Add(this.cmdCreateSet);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewSetDialog";
            this.Text = "NewSetDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdCreateSet;
        private System.Windows.Forms.TextBox txtSetTitle;
        private System.Windows.Forms.TextBox txtSetDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}