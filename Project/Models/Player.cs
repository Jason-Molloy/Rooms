using System.Collections.Generic;
using Rooms.Project.Interfaces;

namespace Rooms.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    // bool Cookies;
    // bool Stockings;
    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }
  }
}