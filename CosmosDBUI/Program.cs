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
        private static readonly string tableName = "Contacts";

        static void Main(string[] args)
        {
            var  c = GetCosmosInfo();
            db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);

            Console.WriteLine("Done processing CosmosDB");
            Console.ReadLine();
        }

        private static void RemoveUser(string id)
        {

        }

        private static void RemovePhoneNumberFromUser(string phoneNumber, string id)
        {


        }

        private static void UpdateFirstName(string firstName, string id)
        {

        }

        private static void GetContactById(string id)
        {

        }

        private static void GetallContacts()
        {

        }

        private static void CreateContact(ContactModel contact)
        {
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