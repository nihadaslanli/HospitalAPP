using AutoMapper;
using HospitalAPP.DLL.Entities;
using HospitalAPP.Dtos.DepartmentDtos;
using HospitalAPP.Dtos.DoctorDtos;
namespace HospitalAPP.Profiles
{
    public class MapProfile : Profile
    {
        private readonly HttpContextAccessor _contextAccessor;
        public MapProfile(HttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var uriBuilder = new UriBuilder
                (
                _contextAccessor.HttpContext.Request.Scheme,
                _contextAccessor.HttpContext.Request.Host.Host,
               (int)_contextAccessor.HttpContext.Request.Host.Port
               );
            var url = uriBuilder.Uri.AbsoluteUri;

            //department
            CreateMap<Doctor, DoctorInDepartmentReturnDto>();
            CreateMap<Department, DepartmentReturnDto>()
                .ForMember(d => d.Img, map => map.MapFrom(d => url + "images/" + d.Img));


            //doctor
            CreateMap<Doctor, DoctorReturnDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            CreateMap<Department, DepartmentInDoctorReturnDto>();

        }
    }
}
