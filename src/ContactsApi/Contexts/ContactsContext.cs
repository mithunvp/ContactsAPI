using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            :base(options) { }
        public ContactsContext(){ }
        public DbSet<Contacts> Contacts { get; set; }
    }
}
