namespace WorksAssign.Pages
{
    partial class EmployeeManage
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
            this.pnl_Header = new Sunny.UI.UIFlowLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.pgr_Employee = new Sunny.UI.UIPagination();
            this.dg_Employee = new Sunny.UI.UIDataGridView();
            this.pnl_Content = new Sunny.UI.UIFlowLayoutPanel();
            this.uiFlowLayoutPanel1 = new Sunny.UI.UIFlowLayoutPanel();
            this.col_Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_JoinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IsCCP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Employee)).BeginInit();
            this.uiFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.Controls.Add(this.pnl_Content);
            this.pnl_Header.Controls.Add(this.uiLabel1);
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnl_Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_Header.Location = new System.Drawing.Point(0, 0);
            this.pnl_Header.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Header.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Padding = new System.Windows.Forms.Padding(20, 2, 20, 2);
            this.pnl_Header.Size = new System.Drawing.Size(882, 60);
            this.pnl_Header.TabIndex = 0;
            this.pnl_Header.Text = "pnl_Header";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(20, 2);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 56);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "班组成员";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgr_Employee
            // 
            this.pgr_Employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgr_Employee.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pgr_Employee.Location = new System.Drawing.Point(20, 10);
            this.pgr_Employee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pgr_Employee.MinimumSize = new System.Drawing.Size(1, 1);
            this.pgr_Employee.Name = "pgr_Employee";
            this.pgr_Employee.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pgr_Employee.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pgr_Employee.ShowJumpButton = false;
            this.pgr_Employee.Size = new System.Drawing.Size(842, 36);
            this.pgr_Employee.TabIndex = 7;
            this.pgr_Employee.Text = "uiPagination1";
            this.pgr_Employee.TotalCount = 0;
            this.pgr_Employee.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.pgr_Employee_PageChanged);
            // 
            // dg_Employee
            // 
            this.dg_Employee.AllowUserToAddRows = false;
            this.dg_Employee.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dg_Employee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Employee.BackgroundColor = System.Drawing.Color.White;
            this.dg_Employee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Employee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_Employee.ColumnHeadersHeight = 32;
            this.dg_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Employee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Chk,
            this.col_Name,
            this.col_Sex,
            this.col_JoinDate,
            this.col_IsCCP});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Employee.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Employee.EnableHeadersVisualStyles = false;
            this.dg_Employee.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dg_Employee.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dg_Employee.Location = new System.Drawing.Point(0, 60);
            this.dg_Employee.Name = "dg_Employee";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dg_Employee.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_Employee.RowTemplate.Height = 29;
            this.dg_Employee.SelectedIndex = -1;
            this.dg_Employee.ShowGridLine = true;
            this.dg_Employee.Size = new System.Drawing.Size(882, 637);
            this.dg_Employee.TabIndex = 8;
            // 
            // pnl_Content
            // 
            this.pnl_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Content.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_Content.Location = new System.Drawing.Point(120, 2);
            this.pnl_Content.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_Content.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_Content.Name = "pnl_Content";
            this.pnl_Content.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.pnl_Content.Size = new System.Drawing.Size(742, 56);
            this.pnl_Content.TabIndex = 9;
            this.pnl_Content.Text = "uiFlowLayoutPanel1";
            // 
            // uiFlowLayoutPanel1
            // 
            this.uiFlowLayoutPanel1.Controls.Add(this.pgr_Employee);
            this.uiFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiFlowLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiFlowLayoutPanel1.Location = new System.Drawing.Point(0, 641);
            this.uiFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiFlowLayoutPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiFlowLayoutPanel1.Name = "uiFlowLayoutPanel1";
            this.uiFlowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.uiFlowLayoutPanel1.Size = new System.Drawing.Size(882, 56);
            this.uiFlowLayoutPanel1.TabIndex = 10;
            this.uiFlowLayoutPanel1.Text = "uiFlowLayoutPanel1";
            // 
            // col_Chk
            // 
            this.col_Chk.HeaderText = "选择";
            this.col_Chk.Name = "col_Chk";
            this.col_Chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_Name
            // 
            this.col_Name.DataPropertyName = "Name";
            this.col_Name.HeaderText = "姓名";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_Sex
            // 
            this.col_Sex.DataPropertyName = "Sex";
            this.col_Sex.HeaderText = "性别";
            this.col_Sex.Name = "col_Sex";
            this.col_Sex.ReadOnly = true;
            // 
            // col_JoinDate
            // 
            this.col_JoinDate.DataPropertyName = "JoinDate";
            this.col_JoinDate.HeaderText = "参工日期";
            this.col_JoinDate.Name = "col_JoinDate";
            this.col_JoinDate.ReadOnly = true;
            // 
            // col_IsCCP
            // 
            this.col_IsCCP.DataPropertyName = "IsCCp";
            this.col_IsCCP.HeaderText = "是否党员";
            this.col_IsCCP.Name = "col_IsCCP";
            this.col_IsCCP.ReadOnly = true;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 697);
            this.Controls.Add(this.uiFlowLayoutPanel1);
            this.Controls.Add(this.dg_Employee);
            this.Controls.Add(this.pnl_Header);
            this.Name = "Employee";
            this.Text = "Employee";
            this.Initialize += new System.EventHandler(this.Employee_Initialize);
            this.pnl_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Employee)).EndInit();
            this.uiFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel pnl_Header;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPagination pgr_Employee;
        private Sunny.UI.UIDataGridView dg_Employee;
        private Sunny.UI.UIFlowLayoutPanel pnl_Content;
        private Sunny.UI.UIFlowLayoutPanel uiFlowLayoutPanel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_JoinDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsCCP;
    }
}