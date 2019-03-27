using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace SafariApi.Controllers.Models
{
  public class Animal
  {

    public int Id { get; set; }

    public string Species { get; set; }

    public int CountOfTimesSeen { get; set; }

    public string LocationOfLastSeen { get; set; }

    public bool IsActive { get; set; } = true;
  }
}
