using DataAccesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private MongoDBDataAccess db;
        private readonly IConfiguration _config;
        private readonly string tableName = "Contacts";

        public ContactsController(IConfiguration config)
        {
            _config = config;
            db = new MongoDBDataAccess("MongoContactsDB", _config.GetConnectionString("Default"));
        }
    }
}
