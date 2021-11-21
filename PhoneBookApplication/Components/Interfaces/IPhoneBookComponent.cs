using PhoneBookApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookApplication.Components.Interfaces
{
    public interface IPhoneBookComponent
    {
        Task<List<DisplayPhoneBookModel>> GetContacts();
        Task<bool> AddContact(PhoneBookModel phoneBookModel);
    }
}
