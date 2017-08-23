using System.Collections.Generic;
using System.Linq;
using ContactsApi.Models;
using ContactsApi.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactsContext _context;
        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }       

        public async Task Add(Contacts item)
        {            
            await _context.Contacts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public bool CheckValidUserKey(string reqkey)
        {
            var userkeyList = new List<string>
            {
                "28236d8ec201df516d0f6472d516d72d",
                "38236d8ec201df516d0f6472d516d72c",
                "48236d8ec201df516d0f6472d516d72b"
            };

            if (userkeyList.Contains(reqkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Contacts> Find(string key)
        {
            return await _context.Contacts
                .Where(e => e.MobilePhone.Equals(key))
                .SingleOrDefaultAsync();
        }       

        public async Task Remove(string Id)
        {
            var itemToRemove = await _context.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == Id);
            if (itemToRemove != null)
            {
                _context.Contacts.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Contacts item)
        {            
            var itemToUpdate = await _context.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
                await _context.SaveChangesAsync();
            }
        }
    }
}