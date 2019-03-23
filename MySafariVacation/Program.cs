using System;

namespace MySafariVacation
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Let's See Some Animals!");
      //we need to create a new instance of our database context class
      var db = new SafariAdventureContext();

      var Animal = new SeenAnimals
      {
        Species = "Lion",
        CountOfTimesSeen = 33,
        LocationOfLastSeen = "Jungle",
      };
      var Animal2 = new SeenAnimals
      {
        Species = "Tiger",
        CountOfTimesSeen = 24,
        LocationOfLastSeen = "Jungle",
      };
      var Animal3 = new SeenAnimals
      {
        Species = "Bear",
        CountOfTimesSeen = 18,
        LocationOfLastSeen = "Jungle",
      };
      var Animal4 = new SeenAnimals
      {
        Species = "Gorilla",
        CountOfTimesSeen = 47,
        LocationOfLastSeen = "Jungle",
      };
      var Animal5 = new SeenAnimals
      {
        Species = "Addax",
        CountOfTimesSeen = 22,
        LocationOfLastSeen = "Desert",
      };
      var Animal6 = new SeenAnimals
      {
        Species = "Dung Beetle",
        CountOfTimesSeen = 12,
        LocationOfLastSeen = "Desert",
      };
      var Animal7 = new SeenAnimals
      {
        Species = "Tortoise",
        CountOfTimesSeen = 2,
        LocationOfLastSeen = "Desert",
      };
      var Animal8 = new SeenAnimals
      {
        Species = "Mongoose",
        CountOfTimesSeen = 8,
        LocationOfLastSeen = "Desert",
      };
      db.SeenAnimals.Add(Animal);
      db.SeenAnimals.Add(Animal2);
      db.SeenAnimals.Add(Animal3);
      db.SeenAnimals.Add(Animal4);
      db.SeenAnimals.Add(Animal5);
      db.SeenAnimals.Add(Animal6);
      db.SeenAnimals.Add(Animal7);
      db.SeenAnimals.Add(Animal8);
      db.SaveChanges();
    }
  }
}
