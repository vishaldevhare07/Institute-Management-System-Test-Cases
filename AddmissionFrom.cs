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
    public partial class AddmissionFrom : Form
    {
        public AddmissionFrom()
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

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Duration";
                comboBox2.ValueMember = "cdid";
            }
           // comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;");

           //if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox5.Text))
           // {
                string insertQuery = "INSERT INTO StdAddmission ([Name], [MobileNo], [Adderss], [AdharNo], [Email], [DOB], [Gender], [Qulification], [SelectDuration], [SelectCourse]) VALUES (@Name,@MobileNo,@Adderss,@AdharNo, @Email,@DOB,@Gender,@Qulification,@SelectDuration,@SelectCourse)";


            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Adderss", textBox3.Text);
                    cmd.Parameters.AddWithValue("@AdharNo", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Qulification", textBox6.Text);
                    cmd.Parameters.AddWithValue("@SelectDuration", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@SelectCourse", comboBox3.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("INSERT SUCCESSFULLY");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();


                    //  To open register page...........................................

                    //StudentRegistration str = new StudentRegistration();
                    //str.Show();
                    //this.Hide();
                }
            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int selectedCategoryId))
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
                {
                    string query = "SELECT cid, Course FROM AddCousres WHERE Duration = '" + comboBox2.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    // da.SelectCommand.Parameters.AddWithValue("@cid", comboBox2.SelectedItem);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox3.DataSource = dt;
                    comboBox3.DisplayMember = "Course";
                    comboBox3.ValueMember = "cid";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
                string selectedName = textBox1.Text.ToString();
                string connectionString = "Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM StudentRegistration WHERE Name = @Name", con);
                cmd.Parameters.AddWithValue("@Name", selectedName);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox2.Text = reader["Address"].ToString();
                        textBox3.Text = reader["MobileNo"].ToString();
                      textBox5.Text = reader["Email"].ToString();                        

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                }

        private void label12_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();

        }
    }
 }
