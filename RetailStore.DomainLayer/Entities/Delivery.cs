using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailStore.DomainLayer.Entities
{
    public class Delivery
    {
        [Key, ForeignKey("Order")]
        public int OrderId { get; set; }

        public string TrackingNumber { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public ICollection<DeliveryDetail> DeliveryDetails { get; set; } = [];
    }
}
