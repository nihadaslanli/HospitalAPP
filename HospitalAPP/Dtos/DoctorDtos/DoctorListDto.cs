namespace HospitalAPP.Dtos.DoctorDtos
{
    public class DoctorListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<DoctorReturnDto> Doctors { get; set; }
    }
}
