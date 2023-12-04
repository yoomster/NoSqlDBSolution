﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLibrary.Models
{
    public class ContactModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmailAddressModel> EmailAddresses { get; set; } = new List<EmailAddressModel>();

        public List<PhoneNumberModel> phoneNumbers { get; set; } = new List<PhoneNumberModel>();
    }
}
