namespace HospitalAPP1.DLL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Exprince { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
