using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    [Table("Attractions", Schema = "dbo")]
    public class csAttractionDbM
    {
        [Key]
        public Guid AttractionID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        public List<csCommentDbM> Comments { get; set; } = new List<csCommentDbM>();

        public Guid AddressID { get; set; }
        [ForeignKey("AddressID")]
        public virtual csAddressDbM Address { get; set; }
    }
}