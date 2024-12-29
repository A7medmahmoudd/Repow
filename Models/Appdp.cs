using Clinic.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Models
{
    public class Appdp:DbContext
    {

        public Appdp(DbContextOptions <Appdp> options) :base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patinet> Patches { get; set; }

        public DbSet<Appoinment> Appoinments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appoinment>().HasOne(x => x.Doctor).WithMany(x => x.AppoinmentList);

            modelBuilder.Entity<Patinet>().HasMany(x => x.AppoinmentList).WithOne(x => x.Patinet);

            modelBuilder.Entity<Patinet>().HasKey(x=> x.PatientsId);
        }
    }
}
