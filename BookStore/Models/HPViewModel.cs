using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models
{
    public class HPViewModel
    {
        public List<PH>? PHs { get; set; }
        public SelectList? Country { get; set; }
        public string? PHCountry { get; set; }
        public string? SearchString { get; set; }
    }
}
