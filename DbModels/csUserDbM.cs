using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    [Table("Users", Schema = "dbo")]
    public class csUserDbM
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        public List<csCommentDbM> Comments { get; set; } = new List<csCommentDbM>();
    }
}