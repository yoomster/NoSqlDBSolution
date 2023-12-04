
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
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "perenboom@gmail.com" });

            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612884703" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612345678" });

            CreateContact(user);


            Console.WriteLine("Done processing MongoDB");
            Console.ReadLine();
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