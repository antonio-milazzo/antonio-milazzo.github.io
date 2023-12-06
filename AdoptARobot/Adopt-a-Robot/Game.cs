/* Adopt A Robot
 * Example code for PROG 101
 * Originally created by Janell Baxter
 * Game class refactored by Antonio Milazzo
 * Fall 2023
 */

using System;
using System.Collections.Generic;
using static System.Console;

namespace Adopt_a_Robot
{
    class Game
    {
        Player player;
        string GameTitle = "Adopt a Robot!";

        public Game()
        {
            player = new Player();
        }
        public Game(string title)
        {
            GameTitle = title;
            player = new Player();
        }

        public void Start()
        {
            Title = GameTitle;

            WriteLine("Welcome to Adopt a Robot!");
            WriteLine("What is your name?");
            player.Name = Console.ReadLine();

            WriteLine("Glad to meet you " + player.Name);

            WriteLine($"You are adopting a robot.");

            WriteLine("What name would you like your robot to have?");
            player.PlayerRobot.Name = ReadLine();

            WriteLine($"What color would you like {player.PlayerRobot.Name} to be?");

            //created an array
            string[] robotcolors = new string[] { "blue" , "purple", "green", "brown", "black", "coral" };
            List<string> colorList = new List<string>() { "blue", "purple", "green", "brown", "black", "coral" };

            WriteLine("Here are your options:");

            //foreach loop to write out the items in the array
            foreach(var robotcolor in colorList) 
            { 
            Console.WriteLine("Color: " + robotcolor);
            }
            string choice = ReadLine();

            string player.PlayerRobot.Color = "";

            switch (choice)
            {
                case blue:
                    player.PlayerRobot.Color = "blue";
                case purple:
                    player.PlayerRobot.Color = "purple";
                case green:
                    player.PlayerRobot.Color = "green";
                case brown:
                    player.PlayerRobot.Color = "brown";
                case black:
                    player.PlayerRobot.Color = "black";
                case coral:
                    player.PlayerRobot.Color = "coral";
                default:
                    player.PlayerRobot.Color = "silver";
                    break;

            }

            WriteLine($"Congratulations {player.Name}! You have adopted a {player.PlayerRobot.Color} robot named {player.PlayerRobot.Name}. Press any key to exit.");
            ReadKey();

        }
    }
}