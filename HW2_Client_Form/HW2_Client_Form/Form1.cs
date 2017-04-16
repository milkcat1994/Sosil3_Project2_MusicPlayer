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
using System.IO;    //DirectoryInfo사용
using System.Net;
using System.Net.Sockets;
using System.Threading;
using HW2_Packet_Form;
using Shell32;      //ShellClass()사용 shell controls 참조 추가
using WMPLib;       //Windows Media Player 사용 위한 참조 추가

namespace HW2_Client_Form
{
    public partial class form_Client : Form
    {
        private NetworkStream m_NetStream;
        private TcpClient m_Client;
        
        private byte[] sendBuffer = new byte[1024 * 1];
        private byte[] readBuffer = new byte[1024 * 2];
        private byte[] fileBuffer = new byte[1024 * 1000];

        //server와의 연결이 되었는지 확인
        private bool m_blsConnect = false;

        //Thread 선언
        private Thread m_Thread = null;
        //receive Thread
        private Thread r_Thread = null;

        public Initialize m_InitializeClass;
        public Login m_LoginClass;
        public MusicList m_musicListClass;
        public ClientRequest m_clientRequestClass
            = new ClientRequest(ClientRequest.RequestType.music_File);
        public ServerMusic m_serverMusicClass;
        public EndStream m_endStreamClass;
        public BinaryWriter fileWriter;

        private NAudio.Wave.Mp3FileReader mp3 = null;
        //data 길이 저장 위한 변수
        UInt32 dataLength;

        //파일 저장 경로
        string storage_Path;

        public void Send()
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();
            int i = 0;
            while(sendBuffer[i++] != 0)
            {
                this.sendBuffer[i] = 0;
            }
        }       

