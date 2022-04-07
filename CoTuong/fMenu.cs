using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace CoTuong
{
    public partial class fMenu : Form
    {
        SoundPlayer soundMenu = new SoundPlayer(CoTuong.Properties.Resources.nenMenu);
        public fMenu()
        {
            InitializeComponent();
            //soundMenu.PlayLooping();
        }

        private void ExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban dung cuoc choi tai day ???","THONG BAO", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void PlayGame_Click(object sender, EventArgs e)
        {
            fBanCo f = new fBanCo();
            this.Hide();
            this.soundMenu.Stop();
            f.ShowDialog();
            this.Show();
            //this.soundMenu.PlayLooping();
        }
    }
}
