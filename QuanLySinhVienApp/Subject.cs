namespace QuanLySinhVienApp
{
    public class Subject
    {
        private static int _nextId = 1;
        public int SubjectCode;
        public string SubjectName;
        public string DepartmentInCharge;
        public int NumberOfCredits;

        public Subject(string subjectName, string departmentInCharge, int numberOfCredits)
        {
            SubjectCode = _nextId++;
            SubjectName = subjectName;
            DepartmentInCharge = departmentInCharge;
            NumberOfCredits = numberOfCredits;
        }
        public void DisplaySubjectInformation()
        {
            Console.WriteLine($"Subject Code: {SubjectCode}, Name Sub: {SubjectName}, Department in charge: : {DepartmentInCharge}, Number of credits: {NumberOfCredits}");
        }
    }
}