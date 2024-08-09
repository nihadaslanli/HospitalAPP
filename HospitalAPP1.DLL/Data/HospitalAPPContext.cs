
using HospitalAPP.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPP.DLL.Data
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
