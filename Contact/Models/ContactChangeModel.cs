using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class ContactChangeModel
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("phoneNumber")]
        public string phoneNumber { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [Required]
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
