using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.MembersAppService.Dto;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.MembersContactAppService.Dto
{
    [AutoMapFrom(typeof(MembersContact))]
    public class MembersContactDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        public Guid MemberId { get; set; }

        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }


        public string EmailAddress { get; set; }

        public string Location { get; set; }

        public string InfoContext { get; set; }


        public MembersDto Members { get; set; }
    }
}