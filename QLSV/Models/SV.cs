using System.ComponentModel.DataAnnotations;

namespace QLSV.Models
{
    public class SV
    {
        [Key]
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Class {  get; set; }

    }
}
