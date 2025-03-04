using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailStore.DomainLayer.Entities
{
    public class DeliveryStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Title { get; set; }

        [JsonIgnore]
        public ICollection<DeliveryDetail> DeliveryDetails { get; set; } = [];
    }
}
