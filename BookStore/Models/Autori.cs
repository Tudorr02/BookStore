using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Autori
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string? Nume { get; set; }


        [Display(Name = "Birth Day")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string? Country { get; set; }

        [Display(Name = "Written Books")]
        public string? WrittenBooks { get; set; }


        public string? Rating { get; set; }
    }
}
