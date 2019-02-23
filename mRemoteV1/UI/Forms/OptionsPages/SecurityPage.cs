using System;
using System.ComponentModel;
using mRemoteNG.Security;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    public sealed partial class SecurityPage : OptionsPage
    {
        public SecurityPage()
        {
            InitializeComponent();
            PopulateEncryptionEngineDropDown();
            PopulateBlockCipherDropDown();
            ApplyTheme();
            PageIcon = Resources.Shield_Icon;
        }

        [Browsable(false)]
        public override string PageName
        {
            get => Language.TabSecurity;
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();
            chkEncryptCompleteFile.Text = Language.EncryptCompleteConnectionFile;
            labelBlockCipher.Text = Language.EncryptionBlockCipherMode;
            labelEncryptionEngine.Text = Language.EncryptionEngine;
            labelKdfIterations.Text = Language.EncryptionKeyDerivationIterations;
            groupAdvancedSecurityOptions.Text = Language.AdvancedSecurityOptions;
        }

        public override void LoadSettings()
        {
            chkEncryptCompleteFile.Checked = Settings.Default.EncryptCompleteConnectionsFile;
            comboBoxEncryptionEngine.Text = Enum.GetName(typeof(BlockCipherEngines), Settings.Default.EncryptionEngine);
            comboBoxBlockCipher.Text =
                Enum.GetName(typeof(BlockCipherModes), Settings.Default.EncryptionBlockCipherMode);
            numberBoxKdfIterations.Value = Settings.Default.EncryptionKeyDerivationIterations;
        }

        public override void SaveSettings()
        {
            Settings.Default.EncryptCompleteConnectionsFile = chkEncryptCompleteFile.Checked;
            Settings.Default.EncryptionEngine = (BlockCipherEngines)comboBoxEncryptionEngine.SelectedItem;
            Settings.Default.EncryptionBlockCipherMode = (BlockCipherModes)comboBoxBlockCipher.SelectedItem;
            Settings.Default.EncryptionKeyDerivationIterations = (int)numberBoxKdfIterations.Value;
        }

        public override void RevertSettings()
        {
        }

        private void PopulateEncryptionEngineDropDown()
        {
            comboBoxEncryptionEngine.DataSource = Enum.GetValues(typeof(BlockCipherEngines));
        }

        private void PopulateBlockCipherDropDown()
        {
            comboBoxBlockCipher.DataSource = Enum.GetValues(typeof(BlockCipherModes));
        }
    }
}