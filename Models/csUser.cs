using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class csUser : IUser
    {
        public virtual Guid UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual List<IComment> Comments { get; set; } = null;
    }
}