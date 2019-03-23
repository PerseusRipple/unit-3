using System;
using System.Linq;

namespace Safari_Adventure
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Let's see some animals!");

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

      //create (insert)
      //select
      //SELECT * FROM Animal WHERE LocationOfLastSeen = 'Jungle' OR LoLs = 'Desert'
      var sightedAnimals = db.SeenAnimals.Where(animals => animals.LocationOfLastSeen == "Jungle" || animals.LocationOfLastSeen == "Desert");

      foreach (var animals in sightedAnimals)
      {
        Console.WriteLine(animals.LocationOfLastSeen + ", " + animals.LocationOfLastSeen);
      }

      // update
      // find the item we want to update
      //if nothing found then return null
      var Gorilla = db.SeenAnimals.FirstOrDefault(animals => animals.Species == "Gorilla");
      // update it
      if (Gorilla != null)
      {
        Gorilla.CountOfTimesSeen = 31;
      }
      // save the changes 
      db.SaveChanges();
      //delete

    }
  }
}
