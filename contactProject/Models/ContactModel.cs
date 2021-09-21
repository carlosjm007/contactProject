using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject.Models
{
    public class ContactModel
    {
        [BsonId]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Profile { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumberWork { get; set; }
        public string PhoneNumberPersonal { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
