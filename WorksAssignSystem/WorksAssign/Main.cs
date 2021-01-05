﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace WorksAssign {
    public partial class Main : UIAsideMainFrame {
        public Main() {
            InitializeComponent();
            this.EscClose = false;
            this.IsForbidAltF4 = false;

            //设置关联
            Aside.TabControl = MainTabControl;

            //增加页面到Main
            AddPage(new WorksAssign.Pages.Outline(), 1);
            AddPage(new WorksAssign.Pages.NewWorks(), 2);
            AddPage(new WorksAssign.Pages.ViewWorks(), 3);
            AddPage(new WorksAssign.Pages.AttendanceManage(), 4);

            //设置Header节点索引

            Aside.CreateNode("工作概况", 61451, 24, 1);
            Aside.CreateNode("增加工作", 61694, 24, 2);
            Aside.CreateNode("浏览工作", 61442, 24, 3);
            Aside.CreateNode("考勤管理", 62068, 24, 4);

            //显示默认界面
            Aside.SelectFirst();

        }

		private void MainNav_OnMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex) {
			if (pageIndex == 3) {
				//this.Size = new Size()
			}
			else if (pageIndex == 2 || pageIndex ==1) {

			}
		}
    }
}
