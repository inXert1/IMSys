using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMSys
{
    public partial class frmAddProd : Form
    {
        SqlConnection conn =
                new SqlConnection(
                    "Data Source=DESKTOP-88PAEL5\\SQLEXPRESS;Initial Catalog=InvMngmt;Integrated Security=True;Encrypt=False;");
        public frmAddProd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Hide();
        }

        private void cBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string checkLash = cBoxCategory.SelectedItem?.ToString().Trim();

            if (checkLash == "Lashes" || checkLash == "Mini Lashes")
            {
                cBoxLashCategory.Enabled = true;

            }
            else
            {
                cBoxLashCategory.Enabled = false;
                cBoxLashCategory.SelectedIndex = -1;
            }
        }

        private void btnAddprod_Click(object sender, EventArgs e)
        {
            string prodCat = cBoxCategory.SelectedItem?.ToString().Trim();
            string checkLashCat = cBoxLashCategory.SelectedItem?.ToString();

            if (cBoxLashCategory.Enabled == true)
            {
                checkLashCat = "N/A";
            }
            else
            {
                checkLashCat = cBoxLashCategory.SelectedItem?.ToString();
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open(); 
                }

                string checkAvail = "SELECT * FROM Products WHERE productName = @ProductName";

                using (SqlCommand checkUser = new SqlCommand(checkAvail, conn))
                {
                    checkUser.Parameters.AddWithValue("@ProductName", txtName.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show(@"Item already exists. Please choose another name.", @"Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string insertData = "INSERT INTO Products (productName, lashCategory, productCategory, Quantity, Price) " +
                                    "VALUES (@Name, @lashCategory, @prodCategory, @Qty, @Price)";

                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@prodCategory", prodCat);
                    cmd.Parameters.AddWithValue("@lashCategory", checkLashCat);
                    cmd.Parameters.AddWithValue("@Qty", int.Parse(txtQty.Text)); 
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text)); 

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(@"Added successfully!", @"Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close(); 
                }
            }
        }
    }
}
