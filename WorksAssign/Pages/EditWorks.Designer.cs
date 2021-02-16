namespace WorksAssign.Pages
{
    partial class EditWorks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Cancel = new Sunny.UI.UISymbolButton();
            this.btn_OK = new Sunny.UI.UISymbolButton();
            this.dpk_WorkDate = new Sunny.UI.UIDatePicker();
            this.cb_Manager = new Sunny.UI.UIComboBox();
            this.cb_Leader = new Sunny.UI.UIComboBox();
            this.cb_WorkType = new Sunny.UI.UIComboBox();
            this.cb_Substation = new Sunny.UI.UIComboBox();
            this.txt_WorkContent = new Sunny.UI.UITextBox();
            this.lbl_Member = new Sunny.UI.UILabel();
            this.lbl_Manager = new Sunny.UI.UILabel();
            this.lbl_Leader = new Sunny.UI.UILabel();
            this.lbl_WorkType = new Sunny.UI.UILabel();
            this.lbl_WorkContent = new Sunny.UI.UILabel();
            this.lbl_WorkDate = new Sunny.UI.UILabel();
            this.lbl_Station = new Sunny.UI.UILabel();
            this.dg_Member = new Sunny.UI.UIDataGridView();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Role = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.uiLine1 = new Sunny.UI.UILine();
            this.txt_exMember = new Sunny.UI.UITextBox();
            this.lbl_exMember = new Sunny.UI.UILabel();
            this.cb_ShortType = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Member)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Cancel.Location = new System.Drawing.Point(497, 595);
            this.btn_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.btn_Cancel.Symbol = 61453;
            this.btn_Cancel.TabIndex = 25;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_OK.Location = new System.Drawing.Point(191, 595);
            this.btn_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 35);
            this.btn_OK.TabIndex = 24;
            this.btn_OK.Text = "确定";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // dpk_WorkDate
            // 
            this.dpk_WorkDate.FillColor = System.Drawing.Color.White;
            this.dpk_WorkDate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_WorkDate.Location = new System.Drawing.Point(389, 58);
            this.dpk_WorkDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_WorkDate.MaxLength = 10;
            this.dpk_WorkDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_WorkDate.Name = "dpk_WorkDate";
            this.dpk_WorkDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_WorkDate.Size = new System.Drawing.Size(150, 30);
            this.dpk_WorkDate.SymbolDropDown = 61555;
            this.dpk_WorkDate.SymbolNormal = 61555;
            this.dpk_WorkDate.TabIndex = 18;
            this.dpk_WorkDate.Text = "2020-12-23";
            this.dpk_WorkDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_WorkDate.Value = new System.DateTime(2020, 12, 23, 8, 56, 4, 768);
            // 
            // cb_Manager
            // 
            this.cb_Manager.FillColor = System.Drawing.Color.White;
            this.cb_Manager.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Manager.Location = new System.Drawing.Point(417, 281);
            this.cb_Manager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Manager.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Manager.Name = "cb_Manager";
            this.cb_Manager.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Manager.Size = new System.Drawing.Size(150, 30);
            this.cb_Manager.TabIndex = 21;
            this.cb_Manager.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Manager.EditorLostFocus += new System.EventHandler(this.cb_Manager_EditorLostFocus);
            // 
            // cb_Leader
            // 
            this.cb_Leader.FillColor = System.Drawing.Color.White;
            this.cb_Leader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Leader.Location = new System.Drawing.Point(143, 281);
            this.cb_Leader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Leader.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Leader.Name = "cb_Leader";
            this.cb_Leader.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Leader.Size = new System.Drawing.Size(150, 30);
            this.cb_Leader.TabIndex = 20;
            this.cb_Leader.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Leader.EditorLostFocus += new System.EventHandler(this.cb_Leader_EditorLostFocus);
            // 
            // cb_WorkType
            // 
            this.cb_WorkType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_WorkType.FillColor = System.Drawing.Color.White;
            this.cb_WorkType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_WorkType.Location = new System.Drawing.Point(141, 106);
            this.cb_WorkType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_WorkType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_WorkType.Name = "cb_WorkType";
            this.cb_WorkType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_WorkType.Size = new System.Drawing.Size(672, 30);
            this.cb_WorkType.TabIndex = 16;
            this.cb_WorkType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_WorkType.SelectedIndexChanged += new System.EventHandler(this.cb_WorkType_SelectedIndexChanged);
            // 
            // cb_Substation
            // 
            this.cb_Substation.FillColor = System.Drawing.Color.White;
            this.cb_Substation.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Substation.Location = new System.Drawing.Point(141, 58);
            this.cb_Substation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Substation.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Substation.Name = "cb_Substation";
            this.cb_Substation.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Substation.Size = new System.Drawing.Size(150, 30);
            this.cb_Substation.TabIndex = 17;
            this.cb_Substation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_Substation.EditorLostFocus += new System.EventHandler(this.cb_Substation_EditorLostFocus);
            // 
            // txt_WorkContent
            // 
            this.txt_WorkContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_WorkContent.FillColor = System.Drawing.Color.White;
            this.txt_WorkContent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_WorkContent.Location = new System.Drawing.Point(141, 154);
            this.txt_WorkContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_WorkContent.Maximum = 2147483647D;
            this.txt_WorkContent.Minimum = -2147483648D;
            this.txt_WorkContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_WorkContent.Multiline = true;
            this.txt_WorkContent.Name = "txt_WorkContent";
            this.txt_WorkContent.Padding = new System.Windows.Forms.Padding(5);
            this.txt_WorkContent.Size = new System.Drawing.Size(672, 111);
            this.txt_WorkContent.TabIndex = 19;
            // 
            // lbl_Member
            // 
            this.lbl_Member.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Member.Location = new System.Drawing.Point(36, 333);
            this.lbl_Member.Name = "lbl_Member";
            this.lbl_Member.Size = new System.Drawing.Size(100, 23);
            this.lbl_Member.TabIndex = 13;
            this.lbl_Member.Text = "工作班成员";
            this.lbl_Member.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Manager
            // 
            this.lbl_Manager.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Manager.Location = new System.Drawing.Point(332, 288);
            this.lbl_Manager.Name = "lbl_Manager";
            this.lbl_Manager.Size = new System.Drawing.Size(100, 23);
            this.lbl_Manager.TabIndex = 14;
            this.lbl_Manager.Text = "管理人员";
            this.lbl_Manager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Leader
            // 
            this.lbl_Leader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Leader.Location = new System.Drawing.Point(54, 288);
            this.lbl_Leader.Name = "lbl_Leader";
            this.lbl_Leader.Size = new System.Drawing.Size(73, 23);
            this.lbl_Leader.TabIndex = 15;
            this.lbl_Leader.Text = "负责人";
            this.lbl_Leader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_WorkType
            // 
            this.lbl_WorkType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_WorkType.Location = new System.Drawing.Point(54, 108);
            this.lbl_WorkType.Name = "lbl_WorkType";
            this.lbl_WorkType.Size = new System.Drawing.Size(82, 23);
            this.lbl_WorkType.TabIndex = 11;
            this.lbl_WorkType.Text = "工作类型";
            this.lbl_WorkType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_WorkContent
            // 
            this.lbl_WorkContent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_WorkContent.Location = new System.Drawing.Point(54, 154);
            this.lbl_WorkContent.Name = "lbl_WorkContent";
            this.lbl_WorkContent.Size = new System.Drawing.Size(82, 23);
            this.lbl_WorkContent.TabIndex = 10;
            this.lbl_WorkContent.Text = "工作内容";
            this.lbl_WorkContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_WorkDate
            // 
            this.lbl_WorkDate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_WorkDate.Location = new System.Drawing.Point(332, 62);
            this.lbl_WorkDate.Name = "lbl_WorkDate";
            this.lbl_WorkDate.Size = new System.Drawing.Size(100, 23);
            this.lbl_WorkDate.TabIndex = 12;
            this.lbl_WorkDate.Text = "日期";
            this.lbl_WorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Station
            // 
            this.lbl_Station.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Station.Location = new System.Drawing.Point(54, 62);
            this.lbl_Station.Name = "lbl_Station";
            this.lbl_Station.Size = new System.Drawing.Size(73, 23);
            this.lbl_Station.TabIndex = 9;
            this.lbl_Station.Text = "变电站";
            this.lbl_Station.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dg_Member
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dg_Member.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Member.BackgroundColor = System.Drawing.Color.White;
            this.dg_Member.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_Member.ColumnHeadersHeight = 32;
            this.dg_Member.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Member.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Name,
            this.col_Role});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Member.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Member.EnableHeadersVisualStyles = false;
            this.dg_Member.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dg_Member.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dg_Member.Location = new System.Drawing.Point(141, 331);
            this.dg_Member.Name = "dg_Member";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dg_Member.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_Member.RowTemplate.Height = 29;
            this.dg_Member.SelectedIndex = -1;
            this.dg_Member.ShowGridLine = true;
            this.dg_Member.Size = new System.Drawing.Size(672, 166);
            this.dg_Member.TabIndex = 26;
            // 
            // col_Name
            // 
            this.col_Name.DataPropertyName = "EmployeeName";
            this.col_Name.HeaderText = "姓名";
            this.col_Name.Name = "col_Name";
            this.col_Name.Width = 282;
            // 
            // col_Role
            // 
            this.col_Role.DataPropertyName = "RoleName";
            this.col_Role.HeaderText = "角色";
            this.col_Role.Name = "col_Role";
            this.col_Role.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Role.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Role.Width = 282;
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.Location = new System.Drawing.Point(3, 560);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(844, 29);
            this.uiLine1.TabIndex = 27;
            this.uiLine1.TabStop = false;
            // 
            // txt_exMember
            // 
            this.txt_exMember.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_exMember.FillColor = System.Drawing.Color.White;
            this.txt_exMember.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_exMember.Location = new System.Drawing.Point(143, 515);
            this.txt_exMember.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_exMember.Maximum = 2147483647D;
            this.txt_exMember.Minimum = -2147483648D;
            this.txt_exMember.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_exMember.Name = "txt_exMember";
            this.txt_exMember.Padding = new System.Windows.Forms.Padding(5);
            this.txt_exMember.Size = new System.Drawing.Size(670, 30);
            this.txt_exMember.TabIndex = 28;
            // 
            // lbl_exMember
            // 
            this.lbl_exMember.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_exMember.Location = new System.Drawing.Point(36, 519);
            this.lbl_exMember.Name = "lbl_exMember";
            this.lbl_exMember.Size = new System.Drawing.Size(100, 23);
            this.lbl_exMember.TabIndex = 13;
            this.lbl_exMember.Text = "外协人员";
            this.lbl_exMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cb_ShortType.Location = new System.Drawing.Point(663, 58);
            this.cb_ShortType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_ShortType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_ShortType.Name = "cb_ShortType";
            this.cb_ShortType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_ShortType.Size = new System.Drawing.Size(150, 30);
            this.cb_ShortType.TabIndex = 30;
            this.cb_ShortType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(583, 62);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(73, 23);
            this.uiLabel1.TabIndex = 29;
            this.uiLabel1.Text = "短类型";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 653);
            this.Controls.Add(this.cb_ShortType);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.txt_exMember);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.dg_Member);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dpk_WorkDate);
            this.Controls.Add(this.cb_Manager);
            this.Controls.Add(this.cb_Leader);
            this.Controls.Add(this.cb_WorkType);
            this.Controls.Add(this.cb_Substation);
            this.Controls.Add(this.txt_WorkContent);
            this.Controls.Add(this.lbl_exMember);
            this.Controls.Add(this.lbl_Member);
            this.Controls.Add(this.lbl_Manager);
            this.Controls.Add(this.lbl_Leader);
            this.Controls.Add(this.lbl_WorkType);
            this.Controls.Add(this.lbl_WorkContent);
            this.Controls.Add(this.lbl_WorkDate);
            this.Controls.Add(this.lbl_Station);
            this.Name = "EditWorks";
            this.Text = "工作编辑";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dg_Member)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton btn_Cancel;
        private Sunny.UI.UISymbolButton btn_OK;
        private Sunny.UI.UIDatePicker dpk_WorkDate;
        private Sunny.UI.UIComboBox cb_Manager;
        private Sunny.UI.UIComboBox cb_Leader;
        private Sunny.UI.UIComboBox cb_WorkType;
        private Sunny.UI.UIComboBox cb_Substation;
        private Sunny.UI.UITextBox txt_WorkContent;
        private Sunny.UI.UILabel lbl_Member;
        private Sunny.UI.UILabel lbl_Manager;
        private Sunny.UI.UILabel lbl_Leader;
        private Sunny.UI.UILabel lbl_WorkType;
        private Sunny.UI.UILabel lbl_WorkContent;
        private Sunny.UI.UILabel lbl_WorkDate;
        private Sunny.UI.UILabel lbl_Station;
        private Sunny.UI.UIDataGridView dg_Member;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UITextBox txt_exMember;
        private Sunny.UI.UILabel lbl_exMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_Role;
        private Sunny.UI.UIComboBox cb_ShortType;
        private Sunny.UI.UILabel uiLabel1;
    }
}