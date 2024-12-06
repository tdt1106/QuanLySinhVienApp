using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVienApp
{
    public class Teacher
    {
        private static int _nextId = 1;  
        public int CodeTeacher { get; set; }
        public string NameTeacher { get; set; }
        public Teacher(string nameTeacher)
        {
            CodeTeacher = _nextId++;  
            NameTeacher = nameTeacher;
        }
    }
}
