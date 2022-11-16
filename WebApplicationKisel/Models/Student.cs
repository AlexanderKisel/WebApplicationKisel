using System.Reflection;

namespace WebApplicationKisel.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public FormStudy formStudy { get; set; }

        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public int Math { get; set; }

        public int Russia { get; set; }

        public int Inform { get; set; }

        public int Sum { get; set; }

    }
}
