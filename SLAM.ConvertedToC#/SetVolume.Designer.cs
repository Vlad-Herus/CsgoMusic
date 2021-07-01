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
	partial class SetVolume : System.Windows.Forms.Form
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
			this.SelectButton = new System.Windows.Forms.Button();
			this.VolumeBar = new System.Windows.Forms.TrackBar();
			this.VolumeNumber = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)this.VolumeBar).BeginInit();
			this.SuspendLayout();
			//
			//SelectButton
			//
			this.SelectButton.Location = new System.Drawing.Point(272, 63);
			this.SelectButton.Name = "SelectButton";
			this.SelectButton.Size = new System.Drawing.Size(100, 23);
			this.SelectButton.TabIndex = 1;
			this.SelectButton.Text = "Done";
			this.SelectButton.UseVisualStyleBackColor = true;
			//
			//VolumeBar
			//
			this.VolumeBar.Location = new System.Drawing.Point(12, 12);
			this.VolumeBar.Maximum = 20;
			this.VolumeBar.Name = "VolumeBar";
			this.VolumeBar.Size = new System.Drawing.Size(360, 45);
			this.VolumeBar.TabIndex = 3;
			this.VolumeBar.Value = 10;
			//
			//VolumeNumber
			//
			this.VolumeNumber.Location = new System.Drawing.Point(12, 59);
			this.VolumeNumber.MaxLength = 3;
			this.VolumeNumber.Name = "VolumeNumber";
			this.VolumeNumber.Size = new System.Drawing.Size(100, 20);
			this.VolumeNumber.TabIndex = 4;
			this.VolumeNumber.Text = "100";
			//
			//SetVolume
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 91);
			this.Controls.Add(this.VolumeNumber);
			this.Controls.Add(this.VolumeBar);
			this.Controls.Add(this.SelectButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetVolume";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Volume";
			((System.ComponentModel.ISupportInitialize)this.VolumeBar).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button withEventsField_SelectButton;
		internal System.Windows.Forms.Button SelectButton {
			get { return withEventsField_SelectButton; }
			set {
				if (withEventsField_SelectButton != null) {
					withEventsField_SelectButton.Click -= SelectButton_Click;
				}
				withEventsField_SelectButton = value;
				if (withEventsField_SelectButton != null) {
					withEventsField_SelectButton.Click += SelectButton_Click;
				}
			}
		}
		private System.Windows.Forms.TrackBar withEventsField_VolumeBar;
		internal System.Windows.Forms.TrackBar VolumeBar {
			get { return withEventsField_VolumeBar; }
			set {
				if (withEventsField_VolumeBar != null) {
					withEventsField_VolumeBar.Scroll -= VolumeBar_Scroll;
				}
				withEventsField_VolumeBar = value;
				if (withEventsField_VolumeBar != null) {
					withEventsField_VolumeBar.Scroll += VolumeBar_Scroll;
				}
			}
		}
		private System.Windows.Forms.TextBox withEventsField_VolumeNumber;
		internal System.Windows.Forms.TextBox VolumeNumber {
			get { return withEventsField_VolumeNumber; }
			set {
				if (withEventsField_VolumeNumber != null) {
					withEventsField_VolumeNumber.KeyPress -= VolumeNumber_KeyPress;
					withEventsField_VolumeNumber.TextChanged -= VolumeNumber_TextChanged;
				}
				withEventsField_VolumeNumber = value;
				if (withEventsField_VolumeNumber != null) {
					withEventsField_VolumeNumber.KeyPress += VolumeNumber_KeyPress;
					withEventsField_VolumeNumber.TextChanged += VolumeNumber_TextChanged;
				}
			}
		}
	}
}
