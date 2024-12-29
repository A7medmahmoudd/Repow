using Clinic.Models.Entites;
using Clinic.Models.Irepo;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Models.Imprepo
{
    public class impAppoinment : iAppoinment
    {
        public readonly Appdp db;
        public impAppoinment(Appdp appdp)
        {
            db = appdp;

        }

        public async Task adddapp(ViewmodelAppointment viewmodelAppointment)
        {
            Appoinment appoinment = new Appoinment()
            {
                Notes = viewmodelAppointment.Note,
                DateTime = viewmodelAppointment.Date,
                doctorid = viewmodelAppointment.idDoctor,
                Patinett = viewmodelAppointment.idPatinet
            };

           await db.Appoinments.AddAsync(appoinment);
           await db.SaveChangesAsync();
            
        }

        public async Task deletedapp(Appoinment appoinment)
        {
            db.Appoinments.Remove(appoinment);
           await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appoinment>> getallapp()
        {
            return await db.Appoinments.Include(x => x.Patinet).Include(w => w.Doctor).ToListAsync();
        }

        public async Task<Appoinment> getbyidapp(int id)
        {
            var y= await db.Appoinments.Include(x=> x.Doctor).Include(x => x.Patinet).FirstOrDefaultAsync(x => x.Appoinmentid == id);
            return y;

            
        }

        public async Task updatedapp(ViewmodelAppointment viewmodelAppointment,int id)
        {
            var w=await db.Appoinments.FirstOrDefaultAsync(x=> x.Appoinmentid==id);

            
            w.Notes = viewmodelAppointment.Note;
            w.DateTime = viewmodelAppointment.Date;
            w.doctorid = viewmodelAppointment.idDoctor;
            w.Patinett = viewmodelAppointment.idPatinet;
                
            
            db.Appoinments.Update(w);
            await db.SaveChangesAsync();

        }
    }
}
