using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailStore.DomainLayer.Entities
{
    public class DeliveryDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DeliveryId { get; set; }

        public int DeliveryStatusId { get; set; }

        public DateTime DateCreated { get; set; }

        public DeliveryStatus? DeliveryStatus { get; set; }

        [JsonIgnore]
        public Delivery? Delivery { get; set; }
    }
}
