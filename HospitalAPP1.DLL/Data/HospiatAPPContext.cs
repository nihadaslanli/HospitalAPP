
using HospitalAPP1.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPP.Data
{
    public class HospitalAPPContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public  HospitalAPPContext(DbContextOptions options) : base(options)
        {

        }
    }
}
