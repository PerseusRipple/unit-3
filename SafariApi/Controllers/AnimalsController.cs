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

    [HttpGet]

    public ActionResult<IList<Animal>> GetAllAnimals()
    {
      //TODO: query the database
      // return the results
      var db = new DatabaseContext();
      var results = db.Animals.OrderBy(o => o.Species).ToList();
      return results;
    }
    //   return new List<Animal> { new Animal { Species = "Lion" }, new Animal { Species = "Tiger" }, new Animal { Species = "Bear" } };
    // }

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
  }
}



