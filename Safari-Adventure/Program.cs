using System;

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

      db.SeenAnimals.Add(Animal);
      db.SaveChanges();

      //create (insert)
      //select
      //update
      //delete


    }
  }
}
