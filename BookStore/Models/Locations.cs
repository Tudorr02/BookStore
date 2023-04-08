using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Locations
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string? Country { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string? City { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string? Adress { get; set; }

        public string? Opens { get; set; }
        public string? Closes { get; set;}

    }
}
