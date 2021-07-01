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
	public partial class SelectKey
	{

		public string ChosenKey;

		List<string> WholeList = new List<string>();
		private void SelectKey_Load(object sender, EventArgs e)
		{
			foreach (object item_loopVariable in BindKeyBox.Items) {
				var item = item_loopVariable;
				WholeList.Add(item.ToString());
			}
		}

		private void BindKeyBox_TextChanged(object sender, EventArgs e)
		{
			BindKeyBox.DroppedDown = false;

			if (string.IsNullOrEmpty(BindKeyBox.Text)) {
				BindKeyBox.Items.Clear();
				BindKeyBox.Items.AddRange(WholeList.ToArray());

			} else {
				BindKeyBox.Text = BindKeyBox.Text.ToUpper();
				BindKeyBox.SelectionStart = BindKeyBox.Text.Length;

				if (WholeList.Contains(BindKeyBox.Text)) {
					BindKeyBox.ForeColor = Color.Green;
				} else {
					BindKeyBox.ForeColor = Color.Red;
				}
			}
		}

		private void SelectButton_Click(object sender, EventArgs e)
		{
			if (WholeList.Contains(BindKeyBox.Text)) {
				ChosenKey = BindKeyBox.Text;
				DialogResult = System.Windows.Forms.DialogResult.OK;

			} else if (string.IsNullOrEmpty(BindKeyBox.Text)) {
				this.Close();

			} else {
				MessageBox.Show("That bind key does not exist.", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		public SelectKey()
		{
			Load += SelectKey_Load;
			InitializeComponent();
		}
	}
}
