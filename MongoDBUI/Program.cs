
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
                FirstName = "Naomi",
                LastName = "Perenboom"
            };
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "naomi@gmail.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "akil@gmail.com" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612884703" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0687654321" });

            ContactModel user2 = new ContactModel
            {
                FirstName = "Adam",
                LastName = "Akil"
            };
            user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "adam@gmail.com" });
            user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "akil@gmail.com" });
            user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612884703" });
            user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0687654321" });

            //CreateContact(user);

            //GetallContacts();

            //GetContactById("b8a2ac7d-0340-4d4d-805a-f6621fda7d16");

            // guid nayoomi: b8a2ac7d-0340-4d4d-805a-f6621fda7d16
            //guid naomi: 7f539ce8-51ad-40c6-844d-ccbfefd74fdf

            //UpdateFirstName("Adam", "7f539ce8-51ad-40c6-844d-ccbfefd74fdf");
            //GetallContacts();

            //RemovePhoneNumberFromUser("0687654321", "7f539ce8-51ad-40c6-844d-ccbfefd74fdf");

            //RemoveUser("fa7e0b65-2c0e-480d-8ab9-a315b8bb462d");

            Console.WriteLine("Done processing MongoDB");
            Console.ReadLine();
        }

        private static void RemoveUser(string id)
        {
            Guid guid = new Guid(id);
            db.DeleteRecord<ContactModel>(tableName, guid);
        }

        private static void RemovePhoneNumberFromUser(string phoneNumber, string id)
        {
            Guid guid = new Guid(id);
            var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

            db.UpsertRecord(tableName, contact.Id, contact);

        }

        private static void UpdateFirstName(string firstName, string id)
        {
            Guid guid = new Guid(id);
            var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            contact.FirstName = firstName;

            db.UpsertRecord(tableName, contact.Id, contact);
        }

        private static void GetContactById(string id)
        {
            Guid guid = new Guid(id);
            var contact = db.LoadRecordById<ContactModel>(tableName, guid);

            Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
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