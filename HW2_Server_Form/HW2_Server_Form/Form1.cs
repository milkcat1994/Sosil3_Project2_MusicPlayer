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
using System.IO;    //DirectoryInfo사용
using System.Net;
using System.Net.Sockets;
using System.Threading;

using Shell32;      //ShellClass()사용 shell controls 참조 추가
using WMPLib;       //Windows Media Player 사용 위한 참조 추가

namespace HW2_Server_Form
{
    public partial class form_Server : Form
    {
        private TcpListener m_Listener = null;
        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;

        public const int little_buf_size = 1024;
        private byte[] sendBuffer = new byte[1024 * 1];
        private byte[] readBuffer = new byte[1024 * 1];
        private byte[] fileBuffer = new byte[1024 * 1000];
        byte[] buffer = new byte[256];
        private string dataType;
        private bool m_blsClientOn = false;

        private Thread m_Thread = null;
        private Thread f_Thread = null;

        //Client, IP, Port
        Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint point;
        private String WanIP;
        int port;

        //Folder Browser value
        //-->Foler_Browser_Dialog foler_Browser_Dialog;
        // mp3 file storage_Path in server
        string storage_Path;

        Folder folder;
        DirectoryInfo di;
        //file Read위한 변수
        FileStream fileReader;
        Stream output;
        

        public form_Server()
        {
            InitializeComponent();
        }
        /*
        //Packet Send Function
        public void Send()
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();
            int i = 0;
            while (sendBuffer[i++] != 0)
            {
                this.sendBuffer[i] = 0;
            }
        }
        */

        public string Get_My_IP_Wan()
        {
            //아이피 주소 획득
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

        //button_Server_Start_Click 에 의해 스래드로 실행됨
        public void RUN()
        {
            //Get_My_IP_Wan을 Form_Load를 통해 사용하여 ip주소값 저장, Listener실행
            IPAddress ip = IPAddress.Parse(WanIP);
            //this.m_Listener = new TcpListener(ip, port);
            //this.m_Listener.Start();

            //7.1_score : 0.3
            //클라이언트가 없다면 text 출력
            if (!this.m_blsClientOn)
                this.textBox_Music_Log.AppendText("Waiting For Client Access...\n");

            while (true)
            {
                point = new IPEndPoint(ip, port);
                Client.Bind(point);
                //소켓 대기상태
                Client.Listen(1);
                Client = Client.Accept();
                //클라이언트의 접속을 기다려 접속시 Client 소켓 정보 초기화
                //Client = this.m_Listener.AcceptSocket();

                //클라이언트 접속시 실행
                if (Client.Connected)
                {
                    ns = new NetworkStream(Client);
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);

                    this.m_blsClientOn = true;
                    this.textBox_Music_Log.AppendText("Client Access!!!\n");

                    //8.1_score : 0.3
                    //접속시 등록된 Music List를 전송
                    get_File_Name("client");
                    this.textBox_Music_Log.AppendText
                        ("send all success\n");

                }

                while (this.m_blsClientOn)
                {
                    try
                    {
                        //파일의 타입을 맨 처음 전송 받음
                        dataType = sr.ReadLine();
                        this.textBox_Music_Log.AppendText
                            ("Server dataType : " + dataType + "\n");
                        //Client.Receive(buffer);
                        //                        dataType = BitConverter.ToString(buffer);
                    }
                    catch
                    {
                        this.m_blsClientOn = false;
                        return;
                    }


                    //패킷 타입 분석 이후 패킷 종류에 따라 나눠서 사용함.
                    if (dataType.Equals("List"))
                    {

                    }
                    else if (dataType.Equals("Client_Request"))
                    {
                        //8.2_score : 1
                        //클라요청은 음악 이름을 받음
                        //                        Client.Receive(buffer);
                        //                       this.sendMp3FiletoClient(BitConverter.ToString(buffer));
                        //뮤직 이름 전송 위한 수신
                        string tempString = sr.ReadLine();
                        //MessageBox.Show("Server : get musicName");
                        this.sendMp3FiletoClient(tempString);
                    }
                }
            }
        }


