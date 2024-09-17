using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetWPFAreasApp.Models
{
    public class UserArea
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Area")]
        [MaxLength(50)]
        public string AreaName { get; set; }

        public virtual User User { get; set; }
        public virtual Area Area { get; set; }
    }
}
