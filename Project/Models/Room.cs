using System;
using System.Collections.Generic;
using Rooms.Project.Interfaces;

namespace Rooms.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public void AddExit(Direction direction, IRoom dest)
    {
      Exits.Add(direction, dest);
    }
    public IRoom UseExit(Direction dir)
    {
      if (Exits.ContainsKey(dir))
      {
        return Exits[dir];
      }
      Console.WriteLine("That's just not possible");
      return (IRoom)this;
    }
    public Room(string name, string desc)
    {
      Exits = new Dictionary<string, IRoom>();
      Items = new List<Item>();
      Name = name;
      Description = desc;
    }
  }
  public enum Direction
  {
    north,
    east,
    south,
    west
  }
}