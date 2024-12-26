using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesWeeperGame
{
    public partial class SetDifficulty : Form
    {
        int size;
        int bomb;
        public SetDifficulty(int size ,int bomb)
        {
            InitializeComponent();
            this.size = size;
            this.bomb = bomb;
        }

        private void size_bomb()
        {
            try
            {
                size = Convert.ToInt32(txtSize.Text);
                bomb = Convert.ToInt32(txtMines.Text);
            }
            catch 
            {
                this.Refresh();
            }
            }

        private void bntPlay_Click(object sender, EventArgs e)
        {
            size_bomb();
            Form frm_Game = new frmGame(size , bomb);
            frm_Game.ShowDialog();
        }
    }
}
