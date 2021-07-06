namespace WorksAssign.Pages
{
    partial class ViewWorks
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
            this.dg_worksAssign = new Sunny.UI.UIDataGridView();
            this.col_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_WorkContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Leader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_exMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpk_Start = new Sunny.UI.UIDatePicker();
            this.dpk_End = new Sunny.UI.UIDatePicker();
            this.btn_Search = new Sunny.UI.UISymbolButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btn_Edit = new Sunny.UI.UISymbolButton();
            this.pgr_workContent = new Sunny.UI.UIPagination();
            this.btn_Del = new Sunny.UI.UISymbolButton();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btn_Export = new Sunny.UI.UISymbolButton();
            this.uiPanel14 = new Sunny.UI.UIPanel();
            this.uiPanel6 = new Sunny.UI.UIPanel();
            this.uiPanel5 = new Sunny.UI.UIPanel();
            this.uiPanel4 = new Sunny.UI.UIPanel();
            this.uiPanel7 = new Sunny.UI.UIPanel();
            this.uiPanel13 = new Sunny.UI.UIPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dg_worksAssign)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.uiPanel7.SuspendLayout();
            this.uiPanel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_worksAssign
            // 
            this.dg_worksAssign.AllowUserToAddRows = false;
            this.dg_worksAssign.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dg_worksAssign.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_worksAssign.BackgroundColor = System.Drawing.Color.White;
            this.dg_worksAssign.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_worksAssign.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_worksAssign.ColumnHeadersHeight = 32;
            this.dg_worksAssign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_worksAssign.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_chk,
            this.col_Date,
            this.col_WorkContent,
            this.col_Leader,
            this.col_Member,
            this.col_exMember,
            this.col_manager});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_worksAssign.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_worksAssign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_worksAssign.EnableHeadersVisualStyles = false;
            this.dg_worksAssign.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dg_worksAssign.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dg_worksAssign.Location = new System.Drawing.Point(34, 0);
            this.dg_worksAssign.Name = "dg_worksAssign";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dg_worksAssign.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_worksAssign.RowTemplate.Height = 29;
            this.dg_worksAssign.SelectedIndex = -1;
            this.dg_worksAssign.ShowGridLine = true;
            this.dg_worksAssign.Size = new System.Drawing.Size(814, 458);
            this.dg_worksAssign.TabIndex = 0;
            // 
            // col_chk
            // 
            this.col_chk.HeaderText = "选择";
            this.col_chk.Name = "col_chk";
            this.col_chk.Width = 60;
            // 
            // col_Date
            // 
            this.col_Date.DataPropertyName = "Date";
            this.col_Date.HeaderText = "时间";
            this.col_Date.Name = "col_Date";
            this.col_Date.ReadOnly = true;
            this.col_Date.Width = 110;
            // 
            // col_WorkContent
            // 
            this.col_WorkContent.DataPropertyName = "Content";
            this.col_WorkContent.HeaderText = "工作内容";
            this.col_WorkContent.Name = "col_WorkContent";
            this.col_WorkContent.ReadOnly = true;
            this.col_WorkContent.Width = 200;
            // 
            // col_Leader
            // 
            this.col_Leader.DataPropertyName = "Leader";
            this.col_Leader.HeaderText = "负责人";
            this.col_Leader.Name = "col_Leader";
            this.col_Leader.ReadOnly = true;
            // 
            // col_Member
            // 
            this.col_Member.DataPropertyName = "Member";
            this.col_Member.HeaderText = "工作班成员";
            this.col_Member.Name = "col_Member";
            this.col_Member.ReadOnly = true;
            // 
            // col_exMember
            // 
            this.col_exMember.DataPropertyName = "ExMember";
            this.col_exMember.HeaderText = "外协人员";
            this.col_exMember.Name = "col_exMember";
            this.col_exMember.ReadOnly = true;
            // 
            // col_manager
            // 
            this.col_manager.DataPropertyName = "Manager";
            this.col_manager.HeaderText = "管理人员";
            this.col_manager.Name = "col_manager";
            this.col_manager.ReadOnly = true;
            // 
            // dpk_Start
            // 
            this.dpk_Start.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpk_Start.FillColor = System.Drawing.Color.White;
            this.dpk_Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_Start.Location = new System.Drawing.Point(57, 20);
            this.dpk_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_Start.MaxLength = 10;
            this.dpk_Start.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_Start.Name = "dpk_Start";
            this.dpk_Start.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_Start.Size = new System.Drawing.Size(150, 30);
            this.dpk_Start.SymbolDropDown = 61555;
            this.dpk_Start.SymbolNormal = 61555;
            this.dpk_Start.TabIndex = 1;
            this.dpk_Start.Text = "2020-12-08";
            this.dpk_Start.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_Start.Value = new System.DateTime(2020, 12, 8, 0, 0, 0, 0);
            // 
            // dpk_End
            // 
            this.dpk_End.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpk_End.FillColor = System.Drawing.Color.White;
            this.dpk_End.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_End.Location = new System.Drawing.Point(240, 20);
            this.dpk_End.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_End.MaxLength = 10;
            this.dpk_End.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_End.Name = "dpk_End";
            this.dpk_End.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_End.Size = new System.Drawing.Size(150, 30);
            this.dpk_End.SymbolDropDown = 61555;
            this.dpk_End.SymbolNormal = 61555;
            this.dpk_End.TabIndex = 1;
            this.dpk_End.Text = "2020-12-09";
            this.dpk_End.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_End.Value = new System.DateTime(2020, 12, 9, 0, 0, 0, 0);
            // 
            // btn_Search
            // 
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Search.Location = new System.Drawing.Point(405, 20);
            this.btn_Search.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(85, 34);
            this.btn_Search.Symbol = 61442;
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "查询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(34, 20);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(23, 34);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "从";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(207, 20);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(33, 34);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "至";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Edit.Location = new System.Drawing.Point(505, 20);
            this.btn_Edit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(100, 34);
            this.btn_Edit.Symbol = 61508;
            this.btn_Edit.TabIndex = 4;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // pgr_workContent
            // 
            this.pgr_workContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgr_workContent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pgr_workContent.Location = new System.Drawing.Point(34, 10);
            this.pgr_workContent.Margin = new System.Windows.Forms.Padding(0);
            this.pgr_workContent.MinimumSize = new System.Drawing.Size(1, 1);
            this.pgr_workContent.Name = "pgr_workContent";
            this.pgr_workContent.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.pgr_workContent.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pgr_workContent.ShowJumpButton = false;
            this.pgr_workContent.Size = new System.Drawing.Size(814, 58);
            this.pgr_workContent.TabIndex = 5;
            this.pgr_workContent.Text = "uiPagination1";
            this.pgr_workContent.TotalCount = 0;
            this.pgr_workContent.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.pgr_workContent_PageChanged);
            // 
            // btn_Del
            // 
            this.btn_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Del.Location = new System.Drawing.Point(620, 20);
            this.btn_Del.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(100, 34);
            this.btn_Del.Symbol = 61544;
            this.btn_Del.TabIndex = 4;
            this.btn_Del.Text = "删除";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.btn_Export);
            this.uiPanel2.Controls.Add(this.uiPanel14);
            this.uiPanel2.Controls.Add(this.btn_Del);
            this.uiPanel2.Controls.Add(this.uiPanel6);
            this.uiPanel2.Controls.Add(this.btn_Edit);
            this.uiPanel2.Controls.Add(this.uiPanel5);
            this.uiPanel2.Controls.Add(this.btn_Search);
            this.uiPanel2.Controls.Add(this.uiPanel4);
            this.uiPanel2.Controls.Add(this.dpk_End);
            this.uiPanel2.Controls.Add(this.uiLabel2);
            this.uiPanel2.Controls.Add(this.dpk_Start);
            this.uiPanel2.Controls.Add(this.uiLabel1);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Padding = new System.Windows.Forms.Padding(34, 20, 34, 20);
            this.uiPanel2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel2.Size = new System.Drawing.Size(882, 74);
            this.uiPanel2.TabIndex = 7;
            this.uiPanel2.Text = null;
            // 
            // btn_Export
            // 
            this.btn_Export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Export.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Export.Location = new System.Drawing.Point(735, 20);
            this.btn_Export.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(115, 34);
            this.btn_Export.Symbol = 61920;
            this.btn_Export.TabIndex = 11;
            this.btn_Export.Text = "导出所有";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // uiPanel14
            // 
            this.uiPanel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel14.Location = new System.Drawing.Point(720, 20);
            this.uiPanel14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel14.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel14.Name = "uiPanel14";
            this.uiPanel14.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiPanel14.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel14.Size = new System.Drawing.Size(15, 34);
            this.uiPanel14.TabIndex = 10;
            this.uiPanel14.Text = null;
            // 
            // uiPanel6
            // 
            this.uiPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel6.Location = new System.Drawing.Point(605, 20);
            this.uiPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel6.Name = "uiPanel6";
            this.uiPanel6.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiPanel6.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel6.Size = new System.Drawing.Size(15, 34);
            this.uiPanel6.TabIndex = 9;
            this.uiPanel6.Text = null;
            // 
            // uiPanel5
            // 
            this.uiPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel5.Location = new System.Drawing.Point(490, 20);
            this.uiPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel5.Name = "uiPanel5";
            this.uiPanel5.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiPanel5.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel5.Size = new System.Drawing.Size(15, 34);
            this.uiPanel5.TabIndex = 8;
            this.uiPanel5.Text = null;
            // 
            // uiPanel4
            // 
            this.uiPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiPanel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel4.Location = new System.Drawing.Point(390, 20);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiPanel4.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel4.Size = new System.Drawing.Size(15, 34);
            this.uiPanel4.TabIndex = 8;
            this.uiPanel4.Text = null;
            // 
            // uiPanel7
            // 
            this.uiPanel7.Controls.Add(this.dg_worksAssign);
            this.uiPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel7.Location = new System.Drawing.Point(0, 74);
            this.uiPanel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel7.Name = "uiPanel7";
            this.uiPanel7.Padding = new System.Windows.Forms.Padding(34, 0, 34, 0);
            this.uiPanel7.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel7.Size = new System.Drawing.Size(882, 458);
            this.uiPanel7.TabIndex = 10;
            this.uiPanel7.Text = "uiPanel7";
            // 
            // uiPanel13
            // 
            this.uiPanel13.Controls.Add(this.pgr_workContent);
            this.uiPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel13.Location = new System.Drawing.Point(0, 532);
            this.uiPanel13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel13.Name = "uiPanel13";
            this.uiPanel13.Padding = new System.Windows.Forms.Padding(34, 10, 34, 10);
            this.uiPanel13.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiPanel13.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPanel13.Size = new System.Drawing.Size(882, 78);
            this.uiPanel13.TabIndex = 13;
            this.uiPanel13.Text = null;
            // 
            // ViewWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 610);
            this.Controls.Add(this.uiPanel13);
            this.Controls.Add(this.uiPanel7);
            this.Controls.Add(this.uiPanel2);
            this.Name = "ViewWorks";
            this.Text = "工作概况";
            ((System.ComponentModel.ISupportInitialize)(this.dg_worksAssign)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel7.ResumeLayout(false);
            this.uiPanel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView dg_worksAssign;
        private Sunny.UI.UIDatePicker dpk_Start;
        private Sunny.UI.UIDatePicker dpk_End;
        private Sunny.UI.UISymbolButton btn_Search;
        private Sunny.UI.UILabel uiLabel1;
		private Sunny.UI.UILabel uiLabel2;
		private Sunny.UI.UISymbolButton btn_Edit;
		private Sunny.UI.UIPagination pgr_workContent;
		private Sunny.UI.UISymbolButton btn_Del;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIPanel uiPanel6;
        private Sunny.UI.UIPanel uiPanel5;
        private Sunny.UI.UIPanel uiPanel4;
        private Sunny.UI.UIPanel uiPanel7;
        private Sunny.UI.UIPanel uiPanel13;
        private Sunny.UI.UISymbolButton btn_Export;
        private Sunny.UI.UIPanel uiPanel14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_WorkContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Leader;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_exMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_manager;
    }
}