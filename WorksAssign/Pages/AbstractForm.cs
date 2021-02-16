using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;

namespace WorksAssign.Pages {
	public class AbstractForm:UIForm {
		protected Dictionary<string, long> substations;
		protected Dictionary<string, long> employees;
		
		protected Dictionary<string, long> workType;
		protected Dictionary<string, bool> dictErr;
		protected DbAgent db;

		protected virtual void InitializeData() {
            
			using (db = new DbAgent()) {
				substations = db.GetSubstation().ToDictionary(k => k.SubstationName, v => v.Id);
				employees = db.GetEmployee().ToDictionary(k => k.Name, v => v.Id);
				workType = db.GetWorkType().ToDictionary(k => k.Content, v => v.Id);
				
				dictErr = new Dictionary<string, bool>();
			}
		}

		protected void ComboBox_EditorLostFocus(UIComboBox cb, Dictionary<string, long> dict) {
			string input = cb.Text;
			try {
				long data = dict[input];
				cb.SelectedValue = data;
				dictErr[cb.Name] = false;
			}
			catch (KeyNotFoundException ex) {
				cb.SelectedIndex = -1;
				cb.SelectedValue = null;
				cb.Text = input;
				dictErr[cb.Name] = true;
			}
		}

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // AbstractForm
            // 
            this.ClientSize = new System.Drawing.Size(862, 784);
            this.Name = "AbstractForm";
            this.ResumeLayout(false);

        }
    }
}
