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

namespace WorksAssign.Pages.MasterPage
{
    public partial class SimpleGridPage : UIPage
    {
        protected WasDbAgent db;
        public bool IsInited { protected set; get; }

        public SimpleGridPage() {
            InitializeComponent();
            AppendControl();
        }

        protected virtual void AppendControl() {

         
        }
        protected virtual void InitializeData() {
            dg_Data.AutoGenerateColumns = false;
           
        }
        private void pgr_Data_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
            dg_Data.DataSource = pagingSource;
        }

        /// <summary>
        /// return the chosen item list. won't return null anytime.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<T> GetChosenItems<T>() {
            List<T> result = new List<T>();
            DataGridViewRowCollection dt = dg_Data.Rows;

            foreach (DataGridViewRow i in dt) {
                if (i.Cells[0].Value != null && (bool)i.Cells[0].Value) {
                    result.Add(((T)i.DataBoundItem));
                }
            }
            return result;
        }

    }
}
