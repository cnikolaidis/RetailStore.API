using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailStore.DomainLayer.Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; } = 0;

        public decimal SubTotal { get; set; } = 0.0m;

        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
