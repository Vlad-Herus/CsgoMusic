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
	public partial class SetVolume
	{


		public int Volume;
		private void SelectButton_Click(object sender, EventArgs e)
		{
			Volume = Convert.ToInt32(VolumeNumber.Text);
			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void VolumeBar_Scroll(object sender, EventArgs e)
		{
			VolumeNumber.Text = "" + VolumeBar.Value * 10;
		}

		private void VolumeNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Strings.Asc(e.KeyChar) != 8) {
				if (Strings.Asc(e.KeyChar) < 48 | Strings.Asc(e.KeyChar) > 57) {
					e.Handled = true;
				}
			}
		}

		private void VolumeNumber_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(VolumeNumber.Text)) {
				if (Convert.ToInt32(VolumeNumber.Text) > 200) {
					VolumeNumber.Text = "200";
					VolumeNumber.SelectionStart = VolumeNumber.TextLength;
				}

				VolumeBar.Value = Convert.ToInt32(VolumeNumber.Text) / 10;

			}
		}
		public SetVolume()
		{
			InitializeComponent();
		}
	}
}
