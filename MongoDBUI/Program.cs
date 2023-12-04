﻿
using DataAccesLibrary;
using DataAccesLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace MongoDBUI
{
    class Program
    {
        private static MongoDBDataAccess db;
        private static readonly string tableName = "Contacts";


        static void Main(string[] args)
        {
            db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());

            ContactModel user = new ContactModel
            {
                FirstName = "Adam",
                LastName = "Akil"
            };
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "adam@gmail.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "akil@gmail.com" });

            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612884703" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0687654321" });

            //CreateContact(user);

            //GetallContacts();


            Console.WriteLine("Done processing MongoDB");
            Console.ReadLine();
        }

        private static void GetallContacts()
        {
            var contacts = db.LoadRecords<ContactModel>(tableName);

            foreach(var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
            }
        }
        private static void CreateContact(ContactModel contact)
        {
            db.UpsertRecord(tableName, contact.Id, contact);
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}