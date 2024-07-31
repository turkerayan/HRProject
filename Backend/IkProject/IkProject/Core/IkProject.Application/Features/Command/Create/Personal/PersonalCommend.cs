using IkProject.Application.DTOs.Personel;
using IkProject.Application.Features.Command.Create.Company;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.Personel
{
    public class PersonalCommend : IRequest<PersonalDto>
    {
        public Guid? UserId { get; set; }    
        public string Email { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? StartAJob { get; set; }
        public DateTime? LeavingJob { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Wage { get; set; }
        public IFormFile ImgPath { get; set; }
        public string Password { get; set; }
        public bool IsBoy { get; set; }

    }
}
