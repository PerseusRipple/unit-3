using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SafariApi.Controllers.Models;

using System.Linq;

namespace safariapi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private DatabaseContext db;

    public AnimalsController()
    {
      this.db = new DatabaseContext();
    }

    [HttpGet]

    public ActionResult<IList<Animal>> GetAllAnimals()
    {
      //TODO: query the database
      // return the results
      var db = new DatabaseContext();
      var results = db.Animals.OrderBy(o => o.Species).ToList();
      return results;
    }
    //return lions
    [HttpGet("species/{species}")]
    public ActionResult<IList<Animal>> GetOneAnimal(string species)
    {
      var db = new DatabaseContext();
      var animal = db.Animals.Where(f => f.Species.Contains(species));
      return animal.ToList();
    }
    // //return jungle animals
    // [HttpGet("locationOfLastSeen/{jungle}")]

    // public ActionResult<IList<Animal>> GetJungleAnimal(string locationOfLastSeen)
    // {
    //   var db = new DatabaseContext();
    //   var animal = db.Animals.Where(f=> f.LocationOfLastSeen.Contains(locationOfLastSeen));
    // }


    //   return new List<Animal> { new Animal { Species = "Lion" }, new Animal { Species = "Tiger" }, new Animal { Species = "Bear" } };
    //  }

    [HttpGet("{id}")]

    public ActionResult<Animal> GetOneAnimal(int id)
    {
      //go to the database
      var db = new DatabaseContext();
      //query the database for the animal with the id of id
      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      //return that animal
      return animal;
    }

    // return new Animal { Species = "Viper", Id = id };


    [HttpPost]
    public ActionResult<Animal> CreateAnimal([FromBody] Animal animalToAdd)
    {

      var db = new DatabaseContext();
      db.Animals.Add(animalToAdd);
      db.SaveChanges();
      return animalToAdd;
    }

    //PUT
    [HttpPut("{id")]
    public ActionResult<Animal> UpdateAnimal(int id, [FromBody] Animal newAnimalData)
    {
      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      animal.Species = newAnimalData.Species;
      animal.CountOfTimesSeen = newAnimalData.CountOfTimesSeen;
      animal.LocationOfLastSeen = newAnimalData.LocationOfLastSeen;
      db.SaveChanges();
      return animal;
    }
    //DELETE

  }
}



