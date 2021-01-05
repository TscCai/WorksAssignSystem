namespace WorksAssign.Pages
{
    partial class AttendanceManage
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
            this.btn_ExportMonthlyAttendance = new Sunny.UI.UISymbolButton();
            this.dpk_MonthlyAttendance = new Sunny.UI.UIDatePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ExportMonthlyAttendance
            // 
            this.btn_ExportMonthlyAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ExportMonthlyAttendance.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ExportMonthlyAttendance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_ExportMonthlyAttendance.Location = new System.Drawing.Point(342, 16);
            this.btn_ExportMonthlyAttendance.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ExportMonthlyAttendance.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ExportMonthlyAttendance.Name = "btn_ExportMonthlyAttendance";
            this.btn_ExportMonthlyAttendance.Size = new System.Drawing.Size(165, 34);
            this.btn_ExportMonthlyAttendance.TabIndex = 0;
            this.btn_ExportMonthlyAttendance.Text = "导出月度考勤表";
            this.btn_ExportMonthlyAttendance.Click += new System.EventHandler(this.btn_ExportMonthlyAttendance_Click);
            // 
            // dpk_MonthlyAttendance
            // 
            this.dpk_MonthlyAttendance.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpk_MonthlyAttendance.FillColor = System.Drawing.Color.White;
            this.dpk_MonthlyAttendance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_MonthlyAttendance.Location = new System.Drawing.Point(160, 19);
            this.dpk_MonthlyAttendance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 5);
            this.dpk_MonthlyAttendance.MaxLength = 10;
            this.dpk_MonthlyAttendance.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_MonthlyAttendance.Name = "dpk_MonthlyAttendance";
            this.dpk_MonthlyAttendance.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_MonthlyAttendance.Size = new System.Drawing.Size(178, 30);
            this.dpk_MonthlyAttendance.SymbolDropDown = 61555;
            this.dpk_MonthlyAttendance.SymbolNormal = 61555;
            this.dpk_MonthlyAttendance.TabIndex = 4;
            this.dpk_MonthlyAttendance.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_MonthlyAttendance.Value = new System.DateTime(2021, 1, 5, 15, 9, 38, 612);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dpk_MonthlyAttendance, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_ExportMonthlyAttendance, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.35294F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.64706F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(835, 244);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(53, 19);
            this.uiLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 28);
            this.uiLabel1.TabIndex = 5;
            this.uiLabel1.Text = "月份选择：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AttendanceManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AttendanceManage";
            this.Text = "AttendanceManage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton btn_ExportMonthlyAttendance;
        private Sunny.UI.UIDatePicker dpk_MonthlyAttendance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
    }
}