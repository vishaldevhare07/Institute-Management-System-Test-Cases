using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ComputerCourse;
namespace ComputerCourse
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        public bool ValidateLogin(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM AdminLogin WHERE email=@email AND password=@password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                bool isValid = ValidateLogin(textBox1.Text, textBox2.Text);

                if (isValid)
                {
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    this.Hide();

                    MessageBox.Show("LOGIN SUCCESSFULLY");
                }
                else
                {
                    MessageBox.Show("Invalid email or password");
                }
            }
            else
            {
                MessageBox.Show("Please enter both email and password");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            index ind = new index();
            ind.Show();
            this.Hide();
        }
    }
}