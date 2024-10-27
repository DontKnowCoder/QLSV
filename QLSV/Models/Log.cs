using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace QLSV.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Class { get; set; }
        public string Action { get; set; }
        [ForeignKey("SV")]
        public int StudentID { get; set; }
    }
}