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
using TelephoneDirectory.MembersContactAppService.Dto;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.MembersContactAppService
{
  public  class MembersContactService : ApplicationService, IMembersContactService
    {
        private readonly IRepository<MembersContact, Guid> _membersContactRepository;

        public MembersContactService(
            IRepository<MembersContact, Guid> membersContactRepository
        )
        {
            _membersContactRepository = membersContactRepository;
        }

        [HttpGet]

        public async Task<ListResultDto<MembersContactDto>> GetMembersContact()
        {
            var members = _membersContactRepository.GetAllIncluding(x=>x.Members).ToList();

            if (members.Count == 0)
            {
                throw new UserFriendlyException();
            }

            return new ListResultDto<MembersContactDto>(ObjectMapper.Map<List<MembersContactDto>>(members));
        }

        [HttpGet]
        public async Task<int> GetMembersLocationReport(string location)
        {
            if(location == null)
            {
                throw new UserFriendlyException("Lokasyon girilmesi zorunludur.");

            }
            var membersLocation = _membersContactRepository.GetAllIncluding(x => x.Members).Where(x => x.Location.ToLower() == location.ToLower()).Select(x => x.MemberId).Distinct().Count();

            if(membersLocation < 0)
            {
                throw new UserFriendlyException("Girilen konumda hiç kayıt bulunamamıştır.");

            }

            return membersLocation;
        }

        [HttpGet]
        public async Task<int> GetPhoneNumbersLocationReport(string location)
        {
            if (location == null)
            {
                throw new UserFriendlyException("Lokasyon girilmesi zorunludur.");

            }
            var phoneNumberLocation = _membersContactRepository.GetAllIncluding(x => x.Members).Where(x => x.Location.ToLower() == location.ToLower()).Count();

            if (phoneNumberLocation < 0)
            {
                throw new UserFriendlyException("Girilen konumda hiç kayıt bulunamamıştır.");

            }

            return phoneNumberLocation;
        }

 

        [HttpPost]
        public async Task<Guid> AddMembersContact(MembersContactDto input)
        {
            MembersContact memberContact = new MembersContact();

            memberContact.MemberId = input.MemberId;
            memberContact.PhoneNumber = input.PhoneNumber;
            memberContact.EmailAddress = input.EmailAddress;
            memberContact.Location = input.Location;
            memberContact.InfoContext = input.InfoContext;

            if (memberContact.MemberId == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                throw new UserFriendlyException("Kişi kaydı olmadan detay bilgiler eklenemez.");

            }

            Guid id = await _membersContactRepository.InsertAndGetIdAsync(memberContact);

            return id;

        }


        [HttpPut]
        public async Task UpdateMembersContact(MembersContactDto input)
        {
            var membersContact = _membersContactRepository.GetAll().Where(x => x.Id == input.Id).FirstOrDefault();
            if (membersContact.Id == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                throw new UserFriendlyException("Veri güncelleme başarısız.");

            }

            membersContact.MemberId = input.MemberId;
            membersContact.PhoneNumber = input.PhoneNumber;
            membersContact.EmailAddress = input.EmailAddress;
            membersContact.Location = input.Location;
            membersContact.InfoContext = input.InfoContext;

            await _membersContactRepository.UpdateAsync(membersContact);

        }

        [HttpGet]
        public async Task<MembersContactDto> FindMembersContact(Guid id)
        {
            var member = _membersContactRepository.FirstOrDefault(x => x.Id == id);
            if(member == null)
            {
                throw new UserFriendlyException("istenilen kayıt bulunamadı.");

            }
            return ObjectMapper.Map<MembersContactDto>(member);
        }

        public async Task DeleteMembersContact(Guid id)
        {
            if (id == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                throw new UserFriendlyException("Silme işlemi başarısız.");

            }
            await _membersContactRepository.DeleteAsync(id);

        }

    }
}
