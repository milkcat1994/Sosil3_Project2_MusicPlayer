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
using System.Collections;

using Shell32;      //ShellClass()사용 shell controls 참조 추가
using WMPLib;       //Windows Media Player 사용 위한 참조 추가

namespace HW2_Client_Form
{
    public partial class form_Client : Form
    {
        private Socket mySocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        private IPEndPoint point;
        //private TcpClient m_Client;

        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;

        private byte[] sendBuffer = new byte[1024 * 1];
        private byte[] readBuffer = new byte[1024 * 1];
        byte[] buffer = new byte[256];
        private byte[] fileBuffer = new byte[1024 * 1000];
        private string dataType;    //데이터 타입

        //server와의 연결이 되었는지 확인
        private bool m_blsConnect = false;

        //Thread 선언
        private Thread m_Thread = null;
        //receive Thread
        private Thread s_Thread = null;
        
        public BinaryWriter fileWriter;
        
        //data 길이 저장 위한 변수
        UInt32 dataLength;

        //파일 저장 경로
        string storage_Path;

        ArrayList player_ArrList = new ArrayList();

        WindowsMediaPlayer WMP = null;
        IWMPMedia media = null;
        IWMPPlaylist PlayList = null;
        IWMPPlaylistArray PlayListArray = null;
        int currentPlayindex = 1;
        int curPosition = 0;
        double curFile_Duration = 0;
        string curFile_Name = null;
        int thickTime = 0;

