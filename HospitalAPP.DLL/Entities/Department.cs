namespace HospitalAPP.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Limit { get; set; }
        public var Img { get; set; }
       
      public List<Doctor> Doctors { get; set; }
    }
}
