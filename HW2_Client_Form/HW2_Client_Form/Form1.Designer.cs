namespace HW2_Client_Form
{
    partial class Form1
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
            this.connect_Button = new System.Windows.Forms.Button();
            this.get_GroupBox = new System.Windows.Forms.GroupBox();
            this.play_GroupBox = new System.Windows.Forms.GroupBox();
            this.music_Player_Label = new System.Windows.Forms.Label();
            this.ip_Panel = new System.Windows.Forms.Panel();
            this.port_Panel = new System.Windows.Forms.Panel();
            this.ip_Label = new System.Windows.Forms.Label();
            this.port_Label = new System.Windows.Forms.Label();
            this.ip_TextBox = new System.Windows.Forms.TextBox();
            this.port_TextBox = new System.Windows.Forms.TextBox();
            this.find_Path_Button = new System.Windows.Forms.Button();
            this.download_Path_Panel = new System.Windows.Forms.Panel();
            this.find_Path_Label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.add_PlayList_Button = new System.Windows.Forms.Button();
            this.music_List_Label = new System.Windows.Forms.Label();
            this.get_ListView = new System.Windows.Forms.ListView();
            this.Music_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Play_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bit_Rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.play_ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.music_Play_Label = new System.Windows.Forms.Label();
            this.remove_PlayList_Button = new System.Windows.Forms.Button();
            this.get_GroupBox.SuspendLayout();
            this.play_GroupBox.SuspendLayout();
            this.ip_Panel.SuspendLayout();
            this.port_Panel.SuspendLayout();
            this.download_Path_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect_Button
            // 
            this.connect_Button.Location = new System.Drawing.Point(86, 54);
            this.connect_Button.Name = "connect_Button";
            this.connect_Button.Size = new System.Drawing.Size(73, 31);
            this.connect_Button.TabIndex = 3;
            this.connect_Button.Text = "Connect";
            this.connect_Button.UseVisualStyleBackColor = true;
            this.connect_Button.Click += new System.EventHandler(this.btTelnet_Click);
            // 
            // get_GroupBox
            // 
            this.get_GroupBox.Controls.Add(this.get_ListView);
            this.get_GroupBox.Controls.Add(this.music_List_Label);
            this.get_GroupBox.Controls.Add(this.add_PlayList_Button);
            this.get_GroupBox.Controls.Add(this.download_Path_Panel);
            this.get_GroupBox.Controls.Add(this.find_Path_Button);
            this.get_GroupBox.Controls.Add(this.port_Panel);
            this.get_GroupBox.Controls.Add(this.ip_Panel);
            this.get_GroupBox.Controls.Add(this.connect_Button);
            this.get_GroupBox.Location = new System.Drawing.Point(13, 12);
            this.get_GroupBox.Name = "get_GroupBox";
            this.get_GroupBox.Size = new System.Drawing.Size(406, 387);
            this.get_GroupBox.TabIndex = 4;
            this.get_GroupBox.TabStop = false;
            this.get_GroupBox.Text = "Get Mp3 File";
            // 
            // play_GroupBox
            // 
            this.play_GroupBox.Controls.Add(this.remove_PlayList_Button);
            this.play_GroupBox.Controls.Add(this.music_Play_Label);
            this.play_GroupBox.Controls.Add(this.play_ListView);
            this.play_GroupBox.Controls.Add(this.music_Player_Label);
            this.play_GroupBox.Location = new System.Drawing.Point(449, 12);
            this.play_GroupBox.Name = "play_GroupBox";
            this.play_GroupBox.Size = new System.Drawing.Size(410, 387);
            this.play_GroupBox.TabIndex = 5;
            this.play_GroupBox.TabStop = false;
            this.play_GroupBox.Text = "Play MP3 File";
            // 
            // music_Player_Label
            // 
            this.music_Player_Label.AutoSize = true;
            this.music_Player_Label.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.music_Player_Label.Location = new System.Drawing.Point(90, -4);
            this.music_Player_Label.Name = "music_Player_Label";
            this.music_Player_Label.Size = new System.Drawing.Size(170, 27);
            this.music_Player_Label.TabIndex = 0;
            this.music_Player_Label.Text = "Music Player";
            // 
            // ip_Panel
            // 
            this.ip_Panel.Controls.Add(this.ip_TextBox);
            this.ip_Panel.Controls.Add(this.ip_Label);
            this.ip_Panel.Location = new System.Drawing.Point(6, 20);
            this.ip_Panel.Name = "ip_Panel";
            this.ip_Panel.Size = new System.Drawing.Size(242, 28);
            this.ip_Panel.TabIndex = 4;
            // 
            // port_Panel
            // 
            this.port_Panel.Controls.Add(this.port_TextBox);
            this.port_Panel.Controls.Add(this.port_Label);
            this.port_Panel.Location = new System.Drawing.Point(260, 20);
            this.port_Panel.Name = "port_Panel";
            this.port_Panel.Size = new System.Drawing.Size(146, 28);
            this.port_Panel.TabIndex = 5;
            // 
            // ip_Label
            // 
            this.ip_Label.AutoSize = true;
            this.ip_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.ip_Label.Location = new System.Drawing.Point(0, 0);
            this.ip_Label.Name = "ip_Label";
            this.ip_Label.Size = new System.Drawing.Size(24, 12);
            this.ip_Label.TabIndex = 0;
            this.ip_Label.Text = "IP :";
            // 
            // port_Label
            // 
            this.port_Label.AutoSize = true;
            this.port_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.port_Label.Location = new System.Drawing.Point(0, 0);
            this.port_Label.Name = "port_Label";
            this.port_Label.Size = new System.Drawing.Size(35, 12);
            this.port_Label.TabIndex = 0;
            this.port_Label.Text = "Port :";
            // 
            // ip_TextBox
            // 
            this.ip_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ip_TextBox.Location = new System.Drawing.Point(24, 0);
            this.ip_TextBox.Name = "ip_TextBox";
            this.ip_TextBox.Size = new System.Drawing.Size(218, 21);
            this.ip_TextBox.TabIndex = 1;
            // 
            // port_TextBox
            // 
            this.port_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.port_TextBox.Location = new System.Drawing.Point(35, 0);
            this.port_TextBox.Name = "port_TextBox";
            this.port_TextBox.Size = new System.Drawing.Size(111, 21);
            this.port_TextBox.TabIndex = 1;
            // 
            // find_Path_Button
            // 
            this.find_Path_Button.Location = new System.Drawing.Point(262, 54);
            this.find_Path_Button.Name = "find_Path_Button";
            this.find_Path_Button.Size = new System.Drawing.Size(73, 31);
            this.find_Path_Button.TabIndex = 6;
            this.find_Path_Button.Text = "Find Path";
            this.find_Path_Button.UseVisualStyleBackColor = true;
            // 
            // download_Path_Panel
            // 
            this.download_Path_Panel.Controls.Add(this.textBox1);
            this.download_Path_Panel.Controls.Add(this.find_Path_Label);
            this.download_Path_Panel.Location = new System.Drawing.Point(8, 91);
            this.download_Path_Panel.Name = "download_Path_Panel";
            this.download_Path_Panel.Size = new System.Drawing.Size(392, 26);
            this.download_Path_Panel.TabIndex = 7;
            // 
            // find_Path_Label
            // 
            this.find_Path_Label.AutoSize = true;
            this.find_Path_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.find_Path_Label.Location = new System.Drawing.Point(0, 0);
            this.find_Path_Label.Name = "find_Path_Label";
            this.find_Path_Label.Size = new System.Drawing.Size(151, 12);
            this.find_Path_Label.TabIndex = 0;
            this.find_Path_Label.Text = "MP3 File Download Path :";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(151, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 21);
            this.textBox1.TabIndex = 1;
            // 
            // add_PlayList_Button
            // 
            this.add_PlayList_Button.Location = new System.Drawing.Point(257, 177);
            this.add_PlayList_Button.Name = "add_PlayList_Button";
            this.add_PlayList_Button.Size = new System.Drawing.Size(143, 23);
            this.add_PlayList_Button.TabIndex = 8;
            this.add_PlayList_Button.Text = "재생 목록에 추가";
            this.add_PlayList_Button.UseVisualStyleBackColor = true;
            // 
            // music_List_Label
            // 
            this.music_List_Label.AutoSize = true;
            this.music_List_Label.Location = new System.Drawing.Point(28, 188);
            this.music_List_Label.Name = "music_List_Label";
            this.music_List_Label.Size = new System.Drawing.Size(100, 12);
            this.music_List_Label.TabIndex = 9;
            this.music_List_Label.Text = "Sever Music List";
            // 
            // get_ListView
            // 
            this.get_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Music_Name,
            this.Artist,
            this.Play_Time,
            this.Bit_Rate});
            this.get_ListView.Location = new System.Drawing.Point(6, 206);
            this.get_ListView.Name = "get_ListView";
            this.get_ListView.Size = new System.Drawing.Size(391, 169);
            this.get_ListView.TabIndex = 10;
            this.get_ListView.UseCompatibleStateImageBehavior = false;
            this.get_ListView.View = System.Windows.Forms.View.Details;
            // 
            // Music_Name
            // 
            this.Music_Name.Text = "Music Name";
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // Play_Time
            // 
            this.Play_Time.Text = "Play Time";
            // 
            // Bit_Rate
            // 
            this.Bit_Rate.Text = "Bit Rate";
            // 
            // play_ListView
            // 
            this.play_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.play_ListView.Location = new System.Drawing.Point(6, 206);
            this.play_ListView.Name = "play_ListView";
            this.play_ListView.Size = new System.Drawing.Size(398, 169);
            this.play_ListView.TabIndex = 11;
            this.play_ListView.UseCompatibleStateImageBehavior = false;
            this.play_ListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Music Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Artist";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Play Time";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Bit Rate";
            // 
            // music_Play_Label
            // 
            this.music_Play_Label.AutoSize = true;
            this.music_Play_Label.Location = new System.Drawing.Point(6, 188);
            this.music_Play_Label.Name = "music_Play_Label";
            this.music_Play_Label.Size = new System.Drawing.Size(54, 12);
            this.music_Play_Label.TabIndex = 11;
            this.music_Play_Label.Text = "Play List";
            // 
            // remove_PlayList_Button
            // 
            this.remove_PlayList_Button.Location = new System.Drawing.Point(261, 177);
            this.remove_PlayList_Button.Name = "remove_PlayList_Button";
            this.remove_PlayList_Button.Size = new System.Drawing.Size(143, 23);
            this.remove_PlayList_Button.TabIndex = 11;
            this.remove_PlayList_Button.Text = "재생 목록에 삭제";
            this.remove_PlayList_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 411);
            this.Controls.Add(this.play_GroupBox);
            this.Controls.Add(this.get_GroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.get_GroupBox.ResumeLayout(false);
            this.get_GroupBox.PerformLayout();
            this.play_GroupBox.ResumeLayout(false);
            this.play_GroupBox.PerformLayout();
            this.ip_Panel.ResumeLayout(false);
            this.ip_Panel.PerformLayout();
            this.port_Panel.ResumeLayout(false);
            this.port_Panel.PerformLayout();
            this.download_Path_Panel.ResumeLayout(false);
            this.download_Path_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button connect_Button;
        private System.Windows.Forms.GroupBox get_GroupBox;
        private System.Windows.Forms.GroupBox play_GroupBox;
        private System.Windows.Forms.Label music_Player_Label;
        private System.Windows.Forms.Panel port_Panel;
        private System.Windows.Forms.TextBox port_TextBox;
        private System.Windows.Forms.Label port_Label;
        private System.Windows.Forms.Panel ip_Panel;
        private System.Windows.Forms.TextBox ip_TextBox;
        private System.Windows.Forms.Label ip_Label;
        private System.Windows.Forms.Button find_Path_Button;
        private System.Windows.Forms.Panel download_Path_Panel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label find_Path_Label;
        private System.Windows.Forms.Button add_PlayList_Button;
        private System.Windows.Forms.ListView get_ListView;
        private System.Windows.Forms.Label music_List_Label;
        private System.Windows.Forms.ColumnHeader Music_Name;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Play_Time;
        private System.Windows.Forms.ColumnHeader Bit_Rate;
        private System.Windows.Forms.ListView play_ListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button remove_PlayList_Button;
        private System.Windows.Forms.Label music_Play_Label;
    }
}

