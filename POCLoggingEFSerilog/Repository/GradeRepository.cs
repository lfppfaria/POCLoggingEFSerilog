using Microsoft.EntityFrameworkCore;
using POCLoggingEFSerilog.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCLoggingEFSerilog.Repository
{
    public class GradeRepository
    {
        private readonly GradesContext _gradesContext;

        public GradeRepository(GradesContext gradesContext)
        {
            _gradesContext = gradesContext;
        }

        public Task<List<Student>> FindGrades()
        {
            var result = _gradesContext
                .Students
                .Include(student => student.Grades)
                .ThenInclude(grade => grade.Subject)
                .AsNoTracking()
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<Student>> FindGrades(string studentName)
        {
            var result = _gradesContext
                .Students
                .Where(s => s.Name.Equals(studentName))
                .Include(student => student.Grades)
                .ThenInclude(grade => grade.Subject)
                .AsNoTracking()
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<Student>> FindGrades(string studentName, string subjectName)
        {
            var result = _gradesContext
                .Students
                .Where(s => s.Name.Equals(studentName))
                .Include(student => student.Grades)
                .ThenInclude(grade => grade.Subject)
                .Select(item => new Student
                {
                    Name = item.Name,
                    Id = item.Id,
                    Grades = item.Grades.Where(gradeItem => gradeItem.Subject.Name.Equals(subjectName)).ToList()
                })
                .AsNoTracking()
                .ToList();

            return Task.FromResult(result);
        }
    }
}
