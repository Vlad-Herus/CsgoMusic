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
	partial class TrimForm : System.Windows.Forms.Form
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
			this.NumericRight = new System.Windows.Forms.NumericUpDown();
			this.DoneButton = new System.Windows.Forms.Button();
			this.NumericLeft = new System.Windows.Forms.NumericUpDown();
			this.ResetButton = new System.Windows.Forms.Button();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.NumericLeftS = new System.Windows.Forms.NumericUpDown();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.NumericRightS = new System.Windows.Forms.NumericUpDown();
			this.Label2 = new System.Windows.Forms.Label();
			this.BackgroundPlayer = new System.ComponentModel.BackgroundWorker();
			this.PlayButton = new System.Windows.Forms.Button();
			this.AdvWaveViewer1 = new SLAM.AdvWaveViewer();
			((System.ComponentModel.ISupportInitialize)this.NumericRight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.NumericLeft).BeginInit();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.NumericLeftS).BeginInit();
			this.GroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.NumericRightS).BeginInit();
			this.SuspendLayout();
			//
			//NumericRight
			//
			this.NumericRight.Location = new System.Drawing.Point(57, 19);
			this.NumericRight.Name = "NumericRight";
			this.NumericRight.Size = new System.Drawing.Size(150, 20);
			this.NumericRight.TabIndex = 2;
			this.NumericRight.ThousandsSeparator = true;
			//
			//DoneButton
			//
			this.DoneButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.DoneButton.Location = new System.Drawing.Point(557, 203);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new System.Drawing.Size(215, 23);
			this.DoneButton.TabIndex = 5;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = true;
			//
			//NumericLeft
			//
			this.NumericLeft.Location = new System.Drawing.Point(57, 19);
			this.NumericLeft.Name = "NumericLeft";
			this.NumericLeft.Size = new System.Drawing.Size(150, 20);
			this.NumericLeft.TabIndex = 6;
			this.NumericLeft.ThousandsSeparator = true;
			//
			//ResetButton
			//
			this.ResetButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.ResetButton.Location = new System.Drawing.Point(557, 174);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(100, 23);
			this.ResetButton.TabIndex = 7;
			this.ResetButton.Text = "Reset";
			this.ResetButton.UseVisualStyleBackColor = true;
			//
			//GroupBox1
			//
			this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.NumericLeftS);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.NumericLeft);
			this.GroupBox1.Location = new System.Drawing.Point(557, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(215, 75);
			this.GroupBox1.TabIndex = 8;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Start";
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(6, 47);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(47, 13);
			this.Label3.TabIndex = 9;
			this.Label3.Text = "Second:";
			//
			//NumericLeftS
			//
			this.NumericLeftS.DecimalPlaces = 3;
			this.NumericLeftS.Location = new System.Drawing.Point(57, 45);
			this.NumericLeftS.Name = "NumericLeftS";
			this.NumericLeftS.Size = new System.Drawing.Size(150, 20);
			this.NumericLeftS.TabIndex = 8;
			this.NumericLeftS.ThousandsSeparator = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(6, 21);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(45, 13);
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Sample:";
			//
			//GroupBox2
			//
			this.GroupBox2.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.GroupBox2.Controls.Add(this.Label4);
			this.GroupBox2.Controls.Add(this.NumericRightS);
			this.GroupBox2.Controls.Add(this.Label2);
			this.GroupBox2.Controls.Add(this.NumericRight);
			this.GroupBox2.Location = new System.Drawing.Point(557, 93);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(215, 75);
			this.GroupBox2.TabIndex = 9;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "End";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(6, 47);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(47, 13);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Second:";
			//
			//NumericRightS
			//
			this.NumericRightS.DecimalPlaces = 3;
			this.NumericRightS.Location = new System.Drawing.Point(57, 45);
			this.NumericRightS.Name = "NumericRightS";
			this.NumericRightS.Size = new System.Drawing.Size(150, 20);
			this.NumericRightS.TabIndex = 9;
			this.NumericRightS.ThousandsSeparator = true;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(6, 21);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(45, 13);
			this.Label2.TabIndex = 8;
			this.Label2.Text = "Sample:";
			//
			//BackgroundPlayer
			//
			this.BackgroundPlayer.WorkerReportsProgress = true;
			this.BackgroundPlayer.WorkerSupportsCancellation = true;
			//
			//PlayButton
			//
			this.PlayButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.PlayButton.Location = new System.Drawing.Point(672, 174);
			this.PlayButton.Name = "PlayButton";
			this.PlayButton.Size = new System.Drawing.Size(100, 23);
			this.PlayButton.TabIndex = 10;
			this.PlayButton.Text = "Play";
			this.PlayButton.UseVisualStyleBackColor = true;
			//
			//AdvWaveViewer1
			//
			this.AdvWaveViewer1.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.AdvWaveViewer1.BackColor = System.Drawing.Color.White;
			this.AdvWaveViewer1.leftpos = 0;
			this.AdvWaveViewer1.leftSample = 0;
			this.AdvWaveViewer1.Location = new System.Drawing.Point(0, 0);
			this.AdvWaveViewer1.Name = "AdvWaveViewer1";
			//Me.AdvWaveViewer1.Position = CType(0, Long)
			this.AdvWaveViewer1.rightpos = 0;
			this.AdvWaveViewer1.rightSample = 0;
			this.AdvWaveViewer1.SamplesPerPixel = 128;
			this.AdvWaveViewer1.Size = new System.Drawing.Size(551, 231);
			this.AdvWaveViewer1.StartPosition = Convert.ToInt64(0);
			this.AdvWaveViewer1.TabIndex = 0;
			this.AdvWaveViewer1.WaveStream = null;
			//
			//TrimForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 231);
			this.Controls.Add(this.PlayButton);
			this.Controls.Add(this.ResetButton);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.AdvWaveViewer1);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.GroupBox2);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(16, 270);
			this.Name = "TrimForm";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Trim";
			((System.ComponentModel.ISupportInitialize)this.NumericRight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.NumericLeft).EndInit();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.NumericLeftS).EndInit();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.NumericRightS).EndInit();
			this.ResumeLayout(false);

		}
		private SLAM.AdvWaveViewer withEventsField_AdvWaveViewer1;
		internal SLAM.AdvWaveViewer AdvWaveViewer1 {
			get { return withEventsField_AdvWaveViewer1; }
			set {
				if (withEventsField_AdvWaveViewer1 != null) {
					withEventsField_AdvWaveViewer1.MouseUp -= AdvWaveViewer1_MouseUp;
				}
				withEventsField_AdvWaveViewer1 = value;
				if (withEventsField_AdvWaveViewer1 != null) {
					withEventsField_AdvWaveViewer1.MouseUp += AdvWaveViewer1_MouseUp;
				}
			}
		}
		private System.Windows.Forms.NumericUpDown withEventsField_NumericRight;
		internal System.Windows.Forms.NumericUpDown NumericRight {
			get { return withEventsField_NumericRight; }
			set {
				if (withEventsField_NumericRight != null) {
					withEventsField_NumericRight.ValueChanged -= NumericRight_ValueChanged;
				}
				withEventsField_NumericRight = value;
				if (withEventsField_NumericRight != null) {
					withEventsField_NumericRight.ValueChanged += NumericRight_ValueChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_DoneButton;
		internal System.Windows.Forms.Button DoneButton {
			get { return withEventsField_DoneButton; }
			set {
				if (withEventsField_DoneButton != null) {
					withEventsField_DoneButton.Click -= DoneButton_Click;
				}
				withEventsField_DoneButton = value;
				if (withEventsField_DoneButton != null) {
					withEventsField_DoneButton.Click += DoneButton_Click;
				}
			}
		}
		private System.Windows.Forms.NumericUpDown withEventsField_NumericLeft;
		internal System.Windows.Forms.NumericUpDown NumericLeft {
			get { return withEventsField_NumericLeft; }
			set {
				if (withEventsField_NumericLeft != null) {
					withEventsField_NumericLeft.ValueChanged -= NumericLeft_ValueChanged;
				}
				withEventsField_NumericLeft = value;
				if (withEventsField_NumericLeft != null) {
					withEventsField_NumericLeft.ValueChanged += NumericLeft_ValueChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_ResetButton;
		internal System.Windows.Forms.Button ResetButton {
			get { return withEventsField_ResetButton; }
			set {
				if (withEventsField_ResetButton != null) {
					withEventsField_ResetButton.Click -= ResetButton_Click;
				}
				withEventsField_ResetButton = value;
				if (withEventsField_ResetButton != null) {
					withEventsField_ResetButton.Click += ResetButton_Click;
				}
			}
		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label3;
		private System.Windows.Forms.NumericUpDown withEventsField_NumericLeftS;
		internal System.Windows.Forms.NumericUpDown NumericLeftS {
			get { return withEventsField_NumericLeftS; }
			set {
				if (withEventsField_NumericLeftS != null) {
					withEventsField_NumericLeftS.ValueChanged -= NumericLeftS_ValueChanged;
				}
				withEventsField_NumericLeftS = value;
				if (withEventsField_NumericLeftS != null) {
					withEventsField_NumericLeftS.ValueChanged += NumericLeftS_ValueChanged;
				}
			}
		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label4;
		private System.Windows.Forms.NumericUpDown withEventsField_NumericRightS;
		internal System.Windows.Forms.NumericUpDown NumericRightS {
			get { return withEventsField_NumericRightS; }
			set {
				if (withEventsField_NumericRightS != null) {
					withEventsField_NumericRightS.ValueChanged -= NumericRightS_ValueChanged;
				}
				withEventsField_NumericRightS = value;
				if (withEventsField_NumericRightS != null) {
					withEventsField_NumericRightS.ValueChanged += NumericRightS_ValueChanged;
				}
			}
		}
		private System.ComponentModel.BackgroundWorker withEventsField_BackgroundPlayer;
		internal System.ComponentModel.BackgroundWorker BackgroundPlayer {
			get { return withEventsField_BackgroundPlayer; }
			set {
				if (withEventsField_BackgroundPlayer != null) {
					withEventsField_BackgroundPlayer.DoWork -= BackgroundPlayer_DoWork;
					withEventsField_BackgroundPlayer.ProgressChanged -= BackgroundPlayer_ProgressChanged;
					withEventsField_BackgroundPlayer.RunWorkerCompleted -= BackgroundPlayer_RunWorkerCompleted;
				}
				withEventsField_BackgroundPlayer = value;
				if (withEventsField_BackgroundPlayer != null) {
					withEventsField_BackgroundPlayer.DoWork += BackgroundPlayer_DoWork;
					withEventsField_BackgroundPlayer.ProgressChanged += BackgroundPlayer_ProgressChanged;
					withEventsField_BackgroundPlayer.RunWorkerCompleted += BackgroundPlayer_RunWorkerCompleted;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_PlayButton;
		internal System.Windows.Forms.Button PlayButton {
			get { return withEventsField_PlayButton; }
			set {
				if (withEventsField_PlayButton != null) {
					withEventsField_PlayButton.Click -= PlayButton_Click;
				}
				withEventsField_PlayButton = value;
				if (withEventsField_PlayButton != null) {
					withEventsField_PlayButton.Click += PlayButton_Click;
				}
			}
		}
		public TrimForm()
		{
			Resize += TrimForm_Resize;
			FormClosing += TrimForm_FormClosing;
			Load += TrimForm_Load;
			InitializeComponent();
		}
	}
}
