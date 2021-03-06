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

    public ActionResult<IList<AnimalViewModel>> GetAllAnimals()
    {
      //TODO: query the database
      // return the results
      // var db = new DatabaseContext();
      var results = db
             .Animals
             .Where(w => w.IsActive)
             .OrderBy(o => o.Species)
             .Select(s => new AnimalViewModel
             {
               Species = s.Species,
               CountOfTimesSeen = s.CountOfTimesSeen,
               LocationOfLastSeen = s.LocationOfLastSeen,
               Id = s.Id
             })
             .ToList();
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
    //return animal location
    [HttpGet("location/{location}")]

    public ActionResult<IList<Animal>> GetAnimalLocation(string location)
    {
      var db = new DatabaseContext();
      var animal = db.Animals.Where(f => f.LocationOfLastSeen.ToLower().Contains(location.ToLower()));
      return animal.ToList();
    }

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
    [HttpPut("{id}")]
    public ActionResult<Animal> UpdateAnimal(int id, [FromBody] Animal newAnimalData)
    {
      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      animal.Species = newAnimalData.Species;
      animal.CountOfTimesSeen = newAnimalData.CountOfTimesSeen;
      animal.LocationOfLastSeen = newAnimalData.LocationOfLastSeen;
      db.SaveChanges();
      return animal;
    }
    //PUT
    // PUT/Animal/{id} that adds 1 to the CoTs (given by id)
    [HttpPut("{id}/count")]
    public ActionResult<Animal> UpdateAnimalCount(int id)
    {
      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      animal.CountOfTimesSeen++;
      db.SaveChanges();
      return animal;

    }

    //DELETE
    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {

      //update that boolean
      //soft delete
      var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      animal.IsActive = false;
      db.SaveChanges();
      return Ok();

      //hard deletion 
      // var animal = db.Animals.FirstOrDefault(f => f.Id == id);
      // db.Animals.Remove(animal);
      // db.SaveChanges();
      // return Ok();
    }
    //GET SUM of ALL CoTs



  }
}



