using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.MembersContactAppService;
using TelephoneDirectory.MembersContactAppService.Dto;
using Xunit;

namespace TelephoneDirectory.Tests.Services
{
    public class MemberContactTestService : TelephoneDirectoryTestBase
    {
        private readonly IMembersContactService _membersContactService;

        public MemberContactTestService()
        {
            _membersContactService = Resolve<IMembersContactService>();
        }


        [Fact]

        public async Task GetMembersContact_Test()
        {
            var output = await _membersContactService.GetMembersContact();
            output.Items.Count.ShouldBeGreaterThan(0);
        }



        [Fact]

        public async Task GetMembersLocationReport_Test()
        {
            var output = await _membersContactService.GetMembersLocationReport("New Location");
            output.ShouldBeGreaterThan(0);
        }



        [Fact]

        public async Task GetPhoneNumbersLocationReport_Test()
        {
            var output = await _membersContactService.GetPhoneNumbersLocationReport("New TelephoneNumber");
            output.ShouldBeGreaterThan(0);
        }


        [Fact]

        public async Task AddMembers_Test()
        {
            MembersContactDto membersContact = new MembersContactDto()
            {
                Id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74de9"),
                MemberId = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def"),
                PhoneNumber = "New PhoneNumber",
                EmailAddress = "New EmailAddress",
                Location = "New Location",
                InfoContext = "New InfoContext"
            };

            await _membersContactService.AddMembersContact(membersContact);
            await UsingDbContextAsync(async context =>
            {
                var result = await context.MembersContact.FirstOrDefaultAsync(u => u.Id == membersContact.Id);
                result.ShouldNotBeNull();
            });
        }


        [Fact]

        public async Task UpdateMembers_Test()
        {
            MembersContactDto membersContact = new MembersContactDto()
            {
                Id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74de9"),
                MemberId = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def"),
                PhoneNumber = "New PhoneNumber",
                EmailAddress = "New EmailAddress",
                Location = "New Location Update",
                InfoContext = "New InfoContext"
            };

            await _membersContactService.UpdateMembersContact(membersContact);

            var result = _membersContactService.FindMembersContact(membersContact.Id);
            //result.Location.ShouldBe(membersContact.Location);
        }


        [Fact]

        public async Task FindMembersContact_Test()
        {
            Guid id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74de9");
            var output = _membersContactService.FindMembersContact(id);
            output.ShouldNotBeNull();
        }

        [Fact]

        public async Task DeleteMembers_Test()
        {
            Guid id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74de9");
            await _membersContactService.DeleteMembersContact(id);
            var output = _membersContactService.FindMembersContact(id);
            output.ShouldNotBeNull();
        }
    }
}
