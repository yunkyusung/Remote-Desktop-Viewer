using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Diagnostics;

namespace Server
{
    public partial class Form2 : Form
    {
        private readonly int port;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream mainstream;

        private readonly Thread Listening;
        private readonly Thread GetImage;

        public Form2(int Port)
        {
            try
            {
                port = Port;
                client = new TcpClient();
                Listening = new Thread(StartListening);
                GetImage = new Thread(ReceiveImage);
                InitializeComponent();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        //Listen for incomeing signals on the selected port
        private void StartListening()
        {
            while (!client.Connected)
            {
                server.Start();
                client = server.AcceptTcpClient();
            }
            GetImage.Start();
        }

        //Stop listening for incomeing signals on the selected port
        private void StopListening()
        {
            server.Stop();
            client = null;
            if (Listening.IsAlive) Listening.Abort();
            if (GetImage.IsAlive) GetImage.Abort();
        }

        //Receve the data from the Client Computer
        private void ReceiveImage()
        {
            BinaryFormatter binformatter = new BinaryFormatter();
            while (client.Connected)
            {
                try
                {
                    mainstream = client.GetStream();
                    pictureBox1.Image = (Image)binformatter.Deserialize(mainstream);

                    if (!client.Connected)
                    {
                        MessageBox.Show("The Connection has ended!");
                        this.Close();
                    }
                }catch(Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            server = new TcpListener(IPAddress.Any, port);
            Listening.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListening();
        }

        private void stopListeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopListening();
            MessageBox.Show("Connection Terminated. Application will now exit.");
            Application.Exit();
        }
    }
}
