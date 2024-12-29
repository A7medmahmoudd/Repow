using Clinic.Models.Entites;

namespace Clinic.Models
{
    public class ViewmodelAppointment
    {

        public DateTime Date {  get; set; }

        public string Note { get; set; }

        public int idDoctor {  get; set; }

        public int idPatinet {  get; set; }

        public IEnumerable<Patinet> ?patinets { get; set; }

        public IEnumerable<Doctor> ?doctors {  get; set; }
    }
}
