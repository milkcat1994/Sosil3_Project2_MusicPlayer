namespace HW2_Server_Form
{
    partial class form_Server
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
            this.panel_Bottom_Full = new System.Windows.Forms.Panel();
            this.panel_Music_Log = new System.Windows.Forms.Panel();
            this.textBox_Music_Log = new System.Windows.Forms.TextBox();
            this.panel_Music_List = new System.Windows.Forms.Panel();
            this.listView_Music_List = new System.Windows.Forms.ListView();
            this.Music_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Play_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bit_Rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel_Sever_IP = new System.Windows.Forms.Panel();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.panel_Sever_Port = new System.Windows.Forms.Panel();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.button_Server_Start = new System.Windows.Forms.Button();
            this.button_Find_Path = new System.Windows.Forms.Button();
            this.panel_Storage_Path = new System.Windows.Forms.Panel();
            this.textBox_Storage_Path = new System.Windows.Forms.TextBox();
            this.label_Storage_Path = new System.Windows.Forms.Label();
            this.label_Sever_Status = new System.Windows.Forms.Label();
            this.label_Music_List = new System.Windows.Forms.Label();
            this.folder_Browser_Dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel_Bottom_Full.SuspendLayout();
            this.panel_Music_Log.SuspendLayout();
            this.panel_Music_List.SuspendLayout();
            this.panel_Sever_IP.SuspendLayout();
            this.panel_Sever_Port.SuspendLayout();
            this.panel_Storage_Path.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Bottom_Full
            // 
            this.panel_Bottom_Full.Controls.Add(this.panel_Music_Log);
            this.panel_Bottom_Full.Controls.Add(this.panel_Music_List);
            this.panel_Bottom_Full.Location = new System.Drawing.Point(12, 165);
            this.panel_Bottom_Full.Name = "panel_Bottom_Full";
            this.panel_Bottom_Full.Size = new System.Drawing.Size(548, 193);
            this.panel_Bottom_Full.TabIndex = 0;
            // 
            // panel_Music_Log
            // 
            this.panel_Music_Log.Controls.Add(this.textBox_Music_Log);
            this.panel_Music_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Music_Log.Location = new System.Drawing.Point(0, 0);
            this.panel_Music_Log.Name = "panel_Music_Log";
            this.panel_Music_Log.Size = new System.Drawing.Size(263, 193);
            this.panel_Music_Log.TabIndex = 3;
            // 
            // textBox_Music_Log
            // 
            this.textBox_Music_Log.Enabled = false;
            this.textBox_Music_Log.Location = new System.Drawing.Point(0, 0);
            this.textBox_Music_Log.Multiline = true;
            this.textBox_Music_Log.Name = "textBox_Music_Log";
            this.textBox_Music_Log.Size = new System.Drawing.Size(263, 193);
            this.textBox_Music_Log.TabIndex = 0;
            // 
            // panel_Music_List
            // 
            this.panel_Music_List.Controls.Add(this.listView_Music_List);
            this.panel_Music_List.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Music_List.Location = new System.Drawing.Point(263, 0);
            this.panel_Music_List.Name = "panel_Music_List";
            this.panel_Music_List.Size = new System.Drawing.Size(285, 193);
            this.panel_Music_List.TabIndex = 1;
            // 
            // listView_Music_List
            // 
            this.listView_Music_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Music_Name,
            this.Artist,
            this.Play_Time,
            this.Bit_Rate});
            this.listView_Music_List.Location = new System.Drawing.Point(0, 0);
            this.listView_Music_List.Name = "listView_Music_List";
            this.listView_Music_List.Size = new System.Drawing.Size(285, 193);
            this.listView_Music_List.TabIndex = 0;
            this.listView_Music_List.UseCompatibleStateImageBehavior = false;
            this.listView_Music_List.View = System.Windows.Forms.View.Details;
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
            // panel_Sever_IP
            // 
            this.panel_Sever_IP.Controls.Add(this.textBox_IP);
            this.panel_Sever_IP.Controls.Add(this.label_IP);
            this.panel_Sever_IP.Location = new System.Drawing.Point(13, 13);
            this.panel_Sever_IP.Name = "panel_Sever_IP";
            this.panel_Sever_IP.Size = new System.Drawing.Size(265, 24);
            this.panel_Sever_IP.TabIndex = 1;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IP.Enabled = false;
            this.textBox_IP.Location = new System.Drawing.Point(24, 0);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(241, 21);
            this.textBox_IP.TabIndex = 1;
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_IP.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_IP.Location = new System.Drawing.Point(0, 0);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 15);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP :";
            // 
            // panel_Sever_Port
            // 
            this.panel_Sever_Port.Controls.Add(this.textBox_Port);
            this.panel_Sever_Port.Controls.Add(this.label_Port);
            this.panel_Sever_Port.Location = new System.Drawing.Point(285, 13);
            this.panel_Sever_Port.Name = "panel_Sever_Port";
            this.panel_Sever_Port.Size = new System.Drawing.Size(122, 24);
            this.panel_Sever_Port.TabIndex = 2;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Port.Location = new System.Drawing.Point(36, 0);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(86, 21);
            this.textBox_Port.TabIndex = 1;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Port.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Port.Location = new System.Drawing.Point(0, 0);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(36, 15);
            this.label_Port.TabIndex = 0;
            this.label_Port.Text = "Port :";
            // 
            // button_Server_Start
            // 
            this.button_Server_Start.Location = new System.Drawing.Point(426, 13);
            this.button_Server_Start.Name = "button_Server_Start";
            this.button_Server_Start.Size = new System.Drawing.Size(125, 23);
            this.button_Server_Start.TabIndex = 3;
            this.button_Server_Start.Text = "Start";
            this.button_Server_Start.UseVisualStyleBackColor = true;
            this.button_Server_Start.Click += new System.EventHandler(this.button_Server_Start_Click);
            // 
            // button_Find_Path
            // 
            this.button_Find_Path.Location = new System.Drawing.Point(426, 84);
            this.button_Find_Path.Name = "button_Find_Path";
            this.button_Find_Path.Size = new System.Drawing.Size(99, 23);
            this.button_Find_Path.TabIndex = 4;
            this.button_Find_Path.Text = "Find Path";
            this.button_Find_Path.UseVisualStyleBackColor = true;
            this.button_Find_Path.Click += new System.EventHandler(this.button_Find_Path_Click);
            // 
            // panel_Storage_Path
            // 
            this.panel_Storage_Path.Controls.Add(this.textBox_Storage_Path);
            this.panel_Storage_Path.Controls.Add(this.label_Storage_Path);
            this.panel_Storage_Path.Location = new System.Drawing.Point(16, 84);
            this.panel_Storage_Path.Name = "panel_Storage_Path";
            this.panel_Storage_Path.Size = new System.Drawing.Size(404, 23);
            this.panel_Storage_Path.TabIndex = 5;
            // 
            // textBox_Storage_Path
            // 
            this.textBox_Storage_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Storage_Path.Location = new System.Drawing.Point(134, 0);
            this.textBox_Storage_Path.Name = "textBox_Storage_Path";
            this.textBox_Storage_Path.Size = new System.Drawing.Size(270, 21);
            this.textBox_Storage_Path.TabIndex = 1;
            // 
            // label_Storage_Path
            // 
            this.label_Storage_Path.AutoSize = true;
            this.label_Storage_Path.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Storage_Path.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Storage_Path.Location = new System.Drawing.Point(0, 0);
            this.label_Storage_Path.Name = "label_Storage_Path";
            this.label_Storage_Path.Size = new System.Drawing.Size(134, 15);
            this.label_Storage_Path.TabIndex = 0;
            this.label_Storage_Path.Text = "MP3 File Storage Path :";
            // 
            // label_Sever_Status
            // 
            this.label_Sever_Status.AutoSize = true;
            this.label_Sever_Status.Location = new System.Drawing.Point(13, 147);
            this.label_Sever_Status.Name = "label_Sever_Status";
            this.label_Sever_Status.Size = new System.Drawing.Size(57, 12);
            this.label_Sever_Status.TabIndex = 6;
            this.label_Sever_Status.Text = "서버 상태";
            // 
            // label_Music_List
            // 
            this.label_Music_List.AutoSize = true;
            this.label_Music_List.Location = new System.Drawing.Point(275, 146);
            this.label_Music_List.Name = "label_Music_List";
            this.label_Music_List.Size = new System.Drawing.Size(64, 12);
            this.label_Music_List.TabIndex = 7;
            this.label_Music_List.Text = "Music List";
            // 
            // folder_Browser_Dialog
            // 
            this.folder_Browser_Dialog.SelectedPath = "D:\\";
            // 
            // form_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 370);
            this.Controls.Add(this.label_Music_List);
            this.Controls.Add(this.label_Sever_Status);
            this.Controls.Add(this.panel_Storage_Path);
            this.Controls.Add(this.button_Find_Path);
            this.Controls.Add(this.button_Server_Start);
            this.Controls.Add(this.panel_Sever_Port);
            this.Controls.Add(this.panel_Sever_IP);
            this.Controls.Add(this.panel_Bottom_Full);
            this.Name = "form_Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_Server_FormClosed);
            this.Load += new System.EventHandler(this.form_Server_Load);
            this.panel_Bottom_Full.ResumeLayout(false);
            this.panel_Music_Log.ResumeLayout(false);
            this.panel_Music_Log.PerformLayout();
            this.panel_Music_List.ResumeLayout(false);
            this.panel_Sever_IP.ResumeLayout(false);
            this.panel_Sever_IP.PerformLayout();
            this.panel_Sever_Port.ResumeLayout(false);
            this.panel_Sever_Port.PerformLayout();
            this.panel_Storage_Path.ResumeLayout(false);
            this.panel_Storage_Path.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Bottom_Full;
        private System.Windows.Forms.Panel panel_Music_Log;
        private System.Windows.Forms.TextBox textBox_Music_Log;
        private System.Windows.Forms.Panel panel_Music_List;
        private System.Windows.Forms.ListView listView_Music_List;
        private System.Windows.Forms.ColumnHeader Music_Name;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Play_Time;
        private System.Windows.Forms.ColumnHeader Bit_Rate;
        private System.Windows.Forms.Panel panel_Sever_IP;
        private System.Windows.Forms.Panel panel_Sever_Port;
        private System.Windows.Forms.Button button_Server_Start;
        private System.Windows.Forms.Button button_Find_Path;
        private System.Windows.Forms.Panel panel_Storage_Path;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_Sever_Status;
        private System.Windows.Forms.Label label_Music_List;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_Storage_Path;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Storage_Path;
        private System.Windows.Forms.FolderBrowserDialog folder_Browser_Dialog;
    }
}

