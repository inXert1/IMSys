using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMSys
{
    public partial class frnLogin : Form
    {
        public frnLogin()
        {
            InitializeComponent();
        }
        SqlConnection conn =
            new SqlConnection(
                "Data Source=DESKTOP-88PAEL5\\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True;Encrypt=False;");

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmPrimaryForm primaryForm = new frmPrimaryForm();
            primaryForm.ShowDialog();
            this.Hide();
        }
    }
}
