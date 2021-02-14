using PhoneBookApplication.Components.Interfaces;
using PhoneBookApplication.Models;
using PhoneBookApplication.Sidecar.Repository.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Components
{
    public class PhoneBookComponent : IPhoneBookComponent
    {
        private readonly ISqlRepository _sqlRepository; 
        public PhoneBookComponent(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }
        public List<DisplayPhoneBookModel> GetContacts()
        {
            return _sqlRepository.QueryList<DisplayPhoneBookModel>("usp_GetPhoneBookEntries", null);
        }
        public void AddContact(PhoneBookModel phoneBookModel)
        {
            _sqlRepository.Execute("usp_AddContactDetails", new
            { @Name = phoneBookModel.Name, @Entries = phoneBookModel.Entries, @PhoneNumber = phoneBookModel.PhoneNumber });
        }

    }
}
