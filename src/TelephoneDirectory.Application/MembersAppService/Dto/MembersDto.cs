using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.MembersAppService.Dto
{
    [AutoMapFrom(typeof(Members))]
     public class MembersDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

    }
}
