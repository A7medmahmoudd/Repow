using Clinic.Models.Entites;

namespace Clinic.Models.Irepo
{
    public interface iAppoinment
    {
        public Task<IEnumerable<Appoinment>> getallapp();


        public Task adddapp(ViewmodelAppointment viewmodelAppointment);

        public Task updatedapp(ViewmodelAppointment viewmodelAppointment, int id);

        public Task deletedapp(Appoinment appoinment);

        public Task<Appoinment> getbyidapp(int id);
     }
}