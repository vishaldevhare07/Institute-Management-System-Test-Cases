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
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void student_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'computerCourseDataSet5.AddQuestions' table. You can move, or remove it, as needed.
            this.addQuestionsTableAdapter.Fill(this.computerCourseDataSet5.AddQuestions);
            // TODO: This line of code loads data into the 'computerCourseDataSet1.StudentRegistration' table. You can move, or remove it, as needed.
            this.studentRegistrationTableAdapter.Fill(this.computerCourseDataSet1.StudentRegistration);

        }
    }
}
