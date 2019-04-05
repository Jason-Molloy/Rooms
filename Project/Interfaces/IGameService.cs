using System.Collections.Generic;
using Rooms.Project.Models;

namespace Rooms.Project.Interfaces
{
  public interface IGameService
  {
    Room CurrentRoom { get; set; }
    Player CurrentPlayer { get; set; }

    //Initializes the game, creates rooms, their exits and add items to rooms
    void Setup();

    //restarts the game
    void Reset();

    //Setup and starts the Game Loop
    void StartGame();

    //Gets user input and calls the appropriate command
    void GetUserInput();

    #region Console Commands

    //stops the application
    void Quit();

    //should display a list of commands to the console
    void Help();

    //Validate CurrentRoom.Exits contains the desired direction
    //if it does, change the CurrentRoom
    void Go(string direction);

    //When taking an item be sure the item is in the current 
    //room before adding it to the player inventory. Also, don't
    //forget to remove the item from the room in which it was 
    //picked up
    void TakeItem(string itemName);

    //No Need to pass a room since Items can onlybe used in the
    //CurrentRoom. Make sure you validate the item is in the 
    //room or player investory before being able to use the item
    void UseItem(string itemName);

    //Print the list of items in the players inventory to console
    void Inventory();

    //Display the CurrentRoom Description, Exits, and Items
    void Look();

    #endregion
  }
}