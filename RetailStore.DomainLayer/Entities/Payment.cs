using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailStore.DomainLayer.Entities
{
    public class Payment
    {
        [Key, ForeignKey("Order")]
        public int OrderId { get; set; }

        public int PaymentMethodId { get; set; }

        public DateTime DateCreated { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }
    }
}
