using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using writersworld;
using WritersWorld.Models;

namespace WritersWorld.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private DatabaseContext db;
    public BooksController()
    {
      this.db = new DatabaseContext();
    }

    [HttpGet]

    public ActionResult<IList<Book>> GetAllBooks()
    {
      //TODO: query the database
      // return the results
      // var db = new DatabaseContext();
      var results = db
             .Books
             .Where(w => w.IsInPrint)
             .OrderBy(o => o.Title)
             .Select(s => new Book
             {
               Genre = s.Genre,
               Title = s.Title,
               DateOfPublication = s.DateOfPublication,
               PublicationHouse = s.PublicationHouse,
               IsInPrint = s.IsInPrint,
               Id = s.Id
             })
             .ToList();
      return results;
    }
  }
}

