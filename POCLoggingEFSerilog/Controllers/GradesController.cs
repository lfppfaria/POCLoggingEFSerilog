using Microsoft.AspNetCore.Mvc;
using POCLoggingEFSerilog.Repository;
using System.Threading.Tasks;

namespace POCLoggingEFSerilog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradeRepository _gradeRepository;

        public GradesController(GradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FindGradesAsync()
        {            
            var result = await _gradeRepository.FindGrades();

            return Ok(result);
        }

        [HttpGet("{studentName}")]
        public async Task<IActionResult> FindGradesAsync([FromRoute]string studentName)
        {
            var result = await _gradeRepository.FindGrades(studentName);

            return Ok(result);
        }

        [HttpGet("{studentName}/{subject}")]
        public async Task<IActionResult> FindGradesAsync([FromRoute]string studentName, [FromRoute]string subject)
        {
            var result = await _gradeRepository.FindGrades(studentName, subject);

            return Ok(result);
        }
    }
}