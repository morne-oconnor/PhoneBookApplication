using PhoneBookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Components.Interfaces
{
    public interface IPhoneBookComponent
    {
        List<DisplayPhoneBookModel> GetContacts();
        void AddContact(PhoneBookModel phoneBookModel);
    }
}
