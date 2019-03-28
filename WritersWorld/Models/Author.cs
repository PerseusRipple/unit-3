using System;

namespace WritersWorld.Models
{
  public class Author
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string DateOfDeath { get; set; }
    public int NumberOfBooks { get; set; }
    public bool IsWinner { get; set; } = false;


    // navigation support
    public int BookId { get; set; }
    public Book Book { get; set; }

  }
}