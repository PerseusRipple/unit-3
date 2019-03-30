using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WritersWorld.Models;



namespace writersworld.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthorsController : ControllerBase
  {
    private DatabaseContext db;
    public AuthorsController()
    {
      this.db = new DatabaseContext();
    }

    [HttpGet]

    public ActionResult<IList<Author>> GetAllAuthors()
    {
      //TODO: query the database
      // return the results
      // var db = new DatabaseContext();
      var results = db
             .Authors
             .Where(w => w.IsWinner)
             .OrderBy(o => o.Name)
             .Select(s => new Author
             {
               Name = s.Name,
               DateOfBirth = s.DateOfBirth,
               DateOfDeath = s.DateOfDeath,
               NumberOfBooks = s.NumberOfBooks,
               Id = s.Id
             })
             .ToList();
      return results;
    }
  }
}
