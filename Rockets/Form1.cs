using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Rockets
{
    public partial class fMain : Form
    {
        static int i = 0;
        public fMain()
        {
            InitializeComponent();
        }

        private void gameRocket(object state)
        {
            List<PictureBox> lists = new List<PictureBox>();
            foreach (var item in Controls)
            {
                if (item is PictureBox)
                {
                    lists.Add((item as PictureBox));
                }
            }

            PictureBox p = state as PictureBox;
            
            while (true )
            {
                Random rand = new Random();
                if (p.Location.Y<Bounds.Top-50)
                {
                    break;
                }
                p.Invoke(new Action(()=> {
                    
                    p.Location = new Point(p.Location.X, p.Location.Y-rand.Next(10));
                    
                }));
             
                Thread.Sleep(200);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ThreadPool.QueueUserWorkItem(gameRocket, pictureBox1);
            ThreadPool.QueueUserWorkItem(gameRocket, pictureBox2);
            ThreadPool.QueueUserWorkItem(gameRocket, pictureBox3);
            ThreadPool.QueueUserWorkItem(gameRocket, pictureBox4);
            ThreadPool.QueueUserWorkItem(gameRocket, pictureBox5);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}