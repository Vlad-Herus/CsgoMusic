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
	partial class SelectKey : System.Windows.Forms.Form
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
			this.Label1 = new System.Windows.Forms.Label();
			this.BindKeyBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			//
			//SelectButton
			//
			this.SelectButton.Location = new System.Drawing.Point(12, 33);
			this.SelectButton.Name = "SelectButton";
			this.SelectButton.Size = new System.Drawing.Size(185, 23);
			this.SelectButton.TabIndex = 1;
			this.SelectButton.Text = "Done";
			this.SelectButton.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(12, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(69, 13);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Select a key:";
			//
			//BindKeyBox
			//
			this.BindKeyBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BindKeyBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BindKeyBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.BindKeyBox.FormattingEnabled = true;
			this.BindKeyBox.Items.AddRange(new object[] {
				"'",
				"-",
				",",
				".",
				"/",
				"[",
				"\\",
				"]",
				"`",
				"=",
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"A",
				"ALT",
				"B",
				"BACKSPACE",
				"C",
				"CAPSLOCK",
				"CTRL",
				"D",
				"DEL",
				"DOWNARROW",
				"E",
				"END",
				"ENTER",
				"ESCAPE",
				"F",
				"F1",
				"F10",
				"F11",
				"F12",
				"F2",
				"F3",
				"F4",
				"F5",
				"F6",
				"F7",
				"F8",
				"F9",
				"G",
				"H",
				"HOME",
				"I",
				"INS",
				"J",
				"K",
				"KP_5",
				"KP_DEL",
				"KP_DOWNARROW",
				"KP_END",
				"KP_ENTER",
				"KP_HOME",
				"KP_INS",
				"KP_LEFTARROW",
				"KP_MINUS",
				"KP_MULTIPLY",
				"KP_PGDN",
				"KP_PGUP",
				"KP_PLUS",
				"KP_RIGHTARROW",
				"KP_SLASH",
				"KP_UPARROW",
				"L",
				"LEFTARROW",
				"LWIN",
				"M",
				"MOUSE1",
				"MOUSE2",
				"MOUSE3",
				"MOUSE4",
				"MOUSE5",
				"MWHEELDOWN",
				"MWHEELUP",
				"N",
				"NUMLOCK",
				"O",
				"P",
				"PGDN",
				"PGUP",
				"Q",
				"R",
				"RCTRL",
				"RIGHTARROW",
				"RSHIFT",
				"RWIN",
				"S",
				"SCROLLOCK",
				"SEMICOLON",
				"SHIFT",
				"SPACE",
				"T",
				"TAB",
				"U",
				"UPARROW",
				"V",
				"W",
				"X",
				"Y",
				"Z"
			});
			this.BindKeyBox.Location = new System.Drawing.Point(84, 6);
			this.BindKeyBox.Name = "BindKeyBox";
			this.BindKeyBox.Size = new System.Drawing.Size(113, 21);
			this.BindKeyBox.TabIndex = 0;
			//
			//SelectKey
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(209, 64);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.SelectButton);
			this.Controls.Add(this.BindKeyBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectKey";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Key Selector";
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
		internal System.Windows.Forms.Label Label1;
		private System.Windows.Forms.ComboBox withEventsField_BindKeyBox;
		internal System.Windows.Forms.ComboBox BindKeyBox {
			get { return withEventsField_BindKeyBox; }
			set {
				if (withEventsField_BindKeyBox != null) {
					withEventsField_BindKeyBox.TextChanged -= BindKeyBox_TextChanged;
				}
				withEventsField_BindKeyBox = value;
				if (withEventsField_BindKeyBox != null) {
					withEventsField_BindKeyBox.TextChanged += BindKeyBox_TextChanged;
				}
			}
		}
	}
}
