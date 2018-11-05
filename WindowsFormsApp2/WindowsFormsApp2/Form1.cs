using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ////Set values into company model
                //SalesContext objCompany = new SalesContext();
                //objCompany.Name = txtCompanyName.Text;

                ////Create context object and then save company data
                //SalesContext objContext = new SalesContext();
                //objContext.Companies.Add(objCompany);
                //objContext.SaveChanges();

                //MessageBox.Show("register success");
                //Clear();

                //dataGridView1.DataSource = objContext.Companies.ToList();
            }
            catch
            {
            }
        }

        void Clear()
        {
             txtCompanyName.Text = "";
        }
    }
}
