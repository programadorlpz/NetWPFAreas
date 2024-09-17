using System.ComponentModel.DataAnnotations;

namespace NetWPFAreasApp.Models
{
    public class Area
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
