using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailStore.DomainLayer.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; } = [];

        [JsonIgnore]
        public Payment? Payment { get; set; }

        [JsonIgnore]
        public Delivery? Delivery { get; set; }
    }
}
