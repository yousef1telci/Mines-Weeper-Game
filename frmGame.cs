using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 


/*                         ملاحظة حسن التايمر     */

namespace MinesWeeperGame
{
    public partial class frmGame : Form
    {
        public int flagCount ;

        private static System.Timers.Timer aTimer;

        //Timer aTime = new Timer();
        int timeCount = 0;

        bool ONEtime = true;

        int Setsize;
        int bombCount;



        public frmGame(int size , int bomb)
        {
            InitializeComponent();
            this.Setsize = size;
            this.bombCount = bomb;
            Setsize = size;
            bombCount = bomb;
            flagCount = bombCount;

        }
        private void frmGame_Load(object sender, EventArgs e)
        {
            initializGame(Setsize, Setsize, bombCount);
            pnlGame.Width = Width * 30;
            pnlGame.Height = Height * 30;
        }


        private void initializGame(int width, int height, int bombCount)
        {
            Random rand = new Random();
            List<boomb> listB = new List<boomb>();
            for (int i = 0; i < bombCount; i++)
            {
            Select:
                boomb b = new boomb(rand.Next(0, width + 1), rand.Next(0, height + 1));
                if (listB.SingleOrDefault(a => a.x == b.x && a.y == b.y) != null)
                    goto Select;
                else
                    listB.Add(b);

            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MButton mb = new MButton
                    {
                        x = i,
                        y = j,
                        Width = 30,
                        Height = 30,
                        Margin = new Padding(0),
                        Font = new Font("Cairo", 12, FontStyle.Bold, GraphicsUnit.Point),
                        BackColor = Color.Gray,
                        Location = new Point(i * 30, j * 30),
                        FlatStyle = FlatStyle.Flat,
                    };
                    if (listB.SingleOrDefault(a => a.x == mb.x && a.y == mb.y) != null)
                    {
                        mb.isBoomb = true;
                        //mb.BackColor = Color.Red;
                    }

                    pnlGame.Controls.Add(mb);
                    mb.MouseDown += Mb_MouseDown;
                }
            }
        }

        private void Mb_MouseDown(object sender, MouseEventArgs e)
        {
            if (ONEtime)
            timer();
            ONEtime = false;

            MButton mb = sender as MButton;
            if (mb != null)
            {
                if (e.Button == MouseButtons.Left)  // left click
                {

                    if (mb.isClidked)
                        return;

                    if (mb.isBoomb)
                    {
                        mb.BackColor = Color.DarkRed;
                        foreach (var item in mb.bntTable)
                        {
                            if (item.isBoomb)
                                item.BackColor = Color.DarkRed;
                        }
                        aTimer.Elapsed -= ATimer_Elapsed;  // when you lose Stop timer
                        MessageBox.Show("Game Over");
                    }
                    else
                    {
                        mb.isClidked = true;
                        mb.BackColor = Color.White;

                        if (mb.NearlyCount == 0)          // eyer yanindaki BOMBA yoksa yanindaki kutulari ac
                        {

                            foreach (var item in mb.Nearly)
                            {

                                Mb_MouseDown(item, e);
                            }
                        }
                        else
                        {
                            mb.ForeColor = mb.NearlyCount == 1 ? Color.Blue : mb.NearlyCount == 2 ? Color.Green : mb.NearlyCount == 3 ? Color.Red :
                                Color.Purple;
                            mb.Text = mb.NearlyCount.ToString();
                        }

                    }
                }
                else //reigth click
                {
                    if (mb.isFagled)
                    {
                        //mb.BackColor = Color.White;
                        mb.Text = "";
                        mb.isFagled = false;
                        flagCount++;
                    }
                    else
                    {
                        if (flagCount == 0)
                            return;
                        mb.Text = "🚩";
                        mb.ForeColor = Color.DarkRed;
                        mb.isFagled = true;
                        flagCount--;
                    }
                }
            }
        }

        public void checkWin()
        {
            List<MButton> ls = new List<MButton>();    
            foreach (var item in pnlGame.Controls)
            {
                ls.Add(item as MButton);
            }

            int c = ls.Where( a => a.isClidked == false ).Count();
            if (c == 20)
            {
                MessageBox.Show("WIN");
            }
        }
        public void timer()
        {
            // Create a timer with a one-second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timeCount++;
                // Safely update the UI from the timer thread.
                lblTime.Invoke(new Action(() =>
                {
                    lblTime.Text = timeCount.ToString();
                }));
            }
            catch { 
                aTimer.Stop();
            }
        }

       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        // exit from game
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
    }

    public class MButton : Button
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool isClidked { get; set; }
        public bool isBoomb { get; set; }
        public bool isFagled { get; set; }
        public int NearlyCount
        {
            get
            {
                 List<MButton> list = new List<MButton>();
                foreach (var item in Parent.Controls)
                {
                    list.Add(item as MButton);
                }

                // => LAMPDA   FORLOOP  yazmadan lambda kullanabiliriz 
                int count = list.Where(a => (a.x == x || a.x == x + 1 || a.x == x - 1) && (a.y == y || a.y == y + 1 || a.y == y - 1)).Where(a => a.isBoomb).Count();

                return count;
            }
        }

        //
        public List<MButton> Nearly
        {
            get
            {
                List<MButton> list = new List<MButton>();
                foreach (var item in Parent.Controls)
                {
                    list.Add(item as MButton);  
                }

                // => LAMPDA   FORLOOP  yazmadan lambda kullanabiliriz 
                var c = list.Where(a => (a.x == x || a.x == x + 1 || a.x == x - 1) && (a.y == y || a.y == y + 1 || a.y == y - 1)).ToList();

                return c;  //return Buttons list    
            }
        }

        // bu attribute form'daki tabloyu dondurur
        public List<MButton> bntTable
        {
            get
            {
                List<MButton> list = new List<MButton>();
                foreach (var item in Parent.Controls)
                {
                    list.Add(item as MButton);
                }
                
                return list;
            }
        }

    }


    public class boomb
    {
        public int x { get; set; }
        public int y { get; set; }

        public boomb(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    
}
