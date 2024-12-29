using Clinic.Models.Entites;

namespace Clinic.Models.Irepo
{
    public interface idoctor
    {

        public Task<IEnumerable<Doctor>> Getall();

       public Task  addd(Doctor doctor);

       public Task updated(Doctor doctor);

       public Task deleted(Doctor doctor);

        public  Task<Doctor>getbyid(int id);
    }
}
