namespace Clinic.Models.Entites
{
    public class Doctor
    {
        public int DoctorId {  get; set; }

        public string DoctorName { get; set; }

        public string Specialty {  get; set; }

        public List<Appoinment> AppoinmentList { get; set; }

    }
}
