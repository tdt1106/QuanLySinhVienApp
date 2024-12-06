using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVienApp
{
    public class Student
    {
        private static int _nextId = 1;
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Teacher Teacher { get; set; }
        public List<Score> Scores { get; set; }

        public Student( string name, string status, Teacher teacher)
        {
            StudentID = _nextId++; 
            Name = name;
            Status = status;
            Teacher = teacher;
            Scores = new List<Score>();
        }

        public double CalculateGPA()
        {
            double TotalScore = 0;
            int TotalCredits = 0;
            foreach (var score in Scores)
            {
                TotalScore += score.PointsAchieved * score.NumberOfCredits;
                TotalCredits += score.NumberOfCredits;
            }
            return TotalCredits > 0 ? TotalScore / TotalCredits : 0;
        }

        public string Classify()
        {
            return Status;
        }
        public void DisplayInformation()
        {
            Console.WriteLine($"Id: {StudentID}, Full name: {Name}, Status: {Status}, Teacher: {Teacher.NameTeacher}");
            foreach (var score in Scores)
            {
                Console.WriteLine($"Subject: {score.Subject.SubjectName}, Score: {score.PointsAchieved}");
            }
        }
    }
}
