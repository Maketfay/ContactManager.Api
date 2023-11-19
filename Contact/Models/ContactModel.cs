using Newtonsoft.Json;

namespace Contact.Models
{
    public class ContactModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
