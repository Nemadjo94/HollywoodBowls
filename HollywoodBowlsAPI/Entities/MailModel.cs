using System.ComponentModel.DataAnnotations;

namespace HollywoodBowlsAPI.Entities
{
    public class MailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string HtmlTemplate { get; set; }
    }
}
