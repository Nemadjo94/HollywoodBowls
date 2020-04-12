using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HollywoodBowlsAPI.Entities
{
    public class WasteFormModel
    {
        [MaxLength(50)]
        public string Company { get; set; } = null;
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone, MaxLength(15)]
        public string Phone { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string State { get; set; }
        [Required, MaxLength(10)]
        public string PostalCode { get; set; }
        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required]
        public string Phrase { get; set; }
        [Required]
        public string LocationType { get; set; }

        [Required, MaxLength(10)]
        public string PickupDate { get; set; }
        [Required, MaxLength(10)]
        public string PickupTime { get; set; }
        [MaxLength(1000)]
        public string Additional { get; set; }

        public List<Location> LocationsArray { get; set; }
    }
}


public class Location
{
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PickupDate { get; set; }
    public string PickupTime { get; set; }
    public string Phrase { get; set; }
    public string LocationType { get; set; }
    public string Additional { get; set; }

}