using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookStore.Models;

public class LocationsViewModel
{
    public List<Locations>? Locations { get; set; }
    public SelectList? Countries { get; set; }
    public string? LocationCountry { get; set; }
    public string? SearchString { get; set; }
}