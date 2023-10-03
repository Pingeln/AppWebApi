using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class csAttraction
    {
        public Guid AttractionID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public csAddress Address { get; set; }
        public List<csComment> Comments { get; set; } = null;
    }
}