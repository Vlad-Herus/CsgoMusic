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
	partial class RenameForm : System.Windows.Forms.Form
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
			this.NameBox = new System.Windows.Forms.TextBox();
			this.DoneButton = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			//NameBox
			//
			this.NameBox.Location = new System.Drawing.Point(79, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(183, 20);
			this.NameBox.TabIndex = 0;
			//
			//DoneButton
			//
			this.DoneButton.Location = new System.Drawing.Point(268, 10);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new System.Drawing.Size(75, 23);
			this.DoneButton.TabIndex = 1;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(12, 15);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(61, 13);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "New name:";
			//
			//RenameForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 42);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.NameBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RenameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rename";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal System.Windows.Forms.TextBox NameBox;
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
		internal System.Windows.Forms.Label Label1;
		public RenameForm()
		{
			Load += RenameForm_Load;
			InitializeComponent();
		}
	}
}
