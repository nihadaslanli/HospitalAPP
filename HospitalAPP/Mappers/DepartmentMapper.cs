using HospitalAPP.Dtos.DepartmentDtos;

namespace HospitalAPP.Mappers
{
    public class DepartmentMapper
    {
        public static CreateDepartmentDto(DepartmentCreateDto dto)
        {
            Name=dto.Name;
            Limit=dto.Limit;
        }
    }
}
