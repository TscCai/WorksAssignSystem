using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace WorksAssign
{
    public partial class Main : UIAsideMainFrame
    {
        bool IsInited = false;
        WorksAssign.Pages.ParamManage frm_ParamManage;
        public Main() {
            InitializeComponent();
            this.EscClose = false;
            this.IsForbidAltF4 = false;
            

            //设置关联
            Aside.TabControl = MainTabControl;
            try {

                string dbVer = Persistence.DatabaseUpdater.GetDatabaseVersion();
                string exeVer = AssemblyGetter.AssemblyVersion;
                if (dbVer != exeVer) {
                    MessageBox.Show("数据库版本与程序版本不一致，请升级数据库或程序文件。\n"
                        + "程序版本：" + exeVer + "\n"
                        + "数据库版本：" + dbVer
                        );
                }


                //增加页面到Main
                AddPage(new WorksAssign.Pages.Outline(), 1);
                AddPage(new WorksAssign.Pages.NewWorks(), 2);
                AddPage(new WorksAssign.Pages.ViewWorks(), 3);
                AddPage(new WorksAssign.Pages.AttendanceManage(), 4);
                frm_ParamManage = new WorksAssign.Pages.ParamManage();
                AddPage(frm_ParamManage, 5);
                AddPage(new WorksAssign.Pages.EmployeeManage(), 6);
                AddPage(new WorksAssign.Pages.Device.ViewDevice(), 7);
                AddPage(new WorksAssign.Pages.About(), 8);

                //设置Header节点索引

                Aside.CreateNode("工作概况", 61451, 24, 1);
                Aside.CreateNode("增加工作", 61694, 24, 2);
                Aside.CreateNode("浏览工作", 61442, 24, 3);
                Aside.CreateNode("考勤与绩效", 62068, 24, 4);
                Aside.CreateNode("参数设置", 62068, 24, 5);
                Aside.CreateNode("班组成员管理", 62068, 24, 6);
                Aside.CreateNode("二次台账查询", 62068, 24, 7);
                Aside.CreateNode("关于", 61530, 24, 8);

                //显示默认界面
                Aside.SelectFirst();
                IsInited = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);

            }

        }

        private void MainNav_OnMenuItemClick(TreeNode node, NavMenuItem item, int pageIndex) {
            if (pageIndex == 3) {
                //this.Size = new Size()
            }
            else if (pageIndex == 2 || pageIndex == 1) {

            }
        }

        private void Aside_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            if (IsInited) {
                switch (Aside.SelectedNode.Text) {
                    case "参数设置":
                        frm_ParamManage.PageChanged();
                        break;

                }
                
            }

        }
    }
}
