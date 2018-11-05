using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class RegisterForm : Form
    {
        string connectionString = @"Data Source = DESKTOP-8JNEN76\MSSQLSERVERSS; Database=Sales; uid=sa;password=123456;";

        public RegisterForm()
        {
            InitializeComponent();
            Initiallize();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
                MessageBox.Show("please fill mandatory fields");
            else if (txtPassword.Text != txtConfirmPassword.Text)
                MessageBox.Show("Password do not match");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("EmployeesAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is success! ");
                    Clear();
                }
            }
        }

        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUserName.Text = txtPassword.Text = txtConfirmPassword.Text = "";
        }

        private void Initiallize()
        {
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            txtPassword.MaxLength = 14;
        }
    }
}
