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

                IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);

                IPAddress[] iPAddress = ipHostEntry.AddressList;
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                foreach (IPAddress ip in iPAddress)
                {
                    try
                    {
                        ipe = new IPEndPoint(IPAddress.Parse(ip.ToString()), 9999);
                        client.Connect(ipe);
                        daketnoi = true;
                        break;
                    }
                    catch { }
                }
                if (!daketnoi)
                {
                    MessageBox.Show("Không tìm thấy server");
                    Application.Exit();
                }
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

        private void PlayGame_Click(object sender, EventArgs e)
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

        
    }
}
