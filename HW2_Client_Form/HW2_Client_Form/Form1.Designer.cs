namespace HW2_Client_Form
{
    partial class form_Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox_Get = new System.Windows.Forms.GroupBox();
            this.progressBar_Download = new System.Windows.Forms.ProgressBar();
            this.listView_Server_Music_List = new System.Windows.Forms.ListView();
            this.server_Music_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.server_Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.server_Play_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.server_Bit_Rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_Server_Music_List = new System.Windows.Forms.Label();
            this.button_Add_PlayList = new System.Windows.Forms.Button();
            this.panel_Storage_Path = new System.Windows.Forms.Panel();
            this.textBox_Storage_Path = new System.Windows.Forms.TextBox();
            this.label_Storage_Path = new System.Windows.Forms.Label();
            this.button_Find_Path = new System.Windows.Forms.Button();
            this.panel_Port = new System.Windows.Forms.Panel();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.panel_IP = new System.Windows.Forms.Panel();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.groupBox_Play = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_Music_Player = new System.Windows.Forms.TrackBar();
            this.button_Previous_Music = new System.Windows.Forms.Button();
            this.button_Next_Music = new System.Windows.Forms.Button();
            this.button_Music_Stop = new System.Windows.Forms.Button();
            this.button_Music_Pause = new System.Windows.Forms.Button();
            this.button_Music_Play = new System.Windows.Forms.Button();
            this.button_Remove_PlayList = new System.Windows.Forms.Button();
            this.label_Play_List = new System.Windows.Forms.Label();
            this.listView_Play_List = new System.Windows.Forms.ListView();
            this.play_Music_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.play_Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.play_Play_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.play_Bit_Rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_Music_Player = new System.Windows.Forms.Label();
            this.folder_Browser_Dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.time_TrackBar_Increase = new System.Windows.Forms.Timer(this.components);
            this.groupBox_Get.SuspendLayout();
            this.panel_Storage_Path.SuspendLayout();
            this.panel_Port.SuspendLayout();
            this.panel_IP.SuspendLayout();
            this.groupBox_Play.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Music_Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(59, 54);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(100, 31);
            this.button_Connect.TabIndex = 3;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // groupBox_Get
            // 
            this.groupBox_Get.Controls.Add(this.progressBar_Download);
            this.groupBox_Get.Controls.Add(this.listView_Server_Music_List);
            this.groupBox_Get.Controls.Add(this.label_Server_Music_List);
            this.groupBox_Get.Controls.Add(this.button_Add_PlayList);
            this.groupBox_Get.Controls.Add(this.panel_Storage_Path);
            this.groupBox_Get.Controls.Add(this.button_Find_Path);
            this.groupBox_Get.Controls.Add(this.panel_Port);
            this.groupBox_Get.Controls.Add(this.panel_IP);
            this.groupBox_Get.Controls.Add(this.button_Connect);
            this.groupBox_Get.Location = new System.Drawing.Point(13, 12);
            this.groupBox_Get.Name = "groupBox_Get";
            this.groupBox_Get.Size = new System.Drawing.Size(406, 387);
            this.groupBox_Get.TabIndex = 4;
            this.groupBox_Get.TabStop = false;
            this.groupBox_Get.Text = "Get Mp3 File";
            // 
            // progressBar_Download
            // 
            this.progressBar_Download.Location = new System.Drawing.Point(8, 149);
            this.progressBar_Download.Name = "progressBar_Download";
            this.progressBar_Download.Size = new System.Drawing.Size(389, 23);
            this.progressBar_Download.Step = 1;
            this.progressBar_Download.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_Download.TabIndex = 11;
            // 
            // listView_Server_Music_List
            // 
            this.listView_Server_Music_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.server_Music_Name,
            this.server_Artist,
            this.server_Play_Time,
            this.server_Bit_Rate});
            this.listView_Server_Music_List.Location = new System.Drawing.Point(6, 206);
            this.listView_Server_Music_List.Name = "listView_Server_Music_List";
            this.listView_Server_Music_List.Size = new System.Drawing.Size(391, 169);
            this.listView_Server_Music_List.TabIndex = 10;
            this.listView_Server_Music_List.UseCompatibleStateImageBehavior = false;
            this.listView_Server_Music_List.View = System.Windows.Forms.View.Details;
            // 
            // server_Music_Name
            // 
            this.server_Music_Name.Text = "Music Name";
            this.server_Music_Name.Width = 102;
            // 
            // server_Artist
            // 
            this.server_Artist.Text = "Artist";
            // 
            // server_Play_Time
            // 
            this.server_Play_Time.Text = "Play Time";
            this.server_Play_Time.Width = 86;
            // 
            // server_Bit_Rate
            // 
            this.server_Bit_Rate.Text = "Bit Rate";
            // 
            // label_Server_Music_List
            // 
            this.label_Server_Music_List.AutoSize = true;
            this.label_Server_Music_List.Location = new System.Drawing.Point(28, 188);
            this.label_Server_Music_List.Name = "label_Server_Music_List";
            this.label_Server_Music_List.Size = new System.Drawing.Size(104, 12);
            this.label_Server_Music_List.TabIndex = 9;
            this.label_Server_Music_List.Text = "Server Music List";
            // 
            // button_Add_PlayList
            // 
            this.button_Add_PlayList.Location = new System.Drawing.Point(257, 177);
            this.button_Add_PlayList.Name = "button_Add_PlayList";
            this.button_Add_PlayList.Size = new System.Drawing.Size(143, 23);
            this.button_Add_PlayList.TabIndex = 8;
            this.button_Add_PlayList.Text = "재생 목록에 추가";
            this.button_Add_PlayList.UseVisualStyleBackColor = true;
            this.button_Add_PlayList.Click += new System.EventHandler(this.button_Add_PlayList_Click);
            // 
            // panel_Storage_Path
            // 
            this.panel_Storage_Path.Controls.Add(this.textBox_Storage_Path);
            this.panel_Storage_Path.Controls.Add(this.label_Storage_Path);
            this.panel_Storage_Path.Location = new System.Drawing.Point(8, 91);
            this.panel_Storage_Path.Name = "panel_Storage_Path";
            this.panel_Storage_Path.Size = new System.Drawing.Size(392, 26);
            this.panel_Storage_Path.TabIndex = 7;
            // 
            // textBox_Storage_Path
            // 
            this.textBox_Storage_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Storage_Path.Location = new System.Drawing.Point(151, 0);
            this.textBox_Storage_Path.Name = "textBox_Storage_Path";
            this.textBox_Storage_Path.Size = new System.Drawing.Size(241, 21);
            this.textBox_Storage_Path.TabIndex = 1;
            // 
            // label_Storage_Path
            // 
            this.label_Storage_Path.AutoSize = true;
            this.label_Storage_Path.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Storage_Path.Location = new System.Drawing.Point(0, 0);
            this.label_Storage_Path.Name = "label_Storage_Path";
            this.label_Storage_Path.Size = new System.Drawing.Size(151, 12);
            this.label_Storage_Path.TabIndex = 0;
            this.label_Storage_Path.Text = "MP3 File Download Path :";
            // 
            // button_Find_Path
            // 
            this.button_Find_Path.Location = new System.Drawing.Point(262, 54);
            this.button_Find_Path.Name = "button_Find_Path";
            this.button_Find_Path.Size = new System.Drawing.Size(73, 31);
            this.button_Find_Path.TabIndex = 6;
            this.button_Find_Path.Text = "Find Path";
            this.button_Find_Path.UseVisualStyleBackColor = true;
            this.button_Find_Path.Click += new System.EventHandler(this.button_Find_Path_Click);
            // 
            // panel_Port
            // 
            this.panel_Port.Controls.Add(this.textBox_Port);
            this.panel_Port.Controls.Add(this.label_Port);
            this.panel_Port.Location = new System.Drawing.Point(260, 20);
            this.panel_Port.Name = "panel_Port";
            this.panel_Port.Size = new System.Drawing.Size(146, 28);
            this.panel_Port.TabIndex = 5;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Port.Location = new System.Drawing.Point(35, 0);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(111, 21);
            this.textBox_Port.TabIndex = 1;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Port.Location = new System.Drawing.Point(0, 0);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(35, 12);
            this.label_Port.TabIndex = 0;
            this.label_Port.Text = "Port :";
            // 
            // panel_IP
            // 
            this.panel_IP.Controls.Add(this.textBox_IP);
            this.panel_IP.Controls.Add(this.label_IP);
            this.panel_IP.Location = new System.Drawing.Point(6, 20);
            this.panel_IP.Name = "panel_IP";
            this.panel_IP.Size = new System.Drawing.Size(242, 28);
            this.panel_IP.TabIndex = 4;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IP.Location = new System.Drawing.Point(24, 0);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(218, 21);
            this.textBox_IP.TabIndex = 1;
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_IP.Location = new System.Drawing.Point(0, 0);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 12);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP :";
            // 
            // groupBox_Play
            // 
            this.groupBox_Play.Controls.Add(this.label3);
            this.groupBox_Play.Controls.Add(this.label2);
            this.groupBox_Play.Controls.Add(this.label1);
            this.groupBox_Play.Controls.Add(this.trackBar_Music_Player);
            this.groupBox_Play.Controls.Add(this.button_Previous_Music);
            this.groupBox_Play.Controls.Add(this.button_Next_Music);
            this.groupBox_Play.Controls.Add(this.button_Music_Stop);
            this.groupBox_Play.Controls.Add(this.button_Music_Pause);
            this.groupBox_Play.Controls.Add(this.button_Music_Play);
            this.groupBox_Play.Controls.Add(this.button_Remove_PlayList);
            this.groupBox_Play.Controls.Add(this.label_Play_List);
            this.groupBox_Play.Controls.Add(this.listView_Play_List);
            this.groupBox_Play.Controls.Add(this.label_Music_Player);
            this.groupBox_Play.Location = new System.Drawing.Point(449, 12);
            this.groupBox_Play.Name = "groupBox_Play";
            this.groupBox_Play.Size = new System.Drawing.Size(410, 387);
            this.groupBox_Play.TabIndex = 5;
            this.groupBox_Play.TabStop = false;
            this.groupBox_Play.Text = "Play MP3 File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            // 
            // trackBar_Music_Player
            // 
            this.trackBar_Music_Player.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar_Music_Player.Location = new System.Drawing.Point(25, 98);
            this.trackBar_Music_Player.Maximum = 400;
            this.trackBar_Music_Player.Name = "trackBar_Music_Player";
            this.trackBar_Music_Player.Size = new System.Drawing.Size(357, 45);
            this.trackBar_Music_Player.TabIndex = 17;
            this.trackBar_Music_Player.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Music_Player.Scroll += new System.EventHandler(this.trackBar_Music_Player_Scroll);
            // 
            // button_Previous_Music
            // 
            this.button_Previous_Music.Location = new System.Drawing.Point(92, 149);
            this.button_Previous_Music.Name = "button_Previous_Music";
            this.button_Previous_Music.Size = new System.Drawing.Size(75, 23);
            this.button_Previous_Music.TabIndex = 16;
            this.button_Previous_Music.Text = "Previous";
            this.button_Previous_Music.UseVisualStyleBackColor = true;
            this.button_Previous_Music.Click += new System.EventHandler(this.button_Previous_Music_Click);
            // 
            // button_Next_Music
            // 
            this.button_Next_Music.Location = new System.Drawing.Point(240, 149);
            this.button_Next_Music.Name = "button_Next_Music";
            this.button_Next_Music.Size = new System.Drawing.Size(75, 23);
            this.button_Next_Music.TabIndex = 15;
            this.button_Next_Music.Text = "Next";
            this.button_Next_Music.UseVisualStyleBackColor = true;
            this.button_Next_Music.Click += new System.EventHandler(this.button_Next_Music_Click);
            // 
            // button_Music_Stop
            // 
            this.button_Music_Stop.Location = new System.Drawing.Point(318, 27);
            this.button_Music_Stop.Name = "button_Music_Stop";
            this.button_Music_Stop.Size = new System.Drawing.Size(64, 58);
            this.button_Music_Stop.TabIndex = 14;
            this.button_Music_Stop.Text = "Stop";
            this.button_Music_Stop.UseVisualStyleBackColor = true;
            this.button_Music_Stop.Click += new System.EventHandler(this.button_Music_Stop_Click);
            // 
            // button_Music_Pause
            // 
            this.button_Music_Pause.Location = new System.Drawing.Point(162, 27);
            this.button_Music_Pause.Name = "button_Music_Pause";
            this.button_Music_Pause.Size = new System.Drawing.Size(64, 58);
            this.button_Music_Pause.TabIndex = 13;
            this.button_Music_Pause.Text = "Pause";
            this.button_Music_Pause.UseVisualStyleBackColor = true;
            this.button_Music_Pause.Click += new System.EventHandler(this.button_Music_Pause_Click);
            // 
            // button_Music_Play
            // 
            this.button_Music_Play.Location = new System.Drawing.Point(25, 27);
            this.button_Music_Play.Name = "button_Music_Play";
            this.button_Music_Play.Size = new System.Drawing.Size(64, 58);
            this.button_Music_Play.TabIndex = 12;
            this.button_Music_Play.Text = "Play";
            this.button_Music_Play.UseVisualStyleBackColor = true;
            this.button_Music_Play.Click += new System.EventHandler(this.button_Music_Play_Click);
            // 
            // button_Remove_PlayList
            // 
            this.button_Remove_PlayList.Location = new System.Drawing.Point(261, 177);
            this.button_Remove_PlayList.Name = "button_Remove_PlayList";
            this.button_Remove_PlayList.Size = new System.Drawing.Size(143, 23);
            this.button_Remove_PlayList.TabIndex = 11;
            this.button_Remove_PlayList.Text = "재생 목록에 삭제";
            this.button_Remove_PlayList.UseVisualStyleBackColor = true;
            this.button_Remove_PlayList.Click += new System.EventHandler(this.button_Remove_PlayList_Click);
            // 
            // label_Play_List
            // 
            this.label_Play_List.AutoSize = true;
            this.label_Play_List.Location = new System.Drawing.Point(6, 188);
            this.label_Play_List.Name = "label_Play_List";
            this.label_Play_List.Size = new System.Drawing.Size(54, 12);
            this.label_Play_List.TabIndex = 11;
            this.label_Play_List.Text = "Play List";
            // 
            // listView_Play_List
            // 
            this.listView_Play_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.play_Music_Name,
            this.play_Artist,
            this.play_Play_Time,
            this.play_Bit_Rate});
            this.listView_Play_List.Location = new System.Drawing.Point(6, 206);
            this.listView_Play_List.Name = "listView_Play_List";
            this.listView_Play_List.Size = new System.Drawing.Size(398, 169);
            this.listView_Play_List.TabIndex = 11;
            this.listView_Play_List.UseCompatibleStateImageBehavior = false;
            this.listView_Play_List.View = System.Windows.Forms.View.Details;
            // 
            // play_Music_Name
            // 
            this.play_Music_Name.Text = "Music Name";
            // 
            // play_Artist
            // 
            this.play_Artist.Text = "Artist";
            // 
            // play_Play_Time
            // 
            this.play_Play_Time.Text = "Play Time";
            this.play_Play_Time.Width = 77;
            // 
            // play_Bit_Rate
            // 
            this.play_Bit_Rate.Text = "Bit Rate";
            // 
            // label_Music_Player
            // 
            this.label_Music_Player.AutoSize = true;
            this.label_Music_Player.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Music_Player.Location = new System.Drawing.Point(90, -4);
            this.label_Music_Player.Name = "label_Music_Player";
            this.label_Music_Player.Size = new System.Drawing.Size(170, 27);
            this.label_Music_Player.TabIndex = 0;
            this.label_Music_Player.Text = "Music Player";
            // 
            // folder_Browser_Dialog
            // 
            this.folder_Browser_Dialog.SelectedPath = "D:\\";
            // 
            // time_TrackBar_Increase
            // 
            this.time_TrackBar_Increase.Tick += new System.EventHandler(this.time_TrackBar_Increase_Tick);
            // 
            // form_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 411);
            this.Controls.Add(this.groupBox_Play);
            this.Controls.Add(this.groupBox_Get);
            this.Name = "form_Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_Client_FormClosed);
            this.Load += new System.EventHandler(this.form_Client_Load);
            this.groupBox_Get.ResumeLayout(false);
            this.groupBox_Get.PerformLayout();
            this.panel_Storage_Path.ResumeLayout(false);
            this.panel_Storage_Path.PerformLayout();
            this.panel_Port.ResumeLayout(false);
            this.panel_Port.PerformLayout();
            this.panel_IP.ResumeLayout(false);
            this.panel_IP.PerformLayout();
            this.groupBox_Play.ResumeLayout(false);
            this.groupBox_Play.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Music_Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.GroupBox groupBox_Get;
        private System.Windows.Forms.GroupBox groupBox_Play;
        private System.Windows.Forms.Label label_Music_Player;
        private System.Windows.Forms.Panel panel_Port;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Panel panel_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Button button_Find_Path;
        private System.Windows.Forms.Panel panel_Storage_Path;
        private System.Windows.Forms.TextBox textBox_Storage_Path;
        private System.Windows.Forms.Label label_Storage_Path;
        private System.Windows.Forms.Button button_Add_PlayList;
        private System.Windows.Forms.ListView listView_Server_Music_List;
        private System.Windows.Forms.Label label_Server_Music_List;
        private System.Windows.Forms.ListView listView_Play_List;
        private System.Windows.Forms.ColumnHeader play_Music_Name;
        private System.Windows.Forms.ColumnHeader play_Artist;
        private System.Windows.Forms.ColumnHeader play_Play_Time;
        private System.Windows.Forms.ColumnHeader play_Bit_Rate;
        private System.Windows.Forms.Button button_Remove_PlayList;
        private System.Windows.Forms.Label label_Play_List;
        private System.Windows.Forms.FolderBrowserDialog folder_Browser_Dialog;
        private System.Windows.Forms.ProgressBar progressBar_Download;
        public System.Windows.Forms.ColumnHeader server_Music_Name;
        public System.Windows.Forms.ColumnHeader server_Artist;
        public System.Windows.Forms.ColumnHeader server_Play_Time;
        public System.Windows.Forms.ColumnHeader server_Bit_Rate;
        private System.Windows.Forms.Button button_Music_Stop;
        private System.Windows.Forms.Button button_Music_Pause;
        private System.Windows.Forms.Button button_Music_Play;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button_Previous_Music;
        private System.Windows.Forms.Button button_Next_Music;
        private System.Windows.Forms.TrackBar trackBar_Music_Player;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer time_TrackBar_Increase;
        private System.Windows.Forms.Label label3;
    }
}