        /*
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
        */
        public form_Client()
        {
            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            //this.m_Client = new TcpClient();
            try
            {
                if (textBox_IP.Text == "" || textBox_Port.Text == "")
                    throw new ObjectDisposedException("null");
                IPAddress ip = IPAddress.Parse(this.textBox_IP.Text);
                point = new IPEndPoint(ip, Convert.ToInt32(this.textBox_Port.Text));
                //this.m_Client.Connect(this.textBox_IP.Text, Int32.Parse(this.textBox_Port.Text));
                mySocket.Connect(point);

                ns = new NetworkStream(mySocket);
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
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
            //this.m_NetStream = this.m_Client.GetStream();

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
            while (this.m_blsConnect)
            {
                try
                {
                    /*
                    //파일 타입 받기
                    mySocket.Receive(buffer);
                    dataType = System.Text.Encoding.UTF8.GetString(buffer);
                    */
                    dataType = sr.ReadLine();
                }
                catch
                {
                    this.m_blsConnect = false;
                    return;
                }
                
                //패킷 타입 분석 이후 패킷 종류에 따라 나눠서 사용함.
                //10.2_score : 1
                //Music List를 Server Music List에 추가시켜줌
                if (dataType.Equals("List"))
                {
                    String tempString;
                    /*
                    //노래제목
                    mySocket.Receive(buffer);
                    tempString = System.Text.Encoding.UTF8.GetString(buffer);
                    ListViewItem lv_Item = new ListViewItem(tempString);
                    //가수이름
                    mySocket.Receive(buffer);
                    tempString = System.Text.Encoding.UTF8.GetString(buffer);
                    lv_Item.SubItems.Add(tempString);
                    //플레이시간
                    mySocket.Receive(buffer);
                    tempString = System.Text.Encoding.UTF8.GetString(buffer);
                    lv_Item.SubItems.Add(tempString);
                    //음질
                    mySocket.Receive(buffer);
                    tempString = System.Text.Encoding.UTF8.GetString(buffer);
                    lv_Item.SubItems.Add(tempString);
                    */

                    //노래제목
                    tempString = sr.ReadLine();
                    ListViewItem lv_Item = new ListViewItem(tempString);
                    //가수이름
                    tempString = sr.ReadLine();
                    lv_Item.SubItems.Add(tempString);
                    //플레이시간
                    tempString = sr.ReadLine();
                    lv_Item.SubItems.Add(tempString);
                    //음질
                    tempString = sr.ReadLine();
                    lv_Item.SubItems.Add(tempString);

                    this.listView_Server_Music_List.Items.Add(lv_Item);
                }
                //서버로 부터 파일을 전송받아 해당 경로에 파일 생성
                //12_1_score : 1
                else if(dataType.Equals("Music_File")) {

                    //파일 크기 수신
                    /*
                    mySocket.Receive(buffer);
                    int fileLength = BitConverter.ToInt32(buffer, 0);
                    */
                    string tempString = sr.ReadLine();
                    int fileLength = Convert.ToInt32(tempString);
                    label2.Text = tempString;
                    int totalLength = 0;
                    /*
                    //파일 이름 수신
                    mySocket.Receive(buffer);
                    string music_Name = System.Text.Encoding.UTF8.GetString(buffer);//노래이름
                    mySocket.Receive(buffer);
                    string music_Singer = System.Text.Encoding.UTF8.GetString(buffer);//가수
                    mySocket.Receive(buffer);
                    string play_Time = System.Text.Encoding.UTF8.GetString(buffer);//플레이시간
                    mySocket.Receive(buffer);
                    string bit_Rate = System.Text.Encoding.UTF8.GetString(buffer);//플레이시간
                    mySocket.Receive(buffer);
                    */

                    //노래제목
                    string music_Name = sr.ReadLine();
                    ListViewItem lv_Item = new ListViewItem(music_Name);
                    //가수이름
                    string music_Singer = sr.ReadLine();
                    lv_Item.SubItems.Add(music_Singer);
                    //플레이시간
                    string play_Time = sr.ReadLine();
                    lv_Item.SubItems.Add(play_Time);
                    //음질
                    string bit_Rate = sr.ReadLine();
                    lv_Item.SubItems.Add(bit_Rate);
                    

                    //open and create storage Path
                    string storage_File = textBox_Storage_Path.Text.ToString() + "\\" + music_Name + ".mp3";
                    storage_File.Replace("\\","\\\\");
                    FileStream stream = new FileStream(storage_File, FileMode.Create, FileAccess.Write);
                    //stream = File.Open(storage_File, FileMode.Append);

                    BinaryWriter writer = new BinaryWriter(stream);
                    int count=0;
                    while (totalLength < fileLength)
                    {
                        int receiveLength = mySocket.Receive(readBuffer);
                        writer.Write(readBuffer, 0, receiveLength);
                        totalLength += receiveLength;
                        label1.Text = ("success" + count++);
                        progressBar_Download.Value = Convert.ToInt32(((double)totalLength / (double)fileLength) * 100);
                    }
                    //stream.Write(m_serverMusicClass.buffer, 0, m_serverMusicClass.buffer.Length);
                    stream.Close();
                    writer.Close();
                    //13_1_score : 0.8

                    //해당 파일 전송 완료 패킷을 받고, Play List View에 해당 파일 추가
                    this.listView_Play_List.Items.Add(lv_Item);

                    //array List 에 받은 데이터 삽입
                    player_ArrList.Add(music_Name);
                    MessageBox.Show("Client : Complete Download");
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
        /*
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
        */
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

            //12.1_score : 1
            //누를경우 ListView의 선택한 것을 서버에 Music Name으로 보내 다운받기
            //ListView에 선택된것 확인하여 전송
            //패킷을 통해 Client_Request 전송
            ListView.SelectedListViewItemCollection col = 
                this.listView_Server_Music_List.SelectedItems;
            string musicName;
            foreach (ListViewItem item in col)
            {
                musicName = item.SubItems[0].Text;
//                string tempString = musicName;
//                mySocket.Send(System.Text.Encoding.UTF8.GetBytes(tempString));

                sw.WriteLine("Client_Request");
                sw.WriteLine(musicName);
                sw.Flush();
                //MessageBox.Show("Client : musicName : " + musicName);
            }
            

            //이후는 receive_Thread에 의해 계속 리시브를 받고있음
        }


        private void button_Music_Play_Click(object sender, EventArgs e)
        {
            //이미 WMP가 있다면
            if (WMP != null)
            {
                WMP.controls.play();
                return;
            }
            WMP = new WindowsMediaPlayer();
            PlayList = WMP.newPlaylist("MusicPlayer", "");

            //현재 플레이리스트 지정
            WMP.currentPlaylist = PlayList;

            for (int i = 0; i < player_ArrList.Count; i++)
            {
                string storage_File = textBox_Storage_Path.Text.ToString() + "\\" + player_ArrList[i] + ".mp3";
                storage_File.Replace("\\", "\\\\");
                media = WMP.newMedia(storage_File);
                //재생 목록에 추가
                PlayList.appendItem(media);
            }
            
            string music_name = listView_Play_List.FocusedItem.SubItems[0].Text;
            //arrlist내 해당 파일 index가져오기
            int arrList_index = player_ArrList.IndexOf(music_name);
            //현재 Playindex를 arrList_index만큼 증가시키기
            while (arrList_index >= currentPlayindex) {
                currentPlayindex += 1;
                WMP.controls.next();
            }
            //14.2_score : 0.3
            //현재 가리킨 음악 재생
            WMP.controls.play();
            curFile_Duration = WMP.currentMedia.duration;
            MessageBox.Show("Client : duration ->" + curFile_Duration);
            time_TrackBar_Increase.Start();
        }

        private void button_Music_Pause_Click(object sender, EventArgs e)
        {
            WMP.controls.pause();
            label1.Text = trackBar_Music_Player.Value.ToString();
            label2.Text = WMP.controls.currentPosition.ToString();
        }

        private void button_Music_Stop_Click(object sender, EventArgs e)
        {
            WMP.controls.stop();
        }

        //16.1_score : 0.3
        //삭제할 항목 선택후 버튼 클릭시 해당 ListView item 삭제
        private void button_Remove_PlayList_Click(object sender, EventArgs e)
        {
            if(listView_Play_List != null)
            {
                string music_name = listView_Play_List.FocusedItem.SubItems[0].Text;
                //arrlist내 해당 파일 index가져오기
                int arrList_index = player_ArrList.IndexOf(music_name);
                //현재 재생 index와 list내 index 동일시 오류 메시지 출력
                if (arrList_index == currentPlayindex)
                {
                    MessageBox.Show("현재 재생중인 곡은 삭제할 수 없습니다.");
                    return;
                }
                listView_Play_List.FocusedItem.Remove();
                player_ArrList.Remove(music_name);
            }
        }

        //15.1_score : 0.1
        //15.3_score : 0.1
        private void button_Previous_Music_Click(object sender, EventArgs e)
        {
            //WMPLib.IWMPPlaylist plThreeList =;
            PlayListArray = WMP.playlistCollection.getByName("MusicPlayer");
            if(currentPlayindex == 1)
            {
                MessageBox.Show("리스트의 첫곡입니다.");
                return;
            }
            currentPlayindex -= 1;
            WMP.controls.stop();
            WMP.controls.previous();
            WMP.controls.play();
        }

        //15.2_score : 0.1
        //15.3_score : 0.1
        private void button_Next_Music_Click(object sender, EventArgs e)
        {
            int temCount = player_ArrList.Count;
            MessageBox.Show("Client temCount : " + temCount 
                +"\n currentPlayindex : " + currentPlayindex);
            //왜 -1일까여..
            if (currentPlayindex >= (temCount))
            {
                MessageBox.Show("리스트의 마지막곡입니다.");
                return;
            }
            currentPlayindex += 1;
            WMP.controls.stop();
            WMP.controls.next();
            WMP.controls.play();
        }

        private void trackBar_Music_Player_Scroll(object sender, EventArgs e)
        {
            curPosition = trackBar_Music_Player.Value;
            WMP.controls.currentPosition = (double)curPosition * (curFile_Duration/(double)400);
            trackBar_Music_Player.Value =
                (int)(WMP.controls.currentPosition * ((double)400 / curFile_Duration));
        }

        private void form_Client_Load(object sender, EventArgs e)
        {
            this.textBox_IP.AppendText("192.168.18.2");
        }
        
        private void form_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            //해당 값들에 대해 널값이 아닌경우에만 실행하여 exit실행
            if (this.m_Thread != null)
                this.m_Thread.Abort();
            if (this.ns != null)
                this.ns.Close();
            if (this.WMP != null)
                WMP.controls.stop();
        }
        
        //TrackBar 수정해주는 timer
        //14.4_score : 0.2
        private void time_TrackBar_Increase_Tick(object sender, EventArgs e)
        {
            time_TrackBar_Increase.Interval = (int)((double)1000 * (WMP.currentMedia.duration/(double)400));
            curFile_Duration = WMP.currentMedia.duration;
            label3.Text = WMP.currentMedia.duration.ToString();
            if (curFile_Duration == 0) return;

            //PlayList.get_Item(0);
            trackBar_Music_Player.Value = 
                (int)(WMP.controls.currentPosition * ((double)400 / curFile_Duration));
            if (trackBar_Music_Player.Value == 399)
            {
                if (currentPlayindex > player_ArrList.Count)
                    return;
                currentPlayindex += 1;
            }
        }
        
    }
}
