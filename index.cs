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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogin Al = new AdminLogin();
            Al.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentRegistration str = new StudentRegistration();
            str.Show();
            this.Hide();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
