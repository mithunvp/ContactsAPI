using ContactsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApi.Repository
{
    public interface IContactsRepository
    {
        Task Add(Contacts item);
        Task<IEnumerable<Contacts>> GetAll();
        Task<Contacts> Find(string key);
        Task Remove(string Id);
        Task Update(Contacts item);

        bool CheckValidUserKey(string reqkey);
    }
}
