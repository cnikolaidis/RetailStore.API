using System.Runtime.Serialization;

namespace RetailStore.ApplicationLayer.Models
{
    [DataContract]
    public class PaymentDto
    {
        [DataMember(Name = "orderId")]
        public int OrderId { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "paymentMethod")]
        public PaymentMethodDto? PaymentMethod { get; set; }
    }
}
