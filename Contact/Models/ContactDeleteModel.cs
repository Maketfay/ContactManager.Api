using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class ContactDeleteModel
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
