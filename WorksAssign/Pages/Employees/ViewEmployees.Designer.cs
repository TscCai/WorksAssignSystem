using System.Windows.Forms;

namespace WorksAssign.Pages
{
    partial class ViewEmployees
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
           
            // 
            // lbl_Header
            // 
            this.pnl_Footer.Controls.SetChildIndex(this.pgr_Data, 0);
            // 
            // ViewEmployees
            // 

            this.Initialize += new System.EventHandler(this.ViewEmployees_Initialize);
   
        }

        #endregion


        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsCCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_JoinDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Chk;

        protected override void AppendControl() {

            //   this.pnl_Header.FlowDirection = FlowDirection.LeftToRight;
            this.col_IsCCP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_JoinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            // 
            // col_IsCCP
            // 
            this.col_IsCCP.DataPropertyName = "IsCCp";
            this.col_IsCCP.HeaderText = "是否党员";
            this.col_IsCCP.Name = "col_IsCCP";
            this.col_IsCCP.ReadOnly = true;
            // 
            // col_JoinDate
            // 
            this.col_JoinDate.DataPropertyName = "JoinDate";
            this.col_JoinDate.HeaderText = "参工日期";
            this.col_JoinDate.Name = "col_JoinDate";
            this.col_JoinDate.ReadOnly = true;
            // 
            // col_Sex
            // 
            this.col_Sex.DataPropertyName = "Sex";
            this.col_Sex.HeaderText = "性别";
            this.col_Sex.Name = "col_Sex";
            this.col_Sex.ReadOnly = true;
            // 
            // col_Name
            // 
            this.col_Name.DataPropertyName = "Name";
            this.col_Name.HeaderText = "姓名";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_Chk
            // 
            this.col_Chk.HeaderText = "选择";
            this.col_Chk.Name = "col_Chk";
            this.col_Chk.Resizable = DataGridViewTriState.True;
            this.col_Chk.SortMode = DataGridViewColumnSortMode.Automatic;

            this.dg_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Data.Columns.AddRange(new DataGridViewColumn[] {
            this.col_Chk,this.col_Name,col_Sex,col_JoinDate,col_IsCCP});

            this.col_Chk.ReadOnly = false;
          //  pgr_Data.PageChanged += Pgr_Data_PageChanged;
            AddButtons();
        }


    }
}