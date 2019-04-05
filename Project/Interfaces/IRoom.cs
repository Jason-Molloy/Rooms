using System.Collections.Generic;
using Rooms.Project.Models;

namespace Rooms.Project.Interfaces
{
  public interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    List<Item> Items { get; set; }
    Dictionary<Direction, IRoom> Exits { get; set; }
  }
}