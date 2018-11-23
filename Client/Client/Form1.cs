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

        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            return screenshot;
        }

        private void SendDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            mainStream = client.GetStream();
            binFormatter.Serialize(mainStream, GrabDesktop());
        }

        public Form1()
        {
            InitializeComponent();
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
