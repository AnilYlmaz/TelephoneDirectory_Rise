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
  public class MembersTestDataCreator
    {
        private readonly TelephoneDirectoryDbContext _context;


        public MembersTestDataCreator(TelephoneDirectoryDbContext context)
        {
            _context = context;
            
        }

        public void Create()
        {
            MembersAdd(new Members
            {
                Id = new Guid("518013ff-9d20-4226-9b01-2a5ba3c74def"),
                Name = "New Name",
                Surname = "New Surname",
                Company = "New Company"
            });
        }

        private void MembersAdd(Members members)
            {
                if (_context.Members.IgnoreQueryFilters().Any(s => s.Id == members.Id))
                {
                    return;
                }

                _context.Members.Add(members);
            }

        
}
}
