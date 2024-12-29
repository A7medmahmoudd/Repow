using Microsoft.EntityFrameworkCore;

namespace Clinic.Models.Entites
{
    public class Patinet
    {
         
        public int PatientsId {  get; set; }

        public string PatientName { get; set; }

        public int Age {  get; set; }

        public List<Appoinment> AppoinmentList { get; set; }
    }
}
