using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOperations
{
    public class StudentsService
    {
        public List<Student> Students;
        public StudentsService()
        {
            Students = new List<Student>();
        }
        public void AddStudent(Student student)
        {
            if (student == null)
                return;
            Students.Add(student);
        }
        public void RemoveByName(string name)
        {
            try
            {
                Students.Remove(Students.Find(x => x.Name == name));
            }
            catch
            {
                throw new Exception("Student was not found on the list");
            }
            
        }
    }
}
