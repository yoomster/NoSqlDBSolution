namespace ApiDBUI.Models
{
    public partial class ContactModel
    {

            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<EmailAddressModel> EmailAddresses { get; set; }
            public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}
