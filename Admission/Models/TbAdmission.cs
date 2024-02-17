using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admission.Models
{
    [Table("tb_Admission")]
    public class TbAdmission
    {
        [Key]
        public int StudentId { get; set; }

        public string? Name { get; set; }
        public string? Course { get; set; }
        public DateTime DOA { get; set; }
    }
}
