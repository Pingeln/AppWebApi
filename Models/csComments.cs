using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class csComment : IComment
    {
        public Guid CommentID { get; set; }
        public string Text { get; set; }
        public virtual IUser User { get; set; }
    }
}