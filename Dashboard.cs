using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerCourse
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           CourseDuration crd = new CourseDuration();
            crd.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddDuration adddrs = new AddDuration();
            adddrs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentRegistration stdr = new StudentRegistration();
            stdr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'computerCourseDataSet8.AddCousres' table. You can move, or remove it, as needed.
            this.addCousresTableAdapter2.Fill(this.computerCourseDataSet8.AddCousres);
            // TODO: This line of code loads data into the 'computerCourseDataSet7.CourseDuration' table. You can move, or remove it, as needed.
            this.courseDurationTableAdapter.Fill(this.computerCourseDataSet7.CourseDuration);
            // TODO: This line of code loads data into the 'computerCourseDataSet6.StudentRegistration' table. You can move, or remove it, as needed.
            this.studentRegistrationTableAdapter1.Fill(this.computerCourseDataSet6.StudentRegistration);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            index ind = new index();
            ind.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            StudentRegistration str = new StudentRegistration();
            str.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            AddmissionFrom addmissionFrom = new AddmissionFrom();   
            addmissionFrom.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddQuestions addQuestions = new AddQuestions();
            addQuestions.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            student student = new student();
            student.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {





        }

        //private void label10_Click(object sender, EventArgs e)
        //{
        //    index ind = new index();
        //    ind.Show();
        //    this.Hide();
        //}
    }
}
