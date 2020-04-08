using System.ComponentModel.DataAnnotations;

namespace HollywoodBowlsAPI.Entities
{
    public class RestroomFormModel
    {
        [MaxLength(50)]
        public string Company { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone, MaxLength(15)]
        public string Phone { get; set; }
        [Required]
        public int Trailers { get; set; }
        [Required, MaxLength(10)]
        public string DeliveryDate { get; set; }
        [Required, MaxLength(10)]
        public string DeliveryTime { get; set; }
        [Required, MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string State { get; set; }
        [Required, MaxLength(10)]
        public string PostalCode { get; set; }
        [Required, MaxLength(50)]
        public string Country { get; set; }
        [Required, MaxLength(10)]
        public string PickupDate { get; set; }
        [Required, MaxLength(10)]
        public string PickupTime { get; set; }
        [Required, MaxLength(200)]
        public string Contact { get; set; }
        [MaxLength(1000)]
        public string Additional { get; set; }
        


    }
}
