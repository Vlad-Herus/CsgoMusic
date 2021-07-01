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
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class SettingsForm : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.VersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.DonateLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.OverrideGroup = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.FinduserdataButton = new System.Windows.Forms.Button();
			this.userdatatext = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.FindsteamappsButton = new System.Windows.Forms.Button();
			this.steamappstext = new System.Windows.Forms.TextBox();
			this.EnableOverrideBox = new System.Windows.Forms.CheckBox();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.ChangeRelayButton = new System.Windows.Forms.Button();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.HoldToPlay = new System.Windows.Forms.CheckBox();
			this.ConTagsCheckBox = new System.Windows.Forms.CheckBox();
			this.StartEnabledCheckBox = new System.Windows.Forms.CheckBox();
			this.LogCheckBox = new System.Windows.Forms.CheckBox();
			this.HintCheckBox = new System.Windows.Forms.CheckBox();
			this.UpdateCheckBox = new System.Windows.Forms.CheckBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.StatusStrip1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.OverrideGroup.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.SuspendLayout();
			//
			//StatusStrip1
			//
			this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.ToolStripStatusLabel1,
				this.VersionLabel,
				this.DonateLabel
			});
			this.StatusStrip1.Location = new System.Drawing.Point(0, 309);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(284, 22);
			this.StatusStrip1.SizingGrip = false;
			this.StatusStrip1.TabIndex = 1;
			this.StatusStrip1.Text = "StatusStrip1";
			//
			//ToolStripStatusLabel1
			//
			this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
			this.ToolStripStatusLabel1.Size = new System.Drawing.Size(49, 17);
			this.ToolStripStatusLabel1.Text = "Version:";
			//
			//VersionLabel
			//
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(31, 17);
			this.VersionLabel.Text = "0.0.0";
			//
			//DonateLabel
			//
			this.DonateLabel.IsLink = true;
			this.DonateLabel.Name = "DonateLabel";
			this.DonateLabel.Size = new System.Drawing.Size(199, 17);
			this.DonateLabel.Text = "Want to support SLAM by donating?";
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.OverrideGroup);
			this.TabPage2.Controls.Add(this.GroupBox3);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(276, 305);
			this.TabPage2.TabIndex = 0;
			this.TabPage2.Text = "Advanced";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//OverrideGroup
			//
			this.OverrideGroup.Controls.Add(this.Label2);
			this.OverrideGroup.Controls.Add(this.FinduserdataButton);
			this.OverrideGroup.Controls.Add(this.userdatatext);
			this.OverrideGroup.Controls.Add(this.Label1);
			this.OverrideGroup.Controls.Add(this.FindsteamappsButton);
			this.OverrideGroup.Controls.Add(this.steamappstext);
			this.OverrideGroup.Controls.Add(this.EnableOverrideBox);
			this.OverrideGroup.Location = new System.Drawing.Point(8, 64);
			this.OverrideGroup.Name = "OverrideGroup";
			this.OverrideGroup.Size = new System.Drawing.Size(260, 96);
			this.OverrideGroup.TabIndex = 3;
			this.OverrideGroup.TabStop = false;
			this.OverrideGroup.Text = "Override folder detection";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Enabled = false;
			this.Label2.Location = new System.Drawing.Point(6, 71);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(51, 13);
			this.Label2.TabIndex = 6;
			this.Label2.Text = "userdata:";
			//
			//FinduserdataButton
			//
			this.FinduserdataButton.Enabled = false;
			this.FinduserdataButton.Location = new System.Drawing.Point(230, 66);
			this.FinduserdataButton.Name = "FinduserdataButton";
			this.FinduserdataButton.Size = new System.Drawing.Size(24, 23);
			this.FinduserdataButton.TabIndex = 5;
			this.FinduserdataButton.Text = "...";
			this.FinduserdataButton.UseVisualStyleBackColor = true;
			//
			//userdatatext
			//
			this.userdatatext.Enabled = false;
			this.userdatatext.Location = new System.Drawing.Point(73, 68);
			this.userdatatext.Name = "userdatatext";
			this.userdatatext.ReadOnly = true;
			this.userdatatext.Size = new System.Drawing.Size(151, 20);
			this.userdatatext.TabIndex = 4;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Enabled = false;
			this.Label1.Location = new System.Drawing.Point(6, 45);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(61, 13);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "steamapps:";
			//
			//FindsteamappsButton
			//
			this.FindsteamappsButton.Enabled = false;
			this.FindsteamappsButton.Location = new System.Drawing.Point(230, 40);
			this.FindsteamappsButton.Name = "FindsteamappsButton";
			this.FindsteamappsButton.Size = new System.Drawing.Size(24, 23);
			this.FindsteamappsButton.TabIndex = 2;
			this.FindsteamappsButton.Text = "...";
			this.FindsteamappsButton.UseVisualStyleBackColor = true;
			//
			//steamappstext
			//
			this.steamappstext.Enabled = false;
			this.steamappstext.Location = new System.Drawing.Point(73, 42);
			this.steamappstext.Name = "steamappstext";
			this.steamappstext.ReadOnly = true;
			this.steamappstext.Size = new System.Drawing.Size(151, 20);
			this.steamappstext.TabIndex = 1;
			//
			//EnableOverrideBox
			//
			this.EnableOverrideBox.AutoSize = true;
			this.EnableOverrideBox.Location = new System.Drawing.Point(6, 19);
			this.EnableOverrideBox.Name = "EnableOverrideBox";
			this.EnableOverrideBox.Size = new System.Drawing.Size(59, 17);
			this.EnableOverrideBox.TabIndex = 0;
			this.EnableOverrideBox.Text = "Enable";
			this.EnableOverrideBox.UseVisualStyleBackColor = true;
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.ChangeRelayButton);
			this.GroupBox3.Location = new System.Drawing.Point(8, 6);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(260, 52);
			this.GroupBox3.TabIndex = 2;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Relay Key";
			//
			//ChangeRelayButton
			//
			this.ChangeRelayButton.Location = new System.Drawing.Point(6, 19);
			this.ChangeRelayButton.Name = "ChangeRelayButton";
			this.ChangeRelayButton.Size = new System.Drawing.Size(248, 23);
			this.ChangeRelayButton.TabIndex = 0;
			this.ChangeRelayButton.Text = "Relay key: \"\"{0}\"\" (change)";
			this.ChangeRelayButton.UseVisualStyleBackColor = true;
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.HoldToPlay);
			this.GroupBox2.Controls.Add(this.ConTagsCheckBox);
			this.GroupBox2.Controls.Add(this.StartEnabledCheckBox);
			this.GroupBox2.Controls.Add(this.LogCheckBox);
			this.GroupBox2.Controls.Add(this.HintCheckBox);
			this.GroupBox2.Controls.Add(this.UpdateCheckBox);
			this.GroupBox2.Location = new System.Drawing.Point(8, 6);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(260, 155);
			this.GroupBox2.TabIndex = 2;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Other";
			//
			//HoldToPlay
			//
			this.HoldToPlay.AutoSize = true;
			this.HoldToPlay.Location = new System.Drawing.Point(6, 134);
			this.HoldToPlay.Name = "HoldToPlay";
			this.HoldToPlay.Size = new System.Drawing.Size(82, 17);
			this.HoldToPlay.TabIndex = 11;
			this.HoldToPlay.Text = "Hold to play";
			this.HoldToPlay.UseVisualStyleBackColor = true;
			//
			//ConTagsCheckBox
			//
			this.ConTagsCheckBox.AutoSize = true;
			this.ConTagsCheckBox.Location = new System.Drawing.Point(6, 111);
			this.ConTagsCheckBox.Name = "ConTagsCheckBox";
			this.ConTagsCheckBox.Size = new System.Drawing.Size(101, 17);
			this.ConTagsCheckBox.TabIndex = 5;
			this.ConTagsCheckBox.Text = "Tags in console";
			this.ConTagsCheckBox.UseVisualStyleBackColor = true;
			//
			//StartEnabledCheckBox
			//
			this.StartEnabledCheckBox.AutoSize = true;
			this.StartEnabledCheckBox.Location = new System.Drawing.Point(6, 88);
			this.StartEnabledCheckBox.Name = "StartEnabledCheckBox";
			this.StartEnabledCheckBox.Size = new System.Drawing.Size(89, 17);
			this.StartEnabledCheckBox.TabIndex = 4;
			this.StartEnabledCheckBox.Text = "Start enabled";
			this.StartEnabledCheckBox.UseVisualStyleBackColor = true;
			//
			//LogCheckBox
			//
			this.LogCheckBox.AutoSize = true;
			this.LogCheckBox.Location = new System.Drawing.Point(6, 65);
			this.LogCheckBox.Name = "LogCheckBox";
			this.LogCheckBox.Size = new System.Drawing.Size(73, 17);
			this.LogCheckBox.TabIndex = 2;
			this.LogCheckBox.Text = "Log errors";
			this.LogCheckBox.UseVisualStyleBackColor = true;
			//
			//HintCheckBox
			//
			this.HintCheckBox.AutoSize = true;
			this.HintCheckBox.Location = new System.Drawing.Point(6, 42);
			this.HintCheckBox.Name = "HintCheckBox";
			this.HintCheckBox.Size = new System.Drawing.Size(65, 17);
			this.HintCheckBox.TabIndex = 3;
			this.HintCheckBox.Text = "No hints";
			this.HintCheckBox.UseVisualStyleBackColor = true;
			//
			//UpdateCheckBox
			//
			this.UpdateCheckBox.AutoSize = true;
			this.UpdateCheckBox.Location = new System.Drawing.Point(6, 19);
			this.UpdateCheckBox.Name = "UpdateCheckBox";
			this.UpdateCheckBox.Size = new System.Drawing.Size(113, 17);
			this.UpdateCheckBox.TabIndex = 2;
			this.UpdateCheckBox.Text = "Check for updates";
			this.UpdateCheckBox.UseVisualStyleBackColor = true;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl1.Location = new System.Drawing.Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(284, 331);
			this.TabControl1.TabIndex = 0;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.GroupBox2);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(276, 305);
			this.TabPage1.TabIndex = 1;
			this.TabPage1.Text = "Misc.";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//SettingsForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 331);
			this.Controls.Add(this.StatusStrip1);
			this.Controls.Add(this.TabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.OverrideGroup.ResumeLayout(false);
			this.OverrideGroup.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal System.Windows.Forms.StatusStrip StatusStrip1;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
		internal System.Windows.Forms.ToolStripStatusLabel VersionLabel;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.CheckBox withEventsField_StartEnabledCheckBox;
		internal System.Windows.Forms.CheckBox StartEnabledCheckBox {
			get { return withEventsField_StartEnabledCheckBox; }
			set {
				if (withEventsField_StartEnabledCheckBox != null) {
					withEventsField_StartEnabledCheckBox.CheckedChanged -= StartEnabledCheckBox_CheckedChanged;
				}
				withEventsField_StartEnabledCheckBox = value;
				if (withEventsField_StartEnabledCheckBox != null) {
					withEventsField_StartEnabledCheckBox.CheckedChanged += StartEnabledCheckBox_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_LogCheckBox;
		internal System.Windows.Forms.CheckBox LogCheckBox {
			get { return withEventsField_LogCheckBox; }
			set {
				if (withEventsField_LogCheckBox != null) {
					withEventsField_LogCheckBox.CheckedChanged -= LogCheckBox_CheckedChanged;
				}
				withEventsField_LogCheckBox = value;
				if (withEventsField_LogCheckBox != null) {
					withEventsField_LogCheckBox.CheckedChanged += LogCheckBox_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_HintCheckBox;
		internal System.Windows.Forms.CheckBox HintCheckBox {
			get { return withEventsField_HintCheckBox; }
			set {
				if (withEventsField_HintCheckBox != null) {
					withEventsField_HintCheckBox.CheckedChanged -= HintCheckBox_CheckedChanged;
				}
				withEventsField_HintCheckBox = value;
				if (withEventsField_HintCheckBox != null) {
					withEventsField_HintCheckBox.CheckedChanged += HintCheckBox_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.CheckBox withEventsField_UpdateCheckBox;
		internal System.Windows.Forms.CheckBox UpdateCheckBox {
			get { return withEventsField_UpdateCheckBox; }
			set {
				if (withEventsField_UpdateCheckBox != null) {
					withEventsField_UpdateCheckBox.CheckedChanged -= UpdateCheckBox_CheckedChanged;
				}
				withEventsField_UpdateCheckBox = value;
				if (withEventsField_UpdateCheckBox != null) {
					withEventsField_UpdateCheckBox.CheckedChanged += UpdateCheckBox_CheckedChanged;
				}
			}
		}
		internal System.Windows.Forms.TabControl TabControl1;
		private System.Windows.Forms.CheckBox withEventsField_ConTagsCheckBox;
		internal System.Windows.Forms.CheckBox ConTagsCheckBox {
			get { return withEventsField_ConTagsCheckBox; }
			set {
				if (withEventsField_ConTagsCheckBox != null) {
					withEventsField_ConTagsCheckBox.CheckedChanged -= ConTagsCheckBox_CheckedChanged;
				}
				withEventsField_ConTagsCheckBox = value;
				if (withEventsField_ConTagsCheckBox != null) {
					withEventsField_ConTagsCheckBox.CheckedChanged += ConTagsCheckBox_CheckedChanged;
				}
			}
		}
		internal System.Windows.Forms.GroupBox GroupBox3;
		private System.Windows.Forms.Button withEventsField_ChangeRelayButton;
		internal System.Windows.Forms.Button ChangeRelayButton {
			get { return withEventsField_ChangeRelayButton; }
			set {
				if (withEventsField_ChangeRelayButton != null) {
					withEventsField_ChangeRelayButton.Click -= ChangeRelayButton_Click;
				}
				withEventsField_ChangeRelayButton = value;
				if (withEventsField_ChangeRelayButton != null) {
					withEventsField_ChangeRelayButton.Click += ChangeRelayButton_Click;
				}
			}
		}
		internal System.Windows.Forms.TabPage TabPage1;
		private System.Windows.Forms.CheckBox withEventsField_HoldToPlay;
		internal System.Windows.Forms.CheckBox HoldToPlay {
			get { return withEventsField_HoldToPlay; }
			set {
				if (withEventsField_HoldToPlay != null) {
					withEventsField_HoldToPlay.CheckedChanged -= HoldToPlay_CheckedChanged;
				}
				withEventsField_HoldToPlay = value;
				if (withEventsField_HoldToPlay != null) {
					withEventsField_HoldToPlay.CheckedChanged += HoldToPlay_CheckedChanged;
				}
			}
		}
		internal GroupBox OverrideGroup;
		private Button withEventsField_FindsteamappsButton;
		internal Button FindsteamappsButton {
			get { return withEventsField_FindsteamappsButton; }
			set {
				if (withEventsField_FindsteamappsButton != null) {
					withEventsField_FindsteamappsButton.Click -= FindsteamappsButton_Click;
				}
				withEventsField_FindsteamappsButton = value;
				if (withEventsField_FindsteamappsButton != null) {
					withEventsField_FindsteamappsButton.Click += FindsteamappsButton_Click;
				}
			}
		}
		internal TextBox steamappstext;
		private CheckBox withEventsField_EnableOverrideBox;
		internal CheckBox EnableOverrideBox {
			get { return withEventsField_EnableOverrideBox; }
			set {
				if (withEventsField_EnableOverrideBox != null) {
					withEventsField_EnableOverrideBox.CheckedChanged -= EnableOverrideBox_CheckedChanged;
				}
				withEventsField_EnableOverrideBox = value;
				if (withEventsField_EnableOverrideBox != null) {
					withEventsField_EnableOverrideBox.CheckedChanged += EnableOverrideBox_CheckedChanged;
				}
			}
		}
		internal Label Label1;
		private ToolStripStatusLabel withEventsField_DonateLabel;
		internal ToolStripStatusLabel DonateLabel {
			get { return withEventsField_DonateLabel; }
			set {
				if (withEventsField_DonateLabel != null) {
					withEventsField_DonateLabel.Click -= DonateLabel_Click;
				}
				withEventsField_DonateLabel = value;
				if (withEventsField_DonateLabel != null) {
					withEventsField_DonateLabel.Click += DonateLabel_Click;
				}
			}
		}
		internal Label Label2;
		private Button withEventsField_FinduserdataButton;
		internal Button FinduserdataButton {
			get { return withEventsField_FinduserdataButton; }
			set {
				if (withEventsField_FinduserdataButton != null) {
					withEventsField_FinduserdataButton.Click -= FinduserdataButton_Click;
				}
				withEventsField_FinduserdataButton = value;
				if (withEventsField_FinduserdataButton != null) {
					withEventsField_FinduserdataButton.Click += FinduserdataButton_Click;
				}
			}
		}
		internal TextBox userdatatext;
	}
}
