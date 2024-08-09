namespace HospitalAPP.Dtos.DepartmentDtos
{
    public class DepartmentReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public string Img { get; set; }
        public List<DoctorInDepartmentReturnDto> Doctors { get; set; }
    }
    public class DoctorInDepartmentReturnDto
    {
        public string Name { get; set; }
        public int Expirnce { get; set; }
    }
}
