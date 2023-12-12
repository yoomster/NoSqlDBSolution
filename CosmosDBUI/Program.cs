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

        static void Main(string[] args)
        {
            var  c = GetCosmosInfo();
            db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);

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

        private static void CreateContact()
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