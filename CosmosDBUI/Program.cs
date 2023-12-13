using DataAccesLibrary;
using DataAccesLibrary.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.IO;


namespace CosmosDBUI
{
    class Program
    {
        private static CosmosDBDataAccess db;

        static async Task Main(string[] args)
        {
            var  c = GetCosmosInfo();
            db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);


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

            //await CreateContact(user);
            //await CreateContact(user2);

            //await GetAllContacts();

            //NP:f96d7cdd-15e9-43ca-ba9c-78dd0c6092c8
            //AK:2a25c494-bbec-4350-99e6-8455a7d86c67

            //await GetContactById("2a25c494-bbec-4350-99e6-8455a7d86c67");

            //await UpdateFirstName("f96d7cdd-15e9-43ca-ba9c-78dd0c6092c8", "Noom");
            //await GetContactById("f96d7cdd-15e9-43ca-ba9c-78dd0c6092c8");

            //await RemovePhoneNumberFromUser("2a25c494-bbec-4350-99e6-8455a7d86c67", "0612884703");

            await RemoveUser("2a25c494-bbec-4350-99e6-8455a7d86c67", "Akil");

            Console.WriteLine("Done processing CosmosDB");
            Console.ReadLine();

        }

        private static async Task RemoveUser(string id, string lastName)
        {
            await db.DeleteRecordAsync<ContactModel>(id, lastName);
        }

        private static async Task RemovePhoneNumberFromUser(string id, string phoneNumber)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

            await db.UpsertRecordAsync(contact);

        }

        private static async Task UpdateFirstName(string id, string firstName)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            contact.FirstName = firstName;

            await db.UpsertRecordAsync(contact);
        }

        private static async Task GetContactById(string id)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
        }

        private static async Task GetAllContacts()
        {
            var contacts = await db.LoadRecordsAsync<ContactModel>();

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
            }
        }

        private static async Task CreateContact(ContactModel contact)
        {
            await db.UpsertRecordAsync(contact);
        }

        private static (string endpointUrl, string primaryKey, string databaseName, string containerName) GetCosmosInfo()
        {
            (string endpointUrl, string primaryKey, string databaseName, string containerName) output;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            
            output.endpointUrl = config.GetValue<string>("CosmosDB:EndpointUrl");
            output.primaryKey = config.GetValue<string>("CosmosDB:PrimaryKey");
            output.databaseName  = config.GetValue<string>("CosmosDB:DatabaseName");
            output.containerName = config.GetValue<string>("CosmosDB:ContainerName");

            return output;
        }
    }
}