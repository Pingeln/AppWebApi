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
        [Required]
        public Guid AddressID { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

    }
}