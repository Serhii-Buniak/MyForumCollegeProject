using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MyForumProject.Models
{
    public class Comment
    {
        public long Id { get; set; }
  
        public virtual AppUser User { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }
        public virtual ICollection<CommentRate> Rates { get; set; }
        [Required]
        public long PostId { get; set; }

        public virtual Post Post { get; set; }

        [NotMapped]
        public int LikeCount => Rates?.Where(r => r.Rate == Rate.Like).Count() ?? 0;

        [NotMapped]
        public int DislikeCount => Rates?.Where(r => r.Rate == Rate.Dislike).Count() ?? 0;

        [NotMapped]
        public int TotalRate => LikeCount - DislikeCount;

        public CommentRate UserRate(AppUser user)
        {
            return Rates.FirstOrDefault(r => r.User == user);
        }

    }


 
}
