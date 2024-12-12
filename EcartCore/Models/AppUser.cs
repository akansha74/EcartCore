using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcartCore.Models
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [NotMapped]
        public SelectList citylist { get; set; }

        [NotMapped]
        public SelectList genderlist { get; set; }

        [NotMapped]
        public List<SelectListItem> interestlist { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public virtual IEnumerable<UserInterest> UserInterest { get; set; }
    }
}
