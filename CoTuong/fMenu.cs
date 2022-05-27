using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Net.Sockets;
using System.Net;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace CoTuong
{
    public partial class fMenu : Form
    {
        SoundPlayer soundMenu = new SoundPlayer(CoTuong.Properties.Resources.nenMenu);
        public Socket client;
        IPEndPoint ipe;
        bool daketnoi = false;
        public fMenu()
        {
            InitializeComponent();
            //soundMenu.PlayLooping();
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void fMenu_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //ipe = new IPEndPoint(IPAddress.Parse("25.5.36.175"), 9999);
                ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

                client.Connect(ipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy server");
                Application.Exit();
            }
        }
        private void fMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban dung cuoc choi tai day ???","THONG BAO", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

		IFirebaseConfig fcon = new FirebaseConfig()
		{
			AuthSecret = "LbuStsX6U5KYTSGKHlLOKGeOlN2XOqA3SCvyd0O0",
			BasePath = "https://ltmcb-cotuong-default-rtdb.firebaseio.com/"
		};

		IFirebaseClient firebaseClient;

		private void PlayGame_Click(object sender, EventArgs e)
        {
			try
			{
				firebaseClient = new FireSharp.FirebaseClient(fcon);
				FirebaseResponse data = firebaseClient.Get("PlayerInfo/" + txtUsername.Text);

				if (data.Body != "null")
				{
					PlayerInfo plr = data.ResultAs<PlayerInfo>();
					if (plr.UserName == txtUsername.Text && plr.Password == txtPass.Text)
					{
						try
						{
							client.Send(VanCo.Serialize("NAMECLIENT|," + txtUsername.Text + ","));
							fBanCo f = new fBanCo();
							this.Hide();
							this.soundMenu.Stop();
							fBanCo.player.socket = client;
							fBanCo.player.ten = txtUsername.Text;
							f.ShowDialog();

							this.Show();

							//this.soundMenu.PlayLooping();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
					else
					{
						MessageBox.Show("Wrong username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Wrong username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				MessageBox.Show("There was a problem in the internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
        }

		private void btnSignUP_Click(object sender, EventArgs e)
		{
			SignUp res = new SignUp();
			this.Hide();
			res.ShowDialog();
			this.Show();
		}
	}
}
