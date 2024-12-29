using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Models.Entites
{
    public class Appoinment
    {
        public int Appoinmentid {  get; set; }

        public DateTime DateTime { get; set; }

        public string? Notes {  get; set; }

        public int doctorid {  get; set; }

        [ForeignKey("doctorid")]
        public Doctor Doctor { get; set; }

        public int Patinett {  get; set; }

        [ForeignKey("Patinett")]

        public Patinet Patinet { get; set; }
    }
}
