using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using ApiDBUI.Models;
using System.Text;

namespace ApiDBUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGet()
        {
            await GetAllContacts();
        }

        private async Task CreateContact()
        {
            ContactModel contact = new ContactModel
            {
                FirstName = "Teddy",
                LastName = "Saurus-Rex"
            };
            contact.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "teddy@gmail.com" });
            contact.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "kitty@gmail.com" });
            contact.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612884703" });
            contact.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "0612345678" });

            var _client = _httpClientFactory.CreateClient();
            var response = await _client.PostAsync(
                "https://localhost:44387/api/contacts",
                new StringContent(JsonSerializer.Serialize(contact), Encoding.UTF8, "application/json"));
        }

        private async Task GetAllContacts()
        {
            var _client = _httpClientFactory.CreateClient();
            var response = await _client.GetAsync("https://localhost:44387/api/contacts");

            List<ContactModel> contacts;

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseText = await response.Content.ReadAsStringAsync();
                contacts = JsonSerializer.Deserialize<List<ContactModel>>(responseText, options);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
