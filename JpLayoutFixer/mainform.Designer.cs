namespace JpLayoutFixer
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.btnGo = new System.Windows.Forms.Button();
            this.currentDllLbl = new System.Windows.Forms.Label();
            this.listBoxAvailableLocales = new System.Windows.Forms.ComboBox();
            this.btnLangJa = new System.Windows.Forms.Button();
            this.infoDetails = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.wizard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGo.Location = new System.Drawing.Point(131, 141);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(72, 21);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.button1_Click);
            // 
            // currentDllLbl
            // 
            this.currentDllLbl.AutoSize = true;
            this.currentDllLbl.Location = new System.Drawing.Point(126, 9);
            this.currentDllLbl.Name = "currentDllLbl";
            this.currentDllLbl.Size = new System.Drawing.Size(77, 13);
            this.currentDllLbl.TabIndex = 1;
            this.currentDllLbl.Text = "[current layout]";
            // 
            // listBoxAvailableLocales
            // 
            this.listBoxAvailableLocales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listBoxAvailableLocales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listBoxAvailableLocales.FormattingEnabled = true;
            this.listBoxAvailableLocales.Location = new System.Drawing.Point(269, 141);
            this.listBoxAvailableLocales.Name = "listBoxAvailableLocales";
            this.listBoxAvailableLocales.Size = new System.Drawing.Size(190, 21);
            this.listBoxAvailableLocales.Sorted = true;
            this.listBoxAvailableLocales.TabIndex = 3;
            // 
            // btnLangJa
            // 
            this.btnLangJa.Location = new System.Drawing.Point(393, 9);
            this.btnLangJa.Name = "btnLangJa";
            this.btnLangJa.Size = new System.Drawing.Size(66, 23);
            this.btnLangJa.TabIndex = 4;
            this.btnLangJa.Text = "日本語";
            this.btnLangJa.UseVisualStyleBackColor = true;
            this.btnLangJa.Click += new System.EventHandler(this.btnJa_Click);
            // 
            // infoDetails
            // 
            this.infoDetails.Location = new System.Drawing.Point(129, 41);
            this.infoDetails.MinimumSize = new System.Drawing.Size(5, 5);
            this.infoDetails.Name = "infoDetails";
            this.infoDetails.Size = new System.Drawing.Size(330, 97);
            this.infoDetails.TabIndex = 7;
            // 
            // btnAbout
            // 
            this.btnAbout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbout.Location = new System.Drawing.Point(214, 141);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(49, 21);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // wizard
            // 
            this.wizard.Image = ChaoJpLayoutFixer.Properties.Resources.res11;
            this.wizard.Location = new System.Drawing.Point(-1, 1);
            this.wizard.Name = "wizard";
            this.wizard.Size = new System.Drawing.Size(121, 161);
            this.wizard.TabIndex = 6;
            this.wizard.TabStop = false;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 166);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.infoDetails);
            this.Controls.Add(this.wizard);
            this.Controls.Add(this.btnLangJa);
            this.Controls.Add(this.listBoxAvailableLocales);
            this.Controls.Add(this.currentDllLbl);
            this.Controls.Add(this.btnGo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "mainform";
            this.Text = "ChaoJpLayoutFixer";
            this.Load += new System.EventHandler(this.mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label currentDllLbl;
        private System.Windows.Forms.ComboBox listBoxAvailableLocales;
        private System.Windows.Forms.Button btnLangJa;
        private System.Windows.Forms.PictureBox wizard;
        private System.Windows.Forms.Label infoDetails;
        private System.Windows.Forms.Button btnAbout;
    }
}

