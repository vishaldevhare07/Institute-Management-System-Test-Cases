using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace ComputerCourse
{
    public partial class Exam : Form
    {

        public string email { get; set; }
        public string Course { get; set; }
        public string Duration { get; set; }
        public string Password { get; set; }
        public string CorrectAns { get; set; }



        private int timeLeft = 3*60;
        private List<Questions> questionList = new List<Questions>();
        private int currentIndex = 0;

        public Exam()
        {
            InitializeComponent();
            this.Load += Exam_Load;


            // hide correct answer.....................................................................

            textBox10.Visible = false;
            label6.Visible = false; // if you have a label for it
            textBox11.Visible = false;
            label7.Visible = false; //


            timer1.Interval = 1000;
            timer1.Start();
            label5.Text = $"⏱ {timeLeft / 60:D2}:{timeLeft % 60:D2}";

        }
        private void LoadQuestions(string course, string duration, string CorrectAns)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
            {
                conn.Open();

                string query = "SELECT TOP 10 * FROM AddQuestions WHERE Course = @course AND Duration = @duration ORDER BY NEWID()"; //ORDER BY NEWID() -- matlab different
                SqlCommand cmd = new SqlCommand(query, conn);                                                                       //que sequence for different student
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@duration", duration);

                SqlDataReader reader = cmd.ExecuteReader();
                questionList.Clear();

                while (reader.Read())
                {
                    questionList.Add(new Questions
                    {
                        QueID = Convert.ToInt32(reader["id"]),
                        Course = reader["Course"].ToString(),
                        Duration = reader["Duration"].ToString(),
                        QuestionText = reader["EnterQue"].ToString(),
                        OptionA = reader["OptionA"].ToString(),
                        OptionB = reader["OptionB"].ToString(),
                        OptionC = reader["OptionC"].ToString(),
                        OptionD = reader["OptionD"].ToString(),
                        CorrectAnswer = reader["CorrectAns"].ToString(),
                        Marks = float.TryParse(reader["Marks"].ToString(), out float m) ? m : 0
                    });
                }
            }

            if (questionList.Count > 0)
            {
                currentIndex = 0;
                DisplayQuestion(currentIndex);
            }
            else
            {
                MessageBox.Show("No questions found for this Course and Duration.");
            }
        }

        private void DisplayQuestion(int index)
        {
            if (index < questionList.Count)
            {
                textBox3.Text = (index + 1) + ": " + questionList[index].QuestionText;
                textBox4.Text = questionList[index].OptionA;
                textBox5.Text = questionList[index].OptionB;
                textBox8.Text = questionList[index].OptionC;
                textBox9.Text = questionList[index].OptionD;
                textBox2.Text = questionList[index].Marks.ToString();

                // Assign correct answer to textBox10..........................................

                textBox10.Text = questionList[index].CorrectAnswer;
            }
            else
            {
                MessageBox.Show("Exam completed.");
            }
        }



        // fetch data from StudentRegistration table ..........................................


        private void LoadStudentData(string email, string password, string Course, string Duration)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
            {
                conn.Open();
                string fetchAadharQuery = "SELECT Name FROM StudentRegistration WHERE email = @email AND password = @password AND Course= @Course AND Duration=@Duration";


                using (SqlCommand cmdFetch = new SqlCommand(fetchAadharQuery, conn))
                {
                    cmdFetch.Parameters.AddWithValue("@email", email);
                    cmdFetch.Parameters.AddWithValue("@password", password);
                    cmdFetch.Parameters.AddWithValue("@Course", Course);
                    cmdFetch.Parameters.AddWithValue("@Duration", Duration);


                    SqlDataReader reader = cmdFetch.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Text = reader["Name"].ToString();
                        textBox6.Text = Duration;
                        textBox7.Text = Course;
                        textBox10.Text = CorrectAns;

                        LoadQuestions(Course, Duration, CorrectAns); // question load only after student is found
                    }
                    else
                    {
                        MessageBox.Show("Invalid student data. Please check Aadhar, Password, Course, and Duration.");
                        this.Close(); // Optional: close exam form if student not found
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                int minutes = timeLeft / 60;
                int seconds = timeLeft % 60;
                label5.Text = $"⏱ {minutes:D2}:{seconds:D2}";
            }
            else
            {
                timer1.Stop();
                FinishExam();
            }
        }

        private void Exam_Load(object sender, EventArgs e)
        {
            label5.Text = "03:00";
            timer1.Start();


            if (!string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(Course) &&
                !string.IsNullOrEmpty(Duration))
            {
                LoadStudentData(email, Password, Course, Duration);
            }

        }

        private void QuesSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True;"))
            {
                conn.Open();

                if (currentIndex < questionList.Count)
                {
                    string selectedAnswer = "";

                    if (radioButton1.Checked) selectedAnswer = "A";
                    else if (radioButton2.Checked) selectedAnswer = "B";
                    else if (radioButton3.Checked) selectedAnswer = "C";
                    else if (radioButton4.Checked) selectedAnswer = "D";

                    if (string.IsNullOrEmpty(selectedAnswer))
                    {
                        MessageBox.Show("Please select an option before Next que.");
                        return; // Stop here, don't go to next question
                    }


                    var currentQuestion = questionList[currentIndex];
                    totalMarks += currentQuestion.Marks;

                    if (selectedAnswer == currentQuestion.CorrectAnswer)
                    {
                        obtainedMarks += currentQuestion.Marks;
                    }

                    currentIndex++;

                    if (currentIndex < questionList.Count)
                    {
                        DisplayQuestion(currentIndex);
                        ClearSelections();
                    }
                    else
                    {
                        FinishExam();
                    }
                }
            }
        }


        private float totalMarks = 0;
        private float obtainedMarks = 0;

        private void ClearSelections() //clear previous selection
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void FinishExam()
        {
            timer1.Stop();
            label5.Text = "⏱ 00:00";
            MessageBox.Show($"Exam finished. You scored {obtainedMarks}/{totalMarks}.");

            SaveResultToDatabase(); // <-- call to insert into DB
            this.Close();
        }

        //  saved exam result in database named column of  SavedResult.....................
        private void SaveResultToDatabase()
        {
            string connStr = @"Data Source=DESKTOP-IBIHNPM\\SQLEXPRESS;Initial Catalog=ComputerCourse;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @" INSERT INTO SavedResult (Name, Course, Duration, MarkObtained, TotalMarks, ExamDate) VALUES  (@Name,  @Course, @Duration, @MarkObtained, @TotalMarks, @ExamDate)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Course", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Duration", textBox6.Text);
                    cmd.Parameters.AddWithValue("@MarkObtained", obtainedMarks);
                    cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);
                    cmd.Parameters.AddWithValue("@ExamDate", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void CheckAnswer(string selectedOption)
        {
            string correctAnswer = textBox10.Text.Trim();

            if (string.IsNullOrEmpty(correctAnswer))
            {
                textBox11.Text = "CorrectAns not found";
                return;
            }

            if (selectedOption == correctAnswer)
            {
                textBox11.Text = "Correct";
               
            }
            else
            {
                textBox11.Text = "Incorrect";
               
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                CheckAnswer("A");
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                CheckAnswer("B");
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                CheckAnswer("C");
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                CheckAnswer("D");
        }
    }
}


    
    

