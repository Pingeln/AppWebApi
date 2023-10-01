using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IComment
    {
        Guid CommentID { get; set; }
        string Text { get; set; }
        IUser User { get; set; } // En kommentar har en användare
    }
}