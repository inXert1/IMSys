using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMSys
{
    public partial class frmInventory : Form
    {

        SqlConnection conn =
                new SqlConnection(
                    "Data Source=DESKTOP-88PAEL5\\SQLEXPRESS;Initial Catalog=IMS;Integrated Security=True;Encrypt=False;");
        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);

            productData.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddProd add = new frmAddProd();
            add.ShowDialog();
        }
    }
}
