using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SafariApi.Controllers.Models;

namespace safariapi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {

    [HttpGet]

    public ActionResult<IEnumerable<Animal>> GetAllAnimals()
    {
      //TODO: query the database
      // return the results
      return new List<Animal> { new Animal { Species = "Lion" }, new Animal { Species = "Tiger" }, new Animal { Species = "Bear" } };
    }

    [HttpGet("{id}")]

    public ActionResult<Animal> GetOneAnimal(int id)
    {

      return new Animal { Species = "Viper", Id = id };
    }

    [HttpPost]

    public ActionResult<Animal> CreateAnimal([FromBody] Animal animalToAdd)
    {
      return new Animal
      {
        Species = animalToAdd.Species
      };
    }
  }
}