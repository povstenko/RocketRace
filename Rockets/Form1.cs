using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rockets
{
    public partial class Form1 : Form
    {
        static int i = 0;
        public Form1()
        {
            InitializeComponent();
            //foreach (var item in Controls)
            //{
            //    if (item is PictureBox)
            //    {
            //        (item as PictureBox).Image = Image.FromFile("rocket.png");
            //        (item as PictureBox).SizeMode = PictureBoxSizeMode.Zoom;
            //    }
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

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
            Close();
        }
    }
}
