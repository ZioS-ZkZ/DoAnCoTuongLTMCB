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
    public partial class fEnd : Form
    {
        public fEnd()
        {
            InitializeComponent();
            SoundPlayer sound = new SoundPlayer(CoTuong.Properties.Resources.ketThuc);
            sound.Play();
        }

        private void rePlay_Click(object sender, EventArgs e)
        {
            VanCo.isWin = false;
            VanCo.clickSound("click");
            this.Close();
            
        }

        
    }
}
