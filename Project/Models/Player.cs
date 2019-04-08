using System.Collections.Generic;
using Rooms.Project.Interfaces;

namespace Rooms.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public bool Cookies = false;
    public bool Stockings = false;
    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }
  }
}