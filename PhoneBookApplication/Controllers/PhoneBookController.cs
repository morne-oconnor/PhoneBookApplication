using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookApplication.Components.Interfaces;
using PhoneBookApplication.Models;

namespace PhoneBookApplication.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly ILogger<PhoneBookController> _logger;
        private readonly IPhoneBookComponent _phoneBookComponent;
        public PhoneBookController(ILogger<PhoneBookController> logger, IPhoneBookComponent phoneBookComponent)
        {
            _logger = logger;
            _phoneBookComponent = phoneBookComponent;
        }

        public IActionResult Index()
        {
            try
            {
                List<DisplayPhoneBookModel> phoneBookEntries = GetContacts();
                _logger.LogInformation("Got phonebook entries");

                return View(phoneBookEntries);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred on Index Controller");

                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
      
        }
        [HttpPost]
        public bool AddContact(PhoneBookModel phoneBook)
        {
            try
            {
                _phoneBookComponent.AddContact(phoneBook);
                _logger.LogInformation($"Added phonebook entry - Name: {phoneBook.Name}");

                return true;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred on Index Controller");

                return false;
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            try
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred on Index Controller");

                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        private List<DisplayPhoneBookModel> GetContacts()
        {
            return _phoneBookComponent.GetContacts();
        }
    }
}
