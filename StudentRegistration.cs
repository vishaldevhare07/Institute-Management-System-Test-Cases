using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerCourse
{
    public partial class StudentRegistration : Form
    {
        public StudentRegistration()
        {
            InitializeComponent();
            LoadDuration();
        }

        private void LoadDuration()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
            {
                string query = "select cdid,Duration from CourseDuration";
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Duration";
                comboBox1.ValueMember = "cdid";
            }
        }

        // Student Registration Method for Testing
        public bool RegisterStudent(string name, string mobile, string email, string address, string password, string duration, string course)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;");

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(mobile) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(password))
            {
                string insertQuery = "INSERT INTO StudentRegistration (Name,MobileNo,Address,Email,Password,Duration,Course) VALUES (@Name,@MobileNo,@Address,@Email,@Password,@Duration,@Course)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@MobileNo", mobile);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@Course", course);

                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }

            return false;
        }

        // Insert Record
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = RegisterStudent(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
                comboBox1.Text,
                comboBox2.Text
            );

            if (result)
            {
                MessageBox.Show("INSERT SUCCESSFULLY");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("Pls Fill the above Informations");
            }
        }

        // Clear Textboxes
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        // Update Student Record
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;");

            conn.Open();

            if (!string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text))
            {
                string updateQuery = "update StudentRegistration set Name=@Name,MobileNo=@MobileNo,Address=@Address,Email=@Email,Password=@Password where id='" + textBox6.Text + "'";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox5.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated Successfully");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                }
            }
        }

        // Go To Login Page
        private void button4_Click(object sender, EventArgs e)
        {
            StudentLogin studentLogin = new StudentLogin();
            studentLogin.Show();
            this.Hide();
        }

        // Load Course According To Duration
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int selectedCategoryId))
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
                {
                    string query = "SELECT cid, Course FROM AddCousres WHERE Duration='" + comboBox1.Text + "'";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Course";
                    comboBox2.ValueMember = "cid";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            index ind = new index();
            ind.Show();
            this.Hide();
        }
    }
}