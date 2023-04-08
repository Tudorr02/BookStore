using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcBookStore.Models;
using BookStore.Models;


public class Book1GenreViewModel
{
    public List<Book1>? Books { get; set; }
    public SelectList? Genres { get; set; }
    public string? BookGenre { get; set; }
    public string? SearchString { get; set; }
}