        private void button_Server_Start_Click(object sender, EventArgs e)
        {
            if(button_Server_Start.Text.Equals("Stop"))
            {
                object a=null;
                FormClosedEventArgs fce = null;
                form_Server_FormClosed(a, fce);
            }
            if (textBox_Storage_Path.Text == "")
            {//5.2_score : 0.1
                MessageBox.Show("전송 가능한 MP3 파일이 없습니다. 경로를 다시 지정하십시오.","Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }
            //스래드로 RUN함수 실행
            this.m_Thread = new Thread(new ThreadStart(RUN));
            this.m_Thread.Start();
            //7.1_score : 0.3
            //Log 추가 및 button의 text 수정
            textBox_Music_Log.AppendText("Server - Start\n");
            textBox_Music_Log.AppendText("Storage Path : " + this.storage_Path + "\n");
            button_Server_Start.Text = "Stop\n";
        }     
        
        public void get_File_Name(string destination)
        {
            if (destination.Equals("server"))
            {
                //사용시 참조중 Shell32의 속성에서 interop를 false로 수정
                ShellClass sc = new ShellClass();
                folder = sc.NameSpace(storage_Path);
                di = new DirectoryInfo(storage_Path);
                //기존 listView 내용 삭제
                listView_Music_List.Items.Clear();
                //내부 파일 확인, .mp3의 확장명이 아니라면 listView에 저장하지 않음
                foreach (var item in di.GetFiles())
                {
                    if (item.Extension.Equals(".mp3"))
                    {
                        FolderItem folder_Item = folder.ParseName(item.Name);
                        ListViewItem lv_Item = new ListViewItem(folder.GetDetailsOf(folder_Item, 0));//노래이름
                        lv_Item.SubItems.Add(folder.GetDetailsOf(folder_Item, 20));//가수
                        lv_Item.SubItems.Add(folder.GetDetailsOf(folder_Item, 27));//Play Time
                        lv_Item.SubItems.Add(folder.GetDetailsOf(folder_Item, 28));//Bit Rate
                        //server쪽 listView에 위에서 저장된 정보 저장
                        listView_Music_List.Items.Add(lv_Item);
                    }
                }
            }
            else if (destination.Equals("client"))
            {
                String tempString;
//                Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));
                //내부 파일 확인, .mp3의 확장명이 아니라면 listView에 저장하지 않음
                foreach (var item in di.GetFiles())
                {
                    if (item.Extension.Equals(".mp3"))
                    {
                        /*
                        //MessageBox.Show("Server : Make MusicList");
                        FolderItem folder_Item = folder.ParseName(item.Name);
                        tempString = folder.GetDetailsOf(folder_Item, 0);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//노래이름
                        tempString = folder.GetDetailsOf(folder_Item, 20);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//가수
                        tempString = folder.GetDetailsOf(folder_Item, 27);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//Play Time
                        tempString = folder.GetDetailsOf(folder_Item, 28);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//Bit Rate
                        */

                        tempString = "List";
                        //파일 타입이 List임을 전송
                        sw.WriteLine(tempString);

                        FolderItem folder_Item = folder.ParseName(item.Name);
                        tempString = folder.GetDetailsOf(folder_Item, 0);
                        sw.WriteLine(tempString);//노래이름
                        tempString = folder.GetDetailsOf(folder_Item, 20);
                        sw.WriteLine(tempString);//가수
                        tempString = folder.GetDetailsOf(folder_Item, 27);
                        sw.WriteLine(tempString);//Play Time
                        tempString = folder.GetDetailsOf(folder_Item, 28);
                        sw.WriteLine(tempString); ;//Bit Rate
                        sw.Flush();
                        //serialize
                        //MessageBox.Show("Server : pre Serialize");
                        // MusicList.Serialize(musicL, sendBuffer.Length).CopyTo(sendBuffer, 0);

                        this.textBox_Music_Log.AppendText("Send Success Music Name : " + folder.GetDetailsOf(folder_Item, 0) +"\n");
                        //this.send()
                    }
                }
            }
        }

        //8.2_score : 1
        //클라이언트가 요청한 file name 파일을 전송한다.
        //file name을 인자로 받아 해당 파일 listview에서 검색 뒤 경로 전송
        public void sendMp3FiletoClient(string fileName)
        {            
            //내부 파일 확인, .mp3의 확장명이 아니라면 listView에 저장하지 않음
            foreach (var item in di.GetFiles())
            {
                if (item.Extension.Equals(".mp3"))
                {
                    //Client Request의 음악 이름이 아닌경우 패스!
                    if (item.Name.Equals(fileName + ".mp3"))
                    {
                        String tempString;
                        tempString = "Music_File";
                        sw.WriteLine(tempString);
                        //파일 타입 전송
//                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));

                        FolderItem folder_Item = folder.ParseName(item.Name);
                        
                        //해당 파일의 경로 저장
                        string requestedFile_Path = ( storage_Path + "\\" + item.Name );
                        //SendFileData
                        //file 열고 읽어오기

                        fileReader = new FileStream(requestedFile_Path, FileMode.Open, FileAccess.Read);

                        // 패킷 내용을 바일 크기 받는것 추가시키기
                        int fileLength = (int)fileReader.Length;
                        //파일 보낼 횟수
                        int count = fileLength / 1024 + 1;
                        //파일 읽기 위한 BinaryReader 객체 생성
                        BinaryReader reader = new BinaryReader(fileReader);
                        //파일 크기 전송 위해 바이트 배열로 전환
                        buffer = BitConverter.GetBytes(fileLength);
                        sw.WriteLine(fileLength);
                        /*
                        //파일 크기 전송
                        Client.Send(buffer);
                        //파일 정보 전송
                        tempString = folder.GetDetailsOf(folder_Item, 0);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//노래이름
                        tempString = folder.GetDetailsOf(folder_Item, 20);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//가수
                        tempString = folder.GetDetailsOf(folder_Item, 27);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//Play Time
                        tempString = folder.GetDetailsOf(folder_Item, 28);
                        Client.Send(System.Text.Encoding.UTF8.GetBytes(tempString));//Bit Rate
                        */

                        tempString = folder.GetDetailsOf(folder_Item, 0);
                        sw.WriteLine(tempString);//노래이름
                        tempString = folder.GetDetailsOf(folder_Item, 20);
                        sw.WriteLine(tempString);//가수
                        tempString = folder.GetDetailsOf(folder_Item, 27);
                        sw.WriteLine(tempString);//Play Time
                        tempString = folder.GetDetailsOf(folder_Item, 28);
                        sw.WriteLine(tempString); ;//Bit Rate
                        sw.Flush();

                        //MessageBox.Show("server 전송 시작");
                        for (int i =0; i< count; i++)
                        {
                            sendBuffer = reader.ReadBytes(1024);
                            //읽은 길이만큼 클라로 전송
                            Client.Send(sendBuffer);
                        }
                        fileReader.Close();
                        reader.Close();

                        MessageBox.Show("server 전송 완료");

                        /*
                        //해당 파일의 끝임을 알림
                        EndStream endstream = new EndStream();
                        endstream.Type = (int)PacketType.end_Stream;
                        endstream.music_Name = folder.GetDetailsOf(folder_Item, 0);//노래이름
                        endstream.music_Singer = folder.GetDetailsOf(folder_Item, 20);//가수
                        endstream.music_Play_Time = folder.GetDetailsOf(folder_Item, 27);//Play Time
                        endstream.music_Bit_Rate = folder.GetDetailsOf(folder_Item, 28);//Bit Rate
                        
                        EndStream.Serialize(endstream, sendBuffer.Length).CopyTo(this.sendBuffer, 0);
                        m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                        this.m_NetStream.Flush();
                        reader.Dispose();
                        */

                        /*
                        UInt32 toRead = (UInt32)fileReader.Length;
                        byte[] dataSize = BitConverter.GetBytes(toRead);
                        serMusic.buffer = new byte[sizeof(UInt32)];
                        
                        dataSize.CopyTo(serMusic.buffer, 0);
                        //this. m_NetStream.Write(serMusic.buffer, 0, serMusic.buffer.Length);
                        
                        //SendFile
                        UInt32 fileSizeInBytes = (UInt32)fileReader.Length;
                        int numberOfBytesRead = 0;
                        
                        //setByteArray
                        fileBuffer = new byte[MAX_BYTE_SIZE];

                        //Packet화 -> 다 안씌이면 어떡하죵...?
                        Packet.Serialize(serMusic).CopyTo(this.fileBuffer, 0);

                        while (numberOfBytesRead < fileSizeInBytes)
                        {
                            //WriteFileToStream
                            numberOfBytesRead += WriteFileToStream(fileSizeInBytes);
                        }
                        fileReader.Close();

                        //여기까지가 본코드
                        //server쪽 listView에 위에서 저장된 정보 저장
                        */
                        return;
                    }
                }
            }
        }

        /*
        public int WriteFileToStream(UInt32 fileSizeInBytes)
        {
            int done = fileReader.Read(this.fileBuffer, 0, this.fileBuffer.Length);
            this.m_NetStream.Write(this.fileBuffer, 0, this.fileBuffer.Length);
            this.m_NetStream.Flush();
            return done;
        }
        */

        private void button_Find_Path_Click(object sender, EventArgs e)
        {
            //6.1_score : 0.1
            //this.foler_Browser_Dialog = new FolderBrowserDialog();
            this.folder_Browser_Dialog.ShowDialog();

            //6.2_score : 1
            //선택한 경로 textBox에 나타냄 및 get_File_Name 이용해 ListView에 나타냄
            storage_Path = this.folder_Browser_Dialog.SelectedPath;
            this.textBox_Storage_Path.Text = storage_Path;

            get_File_Name("server");
        }

        private void form_Server_Load(object sender, EventArgs e)
        {
            //5.1_score : 0.2
            //get my ip
            this.textBox_IP.AppendText(Get_My_IP_Wan());

            //5.1_score : 0.2
            //get port
            Random randNum = new Random();
            port = randNum.Next(7000, 7999);
            this.textBox_Port.Text = port.ToString();
        }

        private void form_Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            //해당 값들에 대해 널값이 아닌경우에만 실행하여 exit실행
            if (this.m_Listener != null)
                this.m_Listener.Stop();
            if (this.m_Thread != null)
                this.m_Thread.Abort();
            if (this.ns != null)
                this.ns.Close();
            if (this.fileReader != null)
                this.fileReader.Close();
        }
    }
}
