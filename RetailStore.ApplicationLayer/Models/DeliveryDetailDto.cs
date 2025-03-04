using System.Runtime.Serialization;

namespace RetailStore.ApplicationLayer.Models
{
    [DataContract]
    public class DeliveryDetailDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "deliveryStatus")]
        public DeliveryStatusDto? DeliveryStatus { get; set; }
    }
}
