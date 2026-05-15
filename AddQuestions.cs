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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComputerCourse
{
    public partial class AddQuestions : Form
    {
        public AddQuestions()
        {
            InitializeComponent();
            LoadDuration();
        }

        // fetch the data from CourseDuration table...................................
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
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        // fetch data from courses table........................................
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuesSubmit_Click(object sender, EventArgs e)
        {
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;");

                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
                {
                    string insertQuery = "INSERT INTO AddQuestions (Duration,Course,EnterQue,OptionA,OptionB,OptionC,OptionD,CorrectAns,Marks) VALUES (@Duration,@Course,@EnterQue, @OptionA,@OptionB,@OptionC,@OptionD,@CorrectAns,@Marks)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Duration", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@Course", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@EnterQue", textBox1.Text);
                        cmd.Parameters.AddWithValue("@OptionA", textBox2.Text);
                        cmd.Parameters.AddWithValue("@OptionB", textBox3.Text);
                        cmd.Parameters.AddWithValue("@OptionC", textBox4.Text);
                        cmd.Parameters.AddWithValue("@OptionD", textBox5.Text);
                        cmd.Parameters.AddWithValue("@CorrectAns", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Marks", textBox7.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("INSERT SUCCESSFULLY");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        Exam CorrectAns = new Exam
                        {
                            CorrectAns = textBox6.Text.Trim()

                        };
                    }
                }
                else
                {
                    MessageBox.Show("Pls fill the above information");
                }
            }
            }
       
    }
    }

