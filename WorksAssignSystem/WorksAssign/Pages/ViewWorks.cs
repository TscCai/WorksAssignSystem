using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;

namespace WorksAssign.Pages {
    public partial class ViewWorks : UIPage {
        public ViewWorks() {
            InitializeComponent();
            InitializeData();
        }

        void InitializeData() {
            dpk_Start.Value = DateTime.Now;
            dpk_End.Value = DateTime.Now;
            
            using (var db = new DbService()) {
                var works = db.GetWorkContent(dpk_Start.Value, dpk_End.Value);

            }

        }
    }
}
