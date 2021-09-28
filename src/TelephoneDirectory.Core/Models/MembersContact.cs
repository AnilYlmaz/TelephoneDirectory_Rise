using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.Models
{
    [Table("AbpMembersContact")]
    public  class MembersContact : FullAuditedEntity<Guid>
    {
        [Required]
        [Column("MemberId")]
        public Guid MemberId { get; set; }

        [Required]
        [Column("PhoneNumber")]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }


        [Column("EmailAddress")]
        public string EmailAddress { get; set; }

        [Column("Location")]
        public string Location { get; set; }

        [Column("InfoContext")]
        public string InfoContext { get; set; }

        [ForeignKey("MemberId")]

        public Members Members { get; set; }
    }
}
