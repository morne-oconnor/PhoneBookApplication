using System;

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
