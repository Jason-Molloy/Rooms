using System;
using System.Collections.Generic;
using Rooms.Project.Interfaces;
using Rooms.Project.Models;

namespace Rooms.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Running { get; set; }

    public void GetUserInput()
    {
      //ask player what to do - run appropriate function accordingly
      string input = Console.ReadLine().ToLower();
      string[] inputArr = input.Split(" ");
      string directive = inputArr[0];
      string selection = "";
      if (inputArr.Length > 1)
      {
        selection = inputArr[1];
      }
      //switch statement that runs appropriate below method
      switch (directive)
      {
        case "quit":
          Quit();
          break;
        case "look":
          Look();
          break;
        case "inventory":
          Inventory();
          break;
        case "help":
          Help();
          break;
        case "go":
          Go(selection);
          break;
        case "take":
          TakeItem(selection);
          break;
        case "use":
          UseItem(selection);
          break;
        default:
          Console.WriteLine("Not sure I understand... @/What would you like to do?");
          break;
      }
      throw new System.NotImplementedException();
    }

    public void Go(string direction)
    {//split 'go' from the indicated direction
     //check currentRoom for available exits, 
     //if an exit exists in the indicated direction
     //currentRoom = the room at that direction
      throw new System.NotImplementedException();
    }

    public void Help()
    {
      Console.WriteLine("Use GO with a direction to navigate the game.@/Use TAKE to add a usable item to your inventory.@/Use LOOK to get a description of your surroundings.@/Use INVENTORY to view your current inventory.@/Use USE to use an item from your inventory.@/Use QUIT to stop playing the game.");
    }

    public void Inventory()
    {
      System.Console.WriteLine(${ CurrentPlayer.Inventory});
    }

    public void Look()
    {
      Console.WriteLine($"{CurrentRoom.Name}: {CurrentRoom.Description}");
    }

    public void Quit()
    {
      Running = false;
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup()
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

      CurrentRoom = rooftop;
      Running = true;
    }

    public void StartGame()
    {
      Setup();
      while (Running)
      {
        Console.WriteLine("${CurrentLocation.Name}: {CurrentLocation.Description}");
      }
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (item != null)
      {
        CurrentPlayer.Inventory.Add(item);
        CurrentRoom.Items.Remove(item);
      }
      else
      {
        System.Console.WriteLine("That item may not be taken, here.");
      }
    }

    public void UseItem(string itemName)
    {
      Item item = CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (item != null)
      {
        CurrentPlayer.Inventory.Remove(item);
      }
      System.Console.WriteLine("That item may not be used, here.");
    }

  }
}