using System.Runtime.Serialization;

namespace RetailStore.ApplicationLayer.Models
{
    [DataContract]
    public class CustomerDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullName")]
        public string? FullName { get; set; }

        [DataMember(Name = "mailAddress")]
        public string? MailAddress { get; set; }

        [DataMember(Name = "phoneNo")]
        public string? PhoneNo { get; set; }

        [DataMember(Name = "birthDate")]
        public DateTime BirthDate { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime DateCreated { get; set; }

        [DataMember(Name = "dateUpdated")]
        public DateTime DateUpdated { get; set; }

        [DataMember(Name = "orders")]
        public ICollection<OrderDto>? Orders { get; set; }
    }
}
