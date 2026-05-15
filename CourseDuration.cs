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
    public partial class CourseDuration : Form
    {
        public CourseDuration()
        {
            InitializeComponent();
            LoadDistrict();
        }

        private void LoadDistrict()
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
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;");


            string insertQuery = "INSERT INTO AddCousres (Duration,Course) VALUES (@Duration,@Course)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Duration", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Course", textBox2.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("INSERT SUCCESSFULLY");

                textBox2.Clear();



                //  To open register page...........................................

                //StudentRegistration str = new StudentRegistration();
                //str.Show();
                //this.Hide();
            }
        }
        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}