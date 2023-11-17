using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class ContactCreateModel
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

    }
}
