using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMSys
{
    public partial class frmPrimaryForm : Form
    {
        
        public frmPrimaryForm()
        {
            InitializeComponent();
        }



        public void loadMenu(object Form)
        {
            if (this.panelDashboard.Controls.Count > 0)
                this.panelDashboard.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelDashboard.Controls.Add(f);
            this.panelDashboard.Tag = f;
            f.Show();

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadMenu(new frmPrimaryForm());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            loadMenu(new frmInventory());
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
           DialogResult result =  MessageBox.Show("Are you sure you want to exit", "Please please please", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                return;
            }
            else {
                this.Dispose();
                this.Close();
            }
        }
    }
}
