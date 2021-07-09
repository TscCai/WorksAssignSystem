namespace WorksAssign.Pages.Devices
{
    partial class ViewDevice
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
            this.btn_Search = new Sunny.UI.UISymbolButton();
            this.pnl_Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.Size = new System.Drawing.Size(735, 55);
            // 
            // pnl_Footer
            // 
            this.pnl_Footer.Location = new System.Drawing.Point(0, 470);
            this.pnl_Footer.Size = new System.Drawing.Size(735, 56);
            this.pnl_Footer.Controls.SetChildIndex(this.pgr_Data, 0);
            // 
            // pgr_Data
            // 
            this.pgr_Data.Size = new System.Drawing.Size(695, 36);
            // 
            // btn_Search
            // 
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Search.Location = new System.Drawing.Point(0, 0);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.btn_Search.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 35);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "Test";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // ViewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 526);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ViewDevice";
            this.Text = "ViewDevice";
            this.pnl_Footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton btn_Search;
    }
}