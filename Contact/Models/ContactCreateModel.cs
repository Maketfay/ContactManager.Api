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
        [RegularExpression(@"^\+?\d{10}$")]
        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [EmailAddress]
        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("jobTitle")]
        public string? JobTitle { get; set; }

        [JsonProperty("birthDate")]
        public DateTime? BirthDate { get; set; }

    }
}
