using System.Collections.Generic;

namespace WritersWorld.Models
{
  public class Book
  {
    public int Id { get; set; }
    public string Genre { get; set; }
    public string Title { get; set; }
    public string DateOfPublication { get; set; }
    public string PublicationHouse { get; set; }

    //Navigation 
    public List<Author> Authors { get; set; } = new List<Author>();




  }
}