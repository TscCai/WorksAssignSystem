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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_worksAssign = new Sunny.UI.UIDataGridView();
            this.dpk_Start = new Sunny.UI.UIDatePicker();
            this.dpk_End = new Sunny.UI.UIDatePicker();
            this.btn_Search = new Sunny.UI.UISymbolButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.dg_worksAssign)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_worksAssign
            // 
            this.dg_worksAssign.AllowUserToAddRows = false;
            this.dg_worksAssign.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dg_worksAssign.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dg_worksAssign.BackgroundColor = System.Drawing.Color.White;
            this.dg_worksAssign.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_worksAssign.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dg_worksAssign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_worksAssign.DefaultCellStyle = dataGridViewCellStyle15;
            this.dg_worksAssign.EnableHeadersVisualStyles = false;
            this.dg_worksAssign.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dg_worksAssign.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dg_worksAssign.Location = new System.Drawing.Point(39, 72);
            this.dg_worksAssign.Name = "dg_worksAssign";
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dg_worksAssign.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dg_worksAssign.RowTemplate.Height = 29;
            this.dg_worksAssign.SelectedIndex = -1;
            this.dg_worksAssign.ShowGridLine = true;
            this.dg_worksAssign.Size = new System.Drawing.Size(587, 452);
            this.dg_worksAssign.TabIndex = 0;
            // 
            // dpk_Start
            // 
            this.dpk_Start.FillColor = System.Drawing.Color.White;
            this.dpk_Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_Start.Location = new System.Drawing.Point(70, 25);
            this.dpk_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_Start.MaxLength = 10;
            this.dpk_Start.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_Start.Name = "dpk_Start";
            this.dpk_Start.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_Start.Size = new System.Drawing.Size(150, 30);
            this.dpk_Start.SymbolDropDown = 61555;
            this.dpk_Start.SymbolNormal = 61555;
            this.dpk_Start.TabIndex = 1;
            this.dpk_Start.Text = "uiDatePicker1";
            this.dpk_Start.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_Start.Value = new System.DateTime(2020, 11, 18, 19, 29, 14, 800);
            // 
            // dpk_End
            // 
            this.dpk_End.FillColor = System.Drawing.Color.White;
            this.dpk_End.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dpk_End.Location = new System.Drawing.Point(267, 25);
            this.dpk_End.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpk_End.MaxLength = 10;
            this.dpk_End.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpk_End.Name = "dpk_End";
            this.dpk_End.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dpk_End.Size = new System.Drawing.Size(150, 30);
            this.dpk_End.SymbolDropDown = 61555;
            this.dpk_End.SymbolNormal = 61555;
            this.dpk_End.TabIndex = 1;
            this.dpk_End.Text = "2020-11-18";
            this.dpk_End.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpk_End.Value = new System.DateTime(2020, 11, 18, 19, 29, 14, 800);
            // 
            // btn_Search
            // 
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Search.Location = new System.Drawing.Point(443, 20);
            this.btn_Search.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(85, 35);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "查询";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(38, 28);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(23, 23);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "从";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(230, 28);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(33, 23);
            this.uiLabel2.TabIndex = 3;
            this.uiLabel2.Text = "至";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 592);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.dpk_End);
            this.Controls.Add(this.dpk_Start);
            this.Controls.Add(this.dg_worksAssign);
            this.Name = "ViewWorks";
            this.Text = "工作概况";
            ((System.ComponentModel.ISupportInitialize)(this.dg_worksAssign)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView dg_worksAssign;
        private Sunny.UI.UIDatePicker dpk_Start;
        private Sunny.UI.UIDatePicker dpk_End;
        private Sunny.UI.UISymbolButton btn_Search;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;

    }
}