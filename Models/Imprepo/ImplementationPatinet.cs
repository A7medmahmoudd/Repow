using Clinic.Models.Entites;
using Clinic.Models.Irepo;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Clinic.Models.Imprepo
{
    public class ImplementationPatinet : iPatinet
    {
        public readonly Appdp db;
        public ImplementationPatinet(Appdp appdp)
        {
            db = appdp;

        }

        public async Task adddpa(Patinet patinet)
        {
            db.Patches.Add(patinet);

            await db.SaveChangesAsync();
        }

        public async Task deletepa(Patinet patinet)
        {
            db.Patches.Remove(patinet);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patinet>> Getall()
        {
            return await db.Patches.ToListAsync();
        }

        public async Task<Patinet> getbypa(int id)
        {
            var w = await db.Patches.FirstOrDefaultAsync(x => x.PatientsId == id);
            return w;
        }

        public async Task updatepa(Patinet patinet)
        {
            db.Patches.Update(patinet);
            db.SaveChanges();

        }
    }
}
