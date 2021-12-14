using System.ComponentModel.DataAnnotations;

namespace MyForumProject.Models
{
    public class FavoritePost
    {
        public long Id { get; set; }
        [Required]
        public virtual AppUser User { get; set; }
        [Required]
        public virtual Post Post { get; set; }
    }


 
}
