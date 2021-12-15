using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MyForumProject.Models
{
    public class Post
    {
        public long Id { get; set; }

        public virtual AppUser User { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Subject { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostRate> Rates { get; set; }

        [NotMapped]
        public int LikeCount => Rates?.Where(r => r.Rate == Rate.Like).Count() ?? 0;

        [NotMapped]
        public int DislikeCount => Rates?.Where(r => r.Rate == Rate.Dislike).Count() ?? 0;

        [NotMapped]
        public int TotalRate => LikeCount - DislikeCount;


        public PostRate UserRate(AppUser user)
        {
            return Rates.FirstOrDefault(r => r.User == user);
        }

    }
}
