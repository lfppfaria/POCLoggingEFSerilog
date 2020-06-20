using System.Collections.Generic;

namespace POCLoggingEFSerilog.Entity
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
