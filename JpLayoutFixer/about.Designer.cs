namespace JpLayoutFixer {
    partial class about {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
            this.aboutBox = new System.Windows.Forms.Label();
            this.linkRepo = new System.Windows.Forms.LinkLabel();
            this.linkTw = new System.Windows.Forms.LinkLabel();
            this.linkWeb = new System.Windows.Forms.LinkLabel();
            this.authorImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.authorImg)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutBox
            // 
            this.aboutBox.Location = new System.Drawing.Point(75, 6);
            this.aboutBox.Name = "aboutBox";
            this.aboutBox.Size = new System.Drawing.Size(205, 23);
            this.aboutBox.TabIndex = 1;
            this.aboutBox.Text = "ChaoJPLayoutFixer by Mistyhands\r\n";
            this.aboutBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkRepo
            // 
            this.linkRepo.AutoSize = true;
            this.linkRepo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkRepo.Location = new System.Drawing.Point(78, 43);
            this.linkRepo.Name = "linkRepo";
            this.linkRepo.Size = new System.Drawing.Size(93, 13);
            this.linkRepo.TabIndex = 3;
            this.linkRepo.TabStop = true;
            this.linkRepo.Text = "GitHub Repository";
            this.linkRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRepo_LinkClicked);
            // 
            // linkTw
            // 
            this.linkTw.AutoSize = true;
            this.linkTw.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkTw.Location = new System.Drawing.Point(177, 43);
            this.linkTw.Name = "linkTw";
            this.linkTw.Size = new System.Drawing.Size(39, 13);
            this.linkTw.TabIndex = 4;
            this.linkTw.TabStop = true;
            this.linkTw.Text = "Twitter";
            this.linkTw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTw_LinkClicked);
            // 
            // linkWeb
            // 
            this.linkWeb.AutoSize = true;
            this.linkWeb.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkWeb.Location = new System.Drawing.Point(227, 43);
            this.linkWeb.Name = "linkWeb";
            this.linkWeb.Size = new System.Drawing.Size(56, 13);
            this.linkWeb.TabIndex = 5;
            this.linkWeb.TabStop = true;
            this.linkWeb.Text = "moya.cafe";
            this.linkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWeb_LinkClicked);
            // 
            // authorImg
            // 
            this.authorImg.Image = global::ChaoJpLayoutFixer.Properties.Resources.author;
            this.authorImg.Location = new System.Drawing.Point(4, 6);
            this.authorImg.Name = "authorImg";
            this.authorImg.Size = new System.Drawing.Size(65, 63);
            this.authorImg.TabIndex = 0;
            this.authorImg.TabStop = false;
            // 
            // about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 74);
            this.Controls.Add(this.linkWeb);
            this.Controls.Add(this.linkTw);
            this.Controls.Add(this.linkRepo);
            this.Controls.Add(this.aboutBox);
            this.Controls.Add(this.authorImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "about";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About ChaoJpLayoutFixer";
            this.Load += new System.EventHandler(this.about_Load);
            ((System.ComponentModel.ISupportInitialize)(this.authorImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox authorImg;
        private System.Windows.Forms.Label aboutBox;
        private System.Windows.Forms.LinkLabel linkRepo;
        private System.Windows.Forms.LinkLabel linkTw;
        private System.Windows.Forms.LinkLabel linkWeb;
    }
}