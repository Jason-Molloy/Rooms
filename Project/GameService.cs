using System.Collections.Generic;
using Rooms.Project.Interfaces;
using Rooms.Project.Models;

namespace Rooms.Project
{
  public class GameService : IGameService
  {
    Room IGameService.CurrentRoom { get; set; }
    Player IGameService.CurrentPlayer { get; set; }

    public void GetUserInput()
    {
      throw new System.NotImplementedException();
    }

    public void Go(string direction)
    {
      throw new System.NotImplementedException();
    }

    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void setup()
    {
      //create all rooms
      Room rooftop = new Room("Rooftop", "You are standing on a large Snowy rooftop with no recollection of how you got here. It's slippery. To the SOUTH is a wide brick chimney. To the EAST and WEST are the sloped eaves of the roof. To the NORTH is cold, thin air, about 23 feet above ground level.");
      Room livingRoom = new Room("Living Room", "You are in a living room. You realize that, though it's dark, you can see by the light of a string of electric lights, hung on a tree in the corner of the nicely decorated room. Besides the festive decorations and tree, are some wrapped packages under the tree, and along the NORTH wall is a fireplace. There are, of course, some stockings hung by the chimney with care (actually on the mantle). There is a bit of light coming from under a door to the EAST and a dark, foreboding and open hallway to the SOUTH.");
      Room kitchen = new Room("Kitchen", "Opening the door, you can see you are in a kitchen, but only by a small light above the stove. It looks like a normal kitchen for a normal family. Other than the usual kitchen apparati, there is a note on the table, along with two plates and a glass of opaque, white liquid (milk, if you had to guess, cream if you're lucky. But not too much - pants are getting tight). On one of the plates is a delicious looking sandwich - this thing would make Dagwood blush. The other, nearer the milk, is filled with an array of homemade sugar cookies - decorated by a child's hands. There is a door to the EAST that appears to lead out of the house. There is also a door to the NORTH. The only other exit is to the WEST.");
      Room hallway = new Room("Hallway", "As you make your way down the dark hallway the light from the living room quickly fades. In the dark, you trip and fall. Someone opens an adjacent door and a small figure can be seen in sillouette. Before you can realize it she says your name in great surprise and begins crying (Why? She's just a kid and you scared her). Looking down, you realize, suddenly, you are Santa Claus! You have been discovered and ruined Christmas. Up til now you've had a perfect track record. Nice job. GAME OVER");
      Room outside = new Room("Outside", "The door is locked, but from the inside. You unlock the door and step out into someone's (the homeowner's) backyard. As you do you alarm the family dog who begins persistently barking. As you are trying to shush the dog, you realize that several neighbors have woken and rushed out with superhuman speed. They are now taking pictures of you, Santa Claus, that will inevitably wind up on the front page of a couple dozen publications, tomorrow. You have been discovered and ruined Christmas. Up til now you've had a perfect track record. Nice job. GAME OVER");
      Room roofSide = new Room("Roof Side", "As you begin to explore the totally vacant roof (Why?), you loose your footing and begin sliding toward the edge. Unable to stop yourself, you tangle in the lights hung from teh roof and inadvertently suspend yourself, completely stuck, 9 inches from the ground. There is no way to deliver presents this year and you've ruined Christmas, Santa Claus. Up til now you've had a perfect track record. Nice job. GAME OVER");
      Room thinAir = new Room("Thin Air", "Really? Did you think you could fly without your sleigh? You fall approximately 23 feet and land hard on your back. You are definitely not getting up soon and hope someone can call for an ambulance. You must be too old for this stuff. There is no way to deliver presents this year and you've ruined Christmas, Santa Claus. Up til now you've had a perfect track record. Nice job. GAME OVER");

      //items
      Item goodies = new Item("Goodies", "A bunch of tiny toys and sweets that would be sure to brighten a child's day.");
      Item cookie = new Item("Cookie", "An array of homemade sugar cookies - decorated by a child's hands.");
      Item sandwich = new Item("Sandwich", "A very tasty looking sandwich - this thing would make Dagwood blush. A high stack of meats, cheeses, sandwich fixins and other unidentifiable forms of deliciousness.");
      Item sleigh = new Item("Sleigh", "A somewhat archaic vehicle for travelling over snow. Usually pulled by horse(s), eight reindeer are hitched to the front of this sleigh.");
      //room relationships
      rooftop.AddExit(Direction.south, livingRoom);
      rooftop.AddExit(Direction.north, thinAir);
      rooftop.AddExit(Direction.east, roofSide);
      rooftop.AddExit(Direction.west, roofSide);
      livingRoom.AddExit(Direction.north, rooftop);
      livingRoom.AddExit(Direction.south, hallway);
      livingRoom.AddExit(Direction.east, kitchen);
      kitchen.AddExit(Direction.west, livingRoom);
      kitchen.AddExit(Direction.east, outside);
      //items to rooms
      livingRoom.AddItem(goodies);
      kitchen.AddItem(cookie);
      kitchen.AddItem(sandwich);

    }

    public void StartGame()
    {
      throw new System.NotImplementedException();
    }

    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    private void initialize()
    {

    }
  }
}