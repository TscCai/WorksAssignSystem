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

    }
}