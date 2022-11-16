using WebApplicationKisel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApplicationKisel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasaKormit : ControllerBase
    {
        private static readonly IList<Student> studentsList = new List<Student>();

        [HttpGet]
        public IList<Student> Get()
        {
            return studentsList;
        }
        [HttpGet("Status")]
        public Status GetStatus()
        {
            var status = new Status()
            {
                AmountStudents = studentsList.Count(),
                AmountPassedStudents = studentsList.Where(scores => scores.Sum > 150).Count(),
            };
            return status;
        }
        [HttpPost]
        public Student Add(FillStudent value)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                FullName = value.FullName,
                Gender = value.Gender,
                BirthDay = value.BirthDay,
                formStudy = value.formStudy,
                Math = value.Math,
                Russia = value.Russia,
                Inform = value.Inform,
                Sum = value.Math + value.Russia + value.Inform,
            };
            studentsList.Add(student);
            return student;
        }
        [HttpPut("{id}")]
        public Student Change([FromRoute] Guid id, [FromBody] FillStudent value)
        {
            var student = studentsList.First(s => s.Id == id);
            if (student != null)
            {
                var index = studentsList.IndexOf(student);

                student.FullName= value.FullName;
                student.Gender= value.Gender;  
                student.BirthDay= value.BirthDay;
                student.formStudy = value.formStudy;
                student.Math = value.Math;
                student.Russia = value.Russia;
                student.Inform = value.Inform;
                student.Sum = value.Math + value.Russia + value.Inform;

                studentsList[index] = student;
            }
            return student;
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            var student = studentsList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                return studentsList.Remove(student);
            }
            return false;
        }
    }
}
