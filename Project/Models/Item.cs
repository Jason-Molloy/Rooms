using System.Collections.Generic;
using Rooms.Project.Interfaces;

namespace Rooms.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }


    public Item(string name, string desc)
    {
      Name = name;
      Description = desc;
    }
  }
}