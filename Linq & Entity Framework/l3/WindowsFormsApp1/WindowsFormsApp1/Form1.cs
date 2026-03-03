using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=lab1;Integrated Security=True")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }

    public partial class Form1 : Form
    {
        AppDbContext db = new AppDbContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgvEmployees.DataSource = db.Employees.ToList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Id = int.Parse(txtId.Text);
            emp.Name = txtName.Text;
            emp.Department = txtDepartment.Text;

            db.Employees.Add(emp);
            db.SaveChanges();

            MessageBox.Show("Employee added successfully");
            btnDisplay_Click(null, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Employee emp = db.Employees.FirstOrDefault(x => x.Id == id);

            if (emp != null)
            {
                emp.Name = txtName.Text;
                emp.Department = txtDepartment.Text;

                db.SaveChanges();
                MessageBox.Show("Employee data updated successfully");
            }
            else
            {
                MessageBox.Show("Employee not found");
            }

            btnDisplay_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Employee emp = db.Employees.FirstOrDefault(x => x.Id == id);

            if (emp != null)
            {
                txtName.Text = emp.Name;
                txtDepartment.Text = emp.Department;
                MessageBox.Show("Employee found");
            }
            else
            {
                MessageBox.Show("Employee not found");
            }
        }
    }
}