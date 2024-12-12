using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcartCore.Models
{
    [Table("UserInterest")]
    public class UserInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserInterestId { get; set; }
  
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("Interest")]
        public int InterestId { get; set; }
        public virtual Interest Interest { get; set; }


    }
}
