using System;
using System.Windows.Forms;

namespace JpLayoutFixer {
    public partial class about : Form {
        public about() {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            authorImg.SizeMode = PictureBoxSizeMode.StretchImage;

            Random random = new Random();
            try {
                if (random.Next(0, 512) == 0)
                    authorImg.Image = ChaoJpLayoutFixer.Properties.Resources.author2;
            } catch (Exception ex) { }
        }

        private void about_Load(object sender, EventArgs e) {
            aboutBox.Text = "ChaoJpLayoutFixer " + Application.ProductVersion + " by Mistyhands";
        }
        

        private void VisitUrl(string url, LinkLabel label) {
            try {
                label.LinkVisited = true;
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex) {
                if (Global.Jp)
                    MessageBox.Show(this, "URLを開くのに失敗しました: " + ex.Message);
                else
                    MessageBox.Show(this, "Failed to open hyperlink: " + ex.Message);
            }
        }

        private void linkRepo_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
            VisitUrl("https://github.com/mistyhands/chaojplayoutfixer", linkRepo);
        }

        private void linkTw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            VisitUrl("https://twitter.com/violentseed", linkTw);
        }

        private void linkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            VisitUrl("https://moya.cafe", linkWeb);
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape) {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
