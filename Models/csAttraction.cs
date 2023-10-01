using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class csAttraction : IAttraction
    {
        public Guid AttractionID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public IAddress Address { get; set; }
        public List<IComment> Comments { get; set; } = null;
    }
}