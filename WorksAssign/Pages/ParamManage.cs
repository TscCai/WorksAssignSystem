using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;

namespace WorksAssign.Pages
{
    public partial class ParamManage : UIPage
    {
        DbAgent db;
        List<long> NewRowsId;
        List<long> UpdateRowsId;
        bool IsInited;
        public ParamManage() {
            IsInited = false;
            InitializeComponent();

        }


        public void InitializationData() {
            var list = db.GetWorkType().ToList();
            dg_WorkType.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = list;
            dg_WorkType.DataSource = bs;
        }

        public void PageChanged() {
            if (db != null) {
                db.Dispose();
                db = null;
            }
            NewRowsId.Clear();
            UpdateRowsId.Clear();
            NewRowsId = null;
            UpdateRowsId = null;
        }

        private void ParamManage_Initialize(object sender, EventArgs e) {
            db = new DbAgent();
            InitializationData();
            NewRowsId = new List<long>();
            UpdateRowsId = new List<long>();
            IsInited = true;

        }

        private void btn_WorkTypeSave_Click(object sender, EventArgs e) {
            this.ShowInfoDialog(NewRowsId.Count.ToString());
        }

        private void dg_WorkType_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            if (IsInited) {
                int row = e.RowIndex;
                int cnt = e.RowCount;
                long value = row - 1;
                NewRowsId.Add(value);
            }
        }

        private void dg_WorkType_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {

        }
    }
}
