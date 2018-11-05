using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UI.BL;

namespace UI
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source = DESKTOP-8JNEN76\MSSQLSERVERSS; Database=Sales; uid=sa;password=123456;";

        public LoginForm()
        {
            InitializeComponent();
            Initiallize();
        }

        Login login = new Login();

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (login.CheckLogin(txtUser, txtPassword))
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string userId = txtUser.Text;
                string password = txtPassword.Text;

                SqlCommand cmd = new SqlCommand("select Username, Password from Employees where Username ='" + txtUser.Text + "' and Password = '" + txtPassword.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login sucess !");
                    Visible = false;

                    Form1 frm = new Form1();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Login error !");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }

        private void Initiallize()
        {
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 14;
        }
    }
}
