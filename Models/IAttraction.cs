using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IAttraction
    {
        Guid AttractionID { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        IAddress Address { get; set; }
        List<IComment> Comments { get; set; }
    }
}