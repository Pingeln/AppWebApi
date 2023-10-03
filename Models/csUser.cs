using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class csUser
    {
        public virtual Guid UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual List<csComment> Comments { get; set; } = null;
    }
}