using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int portNumber;

        //Grab the Desktop Image of the Client Computer
        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            return screenshot;
        }

        //Send the Desktop Image to the Server
        private void SendDesktopImage()
        {
            try
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                mainStream = client.GetStream();
                binFormatter.Serialize(mainStream, GrabDesktop());
            }catch(Exception x)
            {
                timer1.Stop();
                MessageBox.Show(x.Message);
            }
        }

        //Initialize the form
        public Form1()
        {
            InitializeComponent();
        }

        //Button that starts the connection to the client
        private void btnConnect_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(textBox2.Text);
            try
            {
                client.Connect(textBox1.Text, portNumber);
                MessageBox.Show("Connected!");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed To Connect");
            }
        }

        //Button that starts and stops screen sharing
        private void btnShare_Click(object sender, EventArgs e)
        {
            if (btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btnShare.Text = "Stop Sharing";
            }
            else
            {
                timer1.Stop();
                btnShare.Text = "Share Screen";
            }
        }

        //Puts the Client DEstop image in the Viewer Form (From 2)
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }

        #region
        /// <summary>
        /// The controls that control the form movement, minimizeing, Closing
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point lastPoint;
        public string size;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (counter==0)
            {
                this.BackColor = Color.FromArgb(242, 255, 240);
                this.ForeColor = Color.Black;
                textBox1.BackColor = Color.FromArgb(242, 255, 240);
                textBox2.BackColor = Color.FromArgb(242, 255, 240);
                textBox1.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;
                counter = 1;
                button2.Text = "Dark Mode";
            }
            else if (counter==1)
            {
                this.BackColor = Color.FromArgb(63, 63, 70);
                this.ForeColor = Color.White;
                textBox1.BackColor = Color.FromArgb(63, 63, 70);
                textBox2.BackColor = Color.FromArgb(63, 63, 70);
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;
                counter = 0;
                button2.Text = "Light Mode";
            }
        }
    }
}
