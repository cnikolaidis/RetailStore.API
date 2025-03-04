using System.Runtime.Serialization;

namespace RetailStore.ApplicationLayer.Models
{
    [DataContract]
    public class DeliveryDto
    {
        [DataMember(Name = "orderId")]
        public int OrderId { get; set; }

        [DataMember(Name = "trackingNumber")]
        public string TrackingNumber { get; set; } = string.Empty;

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "deliveryDetails")]
        public ICollection<DeliveryDetailDto>? DeliveryDetails { get; set; }
    }
}
