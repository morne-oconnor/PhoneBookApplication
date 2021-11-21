using Microsoft.Extensions.Logging;
using PhoneBookApplication.Components.Interfaces;
using PhoneBookApplication.Helpers;
using PhoneBookApplication.Models;
using PhoneBookApplication.Repository.Sql.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Components
{
    public class PhoneBookComponent : IPhoneBookComponent
    {
        private readonly ILogger<PhoneBookComponent> _logger;
        private readonly ISqlRepository _sqlRepository; 
        public PhoneBookComponent(ILogger<PhoneBookComponent> logger, ISqlRepository sqlRepository)
        {
            _logger = logger;
            _sqlRepository = sqlRepository;
        }
        public async Task<List<DisplayPhoneBookModel>> GetContacts()
        {
            List<DisplayPhoneBookModel> orderedEntries = new List<DisplayPhoneBookModel>();
            List<DisplayPhoneBookModel> phoneBookEntries = await  _sqlRepository.QueryList<DisplayPhoneBookModel>(ValuesHelper.GET_PHONEBOOK_ENTRIES_SP);
            
            if (phoneBookEntries?.Any() ?? false)
            {
                _logger.LogInformation(ValuesHelper.ENTRIES_RETRIEVED_INFO_MESSAGE);
                orderedEntries = phoneBookEntries.OrderByDescending(x => x.Id).ToList();

            }
            else
            {
                _logger.LogInformation(ValuesHelper.NO_ENTRIES_INFO_MESSAGE);
            }

            return orderedEntries;
        }
        public async Task<bool> AddContact(PhoneBookModel phoneBookModel)
        {
            int result = await _sqlRepository.Execute(ValuesHelper.ADD_CONTACT_DETAILS_SP,
                new
                {
                    phoneBookModel.Name,
                    phoneBookModel.Entries,
                    phoneBookModel.PhoneNumber
                });

            bool isContactAdded = (result > 0);
            if (isContactAdded)
            {
                _logger.LogInformation($"{ValuesHelper.ADD_ENTRY_INFO_MESSAGE} {phoneBookModel.Name}");
            }
            else
            {
                _logger.LogInformation($"{ValuesHelper.ADD_ENTRY_FAILED_INFO_MESSAGE} {phoneBookModel.Name}");
            }

            return isContactAdded;
        }
    }
}
