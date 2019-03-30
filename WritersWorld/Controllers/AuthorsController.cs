// using System;
using System.Collections.Generic;
using System.Linq;
// using System.Threading.Tasks;
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
               IsWinner = s.IsWinner,
               Id = s.Id
             })
             .ToList();
      return results;
    }
    //return authors
    [HttpGet("name/{name}")]

    public ActionResult<IList<Author>> GetOneAuthor(string name)
    {
      var author = db.Authors.Where(f => f.Name.Contains(name));
      return author.ToList();
    }
    //return author Date of Birth
    // [HttpGet("birth/{birth")]

    // public ActionResult<IEnumerable<Author>> GetAuthorBirthDate(DateTime birth)
    // {
    //   var author = db.Authors.Where(f=> f.DateOfBirth.Contains(birth));
    //   return author.ToList(); 
    // }

    //Add new Author 
    [HttpPost]

    public ActionResult<Author> CreateAuthor([FromBody] Author authorToAdd)
    {
      db.Authors.Add(authorToAdd);
      db.SaveChanges();
      return authorToAdd;
    }

    //PUT
    [HttpPut("{id}")]

    public ActionResult<Author> UpdateAuthor(int id, [FromBody] Author newAuthorData)
    {
      var author = db.Authors.FirstOrDefault(f => f.Id == id);
      author.Name = newAuthorData.Name;
      author.DateOfBirth = newAuthorData.DateOfBirth;
      author.DateOfDeath = newAuthorData.DateOfDeath;
      author.NumberOfBooks = newAuthorData.NumberOfBooks;
      author.IsWinner = newAuthorData.IsWinner;
      db.SaveChanges();
      return author;
    }

    //Delete
    [HttpDelete("{id}")]

    public ActionResult DeleteAuthor(int id)
    {
      //update boolean
      //soft delete
      var author = db.Authors.FirstOrDefault(f => f.Id == id);
      author.IsWinner = false;
      db.SaveChanges();
      return Ok();
    }

  }
}




