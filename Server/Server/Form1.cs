using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Start Form 2, the form that the Client Desktop appears in.
            new Form2(int.Parse(textBox1.Text)).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Form Border Controls
        /// <summary>
        /// This is the section that controls closing, moving, etc. of the main form.
        /// </summary>
        Point lastPoint;
        public string size;
        //Minimize the form
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #endregion

        int counter = 0;
        private void button5_Click(object sender, EventArgs e)
        {  
            if (counter == 0)
            {
                this.BackColor = Color.FromArgb(242, 255, 240);
                this.ForeColor = Color.Black;
                textBox1.BackColor = Color.FromArgb(242, 255, 240);
                textBox1.ForeColor = Color.Black;
                counter = 1;
                button5.Text = "Dark Mode";
            }
            else if (counter == 1)
            {
                this.BackColor = Color.FromArgb(63, 63, 70);
                this.ForeColor = Color.White;
                textBox1.BackColor = Color.FromArgb(63, 63, 70);
                textBox1.ForeColor = Color.White;
                counter = 0;
                button5.Text = "Light Mode";
            }
        }
    }
}
