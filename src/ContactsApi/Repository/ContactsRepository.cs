using System.Collections.Generic;
using System.Linq;
using ContactsApi.Models;
using ContactsApi.Contexts;

namespace ContactsApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactsContext _context;
        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }
        static List<Contacts> ContactsList = new List<Contacts>();

        public void Add(Contacts item)
        {
            //ContactsList.Add(item);
            _context.Contacts.Add(item);
            _context.SaveChanges();
        }

        public bool CheckValidUserKey(string reqkey)
        {
            var userkeyList = new List<string>();
            userkeyList.Add("28236d8ec201df516d0f6472d516d72d");
            userkeyList.Add("38236d8ec201df516d0f6472d516d72c");
            userkeyList.Add("48236d8ec201df516d0f6472d516d72b");

            if (userkeyList.Contains(reqkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Contacts Find(string key)
        {
            // ToDo - Integrate with EF Core, DbSet.Find not available yet
            return ContactsList
                .Where(e => e.MobilePhone.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<Contacts> GetAll()
        {
            //ContactsList.Add(new Contacts() {FirstName ="Mithun", MobilePhone = "2345" });

            return _context.Contacts.ToList();
        }

        public void Remove(string Id)
        {
            // ToDo - Integrate with EF Core
            var itemToRemove = ContactsList.SingleOrDefault(r => r.MobilePhone == Id);
            if (itemToRemove != null)
                ContactsList.Remove(itemToRemove);
        }

        public void Update(Contacts item)
        {
            // ToDo - Integrate with EF Core
            var itemToUpdate = ContactsList.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
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
            }
        }
    }
}