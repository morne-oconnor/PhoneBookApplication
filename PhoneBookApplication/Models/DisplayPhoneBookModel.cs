using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Models
{
    public class DisplayPhoneBookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Entries { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
