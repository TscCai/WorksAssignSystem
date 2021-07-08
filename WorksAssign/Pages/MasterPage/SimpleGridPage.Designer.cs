using System.Windows.Forms;
using Sunny.UI;

namespace WorksAssign.Pages.MasterPage
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
            this.pnl_Footer = new Sunny.UI.UIFlowLayoutPanel();
            this.pgr_Data = new Sunny.UI.UIPagination();
            this.dg_Data = new Sunny.UI.UIDataGridView();
            this.pnl_Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnl_Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_Header.Location = new System.Drawing.Point(0, 0);
            this.pnl_Header.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Header.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Padding = new System.Windows.Forms.Padding(20, 2, 20, 2);
            this.pnl_Header.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnl_Header.Size = new System.Drawing.Size(882, 55);
            this.pnl_Header.TabIndex = 1;
            this.pnl_Header.Text = "pnl_Header";
            // 
            // pnl_Footer
            // 
            this.pnl_Footer.Controls.Add(this.pgr_Data);
            this.pnl_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Footer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_Footer.Location = new System.Drawing.Point(0, 562);
            this.pnl_Footer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_Footer.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_Footer.Name = "pnl_Footer";
            this.pnl_Footer.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnl_Footer.Size = new System.Drawing.Size(882, 56);
            this.pnl_Footer.TabIndex = 11;
            this.pnl_Footer.Text = "uiFlowLayoutPanel1";
            // 
            // pgr_Data
            // 
            this.pgr_Data.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgr_Data.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pgr_Data.Location = new System.Drawing.Point(20, 10);
            this.pgr_Data.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pgr_Data.MinimumSize = new System.Drawing.Size(1, 1);
            this.pgr_Data.Name = "pgr_Data";
            this.pgr_Data.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pgr_Data.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pgr_Data.ShowJumpButton = false;
            this.pgr_Data.Size = new System.Drawing.Size(842, 36);
            this.pgr_Data.TabIndex = 7;
            this.pgr_Data.Text = "uiPagination1";
            this.pgr_Data.TotalCount = 0;
            this.pgr_Data.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.pgr_Data_PageChanged);
            // 
            // dg_Data
            // 
            this.dg_Data.AllowUserToAddRows = false;
            this.dg_Data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dg_Data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Data.BackgroundColor = System.Drawing.Color.White;
            this.dg_Data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_Data.ColumnHeadersHeight = 32;
            this.dg_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Data.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Data.EnableHeadersVisualStyles = false;
            this.dg_Data.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dg_Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dg_Data.Location = new System.Drawing.Point(0, 55);
            this.dg_Data.Name = "dg_Data";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dg_Data.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_Data.RowTemplate.Height = 29;
            this.dg_Data.SelectedIndex = -1;
            this.dg_Data.ShowGridLine = true;
            this.dg_Data.Size = new System.Drawing.Size(882, 507);
            this.dg_Data.TabIndex = 12;
            // 
            // SimpleGridPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 618);
            this.Controls.Add(this.dg_Data);
            this.Controls.Add(this.pnl_Footer);
            this.Controls.Add(this.pnl_Header);
            this.Name = "SimpleGridPage";
            this.Text = "SimpleGridPage";
            this.pnl_Footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Sunny.UI.UIFlowLayoutPanel pnl_Header;
        protected Sunny.UI.UIFlowLayoutPanel pnl_Footer;
        protected Sunny.UI.UIPagination pgr_Data;
        protected Sunny.UI.UIDataGridView dg_Data;



    }
}