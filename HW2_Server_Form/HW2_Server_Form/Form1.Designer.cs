namespace HW2_Server_Form
{
    partial class server
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
            this.bottom_Full_Panel = new System.Windows.Forms.Panel();
            this.bottom_left_Full_Panel = new System.Windows.Forms.Panel();
            this.Music_Log_Text_Box = new System.Windows.Forms.TextBox();
            this.bottom_Right_Full_Panel = new System.Windows.Forms.Panel();
            this.Music_List_View = new System.Windows.Forms.ListView();
            this.Music_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Play_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bit_Rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sever_IP_Panel = new System.Windows.Forms.Panel();
            this.ip_TextBox = new System.Windows.Forms.TextBox();
            this.ip_Label = new System.Windows.Forms.Label();
            this.sever_Port_Panel = new System.Windows.Forms.Panel();
            this.port_TextBox = new System.Windows.Forms.TextBox();
            this.port_Label = new System.Windows.Forms.Label();
            this.server_Start_Button = new System.Windows.Forms.Button();
            this.find_Path_Buttton = new System.Windows.Forms.Button();
            this.music_File_Storage_Path_Panel = new System.Windows.Forms.Panel();
            this.storage_Path_TextBox = new System.Windows.Forms.TextBox();
            this.storage_Path_Label = new System.Windows.Forms.Label();
            this.sever_Status_Panel = new System.Windows.Forms.Label();
            this.music_List_Label = new System.Windows.Forms.Label();
            this.foler_Browser_Dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.open_File_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.bottom_Full_Panel.SuspendLayout();
            this.bottom_left_Full_Panel.SuspendLayout();
            this.bottom_Right_Full_Panel.SuspendLayout();
            this.sever_IP_Panel.SuspendLayout();
            this.sever_Port_Panel.SuspendLayout();
            this.music_File_Storage_Path_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottom_Full_Panel
            // 
            this.bottom_Full_Panel.Controls.Add(this.bottom_left_Full_Panel);
            this.bottom_Full_Panel.Controls.Add(this.bottom_Right_Full_Panel);
            this.bottom_Full_Panel.Location = new System.Drawing.Point(12, 165);
            this.bottom_Full_Panel.Name = "bottom_Full_Panel";
            this.bottom_Full_Panel.Size = new System.Drawing.Size(548, 193);
            this.bottom_Full_Panel.TabIndex = 0;
            // 
            // bottom_left_Full_Panel
            // 
            this.bottom_left_Full_Panel.Controls.Add(this.Music_Log_Text_Box);
            this.bottom_left_Full_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottom_left_Full_Panel.Location = new System.Drawing.Point(0, 0);
            this.bottom_left_Full_Panel.Name = "bottom_left_Full_Panel";
            this.bottom_left_Full_Panel.Size = new System.Drawing.Size(263, 193);
            this.bottom_left_Full_Panel.TabIndex = 3;
            // 
            // Music_Log_Text_Box
            // 
            this.Music_Log_Text_Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Music_Log_Text_Box.Location = new System.Drawing.Point(0, 0);
            this.Music_Log_Text_Box.Multiline = true;
            this.Music_Log_Text_Box.Name = "Music_Log_Text_Box";
            this.Music_Log_Text_Box.Size = new System.Drawing.Size(263, 193);
            this.Music_Log_Text_Box.TabIndex = 0;
            // 
            // bottom_Right_Full_Panel
            // 
            this.bottom_Right_Full_Panel.Controls.Add(this.Music_List_View);
            this.bottom_Right_Full_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bottom_Right_Full_Panel.Location = new System.Drawing.Point(263, 0);
            this.bottom_Right_Full_Panel.Name = "bottom_Right_Full_Panel";
            this.bottom_Right_Full_Panel.Size = new System.Drawing.Size(285, 193);
            this.bottom_Right_Full_Panel.TabIndex = 1;
            // 
            // Music_List_View
            // 
            this.Music_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Music_Name,
            this.Artist,
            this.Play_Time,
            this.Bit_Rate});
            this.Music_List_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Music_List_View.Location = new System.Drawing.Point(0, 0);
            this.Music_List_View.Name = "Music_List_View";
            this.Music_List_View.Size = new System.Drawing.Size(285, 193);
            this.Music_List_View.TabIndex = 0;
            this.Music_List_View.UseCompatibleStateImageBehavior = false;
            this.Music_List_View.View = System.Windows.Forms.View.Details;
            // 
            // Music_Name
            // 
            this.Music_Name.Text = "Music Name";
            this.Music_Name.Width = 90;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            this.Artist.Width = 47;
            // 
            // Play_Time
            // 
            this.Play_Time.Text = "Play Time";
            this.Play_Time.Width = 77;
            // 
            // Bit_Rate
            // 
            this.Bit_Rate.Text = "Bit Rate";
            // 
            // sever_IP_Panel
            // 
            this.sever_IP_Panel.Controls.Add(this.ip_TextBox);
            this.sever_IP_Panel.Controls.Add(this.ip_Label);
            this.sever_IP_Panel.Location = new System.Drawing.Point(13, 13);
            this.sever_IP_Panel.Name = "sever_IP_Panel";
            this.sever_IP_Panel.Size = new System.Drawing.Size(265, 24);
            this.sever_IP_Panel.TabIndex = 1;
            // 
            // ip_TextBox
            // 
            this.ip_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ip_TextBox.Enabled = false;
            this.ip_TextBox.Location = new System.Drawing.Point(24, 0);
            this.ip_TextBox.Name = "ip_TextBox";
            this.ip_TextBox.Size = new System.Drawing.Size(241, 21);
            this.ip_TextBox.TabIndex = 1;
            this.ip_TextBox.TextChanged += new System.EventHandler(this.ip_TextBox_TextChanged);
            // 
            // ip_Label
            // 
            this.ip_Label.AutoSize = true;
            this.ip_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.ip_Label.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ip_Label.Location = new System.Drawing.Point(0, 0);
            this.ip_Label.Name = "ip_Label";
            this.ip_Label.Size = new System.Drawing.Size(24, 15);
            this.ip_Label.TabIndex = 0;
            this.ip_Label.Text = "IP :";
            // 
            // sever_Port_Panel
            // 
            this.sever_Port_Panel.Controls.Add(this.port_TextBox);
            this.sever_Port_Panel.Controls.Add(this.port_Label);
            this.sever_Port_Panel.Location = new System.Drawing.Point(285, 13);
            this.sever_Port_Panel.Name = "sever_Port_Panel";
            this.sever_Port_Panel.Size = new System.Drawing.Size(122, 24);
            this.sever_Port_Panel.TabIndex = 2;
            // 
            // port_TextBox
            // 
            this.port_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.port_TextBox.Location = new System.Drawing.Point(36, 0);
            this.port_TextBox.Name = "port_TextBox";
            this.port_TextBox.Size = new System.Drawing.Size(86, 21);
            this.port_TextBox.TabIndex = 1;
            // 
            // port_Label
            // 
            this.port_Label.AutoSize = true;
            this.port_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.port_Label.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.port_Label.Location = new System.Drawing.Point(0, 0);
            this.port_Label.Name = "port_Label";
            this.port_Label.Size = new System.Drawing.Size(36, 15);
            this.port_Label.TabIndex = 0;
            this.port_Label.Text = "Port :";
            // 
            // server_Start_Button
            // 
            this.server_Start_Button.Location = new System.Drawing.Point(426, 13);
            this.server_Start_Button.Name = "server_Start_Button";
            this.server_Start_Button.Size = new System.Drawing.Size(125, 23);
            this.server_Start_Button.TabIndex = 3;
            this.server_Start_Button.Text = "Start";
            this.server_Start_Button.UseVisualStyleBackColor = true;
            this.server_Start_Button.Click += new System.EventHandler(this.server_Start_Button_Click);
            // 
            // find_Path_Buttton
            // 
            this.find_Path_Buttton.Location = new System.Drawing.Point(426, 84);
            this.find_Path_Buttton.Name = "find_Path_Buttton";
            this.find_Path_Buttton.Size = new System.Drawing.Size(99, 23);
            this.find_Path_Buttton.TabIndex = 4;
            this.find_Path_Buttton.Text = "Find Path";
            this.find_Path_Buttton.UseVisualStyleBackColor = true;
            this.find_Path_Buttton.Click += new System.EventHandler(this.find_Path_Buttton_Click);
            // 
            // music_File_Storage_Path_Panel
            // 
            this.music_File_Storage_Path_Panel.Controls.Add(this.storage_Path_TextBox);
            this.music_File_Storage_Path_Panel.Controls.Add(this.storage_Path_Label);
            this.music_File_Storage_Path_Panel.Location = new System.Drawing.Point(16, 84);
            this.music_File_Storage_Path_Panel.Name = "music_File_Storage_Path_Panel";
            this.music_File_Storage_Path_Panel.Size = new System.Drawing.Size(404, 23);
            this.music_File_Storage_Path_Panel.TabIndex = 5;
            // 
            // storage_Path_TextBox
            // 
            this.storage_Path_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storage_Path_TextBox.Location = new System.Drawing.Point(134, 0);
            this.storage_Path_TextBox.Name = "storage_Path_TextBox";
            this.storage_Path_TextBox.Size = new System.Drawing.Size(270, 21);
            this.storage_Path_TextBox.TabIndex = 1;
            // 
            // storage_Path_Label
            // 
            this.storage_Path_Label.AutoSize = true;
            this.storage_Path_Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.storage_Path_Label.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.storage_Path_Label.Location = new System.Drawing.Point(0, 0);
            this.storage_Path_Label.Name = "storage_Path_Label";
            this.storage_Path_Label.Size = new System.Drawing.Size(134, 15);
            this.storage_Path_Label.TabIndex = 0;
            this.storage_Path_Label.Text = "MP3 File Storage Path :";
            // 
            // sever_Status_Panel
            // 
            this.sever_Status_Panel.AutoSize = true;
            this.sever_Status_Panel.Location = new System.Drawing.Point(13, 147);
            this.sever_Status_Panel.Name = "sever_Status_Panel";
            this.sever_Status_Panel.Size = new System.Drawing.Size(57, 12);
            this.sever_Status_Panel.TabIndex = 6;
            this.sever_Status_Panel.Text = "서버 상태";
            // 
            // music_List_Label
            // 
            this.music_List_Label.AutoSize = true;
            this.music_List_Label.Location = new System.Drawing.Point(275, 146);
            this.music_List_Label.Name = "music_List_Label";
            this.music_List_Label.Size = new System.Drawing.Size(64, 12);
            this.music_List_Label.TabIndex = 7;
            this.music_List_Label.Text = "Music List";
            // 
            // open_File_Dialog
            // 
            this.open_File_Dialog.FileName = "openFileDialog1";
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 370);
            this.Controls.Add(this.music_List_Label);
            this.Controls.Add(this.sever_Status_Panel);
            this.Controls.Add(this.music_File_Storage_Path_Panel);
            this.Controls.Add(this.find_Path_Buttton);
            this.Controls.Add(this.server_Start_Button);
            this.Controls.Add(this.sever_Port_Panel);
            this.Controls.Add(this.sever_IP_Panel);
            this.Controls.Add(this.bottom_Full_Panel);
            this.Name = "server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.server_FormClosed);
            this.Load += new System.EventHandler(this.server_Load);
            this.bottom_Full_Panel.ResumeLayout(false);
            this.bottom_left_Full_Panel.ResumeLayout(false);
            this.bottom_left_Full_Panel.PerformLayout();
            this.bottom_Right_Full_Panel.ResumeLayout(false);
            this.sever_IP_Panel.ResumeLayout(false);
            this.sever_IP_Panel.PerformLayout();
            this.sever_Port_Panel.ResumeLayout(false);
            this.sever_Port_Panel.PerformLayout();
            this.music_File_Storage_Path_Panel.ResumeLayout(false);
            this.music_File_Storage_Path_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bottom_Full_Panel;
        private System.Windows.Forms.Panel bottom_left_Full_Panel;
        private System.Windows.Forms.TextBox Music_Log_Text_Box;
        private System.Windows.Forms.Panel bottom_Right_Full_Panel;
        private System.Windows.Forms.ListView Music_List_View;
        private System.Windows.Forms.ColumnHeader Music_Name;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Play_Time;
        private System.Windows.Forms.ColumnHeader Bit_Rate;
        private System.Windows.Forms.Panel sever_IP_Panel;
        private System.Windows.Forms.Panel sever_Port_Panel;
        private System.Windows.Forms.Button server_Start_Button;
        private System.Windows.Forms.Button find_Path_Buttton;
        private System.Windows.Forms.Panel music_File_Storage_Path_Panel;
        private System.Windows.Forms.Label ip_Label;
        private System.Windows.Forms.TextBox ip_TextBox;
        private System.Windows.Forms.Label sever_Status_Panel;
        private System.Windows.Forms.Label music_List_Label;
        private System.Windows.Forms.Label port_Label;
        private System.Windows.Forms.Label storage_Path_Label;
        private System.Windows.Forms.TextBox port_TextBox;
        private System.Windows.Forms.TextBox storage_Path_TextBox;
        private System.Windows.Forms.FolderBrowserDialog foler_Browser_Dialog;
        private System.Windows.Forms.OpenFileDialog open_File_Dialog;
    }
}

