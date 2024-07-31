using IkProject.Application.DTOs.Company;
using IkProject.Domain.Company;

namespace IkProject.Application.Features.Queries.GetAdminDetails
{
    public class GetAdminDetailsResponse
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string IdentityNo { get; set; }
        public DateTime? StartAJob { get; set; }
        public DateTime? LeavingJob { get; set; }
        public bool IsActive { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImgPath { get; set; }
        public CompanyDto? Company { get; set; }
    }
}
