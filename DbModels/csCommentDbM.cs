using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    [Table("Comments", Schema = "dbo")]
    public class csCommentDbM
    {
        [Key]
        public Guid CommentID { get; set; }

        [Required]
        public string Text { get; set; }

        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual csUserDbM User { get; set; }

        public Guid AttractionID { get; set; }
        [ForeignKey("AttractionID")]
        public virtual csAttractionDbM Attraction { get; set; }
    }
}