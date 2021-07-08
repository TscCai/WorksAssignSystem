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

namespace WorksAssign.Pages.Master
{
    public partial class SimpleGridPage : UIPage
    {
        public bool IsInit { protected set; get; }

        public SimpleGridPage() {
            InitializeComponent();
            InitControl();
        }

        protected virtual void InitControl() {

        }
    }
}
