using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IAddress
    {
        Guid AddressID { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string Country { get; set; }
    }
}