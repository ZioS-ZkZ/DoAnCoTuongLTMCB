using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace CoTuong
{
	public partial class SignUp : Form
	{
		public SignUp()
		{
			InitializeComponent();
		}

		IFirebaseConfig fcon = new FirebaseConfig()
		{
			AuthSecret = "LbuStsX6U5KYTSGKHlLOKGeOlN2XOqA3SCvyd0O0",
			BasePath = "https://ltmcb-cotuong-default-rtdb.firebaseio.com/"
		};

		IFirebaseClient client;

		private void btnSignUp_Click(object sender, EventArgs e)
		{
			PlayerInfo player = new PlayerInfo()
			{
				FullName = txtName.Text,
				Sex = checkListGender.CheckedItems[0].ToString(),
				BirthYear = txtYear.Text,
				UserName = txtUsr.Text,
				Password = txtPsw.Text,
			};

			try
			{
				client = new FireSharp.FirebaseClient(fcon);
				SetResponse setter = client.Set("PlayerInfo/" + txtUsr.Text, player);
				if (setter.StatusCode.ToString() == "OK")
				{
					MessageBox.Show("Sign up successfully");
				} else
				{
					MessageBox.Show("Something wrong! Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				MessageBox.Show("There was a problem in the internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Close();
		}

		private void checkListGender_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			for (int ix = 0; ix < checkListGender.Items.Count; ++ix)
				if (ix != e.Index) checkListGender.SetItemChecked(ix, false);
		}

		private void txtRePsw_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (!txtPsw.Text.Equals(txtRePsw.Text))
					MessageBox.Show("Wrong reenter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else MessageBox.Show("Confirm reenter password!");
			}
		}

		private void cbHienThiPass_CheckedChanged(object sender, EventArgs e)
		{
			if (cbHienThiPass.Checked)
				txtPsw.UseSystemPasswordChar = false;
			else txtPsw.UseSystemPasswordChar = true;
		}
	}
}
