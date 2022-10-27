using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace PatoRestaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(400)]
        public string ProfilePicture { get; set; }
    }
}