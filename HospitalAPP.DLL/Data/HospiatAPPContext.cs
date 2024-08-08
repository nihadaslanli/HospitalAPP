using HospitalAPP.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPP.Data
{
    public class HospitalAPPContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public  HospitalAPP (DbContextOptions options):base(options)
    }
}
