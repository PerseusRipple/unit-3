using System;

namespace WritersWorld.Models
{
  public class Book
  {
    public int Id { get; set; }
    public string Genre { get; set; }
    public string Title { get; set; }
    public DateTime? DateOfPublication { get; set; } = null;
    public string PublicationHouse { get; set; }
    public bool IsInPrint { get; set; } = true;

    //Navigation support
    public int AuthorId { get; set; }
    public Author Author { get; set; }

  }
}