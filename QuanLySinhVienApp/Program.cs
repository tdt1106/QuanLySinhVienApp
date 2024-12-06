
using QuanLySinhVienApp;

public class Program
{
    public static void Main(string[] args)
    {
        ListStudents manager = new ListStudents();

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

            switch (choice)
            {
                case "1":
                    // Add Student 

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



                    Console.WriteLine("Enter Status (active, suspended, etc.):");
                    string status;
                    do
                    {
                        Console.WriteLine("Enter Status: (1 for active, 2 for suspended)");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            status = "active";
                        }
                        else if (input == "2")
                        {
                            status = "suspended";
                        }
                        else
                        {
                            status = null;  
                            Console.WriteLine("Invalid input. Please enter 1 for active or 2 for suspended.");
                        }
                    } while (status == null);


                    string nameTeacher = "";
                    while (string.IsNullOrWhiteSpace(nameTeacher))   
                    {
                        try
                        {
                            Console.WriteLine("Enter Teacher's Name:");
                            nameTeacher = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nameTeacher))
                            {
                                throw new ArgumentException("Teacher's name cannot be empty.");
                            }
                            var existingTeacher = manager.Teachers.FirstOrDefault(t => t.NameTeacher == nameTeacher);
                            if (existingTeacher != null)
                            {
                                Console.WriteLine("Teacher with this name already exists. Please enter a different name.");
                                nameTeacher = "";  
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Teacher teacher = new Teacher(nameTeacher);

                    Student student = new Student( name, status, teacher);
                    manager.AddStudent(student);

                    break;

                case "2":
                    // Delete Student
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
                    break;

                case "3":
                    Console.WriteLine("Enter Student ID to search:");
                    string searchID = Console.ReadLine();

                    try
                    {
                        var studentSearch = manager.SearchStudent(searchID);
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
                    break;

                case "4":
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
                    break;

                case "5":
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
                    break;

                case "6":
                    // Calculate GPA
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
                    break;

                case "7":
                    // Classify Student
                    Console.WriteLine("Enter Student ID to classify:");
                    string classifyID = Console.ReadLine();
                    manager.ClassifyStudent(classifyID);
                    break;

                case "8":
                    // Display All Students
                    manager.DisplayAllStudents();
                    break;

                case "9":
                    // Exit
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}