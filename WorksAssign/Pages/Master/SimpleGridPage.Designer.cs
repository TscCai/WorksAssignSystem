namespace WorksAssign.Pages.Master
{
    partial class SimpleGridPage
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
            this.pnl_Content = new Sunny.UI.UIFlowLayoutPanel();
            this.lbl_Header = new Sunny.UI.UILabel();
            this.pnl_footer = new Sunny.UI.UIFlowLayoutPanel();
            this.pgr_Employee = new Sunny.UI.UIPagination();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.pnl_Header.SuspendLayout();
            this.pnl_footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.Controls.Add(this.pnl_Content);
            this.pnl_Header.Controls.Add(this.lbl_Header);
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnl_Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_Header.Location = new System.Drawing.Point(0, 0);
            this.pnl_Header.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Header.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Padding = new System.Windows.Forms.Padding(20, 2, 20, 2);
            this.pnl_Header.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnl_Header.Size = new System.Drawing.Size(882, 60);
            this.pnl_Header.TabIndex = 1;
            this.pnl_Header.Text = "pnl_Header";
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
            this.pnl_Content.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnl_Content.Size = new System.Drawing.Size(742, 56);
            this.pnl_Content.TabIndex = 9;
            this.pnl_Content.Text = "uiFlowLayoutPanel1";
            // 
            // lbl_Header
            // 
            this.lbl_Header.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbl_Header.Location = new System.Drawing.Point(20, 2);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(100, 56);
            this.lbl_Header.TabIndex = 0;
            this.lbl_Header.Text = "提示文字";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_footer
            // 
            this.pnl_footer.Controls.Add(this.pgr_Employee);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_footer.Location = new System.Drawing.Point(0, 562);
            this.pnl_footer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_footer.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnl_footer.Size = new System.Drawing.Size(882, 56);
            this.pnl_footer.TabIndex = 11;
            this.pnl_footer.Text = "uiFlowLayoutPanel1";
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
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 60);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView1.RowTemplate.Height = 29;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.ShowGridLine = true;
            this.uiDataGridView1.Size = new System.Drawing.Size(882, 502);
            this.uiDataGridView1.TabIndex = 12;
            // 
            // SimpleGridPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 618);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.pnl_footer);
            this.Controls.Add(this.pnl_Header);
            this.Name = "SimpleGridPage";
            this.Text = "SimpleGridPage";
            this.pnl_Header.ResumeLayout(false);
            this.pnl_footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel pnl_Header;
        private Sunny.UI.UIFlowLayoutPanel pnl_Content;
        private Sunny.UI.UILabel lbl_Header;
        private Sunny.UI.UIFlowLayoutPanel pnl_footer;
        private Sunny.UI.UIPagination pgr_Employee;
        private Sunny.UI.UIDataGridView uiDataGridView1;
    }
}