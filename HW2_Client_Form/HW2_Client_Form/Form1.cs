using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//삽입 해주어야함
using System.IO;
using System.Net;
using System.Net.Sockets;
using HW2_Packet_Form;

namespace HW2_Client_Form
{
    public partial class Form1 : Form
    {
        private NetworkStream m_NetStream;
        private TcpClient m_Client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_blsConnect = false;

        public Initialize m_InitializeClass;
        public Login m_LoginClass;

        public void Send()
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }       

        public Form1()
        {
            InitializeComponent();
        }

        private void btTelnet_Click(object sender, EventArgs e)
        {
            this.m_Client = new TcpClient();
            try
            {
                this.m_Client.Connect(this.textBox1.Text, 7777);
            }
            catch
            {
                MessageBox.Show("접속에러");
                return;
            }
            this.m_blsConnect = true;
            this.m_NetStream = this.m_Client.GetStream();
        }

        private void btInit_Click(object sender, EventArgs e)
        {
            if (!this.m_blsConnect)
                return;
            
            
            this.Send();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (!this.m_blsConnect)
                return;
            
            
            this.Send();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_Client.Close();
            this.m_NetStream.Close();
        }
    }
}
