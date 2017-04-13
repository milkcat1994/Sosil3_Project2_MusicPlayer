using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//참조한 dll파일 using해주어야함
using System.Net;
using System.Net.Sockets;
using System.Threading;
using HW2_Packet_Form;

namespace HW2_Server_Form
{
    public partial class server : Form
    {
        private NetworkStream m_NetStream = null;
        private TcpListener m_Listener = null;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_blsClientOn = false;

        private Thread m_Thread = null;
        private Thread f_Thread = null;

        //Client, IP, Port
        Socket Client = null;
        private String WanIP;
        int port;

        //Folder Browser
        OpenFileDialog folder_Browser;

        public Initialize m_InitializeClass;
        public Login m_LoginClass;

        

        public server()
        {
            InitializeComponent();
        }

        public string Get_My_IP_Wan()
        {
            //외부아이피 반환하는 사이트에서 문자열 파싱
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    WanIP = ip.ToString();
                    break;
                }
            }
            return WanIP;
        }

        public void RUN()
        {
            IPAddress ip = IPAddress.Parse(WanIP);
            this.m_Listener = new TcpListener(ip, port);
            this.m_Listener.Start();

            if (!this.m_blsClientOn)
                this.Music_Log_Text_Box.AppendText("클라이언트 접속 대기중\n");

            Client = this.m_Listener.AcceptSocket();

            if (Client.Connected)
            {
                this.m_blsClientOn = true;
                this.Music_Log_Text_Box.AppendText("클라이언트 접속\n");

                this.m_NetStream = new NetworkStream(Client);
            }

            int nRead = 0;

            while (this.m_blsClientOn)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_NetStream.Read(this.readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_blsClientOn = false;
                    this.m_NetStream = null;
                }

                //패킷 타입으로 저장.
                Packet packet = (Packet)Packet.Deserialize(this.readBuffer);

                //패킷 타입 분석 이후 패킷 종류에 따라 나눠서 사용함.
                switch ((int)packet.Type)
                {
                    case (int)PacketType.초기화:
                        {
                            this.m_InitializeClass = (Initialize)Packet.Deserialize(this.readBuffer);
                            this.Music_Log_Text_Box.AppendText("패킷 전송 성공. Initialize Class Data is" + this.m_InitializeClass.Data + "\n");
                            break;
                        }
                    case (int)PacketType.로그인:
                        {
                            this.m_LoginClass = (Login)Packet.Deserialize(this.readBuffer);
                            this.Music_Log_Text_Box.AppendText("패킷 전송 성공. Login Class Data is" + this.m_LoginClass.m_strID + "\n");
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void server_Load(object sender, EventArgs e)
        {
            //5.1
            //get my ip
            this.ip_TextBox.AppendText(Get_My_IP_Wan());

            //5.1
            //get port
            Random randNum = new Random();
            port = randNum.Next(7000, 7999);
            this.port_TextBox.Text = port.ToString();
        }

        private void server_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.m_Listener != null)
                this.m_Listener.Stop();
            if(this.m_NetStream != null)
                this.m_NetStream.Close();
            if (this.m_Thread != null)
                this.m_Thread.Abort();
        }

        private void server_Start_Button_Click(object sender, EventArgs e)
        {

            if (storage_Path_TextBox.Text == "")
            {//5.2
                MessageBox.Show("전송 가능한 MP3 파일이 없습니다. 경로를 다시 지정하십시오.","Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }
            this.m_Thread = new Thread(new ThreadStart(RUN));
            this.m_Thread.Start();
        }

        private void ip_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        public void end_Path_Folder_Name()
        {
            this.f_Thread.Abort();
        }

        public void get_Path_Folder_Name()
        {
            storage_Path_TextBox.Text = foler_Browser_Dialog.SelectedPath;
            this.end_Path_Folder_Name();
        }

        private void find_Path_Buttton_Click(object sender, EventArgs e)
        {
            folder_Browser  = new OpenFileDialog();
            folder_Browser.ShowDialog();
            this.f_Thread = new Thread(new ThreadStart(get_Path_Folder_Name));
            this.f_Thread.Start();
        }
    }
}
