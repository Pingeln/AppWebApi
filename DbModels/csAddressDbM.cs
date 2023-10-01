using Configuration;
using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DbModels
{
    [Table("Addresses", Schema = "dbo")]
    public class csAddressDbM
    {
        [Key]
        public Guid AddressID { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        public Guid AttractionID { get; set; }
        [ForeignKey("AttractionID")]
        public virtual csAttractionDbM Attraction { get; set; }
    }
}