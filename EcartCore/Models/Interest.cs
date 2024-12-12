using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcartCore.Models
{
    [Table("Interest")]
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }
        public string Name{ get; set; }
        public virtual IEnumerable<UserInterest> UserInterest { get; set; }
    }
}
