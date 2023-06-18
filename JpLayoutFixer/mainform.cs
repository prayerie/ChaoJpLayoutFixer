using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JpLayoutFixer {
    public partial class mainform : Form {

        private Dictionary<string, string> layoutsDict = new Dictionary<string, string>();
        private string currentLblMsg = string.Empty;
        private string currentLblMsgJp = string.Empty;

        public mainform() {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            wizard.SizeMode = PictureBoxSizeMode.StretchImage;
            Global.Jp = CultureInfo.CurrentCulture.Name == "ja-JP";


            LoadKeyboardLayouts();
            LoadCurrentJpLayout();
            SelectCurrentLayout();
            LocaliseComponents();
        }

        private async Task CheckForUpdates() {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "mistyhands/ChaoJpLayoutFixer update check");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            try {
                var response = await client.GetStringAsync("https://api.github.com/repos/mistyhands/chaojplayoutfixer/releases");
                var releases = JArray.Parse(response);

                var latestRelease = releases[0];
                var latestVersion = new Version(latestRelease["tag_name"].ToString().TrimStart('v'));

                var currentVersion = new Version(Application.ProductVersion);

                if (latestVersion > currentVersion) {
                    string message = "A new version of ChaoJpLayoutFixer is available. Go to the release page?";
                    if (Global.Jp)
                        message = "ChaoJpLayoutFixerの新しいバージョンが利用可能です。リリースページをご覧になりたいですか？";
                    var dialogResult = MessageBox.Show(this, message, "Update available", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) {
                        // Open the release page
                        Process.Start(new ProcessStartInfo {
                            FileName = latestRelease["html_url"].ToString(),
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception) {
            }
        }

        private void LocaliseComponents() {
            if (Global.Jp) {
                btnLangJa.Text = "English";
                btnAbout.Text = "情報";
                btnGo.Text = "実行";
                infoDetails.Text = "普通にはMicrosoft 日本語　IMEは、ローマ字入力の場合、米国式または日本式キーボード配列にのみ対応しています。\nこのプログラムで好きなキー配列をWindowsに設定できます。\n\n注意：選択したキー配列は、いくつかの他キー配列の表示されている名が同じであるため、名が間違っている可能性があります。その場合でも、Windowsのキーボード配列は正しく動作します。";
                currentDllLbl.Text = currentLblMsgJp;
            }
            else {
                currentDllLbl.Text = currentLblMsg;
                infoDetails.Text = "Microsoft Japanese IME only supports U.S. or Japanese layouts when typing in Romaji mode.\nUse this programme to set any layout you wish.\n\nYour chosen keyboard may be named incorrectly due to some layouts being the same. Your keyboard will still be correct in your system.";
                btnGo.Text = "Go";
                btnAbout.Text = "About";
                btnLangJa.Text = "日本語";
            }
        }

        private void CheckAndElevatePrivileges() {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator)) {
                var startInfo = new ProcessStartInfo(Application.ExecutablePath) {
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(startInfo);
                Application.Exit();
            }
        }

        private void UpdateLabel(string layoutF) {

            string labelMsg = "Microsoft IME layout:\n{0} ({1})";
            string labelMsgJp = "Microsoft 日本語 IME 現在のキー配列：\n{0} ({1})";

            currentLblMsg = String.Format(labelMsg, layoutsDict[layoutF], layoutF);
            currentLblMsgJp = String.Format(labelMsgJp, layoutsDict[layoutF], layoutF);

            if (Global.Jp)
                currentDllLbl.Text = currentLblMsgJp;
            else
                currentDllLbl.Text = currentLblMsg;
        }

        private void LoadCurrentJpLayout() {
            try {
                using (var regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layouts\00000411 ", false)) {
                    if (regKey != null) {
                        var layoutText = regKey.GetValue("Layout Text") as string;
                        var layoutFile = regKey.GetValue("Layout File") as string;


                        if (!string.IsNullOrEmpty(layoutText)) {
                            UpdateLabel(layoutFile);
                        }
                        else {
                            currentDllLbl.Text = "Registry key value not found";
                        }
                    }
                    else {
                        currentDllLbl.Text = "Registry key not found";
                    }
                }
            }
            catch (Exception ex) {
                currentDllLbl.Text = "Error: " + ex.Message;
            }

        }

        private void SelectCurrentLayout() {
            string currentLayoutFile;
            using (var regKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layouts\00000411", false)) {
                currentLayoutFile = regKey.GetValue("Layout File") as string;
            }

            if (!string.IsNullOrEmpty(currentLayoutFile)) {
                foreach (KeyValuePair<string, string> item in listBoxAvailableLocales.Items) {
                    if (item.Value.Equals(currentLayoutFile)) {
                        listBoxAvailableLocales.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void LoadKeyboardLayouts() {
            try {
                if (Global.Jp) {
                    listBoxAvailableLocales.Items.Add(new KeyValuePair<string, string>("日本語 (106・109キー)", "KBDJPN.DLL"));
                    listBoxAvailableLocales.Items.Add(new KeyValuePair<string, string>("英語（米国, 101・102キー）", "KBDUS.DLL"));
                    layoutsDict["KBDUS.DLL"] = "英語（米国、101・102キー）";
                    layoutsDict["KBDJPN.DLL"] = "日本語 （106・109キー）";
                }
                else {
                    listBoxAvailableLocales.Items.Add(new KeyValuePair<string, string>("Japanese (106/109-key)", "KBDJPN.DLL"));
                    listBoxAvailableLocales.Items.Add(new KeyValuePair<string, string>("English (U.S., 101/102-key)", "KBDUS.DLL"));
                    layoutsDict["KBDUS.DLL"] = "English (U.S., 101/102-key)";
                    layoutsDict["KBDJPN.DLL"] = "Japanese (106/109-key)";
                }

                using (var baseRegKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layouts", false)) {
                    foreach (var subKeyName in baseRegKey.GetSubKeyNames()) {
                        using (var subKey = baseRegKey.OpenSubKey(subKeyName, false)) {
                            var layoutText = subKey.GetValue("Layout Text") as string;
                            var layoutFile = subKey.GetValue("Layout File") as string;

                            if (!string.IsNullOrEmpty(layoutText) && !string.IsNullOrEmpty(layoutFile) && layoutText != "Japanese" && layoutText != "日本語"
                                && layoutFile != "KBDUS.DLL") {
                                listBoxAvailableLocales.Items.Add(new KeyValuePair<string, string>(layoutText, layoutFile));
                                layoutsDict[layoutFile] = layoutText;
                            }
                        }
                    }
                }
                listBoxAvailableLocales.DisplayMember = "Key";
                listBoxAvailableLocales.ValueMember = "Value";

                
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            CheckAndElevatePrivileges();
            try {
                var selectedPair = (KeyValuePair<string, string>)listBoxAvailableLocales.SelectedItem;

                var layoutFile = selectedPair.Value;
                if (!string.IsNullOrEmpty(layoutFile)) {
                    using (var regKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Keyboard Layouts\00000411", true)) {
                        var oldLayoutFile = regKey.GetValue("Layout File") as string;
                        var regFilePath = Path.Combine(Application.StartupPath, "Japanese Layout Backup.reg");
                        Process.Start("reg", $"export \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts\\00000411\" \"{regFilePath}\" /y");
                        regKey.SetValue("Layout File", layoutFile);
                        UpdateLabel(layoutFile);
                        string msg = "Your Japanese input method will now use {0} ({1}).\nYou must log back in for this to take effect.\n\nThe file \"Japanese Layout Backup.reg\" has been created in the current directory if you wish to revert your changes.";
                        string title = "Success";
                        if (Global.Jp) {
                            title = "変更に成功しました";
                            msg = "Microsoft 日本語 IMEのキー配列が {0}（{1}）に設定されていました。\nキー配列の変更は、再ログインするまで反映されません。\n\nキーボード配列の変更を元に戻したい場合は、カレントディレクトリに「Japanese Layout Backup.reg」ファイルが作成されています。";
                        }
                        DialogResult dia = MessageBox.Show(this, String.Format(msg, layoutsDict[layoutFile], layoutFile), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dia == DialogResult.OK)
                            Application.Exit();
                    }
                }
                else {
                    string msg = "Invalid or no layout selected.";
                    string title = "No selection";

                    if (Global.Jp) {
                        title = "無選択";
                        msg = "無効なキーボード配列、または選択されていないキー配列です。";
                    }
                    MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.NullReferenceException) {
                string msg = "That layout name doesn't exist.";
                string title = "Error";
                if (Global.Jp) {
                    msg = "入力されたキー配列名が無効である。";
                    title = "エラーが発生しました";
                }
                MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SelectCurrentLayout();

            }
        }

        private void btnAbout_Click(object sender, EventArgs e) {
            about aboutForm = new about();
            aboutForm.TopMost = true;

            aboutForm.ShowDialog(this);
        }

        /* Switch language to Japanese.
         * This is not a good implementation; a future release will use ResourceManager.
         */
        private void btnJa_Click(object sender, EventArgs e) {
            if (Global.Jp) {
                btnLangJa.Text = "日本語";

            }
            else {
                btnLangJa.Text = "English";
            }
            Global.Jp = !Global.Jp;
            LocaliseComponents();

        }

        private async void mainform_Load(object sender, EventArgs e) {
            await CheckForUpdates();
        }

    }
}
