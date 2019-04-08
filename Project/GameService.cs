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
    public bool DisplayMessage = false;
    public void StartGame()//should be complete
    {
      Console.Clear();
      Setup();
      while (Running == true)
      {
        System.Console.WriteLine("\nPress any button to continue");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine($"{CurrentRoom.Name}: {CurrentRoom.Description}");
        Console.WriteLine("What would you like to do?\nType 'help' for assistance");
        GetUserInput();
      }
    }

    public void Setup()//should be complete
    {
      //create all rooms
      Room rooftop = new Room("Rooftop", "You are standing on a large Snowy rooftop with no recollection of how you got here. It's slippery. \nTo the SOUTH is a wide brick chimney. \nTo the EAST and WEST are the sloped eaves of the roof. \nTo the NORTH is cold, thin air, about 23 feet above ground level.");
      Room livingRoom = new Room("Living Room", "You are in a living room. \nYou realize that, though it's dark, you can see by the light of a string of electric lights, \nloosely wrapped around a tree in the corner of the nicely decorated room. \nThere are some stockings hung by the chimney with care (actually on the mantle). \nBesides the festive decorations and tree, are some wrapped packages under the tree, \nand a large red sack (could you have dropped it on your way down?) filled with some GOODIES. \nAlong the NORTH wall is a fireplace. \nThere is a bit of light coming from under a door to the EAST \nand a dark, foreboding and open hallway to the SOUTH.");
      Room kitchen = new Room("Kitchen", "Opening the door, you can see you are in a kitchen, but only by a small light above the stove. \nIt looks like a normal kitchen for a normal family. Other than the usual kitchen apparati, there is a note on the table, \nalong with two plates and a glass of opaque, white liquid (milk, if you had to guess, cream if you're lucky. \nBut not too much - pants are getting tight). \nOn one of the plates is a giant, delicious looking SANDWICH - this thing would make Dagwood Bumstead blush \n- wrapped in paper. \nThe other, nearer the milk, is filled with an array of homemade sugar COOKIES - decorated by a child's hands. \nAlso written in a child's hand is a note: \n'Deer Santa, Hop yer having a nic crismas. plees leev some good presents for Randy (no costooms). \nI just want a Red Ryder BB gun. sory for being bad and not speling wurds rite. \nLove, Ralphie and Randy.' \nThere is a door to the EAST that appears to lead out of the house. \nThere is also a door to the NORTH. \nThe only other exit is to the WEST.");
      Room hallway = new Room("Hallway", "As you make your way down the dark hallway the light from the living room quickly fades. \nIn the dark, you trip and fall. Someone opens an adjacent door and a small figure can be seen in sillouette. \nBefore you can realize it she says your name in great surprise and begins crying (Why? She's just a kid and you scared her). \nLooking down, you realize, suddenly, you are Santa Claus! \nYou have been discovered and ruined Christmas. Up til now you've had a perfect track record. Nice job. \nGAME OVER");
      Room outside = new Room("Outside", "The door is locked, but from the inside. \nYou unlock the door and step out into someone's (the homeowner's) backyard. \nAs you do you alarm the family dog who begins persistently barking. \nAs you are trying to shush the dog, you realize that several neighbors have woken and rushed out with superhuman speed. \nThey are now taking pictures of you, Santa Claus, that will inevitably wind up on the front page of a couple dozen publications, tomorrow. \nYou have been discovered and ruined Christmas. Up til now you've had a perfect track record. Nice job. \nGAME OVER");
      Room roofSide = new Room("Roof Side", "As you begin to explore the totally vacant roof (Why?), you loose your footing and begin sliding toward the edge. \nUnable to stop yourself, you tangle in the lights hung from the roof and inadvertently suspend yourself, \ncompletely stuck, 9 inches from the ground. \nThere is no way to deliver presents this year and you've ruined Christmas, Santa Claus. \nUp til now you've had a perfect track record. Nice job. \nGAME OVER");
      Room thinAir = new Room("Thin Air", "Really? Did you think you could fly without your sleigh? \nYou fall approximately 23 feet and land hard on your back. \nYou are definitely not getting up soon and hope someone can call for an ambulance. \nYou must be too old for this stuff. \nThere is no way to deliver presents this year and you've ruined Christmas, Santa Claus. \nUp til now you've had a perfect track record. Nice job. \nGAME OVER");

      //items
      Item goodies = new Item("Goodies", "Having an intuition that the oversized socks belong to deserving children, \nyou fish a few goodies from the sack and fill those stockings that are hung (with such care) by the chimney.");
      Item cookie = new Item("Cookies", "The cookies are irresistible. \nYou take one and are surprised by the refinement of flavor coming from a morsel baked by so young an artisan \n(make sure this child gets some goodies). \nYou help yourself to the milk (yes, it's milk - who pours a glass of cream anymore, anyway? Such wishful thinking..) \nand are thoroughly satisfied.");
      Item sandwich = new Item("Sandwich", "As you begin to wrap your hands around the giant sandwich and draw it to your salivating mouth, \na crazed man bursts in from the living room (the slight rustling of the paper must have woken him) \nshouting, 'Who's eating my Christmas sandwich!?!?!' \nrealizing who you are, he stops cold and his mouth drops wide open. \nYou've been discovered, Santa Claus. Christmas is ruined, Nice job. \nGAME OVER!!!");
      Item whistle = new Item("Whistle", "On the roof, again, with a full belly and your work here complete, \nyou blow the whistle and almost at once your sleigh and reindeer are here to carry you to your next stop. \nYou ride off into the night shouting 'Ho, Ho, Ho' and 'Merry Christmas to all' and other such jolly things. \nChristmas can continue... You WIN!!!");

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

      CurrentPlayer = new Player("Santa");
      CurrentRoom = rooftop;
      Running = true;

    }

    public void GetUserInput()//should be complete
    {
      //ask player what to do - run appropriate function accordingly
      string[] inputArr = Console.ReadLine().ToLower().Split(" ");
      string directive = inputArr[0];
      string selection = "";
      if (inputArr.Length > 1)
      {
        selection = inputArr[1];
      }
      // if(directive == "go")
      // {
      //   selection = Direction
      // }
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
        case "reset":
          Reset();
          break;
        case "go":
          Go(selection);
          break;
        case "take":
          TakeItem(selection);
          break;
        case "get":
          TakeItem(selection);
          break;
        case "use":
          UseItem(selection);
          break;
        case "eat":
          UseItem(selection);
          break;
        default:
          Console.WriteLine("Not sure I understand... @/What would you like to do?");
          break;
      }
    }

    public void Quit()//should be complete
    {
      Running = false;
    }

    public void Look()//should be complete
    {
      Console.WriteLine($"Right now, you are in the {CurrentRoom.Name}: {CurrentRoom.Description}");
      Console.WriteLine("What would you like to do?");
    }

    public void Inventory()//should be complete
    {
      System.Console.WriteLine("Currently, you have: ");
      CurrentPlayer.Inventory.ForEach(i =>
      {
        System.Console.WriteLine($"{i.Name}");
      });
    }

    public void Help()//should be complete
    {
      Console.WriteLine("After any action, the console will ask you to hit enter, again, \nallowing you to read (suffer) the consequeses of your actions.\nUse GO with a direction to navigate the game.\nUse TAKE to add a usable item to your inventory.\nUse LOOK to get a description of your surroundings.\nUse INVENTORY to view your current inventory.\nUse USE to use an item from your inventory.\nUse RESET to start over.\nUse QUIT to stop playing the game.");
    }

    public void Reset()//should be complete
    {
      Running = false;
      Setup();
    }
    public void Go(string selection)//incomplete
    {//check currentRoom for available exits, 
     //if an exit exists in the indicated direction
     //currentRoom = the room at that direction
      if (!Enum.TryParse(selection, out Direction direction))
      {
        System.Console.WriteLine("Please try again..");
        return;
      }
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = (Room)CurrentRoom.Exits[direction];
      }
      if (CurrentRoom.Name == "Roof Side" || CurrentRoom.Name == "Hallway" || CurrentRoom.Name == "Outside" || CurrentRoom.Name == "Thin Air")
      {
        System.Console.WriteLine($"{CurrentRoom.Description}");
        EndGame();
      }

    }

    public void TakeItem(string itemName)//should be complete
    {
      Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (itemName.ToLower() == "sandwich")
      {
        System.Console.WriteLine($"{item.Description}");
        EndGame();
      }
      else if (item != null)
      {
        Console.WriteLine("The item has been added to your inventory");
        CurrentPlayer.Inventory.Add(item);
        CurrentRoom.Items.Remove(item);
      }
      else
      {
        Console.WriteLine("That item may not be taken, here.");
      }
    }

    public void UseItem(string itemName)//should be complete
    {
      Item item = CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (item != null)
      {
        if (itemName == "goodies" && CurrentRoom.Name.ToString() == "Living Room")
        {
          Console.WriteLine($"{item.Description}");
          CurrentPlayer.Stockings = true;
        }
        else if (itemName == "cookies" && CurrentRoom.Name.ToString() == "Kitchen")
        {
          Console.WriteLine($"{item.Description}");
          CurrentPlayer.Cookies = true;
        }
        else if (itemName == "whistle" && CurrentRoom.Name.ToString() == "Rooftop")
        {
          Console.WriteLine($"{item.Description}");
          Quit();
        }
        CurrentPlayer.Inventory.Remove(item);
      }
      else
      {
        System.Console.WriteLine("That item may not be used, here.");
      }
      if (CurrentPlayer.Cookies && CurrentPlayer.Stockings && !DisplayMessage)
      {
        DisplayMessage = true;
        CurrentPlayer.Inventory.Add(new Item("Whistle", "On the roof, again, with a full belly and your work here complete, \nyou blow the whistle and almost at once your sleigh and reindeer are here to carry you to your next stop. \nYou ride off into the night shouting 'Ho, Ho, Ho' and 'Merry Christmas to all' and other such jolly things. \nChristmas can continue... You WIN!!!"));
        System.Console.WriteLine("Your full belly and good deeds remind you of a magic whistle in your back pocket. You may want to check your inventory...");
      }
    }

    public void EndGame()//should be complete
    {
      Console.WriteLine("Press return to continue.");
      Console.ReadLine();
      Running = false;
    }
  }
}