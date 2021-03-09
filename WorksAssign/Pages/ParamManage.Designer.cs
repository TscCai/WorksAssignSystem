namespace WorksAssign.Pages
{
    partial class ParamManage
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
            this.tab_Container = new Sunny.UI.UITabControl();
            this.tp_WorkType = new System.Windows.Forms.TabPage();
            this.pnl_tpworkTypeBtn = new Sunny.UI.UIPanel();
            this.btn_WorkTypeSave = new Sunny.UI.UISymbolButton();
            this.pnl_tpWorkType = new Sunny.UI.UIPanel();
            this.dg_WorkType = new Sunny.UI.UIDataGridView();
            this.col_Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TypeWgt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IsOutdoor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tp_Role = new System.Windows.Forms.TabPage();
            this.tp_Formula = new System.Windows.Forms.TabPage();
            this.tab_Container.SuspendLayout();
            this.tp_WorkType.SuspendLayout();
            this.pnl_tpworkTypeBtn.SuspendLayout();
            this.pnl_tpWorkType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_WorkType)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_Container
            // 
            this.tab_Container.Controls.Add(this.tp_WorkType);
            this.tab_Container.Controls.Add(this.tp_Role);
            this.tab_Container.Controls.Add(this.tp_Formula);
            this.tab_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Container.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tab_Container.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tab_Container.ItemSize = new System.Drawing.Size(150, 40);
            this.tab_Container.Location = new System.Drawing.Point(0, 0);
            this.tab_Container.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.tab_Container.Name = "tab_Container";
            this.tab_Container.SelectedIndex = 0;
            this.tab_Container.ShowToolTips = true;
            this.tab_Container.Size = new System.Drawing.Size(850, 571);
            this.tab_Container.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tab_Container.TabBackColor = System.Drawing.Color.Gray;
            this.tab_Container.TabIndex = 0;
            // 
            // tp_WorkType
            // 
            this.tp_WorkType.Controls.Add(this.pnl_tpworkTypeBtn);
            this.tp_WorkType.Controls.Add(this.pnl_tpWorkType);
            this.tp_WorkType.Location = new System.Drawing.Point(0, 40);
            this.tp_WorkType.Name = "tp_WorkType";
            this.tp_WorkType.Size = new System.Drawing.Size(850, 531);
            this.tp_WorkType.TabIndex = 0;
            this.tp_WorkType.Text = "工作类型";
            this.tp_WorkType.UseVisualStyleBackColor = true;
            // 
            // pnl_tpworkTypeBtn
            // 
            this.pnl_tpworkTypeBtn.Controls.Add(this.btn_WorkTypeSave);
            this.pnl_tpworkTypeBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_tpworkTypeBtn.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_tpworkTypeBtn.Location = new System.Drawing.Point(0, 468);
            this.pnl_tpworkTypeBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_tpworkTypeBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_tpworkTypeBtn.Name = "pnl_tpworkTypeBtn";
            this.pnl_tpworkTypeBtn.Padding = new System.Windows.Forms.Padding(300, 10, 300, 10);
            this.pnl_tpworkTypeBtn.Size = new System.Drawing.Size(850, 63);
            this.pnl_tpworkTypeBtn.TabIndex = 5;
            this.pnl_tpworkTypeBtn.Text = null;
            // 
            // btn_WorkTypeSave
            // 
            this.btn_WorkTypeSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_WorkTypeSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_WorkTypeSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_WorkTypeSave.Location = new System.Drawing.Point(276, 17);
            this.btn_WorkTypeSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_WorkTypeSave.Name = "btn_WorkTypeSave";
            this.btn_WorkTypeSave.Size = new System.Drawing.Size(222, 35);
            this.btn_WorkTypeSave.TabIndex = 0;
            this.btn_WorkTypeSave.Text = "保存";
            this.btn_WorkTypeSave.Click += new System.EventHandler(this.btn_WorkTypeSave_Click);
            // 
            // pnl_tpWorkType
            // 
            this.pnl_tpWorkType.Controls.Add(this.dg_WorkType);
            this.pnl_tpWorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_tpWorkType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_tpWorkType.Location = new System.Drawing.Point(0, 0);
            this.pnl_tpWorkType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_tpWorkType.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl_tpWorkType.Name = "pnl_tpWorkType";
            this.pnl_tpWorkType.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnl_tpWorkType.Size = new System.Drawing.Size(850, 531);
            this.pnl_tpWorkType.TabIndex = 4;
            this.pnl_tpWorkType.Text = null;
            // 
            // dg_WorkType
            // 
            this.dg_WorkType.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dg_WorkType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_WorkType.BackgroundColor = System.Drawing.Color.White;
            this.dg_WorkType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_WorkType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_WorkType.ColumnHeadersHeight = 32;
            this.dg_WorkType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_WorkType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Chk,
            this.col_Content,
            this.col_TypeWgt,
            this.col_IsOutdoor});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_WorkType.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_WorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_WorkType.EnableHeadersVisualStyles = false;
            this.dg_WorkType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dg_WorkType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dg_WorkType.Location = new System.Drawing.Point(0, 1);
            this.dg_WorkType.Name = "dg_WorkType";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dg_WorkType.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_WorkType.RowTemplate.Height = 29;
            this.dg_WorkType.SelectedIndex = -1;
            this.dg_WorkType.ShowGridLine = true;
            this.dg_WorkType.Size = new System.Drawing.Size(850, 530);
            this.dg_WorkType.TabIndex = 3;
            this.dg_WorkType.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_WorkType_RowsAdded);
            this.dg_WorkType.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dg_WorkType_RowsRemoved);
            // 
            // col_Chk
            // 
            this.col_Chk.HeaderText = "选择";
            this.col_Chk.Name = "col_Chk";
            this.col_Chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_Content
            // 
            this.col_Content.DataPropertyName = "Content";
            this.col_Content.HeaderText = "工作类型";
            this.col_Content.Name = "col_Content";
            this.col_Content.Width = 500;
            // 
            // col_TypeWgt
            // 
            this.col_TypeWgt.DataPropertyName = "TypeWgt";
            this.col_TypeWgt.HeaderText = "权重系数";
            this.col_TypeWgt.Name = "col_TypeWgt";
            // 
            // col_IsOutdoor
            // 
            this.col_IsOutdoor.DataPropertyName = "IsOutdoor";
            this.col_IsOutdoor.HeaderText = "外勤工作";
            this.col_IsOutdoor.Name = "col_IsOutdoor";
            // 
            // tp_Role
            // 
            this.tp_Role.Location = new System.Drawing.Point(0, 40);
            this.tp_Role.Name = "tp_Role";
            this.tp_Role.Size = new System.Drawing.Size(850, 531);
            this.tp_Role.TabIndex = 1;
            this.tp_Role.Text = "角色及权重";
            this.tp_Role.UseVisualStyleBackColor = true;
            // 
            // tp_Formula
            // 
            this.tp_Formula.Location = new System.Drawing.Point(0, 40);
            this.tp_Formula.Name = "tp_Formula";
            this.tp_Formula.Size = new System.Drawing.Size(850, 531);
            this.tp_Formula.TabIndex = 2;
            this.tp_Formula.Text = "工分计算公式";
            this.tp_Formula.UseVisualStyleBackColor = true;
            // 
            // ParamManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 571);
            this.Controls.Add(this.tab_Container);
            this.Name = "ParamManage";
            this.Text = "参数设置";
            this.Initialize += new System.EventHandler(this.ParamManage_Initialize);
            this.tab_Container.ResumeLayout(false);
            this.tp_WorkType.ResumeLayout(false);
            this.pnl_tpworkTypeBtn.ResumeLayout(false);
            this.pnl_tpWorkType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_WorkType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl tab_Container;
        private System.Windows.Forms.TabPage tp_WorkType;
        private System.Windows.Forms.TabPage tp_Role;
        private System.Windows.Forms.TabPage tp_Formula;
        private Sunny.UI.UIDataGridView dg_WorkType;
        private Sunny.UI.UIPanel pnl_tpWorkType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TypeWgt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsOutdoor;
        private Sunny.UI.UIPanel pnl_tpworkTypeBtn;
        private Sunny.UI.UISymbolButton btn_WorkTypeSave;
    }
}