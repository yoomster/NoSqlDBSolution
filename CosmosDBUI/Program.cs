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

            await CreateContact(user);
            await CreateContact(user2);

            Console.WriteLine("Done processing CosmosDB");
            Console.ReadLine();

        }

        private static void RemoveUser()
        {

        }

        private static void RemovePhoneNumberFromUser()
        {


        }

        private static void UpdateFirstName()
        {

        }

        private static void GetContactById()
        {

        }

        private static void GetallContacts()
        {

        }

        private static async Task CreateContact(ContactModel user)
        {
            await db.UpsertRecordAsync(user);
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