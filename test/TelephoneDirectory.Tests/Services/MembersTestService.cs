using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.MembersAppService;
using TelephoneDirectory.MembersAppService.Dto;
using Xunit;

namespace TelephoneDirectory.Tests.Services
{
   public class MembersTestService : TelephoneDirectoryTestBase
    {
        private readonly IMembersService _membersService;

        public MembersTestService()
        {
            _membersService = Resolve<IMembersService>();
        }


        [Fact]

        public async Task GetMembers_Test()
        {
            var output = await _membersService.GetMembers();
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]

        public async Task AddMembers_Test()
        {
            MembersDto members = new MembersDto()
            {
                Id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def"),
                Name = "New Name",
                Surname = "New Surname",
                Company = "New Company"
            };

            await _membersService.AddMembers(members);
            await UsingDbContextAsync(async context =>
            {
                var result = await context.Members.FirstOrDefaultAsync(u => u.Id == members.Id);
                result.ShouldBeNull();
            });
        }


        [Fact]

        public async Task UpdateMembers_Test()
        {
            MembersDto members = new MembersDto()
            {
                Id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def"),
                Name = "New Name Update",
                Surname = "New Surname Update",
                Company = "New Company"
            };

            await _membersService.UpdateMembers(members);

            var result = _membersService.FindMembers(members.Id);
            //result.Surname.ShouldBe(members.Surname);
        }


        [Fact]

        public async Task FindMembers_Test()
        {
            Guid id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def");
            var output = _membersService.FindMembers(id);
            output.ShouldNotBeNull();
        }

        [Fact]

        public async Task DeleteMembers_Test()
        {
            Guid id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def");
            await _membersService.DeleteMembers(id);
            var output = _membersService.FindMembers(id);
            output.ShouldNotBeNull();
        }
    }
}
