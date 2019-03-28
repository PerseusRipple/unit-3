using System.Collections.Generic;
using System;

namespace WritersWorld.Models
{
  public class Author
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public int NumberOfBooks { get; set; }
    public bool IsWinner { get; set; } = false;


    // navigation support
    public List<Book> Books { get; set; } = new List<Book>();


  }
}