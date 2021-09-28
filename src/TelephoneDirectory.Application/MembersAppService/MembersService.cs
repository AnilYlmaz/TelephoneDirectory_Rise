using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.MembersAppService.Dto;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.MembersAppService
{
    public class MembersService : ApplicationService, IMembersService
    {
        private readonly IRepository<Members, Guid> _membersRepository;

        public MembersService(
            IRepository<Members, Guid> membersRepository
        )
        {
            _membersRepository = membersRepository;
        }

        [HttpGet]

        public async Task<ListResultDto<MembersDto>> GetMembers()
        {
            var members = _membersRepository.GetAll().ToList();

            if(members.Count == 0)
            {
                throw new UserFriendlyException("Rehbere kayıtlı kişi bulunamamıştır.");
            }


            return new ListResultDto<MembersDto>(ObjectMapper.Map<List<MembersDto>>(members));
        }

        [HttpPost]
        public async Task<Guid> AddMembers(MembersDto input)
        {
            if (input.Name == null || input.Surname == null)
            {
                throw new UserFriendlyException("Ad ve soyad alanı boş bırakılamaz.");

            }

            Members member = new Members();

            member.Name = input.Name;
            member.Surname = input.Surname;
            member.Company = input.Company;

     

            Guid id = await _membersRepository.InsertAndGetIdAsync(member);
         
            return id;

        }


        [HttpPut]
        public async Task UpdateMembers(MembersDto input)
        {
            var members = _membersRepository.GetAll().Where(x => x.Id == input.Id).FirstOrDefault();
            if(members.Id == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                throw new UserFriendlyException("Veri güncelleme başarısız.");

            }

            members.Name = input.Name;
            members.Surname = input.Surname;
            members.Company = input.Company;

            await _membersRepository.UpdateAsync(members);

        }

        [HttpGet]
        public async Task<MembersDto> FindMembers(Guid id)
        {
            var member = _membersRepository.FirstOrDefault(x => x.Id == id);
            if(member == null)
            {
                throw new UserFriendlyException("istenilen kayıt bulunamadı.");

            }
            return ObjectMapper.Map<MembersDto>(member);
        }

        public async Task DeleteMembers(Guid id)
        {
            if (id == new Guid("00000000-0000-0000-0000-000000000000")) 
            {
                throw new UserFriendlyException("Silme işlemi başarısız.");

            }
            await _membersRepository.DeleteAsync(id);

        }

    }
}
