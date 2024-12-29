using Clinic.Models.Entites;
using Clinic.Models.Irepo;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Models.Imprepo
{
    public class Implementationdoctor : idoctor
    {
        public readonly Appdp db;
        public Implementationdoctor(Appdp appdp)
        {
            db = appdp;
            
        }
        public async Task addd(Doctor doctor)
        {
             db.Doctors.Add(doctor);

            await db.SaveChangesAsync();
        }

        public async Task deleted(Doctor doctor)
        {
           db.Doctors.Remove(doctor);
          await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> Getall()
        {
            return await db.Doctors.ToListAsync();
        }

        public async Task<Doctor> getbyid(int id)
        {
         var w=  await  db.Doctors.FirstOrDefaultAsync(x=> x.DoctorId==id);
            return w;  
        }

        public async Task updated(Doctor doctor)
        {

            db.Doctors.Update(doctor);
            db.SaveChanges();
            
        }
    }
}
