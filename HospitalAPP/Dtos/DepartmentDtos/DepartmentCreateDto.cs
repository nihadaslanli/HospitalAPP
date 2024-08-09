using FluentValidation;

namespace HospitalAPP.Dtos.DepartmentDtos
{
  
   public class DepartmentCreateDto
    {
        public string Name { get; set; }
        public int Limit { get; set; }
        public IFormFile File { get; set; }

    }
    public class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {

        public DepartmentCreateDtoValidator()
        {
            RuleFor(d => d.Name)
                .MaximumLength(20)
                .MinimumLength(5)
                .NotEmpty();
            RuleFor(d => d.Limit)
                .InclusiveBetween(1, 10)
                .NotEmpty();
            RuleFor(d => d)
                .Custom((d, context) =>
                {
                    if (d.File == null)
                    {
                        context.AddFailure("File", "file can' be empty..");
                        return;
                    }
                    if (d.File.Length / 1024 > 300)
                    {
                        context.AddFailure("File", "size is too large");
                    }
                    if (!d.File.ContentType.Contains("image/"))
                    {
                        context.AddFailure("File", "file only imagee");
                    }
                });
        }
    }
}
