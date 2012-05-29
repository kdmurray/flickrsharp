namespace PlanMaker
{
    partial class AuthorizeDialog
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
            this.lblAuthorizeTitle = new System.Windows.Forms.Label();
            this.txtAuthorizeMessage = new System.Windows.Forms.TextBox();
            this.cmdAuthorize = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAuthorizeTitle
            // 
            this.lblAuthorizeTitle.AutoSize = true;
            this.lblAuthorizeTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorizeTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAuthorizeTitle.Name = "lblAuthorizeTitle";
            this.lblAuthorizeTitle.Size = new System.Drawing.Size(298, 39);
            this.lblAuthorizeTitle.TabIndex = 0;
            this.lblAuthorizeTitle.Text = "Authorize FlickrSharp";
            // 
            // txtAuthorizeMessage
            // 
            this.txtAuthorizeMessage.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthorizeMessage.Location = new System.Drawing.Point(13, 55);
            this.txtAuthorizeMessage.Multiline = true;
            this.txtAuthorizeMessage.Name = "txtAuthorizeMessage";
            this.txtAuthorizeMessage.ReadOnly = true;
            this.txtAuthorizeMessage.Size = new System.Drawing.Size(481, 177);
            this.txtAuthorizeMessage.TabIndex = 1;
            // 
            // cmdAuthorize
            // 
            this.cmdAuthorize.Location = new System.Drawing.Point(272, 251);
            this.cmdAuthorize.Name = "cmdAuthorize";
            this.cmdAuthorize.Size = new System.Drawing.Size(141, 23);
            this.cmdAuthorize.TabIndex = 0;
            this.cmdAuthorize.Text = "Authorize FlickrSharp...";
            this.cmdAuthorize.UseVisualStyleBackColor = true;
            this.cmdAuthorize.Click += new System.EventHandler(this.cmdAuthorize_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(419, 251);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // Authorize
            // 
            this.AcceptButton = this.cmdAuthorize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(506, 286);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAuthorize);
            this.Controls.Add(this.txtAuthorizeMessage);
            this.Controls.Add(this.lblAuthorizeTitle);
            this.Name = "Authorize";
            this.Text = "Authorize";
            this.Load += new System.EventHandler(this.Authorize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthorizeTitle;
        private System.Windows.Forms.TextBox txtAuthorizeMessage;
        private System.Windows.Forms.Button cmdAuthorize;
        private System.Windows.Forms.Button cmdCancel;
    }
}