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
        private Socket Client = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        private IPEndPoint point;
        //private TcpClient m_Client;

        private NetworkStream netStream;
        private StreamReader streamR;
        private StreamWriter streamW;

        public const int little_buf_size = 1024;
        private byte[] sendBuffer = new byte[little_buf_size * 1];
        private byte[] readBuffer = new byte[little_buf_size * 1];
        byte[] buffer = new byte[256];
        private string dataType;    //데이터 타입

        //server와의 연결이 되었는지 확인
        private bool m_blsConnect = false;

        //Thread 선언
        private Thread m_Thread = null;

        //파일 저장 경로
        string storage_Path;

        ArrayList player_ArrList = new ArrayList();

        //Media 재생에 필요한 변수
        WindowsMediaPlayer WMP = null;
        IWMPMedia media = null;
        IWMPPlaylist PlayList = null;
        int currentPlayindex = 1;   //current PlayList index
        int curPosition = 0;        //current trackBar_Value
        double curFile_Duration = 0;//current file whole time
        int flag=3;  //Play Option_ Default : one cycle List

        public form_Client()
        {
            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_Connect.Text.Equals("DisConnect"))
                {
                    Client.Close();
                    button_Connect.Text = "Connect";
                    this.button_Connect.ForeColor = Color.Black;
                    listView_Server_Music_List.Items.Clear();
                    return;
                }
                //IP, Port입력에 따른 예외처리
                //Client.Connect(point)의 실패에 따른 예외처리 구간
                if (textBox_IP.Text == "" || textBox_Port.Text == "")
                    throw new ObjectDisposedException("null");
                IPAddress ip = IPAddress.Parse(this.textBox_IP.Text);
                //연결지점 설정
                point = new IPEndPoint(ip, Convert.ToInt32(this.textBox_Port.Text));
                //해당 IP, Port와의 연결 시도
                Client.Connect(point);

                //성공시 3개의 Stream 초기화
                netStream = new NetworkStream(Client);
                streamR = new StreamReader(netStream);
                streamW = new StreamWriter(netStream);
            }//IP, Port가 입력되지 않았을 경우
            catch(ObjectDisposedException ode)
            {
                //9.1_score : 0.1
                //IP 또는 Port가 입력되지 않고 Connect 버튼이 눌린경우
                MessageBox.Show("IP 혹은 Port Number가 설정되지 않았습니다.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }//연결이 오류일 경우
            catch (SocketException se)
            {
                MessageBox.Show("socketException");
                return;
            }//Server가 없을 경우
            catch (ArgumentNullException ane)
            {
                //9.2_score : 0.1
                //Server가 Start되지 않은 경우
                MessageBox.Show("Can not Connection...");
                return;
            }
            //연결 완료시 true로 변경
            this.m_blsConnect = true;

            //Changed Button Text
            this.button_Connect.Text = "DisConnect";
            this.button_Connect.ForeColor = Color.Red;

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
                    dataType = streamR.ReadLine();
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
                    //노래제목
                    tempString = streamR.ReadLine();
                    //한 리스트를 다 받고 난뒤 리스트의 마지막일 경우 List에 해당하는 루프를 빠져나옴
                    ListViewItem lv_Item = new ListViewItem(tempString);
                    //가수이름
                    tempString = streamR.ReadLine();
                    lv_Item.SubItems.Add(tempString);
                    //플레이시간
                    tempString = streamR.ReadLine();
                    lv_Item.SubItems.Add(tempString);
                    //음질
                    tempString = streamR.ReadLine();
                    lv_Item.SubItems.Add(tempString);

                    this.listView_Server_Music_List.Items.Add(lv_Item);
                }
                //서버로 부터 파일을 전송받아 해당 경로에 파일 생성
                //12_1_score : 1
                else if(dataType.Equals("Music_File")) {

                    //파일 크기 수신
                    string tempString = streamR.ReadLine();
                    int fileLength = Convert.ToInt32(tempString);
                    int totalLength = 0;

                    //노래제목
                    string music_Name = streamR.ReadLine();
                    ListViewItem lv_Item = new ListViewItem(music_Name);
                    //가수이름
                    string music_Singer = streamR.ReadLine();
                    lv_Item.SubItems.Add(music_Singer);
                    //플레이시간
                    string play_Time = streamR.ReadLine();
                    lv_Item.SubItems.Add(play_Time);
                    //음질
                    string bit_Rate = streamR.ReadLine();
                    lv_Item.SubItems.Add(bit_Rate);
                    
                    
                    //open and create storage Path
                    string storage_File = textBox_Storage_Path.Text.ToString() + "\\" + music_Name + ".mp3";
                    storage_File.Replace("\\","\\\\");
                    FileStream stream = new FileStream(storage_File, FileMode.Create, FileAccess.Write);

                    BinaryWriter writer = new BinaryWriter(stream);
                    while (totalLength < fileLength)
                    {
                        int receiveLength = Client.Receive(readBuffer);
                        writer.Write(readBuffer, 0, receiveLength);
                        totalLength += receiveLength;
                        //12.2_score : 0.3
                        progressBar_Download.Value = Convert.ToInt32(((double)totalLength / (double)fileLength) * 100);
                    }
                    stream.Close();
                    writer.Close();
                    //13_1_score : 0.8

                    //해당 파일 전송 완료 패킷을 받고, Play List View에 해당 파일 추가
                    this.listView_Play_List.Items.Add(lv_Item);

                    //array List 에 받은 데이터 삽입
                    player_ArrList.Add(music_Name);
                    //add file Length
                }
            }
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

                streamW.WriteLine("Client_Request");
                streamW.WriteLine(musicName);
                streamW.Flush();
            }
            //이후는 receive_Thread에 의해 계속 리시브를 받고있음
        }


        //17.1_score : 1
        private void button_File_UpLoad_Click(object sender, EventArgs e)
        {
            this.open_File_Dialog.ShowDialog();
            //전체 경로
            string full_file_path = open_File_Dialog.FileName;
            //확장자포함 파일이름
            string file_name = open_File_Dialog.SafeFileName;
            //경로
            string path_name = full_file_path.Substring(0, (full_file_path.Length - file_name.Length));
            FileStream fileReader = new FileStream(full_file_path, FileMode.Open, FileAccess.Read);

            //client가 업로드함을 알림
            streamW.WriteLine("Client UpLoad");


            // 패킷 내용을 바일 크기 받는것 추가시키기
            int fileLength = (int)fileReader.Length;
            //파일 보낼 횟수
            int count = fileLength / little_buf_size + 1;
            //파일 읽기 위한 BinaryReader 객체 생성
            BinaryReader reader = new BinaryReader(fileReader);
            //파일 크기 전송 위해 바이트 배열로 전환
            buffer = BitConverter.GetBytes(fileLength);
            streamW.WriteLine(fileLength);
            streamW.Flush();

            ShellClass sc = new ShellClass();
            Folder folder = sc.NameSpace(path_name);
            FolderItem folder_Item = folder.ParseName(file_name);

            String tempString = folder.GetDetailsOf(folder_Item, 0);
            streamW.WriteLine(tempString);//노래이름
            tempString = folder.GetDetailsOf(folder_Item, 20);
            streamW.WriteLine(tempString);//가수
            tempString = folder.GetDetailsOf(folder_Item, 27);
            streamW.WriteLine(tempString);//Play Time
            tempString = folder.GetDetailsOf(folder_Item, 28);
            streamW.WriteLine(tempString); ;//Bit Rate
            streamW.Flush();

            //파일 전송 시작
            for (int i = 0; i < count; i++)
            {
                sendBuffer = reader.ReadBytes(little_buf_size);
                //읽은 길이만큼 클라로 전송
                Client.Send(sendBuffer);
            }

            fileReader.Close();
            reader.Close();

            //For get all ListView items from Server
            listView_Server_Music_List.Items.Clear();
        }

        private void button_Music_Play_Click(object sender, EventArgs e)
        {
            //이미 WMP가 있다면
            if (WMP != null)
            {
                //14.3_score:0.1
                //Play, Pause상태에 따라 image 변경
                //Play button image == Play
                if (button_Music_Play.ImageIndex == 0)
                {
                    if (listView_Play_List.FocusedItem != null)
                    {
                        //선택된 항목 재생하기
                        string music_name_2 = listView_Play_List.FocusedItem.SubItems[0].Text;
                        //arrlist내 해당 파일 index가져오기
                        int arrList_index1 = player_ArrList.IndexOf(music_name_2);
                        //Increase Play List index to Selected index
                        if (arrList_index1 >= currentPlayindex)
                        {
                            while (arrList_index1 >= currentPlayindex)
                            {
                                currentPlayindex += 1;
                                WMP.controls.stop();
                                WMP.controls.next();
                            }
                        }
                        //Decrease Play List index to Selected index
                        else if (arrList_index1 + 1 < currentPlayindex)
                        {
                            while (arrList_index1 + 1 < currentPlayindex)
                            {
                                currentPlayindex -= 1;
                                WMP.controls.stop();
                                WMP.controls.previous();
                            }
                        }
                    }
                    //change image to Play
                    button_Music_Play.ImageIndex = 1;
                    time_TrackBar_Increase.Start();
                    WMP.controls.play();
                }
                //Play button image == Pause
                else if (button_Music_Play.ImageIndex == 1)
                {
                    //change image to Play
                    button_Music_Play.ImageIndex = 0;
                    time_TrackBar_Increase.Stop();
                    WMP.controls.pause();
                }
                return;
            }

            WMP = new WindowsMediaPlayer();
            WMP.controls.pause();
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
            
            string music_name_1 = listView_Play_List.FocusedItem.SubItems[0].Text;
            //arrlist내 해당 파일 index가져오기
            int arrList_index_2 = player_ArrList.IndexOf(music_name_1);
            //현재 Playindex를 arrList_index만큼 증가시키기
            while (arrList_index_2 >= currentPlayindex) {
                currentPlayindex += 1;
                WMP.controls.next();
            }

            //14.2_score : 0.3
            //현재 가리킨 음악 재생
            WMP.controls.play();

            //14.1_score : 0.1
            //현재 재생중인 음악 제목 표시
            label_Music_Name.Text = WMP.controls.currentItem.name;

            //change image to Pause
            button_Music_Play.ImageIndex = 1;

            //현재 파일 위치 체크
            curFile_Duration = WMP.currentMedia.duration;
            //재생량에 따른 TrackBar 증가 tick 시작
            time_TrackBar_Increase.Start();
        }
        
        private void button_Music_Stop_Click(object sender, EventArgs e)
        {
            //WMP Player stop
            WMP.controls.stop();
            //Stop timer
            time_TrackBar_Increase.Stop();
            //TrackBar Value set 0
            trackBar_Music_Player.Value = 0;
            //Change button to Play
            button_Music_Play.ImageIndex = 0;
            //Set default Time
            label_time.Text = "00:00";
            label_Music_Name.Text = "선택된 곡이 없습니다.";
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
                if (arrList_index+1 == currentPlayindex)
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
            //check Firsst music
            if (currentPlayindex == 1)
            {
                MessageBox.Show("리스트의 첫곡입니다.");
                return;
            }
            currentPlayindex -= 1;
            WMP.controls.stop();
            WMP.controls.previous();
            WMP.controls.play();
            //14.1_score : 0.1
            label_Music_Name.Text = WMP.controls.currentItem.name;
        }

        //15.2_score : 0.1
        //15.3_score : 0.1
        private void button_Next_Music_Click(object sender, EventArgs e)
        {
            //Save Size PlayList
            int temCount = player_ArrList.Count;

            //17.2_score : 0.5*3
            //check flag_ Play Option
            switch (flag)
            {
                case 1:
                    break;
                case 2:
                    //Decrease Play List index to Selected index
                    //play First Music
                    MessageBox.Show("currentindex:"+currentPlayindex.ToString() + "\ntemCount:"+temCount);
                    if (currentPlayindex == temCount)
                    {
                        while (1 < currentPlayindex)
                        {
                            currentPlayindex -= 1;
                            WMP.controls.stop();
                            WMP.controls.previous();
                        }
                        WMP.controls.play();
                        return;
                    }
                    break;
                case 3:
                    break;
            }

            //check Last music
            if (currentPlayindex >= (temCount))
            {
                MessageBox.Show("리스트의 마지막곡입니다.");
                return;
            }
            currentPlayindex += 1;
            WMP.controls.stop();
            WMP.controls.next();
            WMP.controls.play();
            //14.1_score : 0.1
            label_Music_Name.Text = WMP.controls.currentItem.name;
        }

        private void trackBar_Music_Player_Scroll(object sender, EventArgs e)
        {
            curPosition = trackBar_Music_Player.Value;
            WMP.controls.currentPosition = (double)curPosition * (curFile_Duration/(double)400);
            trackBar_Music_Player.Value =
                (int)(WMP.controls.currentPosition * ((double)400 / curFile_Duration));
        }

        //17.2_score : 0.5*3
        private void radioButton_Option_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;
            switch (selectedRadioButton.Name)
            {
                //replay one music
                case "radioButton_Option_one":
                    flag = 1;
                    break;
                //play always all List
                case "radioButton_Option_List":
                    flag = 2;
                    break;
                //play Only One Cycle List
                case "radioButton_Option_List_One":
                    flag = 3;
                    break;
            }
        }

        private void form_Client_Load(object sender, EventArgs e)
        {
            //select the image to Form Load
            button_Music_Play.ImageIndex = 0;
        }
        
        private void form_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            //해당 값들에 대해 널값이 아닌경우에만 실행하여 exit실행
            if (this.m_Thread != null)
                this.m_Thread.Abort();
            if (this.WMP != null)
                this.WMP.controls.stop();
            if(this.Client != null)
                this.Client.Close();
            if (this.netStream != null)
                this.netStream.Close();
            if (this.streamR != null)
                this.streamR.Close();
            if (this.streamW != null)
                this.streamW.Close();
        }
        
        //TrackBar 수정해주는 timer
        //14.4_score : 0.2
        private void time_TrackBar_Increase_Tick(object sender, EventArgs e)
        {
            //trackBar 증가 Timer의 주기를 곡의 길이에 따라 수정하여 trackBar의 맥시멈 크기만큼 분할하여
            //해당 크기 만큼의 실행을 하도록 한다.
            curFile_Duration = WMP.currentMedia.duration;
            if (curFile_Duration == 0) return;
            time_TrackBar_Increase.Interval =
                (int)((double)1000 * (WMP.currentMedia.duration / (double)trackBar_Music_Player.Maximum));

            //Print Current Time Value
            int currentPlaytime = (int)WMP.controls.currentPosition;
            int minute = currentPlaytime / 60;
            int second = currentPlaytime % 60;
            label_time.Text = minute.ToString() + ":" + second.ToString();
            
            //PlayList.get_Item(0);
            trackBar_Music_Player.Value = 
                (int)(WMP.controls.currentPosition * ((double)trackBar_Music_Player.Maximum / curFile_Duration));
            //노래가 거의 끝나갈쯤 현재 플레이 index 증가
            if (trackBar_Music_Player.Value == trackBar_Music_Player.Maximum-1)
            {
                if (currentPlayindex > player_ArrList.Count)
                    return;
                //plus current play index 
                if(currentPlayindex < player_ArrList.Count)
                    currentPlayindex += 1;
                //17.2_score : 0.5*3
                //check flag_ Play Option
                switch (flag)
                {
                    case 1:
                        WMP.controls.stop();
                        WMP.controls.previous();
                        WMP.controls.next();
                        WMP.controls.play();
                        break;
                    case 2:
                        //Decrease Play List index to Selected index
                        //play First Music
                        if (1< currentPlayindex)
                            WMP.controls.stop();
                        while (1 < currentPlayindex)
                        {
                            currentPlayindex -= 1;
                            WMP.controls.previous();
                        }
                        WMP.controls.play();
                        break;
                    case 3:
                        if (currentPlayindex == player_ArrList.Count) {
                            button_Music_Play.ImageIndex = 0;
                        }
                        break;
                }
            }


            //14.1_score : 0.1
            //현재 목록을 계속 보며 노래 이름 띄우는 라벨 수정
            label_Music_Name.Text = WMP.controls.currentItem.name;
        }
    }
}
