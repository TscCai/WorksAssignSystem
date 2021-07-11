using System.Windows.Forms;

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
            this.pnl_Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.Padding = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.pnl_Header.Size = new System.Drawing.Size(882, 65);
            // 
            // pnl_Footer
            // 
            this.pnl_Footer.Location = new System.Drawing.Point(0, 551);
            this.pnl_Footer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pnl_Footer.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnl_Footer.Size = new System.Drawing.Size(882, 66);
            this.pnl_Footer.Controls.SetChildIndex(this.pgr_Data, 0);
            // 
            // pgr_Data
            // 
            this.pgr_Data.Location = new System.Drawing.Point(24, 12);
            this.pgr_Data.PagerCount = 13;
            this.pgr_Data.PageSize = 30;
            this.pgr_Data.Size = new System.Drawing.Size(834, 36);
            // 
            // ViewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 617);
            this.Name = "ViewDevice";
            this.Text = "ViewDevice";
            this.pnl_Footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion



        private Sunny.UI.UISymbolButton btn_Search = new Sunny.UI.UISymbolButton();
        private Sunny.UI.UISymbolButton btn_Add = new Sunny.UI.UISymbolButton();
        private Sunny.UI.UISymbolButton btn_Del = new Sunny.UI.UISymbolButton();
        private Sunny.UI.UISymbolButton btn_Edit = new Sunny.UI.UISymbolButton();
        private Sunny.UI.UISymbolButton btn_Export = new Sunny.UI.UISymbolButton();

        protected override void AppendControl() {

            dg_Data.ReadOnly = true;
            dg_Data.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dg_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            pnl_Header.FlowDirection = FlowDirection.LeftToRight;
            this.pnl_Header.AddControl(this.btn_Search);
            this.pnl_Header.AddControl(this.btn_Add);
            this.pnl_Header.AddControl(this.btn_Edit);
            this.pnl_Header.AddControl(this.btn_Del);
            this.pnl_Header.AddControl(this.btn_Export);
            //btn_Search.BringToFront();
            pgr_Data.PagerCount = 11;

            // 
            // btn_Search
            // 
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Search.Location = new System.Drawing.Point(0, 0);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.btn_Search.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 30);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "查询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            this.btn_Search.Symbol = 61442;

            // 
            // btn_Add
            // 
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.btn_Add.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 30);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "添加";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            this.btn_Add.Symbol = 61543;



            // 
            // btn_Del
            // 
            this.btn_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Del.Location = new System.Drawing.Point(0, 0);
            this.btn_Del.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.btn_Del.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(100, 30);
            this.btn_Del.TabIndex = 0;
            this.btn_Del.Text = "删除";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            this.btn_Del.Symbol = 61544;

            //
            // btn_Edit
            //
            this.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Edit.Location = new System.Drawing.Point(0, 0);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.btn_Edit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(100, 30);
            this.btn_Edit.TabIndex = 0;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            this.btn_Edit.Symbol = 61508;



            //
            // btn_Export
            //
            this.btn_Export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Export.Location = new System.Drawing.Point(0, 0);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.btn_Export.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(100, 30);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "导出";
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            this.btn_Export.Symbol = 61920;





        }
    }
}