        public form_Client()
        {
            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            this.m_Client = new TcpClient();
            try
            {
                if (textBox_IP.Text == "" || textBox_Port.Text == "")
                    throw new ObjectDisposedException("null");
                this.m_Client.Connect(this.textBox_IP.Text, Int32.Parse(this.textBox_Port.Text));
            }
            catch(ObjectDisposedException ode)
            {
                //9.1_score : 0.1
                //IP 또는 Port가 입력되지 않고 Connect 버튼이 눌린경우
                MessageBox.Show("IP 혹은 Port Number가 설정되지 않았습니다.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (SocketException se)
            {
                MessageBox.Show("socketException");
                return;
            }
            catch (ArgumentNullException ane)
            {
                //9.2_score : 0.1
                //Server가 Start되지 않은 경우
                MessageBox.Show("Can not Connection...");
                return;
            }
            this.m_blsConnect = true;
            this.m_NetStream = this.m_Client.GetStream();

            //Changed Button Text
            this.button_Connect.Text = "DisConnect";
            //received music list
            //스래드로 RUN함수 실행
            this.m_Thread = new Thread(new ThreadStart(receive_Thread));
            this.m_Thread.Start();
        }

        //10.1_score : 0.3
        //서버가 전송한 Music_File_List 받아서 Client쪽 ListView에 보여주기
        public void receive_Thread()
        {
            int nRead = 0;
            while (this.m_blsConnect)
            {
                try
                {
                    nRead = 0;
                    if (!m_NetStream.DataAvailable) { continue; }
                    nRead = this.m_NetStream.Read(this.readBuffer, 0, this.readBuffer.Length);
                    if (nRead <= 0) { continue; }
                }
                catch
                {
                    this.m_blsConnect = false;
                    this.m_NetStream = null;
                    return;
                }

                //패킷 타입으로 저장.
                Packet packet = (Packet)Packet.Deserialize(this.readBuffer,this.readBuffer.Length);
                //패킷 타입 분석 이후 패킷 종류에 따라 나눠서 사용함.
                //10.2_score : 1
                //Music List를 Server Music List에 추가시켜줌
                if (packet.Type == (int)PacketType.리스트)
                {
                    //리스트를 받을 경우 리스트를 serverListView 부분에 add해주어야함
                    this.m_musicListClass = (MusicList)Packet.Deserialize(this.readBuffer,this.readBuffer.Length);
                    ListViewItem lv_Item = new ListViewItem(m_musicListClass.music_Name);
                    lv_Item.SubItems.Add(m_musicListClass.music_Singer);
                    lv_Item.SubItems.Add(m_musicListClass.music_Play_Time);
                    lv_Item.SubItems.Add(m_musicListClass.music_Bit_Rate);
                    this.listView_Server_Music_List.Items.Add(lv_Item);
                }
                else if(packet.Type == (int)PacketType.server_Music || packet.Type == (int)PacketType.end_Stream) {
                        if (packet.Type == (int)PacketType.server_Music)
                        {
                            this.m_serverMusicClass = (ServerMusic)Packet.Deserialize(this.readBuffer,this.readBuffer.Length);
                            string music_Name = m_serverMusicClass.music_Name;
                            //open and create storage Path
                            string storage_File = textBox_Storage_Path.ToString() + @"\" + music_Name + ".mp3";

                            FileStream stream = null;
                            //stream = File.Open(storage_File, FileMode.Append);
                            stream = File.Open(@"C: \Users\지용\Pictures\" + music_Name + ".mp3", FileMode.Append);
                            stream.Write(m_serverMusicClass.buffer, 0, m_serverMusicClass.buffer.Length);
                            stream.Close();
                        }

                        if (packet.Type == (int)PacketType.end_Stream)
                        {
                            this.m_endStreamClass = (EndStream)Packet.Deserialize(this.readBuffer, this.readBuffer.Length);
                            ListViewItem lv_Item = new ListViewItem(m_endStreamClass.music_Name);
                            lv_Item.SubItems.Add(m_endStreamClass.music_Singer);
                            lv_Item.SubItems.Add(m_endStreamClass.music_Play_Time);
                            lv_Item.SubItems.Add(m_endStreamClass.music_Bit_Rate);
                            this.listView_Play_List.Items.Add(lv_Item);
                            MessageBox.Show("Client : Complete Download");
                        }
                    //add file Length
                }
            }
        }

        public void Open_Storage_Path(string filePath)
        {
            int enumeration = 1;
            string tempPath = filePath.Substring(0, filePath.IndexOf(".", StringComparison.Ordinal));
            string tempExtension = filePath.Substring(filePath.IndexOf(".", StringComparison.Ordinal), (filePath.Length - tempPath.Length));

            if (File.Exists(filePath))
            {
                while(File.Exists(tempPath + tempExtension))
                {
                    tempPath = filePath.Substring(0, filePath.IndexOf(".", StringComparison.Ordinal));
                    tempPath += "(" + enumeration + ")";
                    enumeration += 1;
                }
                filePath = tempPath + tempExtension;
            }
            fileWriter = new BinaryWriter(File.Open(filePath, FileMode.CreateNew));
        }

        public int GetNextChunk()
        {
            int byteTotal = 0;
            while (byteTotal < fileBuffer.Length || m_NetStream.DataAvailable)
            {
                int dataBytes = m_NetStream.Read(fileBuffer, byteTotal, (fileBuffer.Length - byteTotal));
                byteTotal += dataBytes;
            } 
            return byteTotal;

        }

        public void WriteChunkToFile(int bytesRead)
        {
            fileWriter.Write(fileBuffer, 0, bytesRead);
            dataLength -= (UInt32)bytesRead;
            fileBuffer = new byte[dataLength];
        }
        

        private void button_Find_Path_Click(object sender, EventArgs e)
        {
            //11.1_score : 0.1
            //folder_Browser_Dialog 띄우기
            this.folder_Browser_Dialog.ShowDialog();
            
            //선택한 경로 textBox에 나타냄
            storage_Path = this.folder_Browser_Dialog.SelectedPath;
            this.textBox_Storage_Path.Text = storage_Path;
        }

        private void button_Add_PlayList_Click(object sender, EventArgs e)
        {
            //11.2_score : 0.1
            if(textBox_Storage_Path.Text == "")
            {
                MessageBox.Show("파일을 다운로드 받을 위치를 정하지 않았습니다.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //누를경우 ListView의 선택한 것을 서버에 Music Name으로 보내 다운받기
            //ListView에 선택된것 확인하여 전송
            //패킷을 통해 Client_Request 전송
            ListView.SelectedListViewItemCollection col = 
                this.listView_Server_Music_List.SelectedItems;
            string musicName;
            foreach (ListViewItem item in col)
            {
                musicName = item.SubItems[0].Text;
                m_clientRequestClass.music_Name = musicName;
                MessageBox.Show("Client : musicName : " + musicName);
                //serialize
                ClientRequest.Serialize(m_clientRequestClass, sendBuffer.Length).CopyTo(sendBuffer, 0);
                this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.m_NetStream.Flush();
            }
            

            //이후는 receive_Thread에 의해 계속 리시브를 받고있음
        }

        private void form_Client_Load(object sender, EventArgs e)
        {
            this.textBox_IP.AppendText("192.168.18.2");
        }

        private void form_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            //해당 값들에 대해 널값이 아닌경우에만 실행하여 exit실행
            if (this.m_NetStream != null)
                this.m_NetStream.Close();
            if (this.m_Thread != null)
                this.m_Thread.Abort();
        }
    }
}
