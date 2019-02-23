using System;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    public sealed partial class StartupExitPage
    {
        public StartupExitPage()
        {
            InitializeComponent();
            ApplyTheme();
            PageIcon = Resources.StartupExit_Icon;
        }

        public override string PageName
        {
            get => Language.StartupExit;
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();

            chkSaveConsOnExit.Text = Language.SaveConsOnExit;
            chkReconnectOnStart.Text = Language.ReconnectAtStartup;
            chkSingleInstance.Text = Language.AllowOnlySingleInstance;
            chkProperInstallationOfComponentsAtStartup.Text = Language.CheckProperInstallationOfComponentsAtStartup;
        }

        public override void SaveSettings()
        {
            base.SaveSettings();

            Settings.Default.SaveConsOnExit = chkSaveConsOnExit.Checked;
            Settings.Default.OpenConsFromLastSession = chkReconnectOnStart.Checked;
            Settings.Default.SingleInstance = chkSingleInstance.Checked;
            Settings.Default.StartupComponentsCheck = chkProperInstallationOfComponentsAtStartup.Checked;
        }

        private void StartupExitPage_Load(object sender, EventArgs e)
        {
            chkSaveConsOnExit.Checked = Settings.Default.SaveConsOnExit;
            chkReconnectOnStart.Checked = Settings.Default.OpenConsFromLastSession;
            chkSingleInstance.Checked = Settings.Default.SingleInstance;
            chkProperInstallationOfComponentsAtStartup.Checked = Settings.Default.StartupComponentsCheck;
        }
    }
}