namespace WorksAssign.Pages {
    partial class NewWorks {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Station = new Sunny.UI.UILabel();
            this.lbl_WorkDate = new Sunny.UI.UILabel();
            this.lbl_WorkContent = new Sunny.UI.UILabel();
            this.lbl_Leader = new Sunny.UI.UILabel();
            this.lbl_Manager = new Sunny.UI.UILabel();
            this.lbl_Member = new Sunny.UI.UILabel();
            this.txt_WorkContent = new Sunny.UI.UITextBox();
            this.txt_Member = new Sunny.UI.UITextBox();
            this.cb_Substation = new Sunny.UI.UIComboBox();
            this.cb_Leader = new Sunny.UI.UIComboBox();
            this.cb_Manager = new Sunny.UI.UIComboBox();
            this.dpk_WorkDate = new Sunny.UI.UIDatePicker();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btn_OK = new Sunny.UI.UISymbolButton();
            this.btn_Reset = new Sunny.UI.UISymbolButton();
            this.lbl_WorkType = new Sunny.UI.UILabel();
            this.cb_WorkType = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.cb_ShortType = new Sunny.UI.UIComboBox();
            this.SuspendLayout();
            // 
            // lbl_Station
            // 
            this.lbl_Station.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Station.Location = new System.Drawing.Point(30, 40);
            this.lbl_Station.Name = "lbl_Station";
            this.lbl_Station.Size = new System.Drawing.Size(73, 23);
            this.lbl_Station.TabIndex = 0;
            this.lbl_Station.Text = "变电站";
            this.lbl_Station.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_WorkDate
            // 
            this.lbl_WorkDate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_WorkDate.Location = new System.Drawing.Point(323, 39);
            this.lbl_WorkDate.Name = "lbl_WorkDate";
            this.lbl_WorkDate.Size = new System.Drawing.Size(100, 23);
            this.lbl_WorkDate.TabIndex = 0;
            this.lbl_WorkDate.Text = "日期";
            this.lbl_WorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_WorkContent
            // 
            this.lbl_WorkContent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_WorkContent.Location = new System.Drawing.Point(30, 129);
            this.lbl_WorkContent.Name = "lbl_WorkContent";
            this.lbl_WorkContent.Size = new System.Drawing.Size(82, 23);
            this.lbl_WorkContent.TabIndex = 0;
            this.lbl_WorkContent.Text = "工作内容";
            this.lbl_WorkContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Leader
            // 
            this.lbl_Leader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Leader.Location = new System.Drawing.Point(30, 342);
            this.lbl_Leader.Name = "lbl_Leader";
            this.lbl_Leader.Size = new System.Drawing.Size(73, 23);
            this.lbl_Leader.TabIndex = 0;
            this.lbl_Leader.Text = "负责人";
            this.lbl_Leader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Manager
            // 
            this.lbl_Manager.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Manager.Location = new System.Drawing.Point(363, 342);
            this.lbl_Manager.Name = "lbl_Manager";
            this.lbl_Manager.Size = new System.Drawing.Size(100, 23);
            this.lbl_Manager.TabIndex = 0;
            this.lbl_Manager.Text = "管理人员";
            this.lbl_Manager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Member
            // 
            this.lbl_Member.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Member.Location = new System.Drawing.Point(12, 375);
            this.lbl_Member.Name = "lbl_Member";
            this.lbl_Member.Size = new System.Drawing.Size(100, 23);
            this.lbl_Member.TabIndex = 0;
            this.lbl_Member.Text = "工作班成员";
            this.lbl_Member.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_WorkContent
            // 
            this.txt_WorkContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_WorkContent.FillColor = System.Drawing.Color.White;
            this.txt_WorkContent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_WorkContent.Location = new System.Drawing.Point(117, 129);
            this.txt_WorkContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_WorkContent.Maximum = 2147483647D;
            this.txt_WorkContent.Minimum = -2147483648D;
            this.txt_WorkContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_WorkContent.Multiline = true;
            this.txt_WorkContent.Name = "txt_WorkContent";
            this.txt_WorkContent.Padding = new System.Windows.Forms.Padding(5);
            this.txt_WorkContent.Size = new System.Drawing.Size(691, 196);
            this.txt_WorkContent.TabIndex = 3;
            // 
            // txt_Member
            // 
            this.txt_Member.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Member.FillColor = System.Drawing.Color.White;
            this.txt_Member.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_Member.Location = new System.Drawing.Point(117, 375);
            this.txt_Member.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Member.Maximum = 2147483647D;
            this.txt_Member.Minimum = -2147483648D;
            this.txt_Member.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_Member.Multiline = true;
            this.txt_Member.Name = "txt_Member";
            this.txt_Member.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Member.Size = new System.Drawing.Size(689, 114);
            this.txt_Member.TabIndex = 6;
            // 
            // cb_Substation
            // 
            this.cb_Substation.FillColor = System.Drawing.Color.White;
            this.cb_Substation.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Substation.Location = new System.Drawing.Point(117, 33);
            this.cb_Substation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Substation.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Substation.Name = "cb_Substation";
            this.cb_Substation.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Substation.Size = new System.Drawing.Size(150, 34);
            this.cb_Substation.TabIndex = 1;
            this.cb_Substation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Substation.EditorLostFocus += new System.EventHandler(this.cb_Substation_EditorLostFocus);
            // 
            // cb_Leader
            // 
            this.cb_Leader.FillColor = System.Drawing.Color.White;
            this.cb_Leader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Leader.Location = new System.Drawing.Point(117, 335);
            this.cb_Leader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Leader.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Leader.Name = "cb_Leader";
            this.cb_Leader.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Leader.Size = new System.Drawing.Size(150, 34);
            this.cb_Leader.TabIndex = 4;
            this.cb_Leader.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Leader.EditorLostFocus += new System.EventHandler(this.cb_Leader_EditorLostFocus);
            // 
            // cb_Manager
            // 
            this.cb_Manager.FillColor = System.Drawing.Color.White;
            this.cb_Manager.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Manager.Location = new System.Drawing.Point(448, 335);
            this.cb_Manager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Manager.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Manager.Name = "cb_Manager";
            this.cb_Manager.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Manager.Size = new System.Drawing.Size(150, 34);
            this.cb_Manager.TabIndex = 5;
            this.cb_Manager.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Manager.EditorLostFocus += new System.EventHandler(this.cb_Manager_EditorLostFocus);
            // 
            // dpk_WorkDate
            // 
            this.dpk_WorkDate.FillColor = System.Drawing.Color.White;
            this.dpk_WorkDate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_WorkDate.Location = new System.Drawing.Point(380, 33);
            this.dpk_WorkDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_WorkDate.MaxLength = 10;
            this.dpk_WorkDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_WorkDate.Name = "dpk_WorkDate";
            this.dpk_WorkDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_WorkDate.Size = new System.Drawing.Size(150, 34);
            this.dpk_WorkDate.SymbolDropDown = 61555;
            this.dpk_WorkDate.SymbolNormal = 61555;
            this.dpk_WorkDate.TabIndex = 2;
            this.dpk_WorkDate.Text = "2020-12-23";
            this.dpk_WorkDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_WorkDate.Value = new System.DateTime(2020, 12, 23, 8, 56, 4, 768);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.Location = new System.Drawing.Point(12, 497);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(813, 29);
            this.uiLine1.TabIndex = 7;
            this.uiLine1.TabStop = false;
            // 
            // btn_OK
            // 
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_OK.Location = new System.Drawing.Point(160, 532);
            this.btn_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 35);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "添加";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Reset.Location = new System.Drawing.Point(558, 532);
            this.btn_Reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(100, 35);
            this.btn_Reset.Symbol = 61714;
            this.btn_Reset.TabIndex = 8;
            this.btn_Reset.Text = "重置";
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // lbl_WorkType
            // 
            this.lbl_WorkType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_WorkType.Location = new System.Drawing.Point(30, 89);
            this.lbl_WorkType.Name = "lbl_WorkType";
            this.lbl_WorkType.Size = new System.Drawing.Size(82, 23);
            this.lbl_WorkType.TabIndex = 0;
            this.lbl_WorkType.Text = "工作类型";
            this.lbl_WorkType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_WorkType
            // 
            this.cb_WorkType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_WorkType.FillColor = System.Drawing.Color.White;
            this.cb_WorkType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_WorkType.Location = new System.Drawing.Point(117, 87);
            this.cb_WorkType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_WorkType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_WorkType.Name = "cb_WorkType";
            this.cb_WorkType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_WorkType.Size = new System.Drawing.Size(689, 34);
            this.cb_WorkType.TabIndex = 1;
            this.cb_WorkType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(578, 39);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(73, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "短类型";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_ShortType
            // 
            this.cb_ShortType.FillColor = System.Drawing.Color.White;
            this.cb_ShortType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_ShortType.Items.AddRange(new object[] {
            "查勘",
            "预试",
            "处缺",
            "直流预试",
            "抢修",
            "验收",
            "内务",
            "出差",
            "培训"});
            this.cb_ShortType.Location = new System.Drawing.Point(658, 32);
            this.cb_ShortType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_ShortType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_ShortType.Name = "cb_ShortType";
            this.cb_ShortType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_ShortType.Size = new System.Drawing.Size(150, 34);
            this.cb_ShortType.TabIndex = 1;
            this.cb_ShortType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_ShortType.EditorLostFocus += new System.EventHandler(this.cb_Substation_EditorLostFocus);
            // 
            // NewWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(837, 592);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.dpk_WorkDate);
            this.Controls.Add(this.cb_Manager);
            this.Controls.Add(this.cb_Leader);
            this.Controls.Add(this.cb_WorkType);
            this.Controls.Add(this.cb_ShortType);
            this.Controls.Add(this.cb_Substation);
            this.Controls.Add(this.txt_Member);
            this.Controls.Add(this.txt_WorkContent);
            this.Controls.Add(this.lbl_Member);
            this.Controls.Add(this.lbl_Manager);
            this.Controls.Add(this.lbl_Leader);
            this.Controls.Add(this.lbl_WorkType);
            this.Controls.Add(this.lbl_WorkContent);
            this.Controls.Add(this.lbl_WorkDate);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.lbl_Station);
            this.Name = "NewWorks";
            this.Text = "NewWorks";
            this.Initialize += new System.EventHandler(this.NewWorks_Initialize);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lbl_Station;
        private Sunny.UI.UILabel lbl_WorkDate;
        private Sunny.UI.UILabel lbl_WorkContent;
        private Sunny.UI.UILabel lbl_Leader;
        private Sunny.UI.UILabel lbl_Manager;
        private Sunny.UI.UILabel lbl_Member;
        private Sunny.UI.UITextBox txt_WorkContent;
        private Sunny.UI.UITextBox txt_Member;
        private Sunny.UI.UIComboBox cb_Substation;
        private Sunny.UI.UIComboBox cb_Leader;
        private Sunny.UI.UIComboBox cb_Manager;
        private Sunny.UI.UIDatePicker dpk_WorkDate;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton btn_OK;
        private Sunny.UI.UISymbolButton btn_Reset;
        private Sunny.UI.UILabel lbl_WorkType;
        private Sunny.UI.UIComboBox cb_WorkType;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cb_ShortType;
    }
}