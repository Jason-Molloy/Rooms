using System;
using Rooms.Project;

namespace rooms
{
  class Program
  {
    static void Main(string[] args)
    {
      GameService gs = new GameService();
      gs.StartGame();
    }
  }
}
