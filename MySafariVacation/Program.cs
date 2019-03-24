using System;
using System.Linq;

namespace MySafariVacation
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Let's See Some Animals!");
      //CREATE (insert)
      //we need to create a new instance of our database context class
      var db = new MySafariVacationContext();

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

      //   db.Animals.Add(Animal);
      //   db.Animals.Add(Animal2);
      //   db.Animals.Add(Animal3);
      //   db.Animals.Add(Animal4);
      //   db.Animals.Add(Animal5);
      //   db.Animals.Add(Animal6);
      //   db.Animals.Add(Animal7);
      //   db.Animals.Add(Animal8);
      db.SaveChanges();

      //select
      //SELECT * FROM Animals all animals user has seen
      //SELECT * FROM Animals WHERE LoLs == "Jungle" or LoLs == "Desert"
      var sightedAnimals = db.Animals.Where(seenAnimals => seenAnimals.LocationOfLastSeen == "Jungle" || seenAnimals.LocationOfLastSeen == "Desert");

      foreach (var seenAnimals in sightedAnimals)
      {
        Console.WriteLine(seenAnimals.Species + " " + seenAnimals.LocationOfLastSeen);

      }

      // update
      // find the item we want to update
      //SELECT * FROM ANIMALS WHERE Species = 'Gorilla'
      //if nothing found then return null
      var gorilla = db.Animals.FirstOrDefault(seenAnimals => seenAnimals.Species == "Gorilla");
      // update it
      if (gorilla != null)
      {
        gorilla.CountOfTimesSeen = 31;
        gorilla.LocationOfLastSeen = "Desert";
      }
      // save the changes 
      db.SaveChanges();

      //SELECT * FROM Animals WHERE LoLs = "Jungle"
      var jungleAnimals = db.Animals.Where(seenAnimals => seenAnimals.LocationOfLastSeen == "Jungle");

      foreach (var seenAnimals in jungleAnimals)
      {
        Console.WriteLine(seenAnimals.Species + " " + seenAnimals.LocationOfLastSeen);
      }
      //delete
      //DELETE FROM ANIMALS WHERE LoLs = "Desert"
      //find the thing to delete
      var desertAnimals = db.Animals.FirstOrDefault(SeenAnimals => SeenAnimals.LocationOfLastSeen == "Desert");
      if (desertAnimals != null)
      {
        //delete it
        db.Animals.Remove(desertAnimals);
      }
      //save the changes
      db.SaveChanges();
    }

  }
}


