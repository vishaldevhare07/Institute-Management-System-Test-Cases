using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerCourse
{
    internal class Questions
    {
        public int QueID { get; set; }           // Optional if you want to track question ID
        public string Course { get; set; }
        public string Duration { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public float Marks { get; set; }
        public string StudentName { get; set; }

    }
}
