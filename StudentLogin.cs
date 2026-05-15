using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerCourse
{
    public partial class StudentLogin : Form
    {
        public StudentLogin()
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
            // comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

        }


        // fetch data from studentregistration to login successfully..............................................
        private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
        {
            conn.Open();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
              string fetchAadharQuery = "SELECT email, Password, Course, Duration FROM StudentRegistration WHERE email = @email AND password = @password AND Course= @Course AND Duration=@Duration";

            using (SqlCommand cmdFetch = new SqlCommand(fetchAadharQuery, conn))
            {
                cmdFetch.Parameters.AddWithValue("@email", textBox1.Text);
                cmdFetch.Parameters.AddWithValue("@password", textBox2.Text);
                cmdFetch.Parameters.AddWithValue("@Course", comboBox2.Text);
                cmdFetch.Parameters.AddWithValue("@Duration", comboBox1.Text);

                using (SqlDataReader reader = cmdFetch.ExecuteReader())
                {
                if (reader.HasRows) // Check if a matching record exists
                {
                Exam Ex = new Exam();
               // Ex.Show();
                this.Hide();

                MessageBox.Show("LOGIN SUCCESSFULLY");

                Exam examStartForm = new Exam
                {
                    email = textBox1.Text.Trim(),
                    Password = textBox2.Text.Trim(),
                    Course = comboBox2.Text.Trim(),
                    Duration = comboBox1.Text.Trim()   

                };

                examStartForm.ShowDialog();
                this.Show();
                this.Hide();


                textBox1.Clear();
                textBox2.Clear();

                }
                else
                {
                    MessageBox.Show("Invalid Information pls fill the Correct Information");
                }
            }
        }
    }
            else
            {
                MessageBox.Show("Please enter both email and password");
            }

        }
    }

        private void label3_Click(object sender, EventArgs e)
        {
            StudentRegistration str = new StudentRegistration();
            str.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int selectedCategoryId))
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
                {
                    string query = "SELECT cid, Course FROM AddCousres WHERE Duration = '" + comboBox1.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                
                    // da.SelectCommand.Parameters.AddWithValue("@cid", comboBox2.SelectedItem);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Course";
                    comboBox2.ValueMember = "cid";
                }
            }
        }
    }
}

    
