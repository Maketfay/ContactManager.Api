using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class PagedModel
    {
        [Required]
        [JsonProperty("page")]
        public int Page { get; set; } = 1;

        [Required]
        [JsonProperty("pageSize")]
        public int PageSize { get; set; } = 10;
    }
}
