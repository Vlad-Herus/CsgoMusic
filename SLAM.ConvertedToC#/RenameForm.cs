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
	public partial class RenameForm
	{
		public string filename;
		private void DoneButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(NameBox.Text)) {
				MessageBox.Show("The name can not be empty.", "Naming Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				filename = NameBox.Text;
				DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		private void RenameForm_Load(object sender, EventArgs e)
		{
			NameBox.Text = filename;
		}
	}
}
