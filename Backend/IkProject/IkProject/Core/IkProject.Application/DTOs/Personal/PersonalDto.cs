using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.DTOs.Personel
{
    public class PersonalDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? StartAJob { get; set; }
        public DateTime? LeavingJob { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
    }
}
