using DALayer;
using DALayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ManageAccountForm : Form
    {
        string Gender;

        public ManageAccountForm()
        {
            InitializeComponent();
            Bind();
        }

        private void Bind()
        {
            using (SalesContext salesContext = new SalesContext())
            {
                List<Employee> _employeeList = new List<Employee>();
                var myResult = (from Employee in salesContext.Employees
                                select new
                                {
                                    Employee.Id,
                                    Employee.FirstName,
                                    Employee.LastName,
                                    Employee.Email,
                                    Employee.Contact,
                                    Employee.Gender,
                                    Employee.Address,
                                    Employee.Username,
                                    Employee.Password
                                }).ToList()
                                .Select(x => new Employee
                                {
                                    Id = x.Id,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    Email = x.Email,
                                    Contact = x.Contact,
                                    Gender = x.Gender,
                                    Address = x.Address,
                                    Username = x.Username,
                                    Password = x.Password
                                }).ToList();
                dgvSales.DataSource = myResult;
                dgvSales.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Employee employee = new Employee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastname.Text;
            employee.Email = txtEmail.Text;
            employee.Contact = txtContact.Text;
            if (radioButton1.Checked)
            {
                employee.Gender = Gender;
            }
            if (radioButton2.Checked)
            {
                employee.Gender = Gender;
            }
            employee.Address = txtAddress.Text;
            employee.Username = txtUsername.Text;
            employee.Password = txtPassword.Text;
            bool result = SaveEmployees(employee);
            MessageBox.Show("Insert success !");
            Bind();
            Clear();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            Employee employee = SetValues( Convert.ToInt32(lblId.Text) ,txtFirstName.Text, txtLastname.Text, txtEmail.Text,
                txtContact.Text, Gender, txtAddress.Text, txtUsername.Text, txtPassword.Text);
            bool result = UpdateEmployees(employee);
            MessageBox.Show("Update success !");
            Bind();
            Clear();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            Employee employee = SetValues(Convert.ToInt32(lblId.Text), txtFirstName.Text, txtLastname.Text, txtEmail.Text,
                txtContact.Text, Gender, txtAddress.Text, txtUsername.Text, txtPassword.Text);

            bool result = DeleteEmployee(employee);
            MessageBox.Show("Delete Row success !");
            Bind();
            Clear();
        }

        public bool SaveEmployees(Employee employee)
        {
            using (SalesContext salesContext = new SalesContext())
            {
                salesContext.Employees.Add(employee);
                salesContext.SaveChanges();
            }
            return true;
        }

        public bool UpdateEmployees(Employee employee)
        {
            bool result = false;
            using (SalesContext salesContext = new SalesContext())
            {
                Employee _employee = salesContext.Employees.Where(x => x.Id == employee.Id).Select(x => x).FirstOrDefault();
                _employee.Id = employee.Id;
                _employee.FirstName = employee.FirstName;
                _employee.LastName = employee.LastName;
                _employee.Email = employee.Email;
                _employee.Contact = employee.Contact;
                _employee.Address = employee.Address;
                _employee.Username = employee.Username;
                _employee.Password = employee.Password;
                salesContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteEmployee(Employee employee)
        {
            bool result = false;
            using (SalesContext salesContext = new SalesContext())
            {
                Employee _employee = salesContext.Employees.Where(x => x.Id == employee.Id).Select(x => x).FirstOrDefault();
                salesContext.Employees.Remove(_employee);
                salesContext.SaveChanges();
                result = true;
            }
            return result;
        }
            
        public Employee SetValues(int Id, string Firstname, string Lastname,string Email, string Contact, string Gender, string Address, string Username, string Password)
        {
            Employee employee = new Employee();
            employee.Id = Id;
            employee.FirstName = Firstname;
            employee.LastName = Lastname;
            employee.Contact = Contact;
            if (radioButton1.Checked)
            {
                employee.Gender = Gender;
            }
            if (radioButton2.Checked)
            {
                employee.Gender = Gender;
            }
            employee.Address = Address;
            employee.Username = Username;
            employee.Password = Password;
            return employee;
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            Gender = "FeMale";
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = dgvSales.Rows[e.RowIndex];

                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastname.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void Clear()
        {
            txtFirstName.Text = txtLastname.Text = txtContact.Text = txtEmail.Text
                = txtAddress.Text = txtUsername.Text = txtPassword.Text = string.Empty;
        }
    }
}