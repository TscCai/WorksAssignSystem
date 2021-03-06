namespace WorksAssign.Pages
{
    partial class AddEmployee
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.btn_Cancel = new Sunny.UI.UISymbolButton();
            this.btn_OK = new Sunny.UI.UISymbolButton();
            this.txt_Name = new Sunny.UI.UITextBox();
            this.cb_Sex = new Sunny.UI.UIComboBox();
            this.dpk_JoinDate = new Sunny.UI.UIDatePicker();
            this.chk_IsCCP = new Sunny.UI.UICheckBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(87, 67);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(74, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "姓名：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(405, 67);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 23);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "性别：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(47, 153);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(114, 23);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "参工日期：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Cancel.Location = new System.Drawing.Point(486, 420);
            this.btn_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(122, 42);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_OK.Location = new System.Drawing.Point(92, 420);
            this.btn_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(122, 42);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "确定";
            this.btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // txt_Name
            // 
            this.txt_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Name.FillColor = System.Drawing.Color.White;
            this.txt_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txt_Name.Location = new System.Drawing.Point(161, 64);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Name.Maximum = 2147483647D;
            this.txt_Name.Minimum = -2147483648D;
            this.txt_Name.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Name.Size = new System.Drawing.Size(150, 34);
            this.txt_Name.TabIndex = 3;
            // 
            // cb_Sex
            // 
            this.cb_Sex.FillColor = System.Drawing.Color.White;
            this.cb_Sex.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cb_Sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cb_Sex.Location = new System.Drawing.Point(486, 64);
            this.cb_Sex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_Sex.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_Sex.Name = "cb_Sex";
            this.cb_Sex.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cb_Sex.Size = new System.Drawing.Size(150, 34);
            this.cb_Sex.TabIndex = 4;
            this.cb_Sex.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dpk_JoinDate
            // 
            this.dpk_JoinDate.FillColor = System.Drawing.Color.White;
            this.dpk_JoinDate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_JoinDate.Location = new System.Drawing.Point(161, 150);
            this.dpk_JoinDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_JoinDate.MaxLength = 10;
            this.dpk_JoinDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_JoinDate.Name = "dpk_JoinDate";
            this.dpk_JoinDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_JoinDate.Size = new System.Drawing.Size(150, 34);
            this.dpk_JoinDate.SymbolDropDown = 61555;
            this.dpk_JoinDate.SymbolNormal = 61555;
            this.dpk_JoinDate.TabIndex = 5;
            this.dpk_JoinDate.Text = "2021-03-06";
            this.dpk_JoinDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_JoinDate.Value = new System.DateTime(2021, 3, 6, 19, 56, 18, 576);
            // 
            // chk_IsCCP
            // 
            this.chk_IsCCP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_IsCCP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chk_IsCCP.Location = new System.Drawing.Point(410, 147);
            this.chk_IsCCP.MinimumSize = new System.Drawing.Size(1, 1);
            this.chk_IsCCP.Name = "chk_IsCCP";
            this.chk_IsCCP.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chk_IsCCP.Size = new System.Drawing.Size(150, 29);
            this.chk_IsCCP.TabIndex = 6;
            this.chk_IsCCP.Text = "党员";
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.Location = new System.Drawing.Point(3, 385);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(794, 29);
            this.uiLine1.TabIndex = 7;
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.chk_IsCCP);
            this.Controls.Add(this.dpk_JoinDate);
            this.Controls.Add(this.cb_Sex);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel1);
            this.Name = "AddEmployee";
            this.Text = "编辑成员";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILine uiLine1;
        protected Sunny.UI.UITextBox txt_Name;
        protected Sunny.UI.UIComboBox cb_Sex;
        protected Sunny.UI.UIDatePicker dpk_JoinDate;
        protected Sunny.UI.UICheckBox chk_IsCCP;
        protected Sunny.UI.UISymbolButton btn_Cancel;
        protected Sunny.UI.UISymbolButton btn_OK;
    }
}