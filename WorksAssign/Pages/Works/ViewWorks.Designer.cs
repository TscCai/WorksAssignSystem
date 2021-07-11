using System.Windows.Forms;
using Sunny.UI;

namespace WorksAssign.Pages.Works
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
            this.pnl_Header.SuspendLayout();
            this.pnl_Footer.SuspendLayout();
            this.SuspendLayout();
            this.pnl_Footer.Controls.SetChildIndex(this.pgr_Data, 0);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 618);
            this.Name = "View";
            this.Text = "View";
            this.pnl_Header.ResumeLayout(false);
            this.pnl_Footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        UISymbolButton btn_Export = new UISymbolButton();
        UISymbolButton btn_Del = new UISymbolButton();
        UISymbolButton btn_Edit = new UISymbolButton();
        UISymbolButton btn_Search = new UISymbolButton();
        UILabel uiLabel1 = new UILabel();
        UILabel uiLabel2 = new UILabel();
        UIDatePicker dpk_Start = new UIDatePicker();
        UIDatePicker dpk_End = new UIDatePicker();

        private System.Windows.Forms.DataGridViewCheckBoxColumn col_chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_WorkContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Leader;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_exMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_manager;


        protected override void AppendControl() {
            pnl_Header.FlowDirection = FlowDirection.LeftToRight;

            this.btn_Export.Cursor = Cursors.Hand;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 12F);
            btn_Export.Size = new System.Drawing.Size(110, 30);
            this.btn_Export.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Symbol = 61920;
            this.btn_Export.TabIndex = 19;
            this.btn_Export.Text = "导出所有";
            btn_Export.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            // 
            // btn_Del
            // 
            this.btn_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 12F);
            btn_Del.Size = new System.Drawing.Size(85, 30); 
            this.btn_Del.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Symbol = 61544;
            this.btn_Del.TabIndex = 17;
            this.btn_Del.Text = "删除";
            btn_Del.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Edit.MinimumSize = new System.Drawing.Size(1, 1);
            btn_Edit.Size = new System.Drawing.Size(85, 30);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Symbol = 61508;
            this.btn_Edit.TabIndex = 18;
            this.btn_Edit.Text = "编辑";
            btn_Edit.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            // 
            // btn_Search
            // 
            
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Search.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(85, 30);
            this.btn_Search.Symbol = 61442;
            this.btn_Search.TabIndex = 14;
            this.btn_Search.Text = "查询";
            btn_Search.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            // 
            // dpk_Start
            // 
            this.dpk_Start.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpk_Start.FillColor = System.Drawing.Color.White;
            this.dpk_Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_Start.Margin = new System.Windows.Forms.Padding(4, 10, 4, 5);
            this.dpk_Start.MaxLength = 10;
            this.dpk_Start.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_Start.Name = "dpk_Start";
            this.dpk_Start.Size = new System.Drawing.Size(150, 34);
            this.dpk_Start.SymbolDropDown = 61555;
            this.dpk_Start.SymbolNormal = 61555;
            this.dpk_Start.TabIndex = 13;
            this.dpk_Start.Text = "2020-12-08";
            this.dpk_Start.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_Start.Value = new System.DateTime(2020, 12, 8, 0, 0, 0, 0);
            // 
            // dpk_End
            // 
            this.dpk_End.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpk_End.FillColor = System.Drawing.Color.White;
            this.dpk_End.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_End.Margin = new System.Windows.Forms.Padding(4, 10, 4, 5);
            this.dpk_End.MaxLength = 10;
            this.dpk_End.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_End.Name = "dpk_End";
            this.dpk_End.Size = new System.Drawing.Size(150, 34);
            this.dpk_End.SymbolDropDown = 61555;
            this.dpk_End.SymbolNormal = 61555;
            this.dpk_End.TabIndex = 12;
            this.dpk_End.Text = "2020-12-09";
            this.dpk_End.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_End.Value = new System.DateTime(2020, 12, 9, 0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(193, 2);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(33, 51);
            this.uiLabel2.TabIndex = 15;
            this.uiLabel2.Text = "至";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(23, 51);
            this.uiLabel1.TabIndex = 16;
            this.uiLabel1.Text = "从";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            pnl_Header.AddControl(uiLabel1);
            pnl_Header.AddControl(dpk_Start);
            pnl_Header.AddControl(uiLabel2);
            pnl_Header.AddControl(dpk_End);
            pnl_Header.AddControl(btn_Search);
            pnl_Header.AddControl(btn_Edit);
            pnl_Header.AddControl(btn_Del);
            pnl_Header.AddControl(btn_Export);

            this.col_chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_WorkContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Leader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_exMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();

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



            btn_Export.Click += btn_Export_Click;
            btn_Del.Click += btn_Del_Click;
            btn_Search.Click += btn_Search_Click;
            btn_Edit.Click += btn_Edit_Click;
            dg_Data.Columns.AddRange(new DataGridViewColumn[] { col_chk, col_Date, col_WorkContent, col_Leader, col_manager, col_Member,col_exMember });
        }

        #endregion
    }
}