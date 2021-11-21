using System;
using System.Diagnostics;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _phoneBookComponent.GetContacts());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }     
        }

        [HttpPost]
        public async Task<bool> AddContact(PhoneBookModel phoneBook)
        {
            try
            {
                return await _phoneBookComponent.AddContact(phoneBook);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
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
                _logger.LogError(ex.Message);
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
