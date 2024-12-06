
using System.Text;
using QuanLySinhVienApp;
using static QuanLySinhVienApp.Student;
 
public class Program
{
    private static ListStudents manager = new ListStudents();

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Add Subject");
            Console.WriteLine("5. Manage Scores");
            Console.WriteLine("6. Calculate GPA");
            Console.WriteLine("7. Classify Student");
            Console.WriteLine("8. Display All Students");
            Console.WriteLine("9. Exit");
            Console.Write("Please select an option: ");
            string choice = Console.ReadLine();

            if (!int.TryParse(choice, out int parsedChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (parsedChoice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    AddSubject();
                    break;
                case 5:
                    ManageScores();
                    break;
                case 6:
                    CalculateGPA();
                    break;
                case 7:
                    ClassifyStudent();
                    break;
                case 8:
                    DisplayAllStudents();
                    break;
                case 9:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private static void AddStudent()
    {

                            string name = "";
        while (string.IsNullOrWhiteSpace(name))
        {
            try
            {
                Console.WriteLine("Enter Full Name:");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Student name cannot be empty.");
                }

                var existingStudent = manager.Students.FirstOrDefault(s => s.Name == name);
                if (existingStudent != null)
                {
                    Console.WriteLine("Student with this name already exists. Please enter a different name.");
                    name = "";
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("Select Student Status: ");
        Console.WriteLine("1. Active (Đang học)");
        Console.WriteLine("2. Suspended (Nghỉ học)");
        Console.WriteLine("3. Deferred (Bảo lưu)");

        StudentStatus status;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "1")
            {
                status = StudentStatus.Active;
                break;
            }
            else if (input == "2")
            {
                status = StudentStatus.Suspended;
                break;
            }
            else if (input == "3")
            {
                status = StudentStatus.Deferred;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            }
        }

        Teacher? teacher = null;
        if (status == StudentStatus.Active)
        {
            string teacherName = "";
            while (string.IsNullOrWhiteSpace(teacherName))
            {
                Console.WriteLine("Enter Teacher's Name:");
                teacherName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(teacherName))
                {
                    teacher = new Teacher(teacherName);
                }
                else
                {
                    Console.WriteLine("Teacher name cannot be empty.");
                }
            }
        }

        Student student = new Student(name, status, teacher);
        manager.AddStudent(student);

    }

    private static void DeleteStudent()
    {
                            try
        {
            Console.WriteLine("Enter Student ID to delete:");
            string deleteID = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(deleteID))
            {
                throw new ArgumentException("Student ID cannot be empty.");
            }
            manager.DeleteStudent(deleteID);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void SearchStudent()
    {
        Console.WriteLine("Enter Student ID or Name to search:");
        string searchValue = Console.ReadLine();

        try
        {
            var studentSearch = manager.SearchStudent(searchValue);
            if (studentSearch != null)
            {
                studentSearch.DisplayInformation();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

    }

    private static void AddSubject()
    {
        string subjectName = "";
        while (string.IsNullOrWhiteSpace(subjectName))
        {
            try
            {
                Console.WriteLine("Enter Subject Name:");
                subjectName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(subjectName))
                {
                    throw new ArgumentException("Subject name cannot be empty.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        string department = "";
        while (string.IsNullOrWhiteSpace(department))
        {
            try
            {
                Console.WriteLine("Enter Department:");
                department = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(department))
                {
                    throw new ArgumentException("Department cannot be empty.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        int creditHours = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Enter Credit Hours:");
                string creditHoursInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(creditHoursInput))
                {
                    throw new ArgumentException("Credit hours cannot be empty.");
                }

                if (!int.TryParse(creditHoursInput, out creditHours) || creditHours <= 0)
                {
                    throw new ArgumentException("Invalid input. Credit hours must be a positive number.");
                }

                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        manager.AddSubject(new Subject(subjectName, department, creditHours));
    }

    private static void ManageScores()
    {
        // Manage Scores
        try
        {
            Console.WriteLine("Enter Student ID:");
            string studentID = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(studentID))
            {
                throw new ArgumentException("Student ID cannot be empty.");
            }

            Console.WriteLine("Enter Subject ID:");
            string subjectIDForScore = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(subjectIDForScore))
            {
                throw new ArgumentException("Subject ID cannot be empty.");
            }

            if (int.TryParse(subjectIDForScore, out int SubjectCode))
            {
                Subject subjectForScore = manager.Subjects.Find(s => s.SubjectCode == SubjectCode);

                if (subjectForScore != null)
                {
                    Console.WriteLine("Enter Score:");
                    double score = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Credit Hours:");
                    int scoreCreditHours = int.Parse(Console.ReadLine());
                    manager.ManageScores(studentID, subjectForScore, score, scoreCreditHours);
                }
                else
                {
                    Console.WriteLine("Subject not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Subject ID.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void CalculateGPA()
    {
        Console.WriteLine("Enter Student ID to calculate GPA:");
        string studentGPAID = Console.ReadLine();
        var studentGPA = manager.SearchStudent(studentGPAID);
        if (studentGPA != null)
        {
            Console.WriteLine($"GPA of {studentGPA.Name}: {studentGPA.CalculateGPA()}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    private static void ClassifyStudent()
    {
        // Classify Student
        // Classify Student
        Console.WriteLine("Enter Student ID to classify:");
        string classifyID = Console.ReadLine();
        manager.ClassifyStudent(classifyID);
    }

    private static void DisplayAllStudents()
    {
        manager.DisplayAllStudents();
    }
}
