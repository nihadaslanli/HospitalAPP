using FluentValidation;

namespace HospitalAPP.Dtos.DoctorDtos
{
    public class DoctorUpdateDto
    {
        public string Name { get; set; }
        public int Exprince { get; set; }
        public int DepartmentId { get; set; }

    }
    public class DoctorUpdateDtoValidator : AbstractValidator<DoctorUpdateDto>
    {
        public DoctorUpdateDtoValidator()
        {
            RuleFor(d => d.Name)
               .MaximumLength(20)
               .MinimumLength(3)
               .NotEmpty();
            RuleFor(d => d.Exprince)
                .InclusiveBetween(1, 50)
                .NotEmpty();
        }
    }
}
