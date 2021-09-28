using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.EntityFrameworkCore;
using TelephoneDirectory.Models;

namespace TelephoneDirectory.Tests.MembersDataCreator
{
    public class MembersContactTestDataCreator
    {
        private readonly TelephoneDirectoryDbContext _context;

        public MembersContactTestDataCreator(TelephoneDirectoryDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            MembersContactAdd(new MembersContact
            {
                Id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74de9"),
                MemberId = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def"),
                PhoneNumber = "New PhoneNumber",
                EmailAddress = "New EmailAddress",
                Location = "New Location",
                InfoContext = "New InfoContext"
            });
        }

        private void MembersContactAdd(MembersContact membersContact)
        {
            if (_context.MembersContact.IgnoreQueryFilters().Any(s => s.Id == membersContact.Id))
            {
                return;
            }

            _context.MembersContact.Add(membersContact);
        }


    }
}
