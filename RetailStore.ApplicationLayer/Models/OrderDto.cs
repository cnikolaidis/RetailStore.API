using System.Runtime.Serialization;

namespace RetailStore.ApplicationLayer.Models
{
    [DataContract]
    public class OrderDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "customerId")]
        public int CustomerId { get; set; }

        [DataMember(Name = "totalAmount")]
        public decimal TotalAmount { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "payment")]
        public PaymentDto? Payment { get; set; }

        [DataMember(Name = "delivery")]
        public DeliveryDto? Delivery { get; set; }

        [DataMember(Name = "orderItems")]
        public ICollection<OrderItemDto> OrderItems { get; set; } = [];
    }
}
