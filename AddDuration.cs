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
    public partial class AddDuration : Form
    {
        public AddDuration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;");


            string insertQuery = "INSERT INTO CourseDuration (Duration) VALUES (@Duration)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Duration", textBox2.Text);


                cmd.ExecuteNonQuery();

                MessageBox.Show("INSERT SUCCESSFULLY");

                textBox2.Clear();



                //  To open register page...........................................

                //StudentRegistration str = new StudentRegistration();
                //str.Show();
                //this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }
    }
}
