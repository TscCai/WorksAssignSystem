namespace WorksAssign.Pages
{
    partial class About
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
            this.lbl_AboutMsg = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // lbl_AboutMsg
            // 
            this.lbl_AboutMsg.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_AboutMsg.Location = new System.Drawing.Point(36, 30);
            this.lbl_AboutMsg.Name = "lbl_AboutMsg";
            this.lbl_AboutMsg.Size = new System.Drawing.Size(402, 137);
            this.lbl_AboutMsg.TabIndex = 0;
            this.lbl_AboutMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 460);
            this.Controls.Add(this.lbl_AboutMsg);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lbl_AboutMsg;
    }
}