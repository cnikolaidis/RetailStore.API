using System.Runtime.Serialization;

namespace RetailStore.ApplicationLayer.Models
{
    [DataContract]
    public class ProductDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string? Title { get; set; }

        [DataMember(Name = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "stock")]
        public int Stock { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime? DateCreated { get; set; }

        [DataMember(Name = "dateUpdated")]
        public DateTime? DateUpdated { get; set; }
    }
}
