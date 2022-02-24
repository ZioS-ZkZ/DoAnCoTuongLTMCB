using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoTuong
{
    public partial class fMenu : Form
    {
        public fMenu()
        {
            InitializeComponent();
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
            f.ShowDialog();
            this.Show();

        }
    }
}
