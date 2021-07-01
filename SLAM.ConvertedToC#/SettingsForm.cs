using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
namespace SLAM
{
	public partial class SettingsForm
	{

		private void SettingsForm_Load(object sender, EventArgs e)
		{
            VersionLabel.Text = SLAM.My.MyProject.Application.Info.Version.ToString();

            UpdateCheckBox.Checked = SLAM.Properties.Settings.Default.UpdateCheck;
			HintCheckBox.Checked = SLAM.Properties.Settings.Default.NoHint;
			LogCheckBox.Checked = SLAM.Properties.Settings.Default.LogError;
			StartEnabledCheckBox.Checked = SLAM.Properties.Settings.Default.StartEnabled;
			ConTagsCheckBox.Checked = SLAM.Properties.Settings.Default.WriteTags;
			ChangeRelayButton.Text = string.Format("Relay key: \"{0}\" (change)", SLAM.Properties.Settings.Default.RelayKey);
			HoldToPlay.Checked = SLAM.Properties.Settings.Default.HoldToPlay;
			userdatatext.Text = SLAM.Properties.Settings.Default.userdata;
			steamappstext.Text = SLAM.Properties.Settings.Default.steamapps;
			EnableOverrideBox.Checked = SLAM.Properties.Settings.Default.OverrideFolders;
		}

		private void UpdateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.UpdateCheck = UpdateCheckBox.Checked;
			SLAM.Properties.Settings.Default.Save();
		}

		private void HintCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.NoHint = HintCheckBox.Checked;
			SLAM.Properties.Settings.Default.Save();
		}

		private void LogCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.LogError = LogCheckBox.Checked;
			SLAM.Properties.Settings.Default.Save();
		}

		private void StartEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.StartEnabled = StartEnabledCheckBox.Checked;
			SLAM.Properties.Settings.Default.Save();
		}

		private void ConTagsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.WriteTags = ConTagsCheckBox.Checked;
			SLAM.Properties.Settings.Default.Save();
		}

		private void ChangeRelayButton_Click(object sender, EventArgs e)
		{
			SelectKey SelectKeyDialog = new SelectKey();
			if (SelectKeyDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				if (!(SelectKeyDialog.ChosenKey == SLAM.Properties.Settings.Default.PlayKey)) {
					SLAM.Properties.Settings.Default.RelayKey = SelectKeyDialog.ChosenKey;
					SLAM.Properties.Settings.Default.Save();
					ChangeRelayButton.Text = string.Format("Relay key: \"{0}\" (change)", SLAM.Properties.Settings.Default.RelayKey);
				} else {
					MessageBox.Show("Play key and relay key can not be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void HoldToPlay_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.HoldToPlay = HoldToPlay.Checked;
			SLAM.Properties.Settings.Default.Save();
		}

		private void DonateLabel_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RVLLPGWJUG6CY");
		}

		private void EnableOverrideBox_CheckedChanged(object sender, EventArgs e)
		{
			SLAM.Properties.Settings.Default.OverrideFolders = EnableOverrideBox.Checked;
			SLAM.Properties.Settings.Default.Save();

			foreach (Control control in OverrideGroup.Controls) {
				control.Enabled = EnableOverrideBox.Checked;
			}
			EnableOverrideBox.Enabled = true;
		}

		private string ShowFolderSelector(string name, string setting)
		{
			FolderBrowserDialog ChangeDirDialog = new FolderBrowserDialog();
			ChangeDirDialog.Description = string.Format("Select your {0} folder:", name);
			ChangeDirDialog.ShowNewFolderButton = false;

			if (ChangeDirDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				setting = ChangeDirDialog.SelectedPath + "\\";
				SLAM.Properties.Settings.Default.Save();
			}

            return setting;
		}

		private void FindsteamappsButton_Click(object sender, EventArgs e)
		{
            SLAM.Properties.Settings.Default.steamapps = ShowFolderSelector("steamapps", SLAM.Properties.Settings.Default.steamapps);
			steamappstext.Text = SLAM.Properties.Settings.Default.steamapps;
		}

		private void FinduserdataButton_Click(object sender, EventArgs e)
		{
            SLAM.Properties.Settings.Default.userdata = ShowFolderSelector("userdata", SLAM.Properties.Settings.Default.userdata);
			userdatatext.Text = SLAM.Properties.Settings.Default.userdata;
		}

		public SettingsForm()
		{
			Load += SettingsForm_Load;
			InitializeComponent();
		}
	}
}
