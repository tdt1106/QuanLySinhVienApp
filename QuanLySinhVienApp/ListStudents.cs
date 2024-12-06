using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVienApp
{
    public class ListStudents
    {
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public ListStudents()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
            Teachers = new List<Teacher>();
        }

        public Student FindStudentByID(int studentID)
        {
            return Students.FirstOrDefault(s => s.StudentID == studentID);
        }


        public void AddStudent(Student student)
        {
            var existingStudent = FindStudentByID(student.StudentID);
            if (existingStudent != null)
            {
                Console.WriteLine("Student with this ID already exists.");
            }
            else
            {
                Students.Add(student);
                Console.WriteLine("Student added successfully.");
            }
        }


        public void DeleteStudent(string studentID)
        {
            if (int.TryParse(studentID, out int id)) 
            {
                var student = Students.Find(s => s.StudentID == id);
                if (student != null)
                {
                    Students.Remove(student);
                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }


        public Student SearchStudent(string studentID)
        {
            if (int.TryParse(studentID, out int id))
            {
                return Students.Find(s => s.StudentID == id);
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
                return null;
            }
        }


        public void AddSubject(Subject subject)
        {
            if (subject != null)
            {
                Subjects.Add(subject);
                Console.WriteLine("Subject added successfully.");
            }
            else
            {
                Console.WriteLine("Subject cannot be null.");
            }
        }

        public void DisplayAllStudents()
        {
            foreach (var student in Students)
            {
                student.DisplayInformation();
            }
        }

        public void DisplayAllSubjects()
        {
            foreach (var subject in Subjects)
            {
                subject.DisplaySubjectInformation();
            }
        }

        public void ManageScores(string studentID, Subject subject, double score, int creditHours)
        {
            if (int.TryParse(studentID, out int id)) 
            {
                var student = Students.Find(s => s.StudentID == id);
                if (student != null)
                {
                    student.Scores.Add(new Score(subject, score, creditHours));
                    Console.WriteLine("Score added successfully.");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }


        public void ClassifyStudent(string studentID)
        {
            if (int.TryParse(studentID, out int id))
            {
                var student = Students.Find(s => s.StudentID == id);
                if (student != null)
                {
                    Console.WriteLine($"Student {student.Name} is classified as: {student.Status}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

    }
}
