using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=lab1;Integrated Security=True";
        SqlDataAdapter adapter;
        DataTable dtEmployees;
        SqlCommandBuilder cmdBuilder;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Employees";
            adapter = new SqlDataAdapter(query, connectionString);
            cmdBuilder = new SqlCommandBuilder(adapter);
            dtEmployees = new DataTable();
            adapter.Fill(dtEmployees);
            dgvEmployees.DataSource = dtEmployees;
        }
        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (dtEmployees != null)
            {
                DataRow newRow = dtEmployees.NewRow();
                newRow["Id"] = int.Parse(txtId.Text);
                newRow["Name"] = txtName.Text;
                newRow["Department"] = txtDepartment.Text;

                dtEmployees.Rows.Add(newRow);
                adapter.Update(dtEmployees);
                MessageBox.Show("Employee add Done");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (adapter != null && dtEmployees != null)
            {
                adapter.Update(dtEmployees);
                MessageBox.Show("Data is updated");
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (dtEmployees != null)
            {

                DataRow[] foundRows = dtEmployees.Select($"Id = {txtId.Text}");

                if (foundRows.Length > 0)
                {
                    txtName.Text = foundRows[0]["Name"].ToString();
                    txtDepartment.Text = foundRows[0]["Department"].ToString();
                    MessageBox.Show("Search on this Employee is Done");
                }
                else
                {
                    MessageBox.Show("cannot find employee with this name");
                }
            }
        }
    }
}