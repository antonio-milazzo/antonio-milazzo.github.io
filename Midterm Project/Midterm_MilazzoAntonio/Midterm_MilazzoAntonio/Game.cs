using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Console;

namespace Midterm_MilazzoAntonio
{

    internal class Game
    {
        
        private string GameTitle = "The Lost Key to the Kingdom";
        public List<Item> generalitemList = new List<Item>();
        public List<Item> playerInventory = new List<Item>();
        Item gem = new Item("Gem", "A shiny object, valued by some but treasured by one");
        Item sword = new Item("Rusty Sword", "Not much use for it now, but maybe someone can fix it");
        Item map = new Item("Map", "Look and see what it says, maybe it will help us find the key");
        Item armor = new Item("Armor", "There hasn't been a battle here in decades, maybe someone else may appreciate it");
        Item shield = new Item("Decorative Shield", "Hmmmm no one would actually use this, it's more of an art piece");
        Item medallion = new Item("Historic Medallion", "Wow this is very old, I wonder when it's from");
        Item key = new Item("Key", "The item you've been looking for during this adventure");

        public List<NPC> characterselection = new List<NPC>();
        NPC Blacksmith = new NPC("Blacksmith", "A man who creates weapons");
        NPC FortuneTeller = new NPC("Fortune Teller", "A woman who sees your future");
        NPC Historian = new NPC("Historian", "A woman who loves to study object from the olden days");
        NPC Collector = new NPC("Collector", "A person who admires the fine arts");
        NPC Librarian = new NPC("Librarian", "A caretaker of object new and old");
        private Player CurrentPlayer;

        public List<Option> playerOptions = new List<Option>();
        Option FirstOption = new Option("I'm looking to trade this item!");
        Option SecondOption = new Option("Just stopping by to say hi, I'll be on my way");
        Option ThirdOption = new Option("Tell me something about yourself");
        Option FourthOption = new Option("Back to menu");

        public List <Location> locationselection = new List<Location>();
        Location forest = new Location("Forest", "A vast area with many tress, bushes and stones");
        Location cave = new Location("Cave", "A dark scary place with tons of hiding spots");
        Location creek = new Location("Creek", "A small body of water with many fish and other lving creatures");

        Gimili gimili = new Gimili("Gimili", "Your helpful friend on this adventure");

      
        public List <Location> hasvisited = new List<Location>();

        public List <NPC> hastraded = new List<NPC>();
        public Game()
        {
            playerOptions.Add(FirstOption);
            playerOptions.Add(SecondOption);
            playerOptions.Add(ThirdOption);
            playerOptions.Add(FourthOption);
            characterselection.Add(Blacksmith);
            characterselection.Add(FortuneTeller);
            characterselection.Add(Historian);
            characterselection.Add(Collector);
            characterselection.Add(Librarian);
            generalitemList.Add(gem);
            generalitemList.Add(sword);
            generalitemList.Add(map);
            generalitemList.Add(armor);
            generalitemList.Add(shield);
            generalitemList.Add(medallion);
            locationselection.Add(forest);
            locationselection.Add(cave);
            locationselection.Add(creek);

            
        }

        public void PressanyKey()
        {
            WriteLine("*Press any key to continue*");
        }

        public void Sleep()
        {
            Thread.Sleep(1500);
        }

        public void Start()
        {
           
            //title art from https://patorjk.com/software/taag/#p=testall&f=Graffiti&t=The%20%0ALost%20Key%20%0Ato%20the%20%0AKingdom
            WriteLine("\r\n _____ _                                   \r\n|_   _| |                                  \r\n  | | | |__   ___                          \r\n  | | | '_ \\ / _ \\                         \r\n  | | | | | |  __/                         \r\n  \\_/ |_| |_|\\___|                         \r\n                                           \r\n                                           \r\n _               _     _   __              \r\n| |             | |   | | / /              \r\n| |     ___  ___| |_  | |/ /  ___ _   _    \r\n| |    / _ \\/ __| __| |    \\ / _ \\ | | |   \r\n| |___| (_) \\__ \\ |_  | |\\  \\  __/ |_| |   \r\n\\_____/\\___/|___/\\__| \\_| \\_/\\___|\\__, |   \r\n                                   __/ |   \r\n                                  |___/    \r\n _          _   _                          \r\n| |        | | | |                         \r\n| |_ ___   | |_| |__   ___                 \r\n| __/ _ \\  | __| '_ \\ / _ \\                \r\n| || (_) | | |_| | | |  __/                \r\n \\__\\___/   \\__|_| |_|\\___|                \r\n                                           \r\n                                           \r\n _   ___                 _                 \r\n| | / (_)               | |                \r\n| |/ / _ _ __   __ _  __| | ___  _ __ ___  \r\n|    \\| | '_ \\ / _` |/ _` |/ _ \\| '_ ` _ \\ \r\n| |\\  \\ | | | | (_| | (_| | (_) | | | | | |\r\n\\_| \\_/_|_| |_|\\__, |\\__,_|\\___/|_| |_| |_|\r\n                __/ |                      \r\n               |___/                       \r\n");
            WriteLine($"Welcome to {GameTitle}, press any key to continue");
            ReadKey();
            Clear();
            WriteLine("Welcome traveler! What is your name?");
            string name = ReadLine().Trim();
            CurrentPlayer = new Player(name);
            WriteLine($"It's wonderful to meet you {name}! Our adventure together begins now!");
            Sleep();
            Clear();
            Overview();
        }

        public void Overview()
        {
            Console.WriteLine($"Hello {CurrentPlayer.playerName}!");
            gimili.Greet();
            OverviewRecursion();
        }
        public void GeneralList()
        {
            
            foreach (var Item in generalitemList)
            {
               WriteLine($"{Item.ItemName}: {Item.ItemDescription}");
            }
        }
        public void OverviewRecursion()
        {
           WriteLine("~Please type '1' for yes or '2' for no~");
            string input =ReadLine();
        
            switch (input)
            {
                case "1":
                    Clear();
                    WriteLine("Great! You'll be trading and interacting with people, looking for items, and in the end, hopefully finding the lost key");
                    WriteLine("Here's everything you're going to be looking for in this quest:");
                    ReadKey();
                    Clear();
                   GeneralList();
                    ReadKey();
                   WriteLine($"Currently, {CurrentPlayer.playerName} has {CurrentPlayer.ItemsCollected} items");
                   WriteLine("Once you're ready, press any key to continue and start our adventure!");
                   ReadKey();
                    Clear();
                    Level1();
                    break;
                case "2":
                   WriteLine("Wow, it looks like you know what you're doing, let's get started!");
                    ReadKey();
                    Level1();
                    break;
                default:
                   WriteLine("Please enter a valid option; either 1 for yes or 2 for no");
                   OverviewRecursion();
                    break;
            }
        }

        public void Level1()
        {
            Clear();
            playerInventory.Add(gem);
           WriteLine("Gimili: 'I'm going to give you this item to start out with, trade with villagers to try and find the key");
            PressanyKey();
           ReadKey();
            //ascii art from https://www.asciiart.eu/miscellaneous/diamonds
            WriteLine(" .     '     ,\r\n    _________\r\n _ /_|_____|_\\ _\r\n   '. \\   / .'\r\n     '.\\ /.'\r\n       '.'");
           WriteLine($"You recieved {gem.ItemName}, {gem.ItemDescription}!");
            CurrentPlayer.ItemsCollected++;
            Sleep();
           WriteLine($"{CurrentPlayer.playerName} has collected {CurrentPlayer.ItemsCollected} items");
            Sleep();
           WriteLine("Gimili: Let's start trading with people!");
            PressanyKey();
            ReadKey();
            Clear();
            CharacterSelection();
            
            
          
        }

        public void CharacterSelection()
        {
            Clear();
           WriteLine("Who would you like to talk to? (Please type the number of the person you'd like to talk to)");
            int index = 1;
            foreach (var NPC in characterselection)
            {
                WriteLine($"{index}: {NPC.Name}: {NPC.Description}");
                index++;

            }
            CharacterSelectionRecursion();
        }

        public void CharacterSelectionRecursion()
        {

            string input = ReadLine().ToLower().Trim();

            switch (input)
            {
                case "1":
                    BlacksmithLevel();
                    break;
                case "2":
                    FortuneTellerLevel();
                    break;
                case "3":
                    HistorianLevel();
                    break;
                case "4":
                    CollectorLevel();
                    break;
                case "5":
                    LibrarianLevel();
                    break;
                default:
                    WriteLine("Please type a valid option");
                    CharacterSelectionRecursion();
                    break;

            }
        }

        public void BlacksmithLevel()
        {
            Clear();
            WriteLine($"Hello, {CurrentPlayer.playerName}! It's so nice to meet you!");
            WriteLine("I am the Blacksmith, I love building and restoring weapons!");
            Sleep();
            WriteLine("What would like to talk about?");
            int index = 1;
            foreach (var Option in playerOptions)
            {
                WriteLine($"{index}: {Option.OptionChoice}");
                index++;
            }
            BlackSmithRecursion();
            
        }

        public void BlackSmithRecursion()
        {
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    WriteLine("Well let's see what you have");
                    Sleep();
                    foreach (var Item in playerInventory)
                    {
                        WriteLine($"{CurrentPlayer.playerName} has {Item.ItemName} in their inventory");
                       
                    }
                    Sleep();
                    BlacksmithTrade();
                    break;
                case "2":
                    WriteLine($"Okay {CurrentPlayer.playerName}, hope you come back soon!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "3":
                    WriteLine("I use the 4 natural elements in my craft; earth to iron, air to increase the heat of coals, water to cool the metal, and fire to forge");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                    case "4":
                    CharacterSelection();
                    break;
                default:
                    WriteLine("Please type a valid option");
                    BlackSmithRecursion();
                    break;

            }
        }

        public void BlacksmithTrade()
        {
            Clear();
            if (hastraded.Contains(Blacksmith))
            {
                WriteLine("Looks like we've already traded, maybe trade with someone else");
                PressanyKey();
                ReadKey();
                CharacterSelection();
            }
            else
            {
                if (playerInventory.Contains(sword))
                {
                    WriteLine("Wow looks like you have what I'm looking for! Let's trade!");
                    playerInventory.Remove(sword);
                    playerInventory.Add(map);
                    hastraded.Add(Blacksmith);
                    CurrentPlayer.ItemsCollected++;
                    WriteLine($"{CurrentPlayer.playerName} has recieved {map.ItemName}: {map.ItemDescription}");
                    Sleep();
                    WriteLine($"{CurrentPlayer.playerName} has now collected {CurrentPlayer.ItemsCollected} items");
                    PressanyKey();
                    ReadKey();
                    MapLevel();
                }
                else
                {
                    WriteLine("It doesn't look like you have what I want, come back when you think you may have it");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
            }
            
                      
        }

        public void FortuneTellerLevel()
        {
            Clear();
            WriteLine($"Hello, {CurrentPlayer.playerName}! I knew you'd come to see me");
            WriteLine("I am the Fortune Teller, I see your future in my crystal ball");
            Sleep();
            WriteLine("Tell me what you'd like to know about");
            int index = 1;
            foreach (var Option in playerOptions)
            {
                WriteLine($"{index}: {Option.OptionChoice}");
                index++;
            }
            FortuneTellerRecursion();
           
        }
        public void FortuneTellerRecursion()
        {
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    WriteLine("Well let's see what you have");
                    Sleep();
                    foreach (var Item in playerInventory)
                    {
                        WriteLine($"{CurrentPlayer.playerName} has {Item.ItemName} in their inventory");

                    }
                    Sleep();
                    FortuneTellerTrade();
                    break;
                case "2":
                    WriteLine($"Okay {CurrentPlayer.playerName}, I can see that you will be coming back in the future");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "3":
                    WriteLine("Besides reading a crystal ball, one of my favorite methods of fortune telling is palmistry. I interpret the shape, lines and curves of someone's palm to predcit their future");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "4":
                    CharacterSelection(); 
                    break;
                default:
                    WriteLine("Please type a valid option");
                    FortuneTellerRecursion();
                    break;

            }
        }
        public void FortuneTellerTrade()
        {
            Clear();
            if (hastraded.Contains(FortuneTeller))
            {
                WriteLine("Looks like we've already traded, maybe trade with someone else");
                PressanyKey();
                ReadKey();
                CharacterSelection();
            }
            else
            {
                if (playerInventory.Contains(gem))
                {
                    WriteLine("Ah it looks like you have something that catches my eye. I think I'll take that from you and give you this...");
                    Sleep();
                    playerInventory.Remove(gem);
                    playerInventory.Add(armor);
                    hastraded.Add(FortuneTeller);
                    CurrentPlayer.ItemsCollected++;
                    //ascii art from https://www.asciiart.eu/clothing-and-accessories/shirts
                    WriteLine("  _   _\r\n ) `-' (\r\n|sponsor|\r\n|_______|\r\n|_/ , \\_|\r\n|___|___|");
                    WriteLine($"{CurrentPlayer.playerName} has recieved {armor.ItemName}: {armor.ItemDescription}");
                    Sleep();
                    WriteLine($"{CurrentPlayer.playerName} has now collected {CurrentPlayer.ItemsCollected} items");
                    Sleep();
                    WriteLine("Let's keep trading!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
                else
                {
                    WriteLine("It doesn't look like you have what I want, come back when you think you may have it");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
            }
        }

        public void HistorianLevel()
        {
            Clear();
            WriteLine($"Hello, {CurrentPlayer.playerName}! It'swonderful to meet you!");
            WriteLine("I am the Historian, as boring as that sounds, I can probably tell you about so much!");
            Sleep();
            WriteLine("Tell me what you'd like to know about");
            int index = 1;
            foreach (var Option in playerOptions)
            {
                WriteLine($"{index}: {Option.OptionChoice}");
                index++;
            }
            HistorianRecursion();
        }

        public void HistorianRecursion()
        {
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    WriteLine("Well let's see what you have");
                    Sleep();
                    foreach (var Item in playerInventory)
                    {
                        WriteLine($"{CurrentPlayer.playerName} has {Item.ItemName} in their inventory");

                    }
                    Sleep();
                    HistorianTrade();
                    break;
                case "2":
                    WriteLine($"Okay {CurrentPlayer.playerName}, go out and learn something new! Come back whenever you'd like!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "3":
                    WriteLine("There's so much to learn about in this world, there's an unlimited supply of knowledge!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "4":
                    CharacterSelection();
                    break;
                default:
                    WriteLine("Please type a valid option");
                    HistorianRecursion();
                    break;

            }
        }
        public void HistorianTrade()
        {
            Clear();
            if (hastraded.Contains(Historian))
            {
                WriteLine("Looks like we've already traded, maybe trade with someone else");
                PressanyKey();
                ReadKey();
                CharacterSelection();
            }
            else
            {
                if (playerInventory.Contains(armor))
                {
                    WriteLine("Wow looks like you have what I'm looking for! Let's trade!");
                    Sleep();
                    hastraded.Add(Historian);
                    playerInventory.Remove(armor);
                    playerInventory.Add(shield);
                    CurrentPlayer.ItemsCollected++;
                    //ascii art from https://www.asciiart.eu/weapons/shields
                    WriteLine(" _________________________ \r\n|<><><>     |  |    <><><>|\r\n|<>         |  |        <>|\r\n|           |  |          |\r\n|  (______ <\\-/> ______)  |\r\n|  /_.-=-.\\| \" |/.-=-._\\  | \r\n|   /_    \\(o_o)/    _\\   |\r\n|    /_  /\\/ ^ \\/\\  _\\    |\r\n|      \\/ | / \\ | \\/      |\r\n|_______ /((( )))\\ _______|\r\n|      __\\ \\___/ /__      |\r\n|--- (((---'   '---))) ---|\r\n|           |  |          |\r\n|           |  |          |\r\n:           |  |          :     \r\n \\<>        |  |       <>/      \r\n  \\<>       |  |      <>/       \r\n   \\<>      |  |     <>/       \r\n    `\\<>    |  |   <>/'         \r\n      `\\<>  |  |  <>/'         \r\n        `\\<>|  |<>/'         \r\n          `-.  .-`           \r\n            '--'");
                    WriteLine($"{CurrentPlayer.playerName} has recieved {shield.ItemName}: {shield.ItemDescription}");
                    Sleep();
                    WriteLine($"{CurrentPlayer.playerName} has now collected {CurrentPlayer.ItemsCollected} items");
                    Sleep();
                    WriteLine("Let's keep trading!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
                else
                {
                    WriteLine("It doesn't look like you have what I want, come back when you think you may have it");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
            }
        }

        public void CollectorLevel()
        {
            Clear();
            WriteLine($"Hello, {CurrentPlayer.playerName}! Nice to meet you!");
            WriteLine("I am the Collector, don't mind the mess, I'm sorting through all my treasures!");
            Sleep();
            WriteLine("Tell me what you'd like to talk about");
            int index = 1;
            foreach (var Option in playerOptions)
            {
                WriteLine($"{index}: {Option.OptionChoice}");
                index++;
            }
            CollectorRecursion();
        }

        public void CollectorRecursion()
        {
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    WriteLine("Well let's see what you have");
                    foreach (var Item in playerInventory)
                    {
                        WriteLine($"{CurrentPlayer.playerName} has {Item.ItemName} in their inventory");

                    }
                    Sleep();
                    CollectorTrade();
                    break;
                case "2":
                    WriteLine($"Okay {CurrentPlayer.playerName}, I'll be here polishing my antiques, please come back whenever");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "3":
                    WriteLine("My collection ranges from things I enjoyed when I was a child, things others have gotten me, and things I just like");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "4":
                    CharacterSelection();
                    break;
                default:
                    WriteLine("Please type a valid option");
                    CollectorRecursion();
                    break;

            }
        }
        public void CollectorTrade()
        {
            Clear();
            if (hastraded.Contains(Collector))
            {
                WriteLine("Looks like we've already traded, maybe trade with someone else");
                PressanyKey();
                ReadKey();
                CharacterSelection();
            }
            else
            {
                if (playerInventory.Contains(shield))
                {
                    WriteLine("Wow looks like you have what I'm looking for! Let's trade!");
                    Sleep();
                    hastraded.Add(Collector);
                    playerInventory.Remove(shield);
                    playerInventory.Add(medallion);
                    CurrentPlayer.ItemsCollected++;
                    //ascii art from https://www.asciiart.eu/miscellaneous/badges
                    WriteLine("    _____________________\r\n     |       .--.--.       |\r\n     |  +   /|  |  |\\   +  |\r\n     | +{+  ||.-o-.||  +}+ |\r\n     |  l   |/.-'-.\\|   l  |\r\n     |--+-------+-------+--|\r\n     |  |.o. .o.|WwW WwW|  |\r\n     |  |`;`o`;`| wWwWw |  |\r\n     |  |  `;`  |   W   |  |\r\n     ;  |-------|-------|  ;\r\n      ; ; WwWWwW|.o..o. ; ;\r\n       \\ \\ W  W |`;``;`/ /  \r\n        \\ '. WwW|.o. .' /\r\n         '. `.w | `;` .'   \r\n*          '. `.|.` .'            * \r\n \\N_O_U_S    '. | .'    P_R_Ê_T_S/                           \r\n         \\     '+'     /    \r\n           S_O_M_M_E_S");
                    WriteLine($"{CurrentPlayer.playerName} has recieved {medallion.ItemName}: {medallion.ItemDescription}");
                    Sleep();
                    WriteLine($"{CurrentPlayer.playerName} has now collected {CurrentPlayer.ItemsCollected} items");
                    Sleep();
                    WriteLine("Let's keep trading!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
                else
                {
                    WriteLine("It doesn't look like you have what I want, come back when you think you may have it");
                    ReadKey();
                    CharacterSelection();
                }
            }
        }

        public void LibrarianLevel()
        {
            Clear();
            WriteLine($"Hello, {CurrentPlayer.playerName}! I was just reading a fascinating book!");
            WriteLine("I am the Librarian, I love to read and read and read!");
            Sleep();
            WriteLine("Tell me what you'd like to know about");
            int index = 1;
            foreach (var Option in playerOptions)
            {
                WriteLine($"{index}: {Option.OptionChoice}");
                index++;
            }
            LibrarianRecursion();
        }

        public void LibrarianRecursion()
        {
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    WriteLine("Well let's see what you have");
                    Sleep();
                    foreach (var Item in playerInventory)
                    {
                        WriteLine($"{CurrentPlayer.playerName} has {Item.ItemName} in their inventory");

                    }
                    Sleep();
                    LibrarianTrade();
                    break;
                case "2":
                    WriteLine($"Okay {CurrentPlayer.playerName}, come back whenever, I'll be reading");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "3":
                    WriteLine("My favorite book is The Lord of the Rings, specifically the last book, The Return of the King ");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                    break;
                case "4":
                    CharacterSelection();
                    break;
                default:
                    WriteLine("Please type a valid option");
                    LibrarianRecursion();
                    break;

            }
        }
        public void LibrarianTrade()
        {
            Clear();
            if (hastraded.Contains(Librarian))
            {
                WriteLine("Looks like we've already traded, maybe trade with someone else");
                ReadKey();
                CharacterSelection();
            }
            else
            {
                if (playerInventory.Contains(medallion))
                {
                    WriteLine("Wow looks like you have what I'm looking for! Let's trade!");
                    Sleep();
                    hastraded.Add(Librarian);
                    playerInventory.Remove(medallion);
                    playerInventory.Add(sword);
                    CurrentPlayer.ItemsCollected++;
                    //ascii art from https://www.asciiart.eu/weapons/swords
                    WriteLine("      /| ________________\r\nO|===|* >________________>\r\n      \\|");
                    WriteLine($"{CurrentPlayer.playerName} has recieved {sword.ItemName}: {sword.ItemDescription}");
                    Sleep();
                    WriteLine($"{CurrentPlayer.playerName} has now collected {CurrentPlayer.ItemsCollected} items");
                    Sleep();
                    WriteLine("Let's keep trading!");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
                else
                {
                    WriteLine("It doesn't look like you have what I want, come back when you think you may have it");
                    PressanyKey();
                    ReadKey();
                    CharacterSelection();
                }
            }
        }

        public void MapLevel()
        {
            Clear();
            WriteLine($"Gimili: Wow {CurrentPlayer.playerName}, it looks like you've found the map. There seems to only be three locations on there, let's see what they are.");
            Sleep();
            LookatMap();
        }

        public void LookatMap()
        {
            int index = 1;
            foreach (var Location in locationselection)
            {
                WriteLine($"{index}: {Location.LocationName}: {Location.LocationDescription}");
                index++;
            }
            WriteLine("Gimili: Where would you like to travel to? (Please type the number of the location");
            LocationRecursion();
        }

        public void LocationRecursion()
        {
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    ForestLevel();
                    break;
                case "2":
                    CaveLevel();
                    break;
                case "3":
                    CreekLevel();
                    break;
                default:
                    WriteLine("Please type a valid option");
                    LocationRecursion();
                    break;

            }
        }

        public void ForestLevel()
        {
            Clear();
            if (hasvisited.Contains(forest))
            {
                WriteLine($"Gimili: We've checked this area already {CurrentPlayer.playerName}. Let's look at a different location");
                LookatMap();
            }
            else
            {
                hasvisited.Add(forest);
                //ascii art from http://ascii-art.de/ascii/t/tree.txt
                WriteLine("            .        +          .      .          .\r\n     .            _        .                    .\r\n  ,              /;-._,-.____        ,-----.__\r\n ((        .    (_:#::_.:::. `-._   /:, /-._, `._,\r\n  `                 \\   _|`\"=:_::.`.);  \\ __/ /\r\n                      ,    `./  \\:. `.   )==-'  .\r\n    .      ., ,-=-.  ,\\, +#./`   \\:.  / /           .\r\n.           \\/:/`-' , ,\\ '` ` `   ): , /_  -o\r\n       .    /:+- - + +- : :- + + -:'  /(o-) \\)     .\r\n  .      ,=':  \\    ` `/` ' , , ,:' `'--\".--\"---._/`7\r\n   `.   (    \\: \\,-._` ` + '\\, ,\"   _,--._,---\":.__/\r\n              \\:  `  X` _| _,\\/'   .-'\r\n.               \":._:`\\____  /:'  /      .           .\r\n                    \\::.  :\\/:'  /              +\r\n   .                 `.:.  /:'  }      .\r\n           .           ):_(:;   \\           .\r\n                      /:. _/ ,  |\r\n                   . (|::.     ,`                  .\r\n     .                |::.    {\\\r\n                      |::.\\  \\ `.\r\n                      |:::(\\    |\r\n              O       |:::/{ }  |                  (o\r\n               )  ___/#\\::`/ (O \"==._____   O, (O  /`\r\n          ~~~w/w~\"~~,\\` `:/,-(~`\"~~~~~~~~\"~o~\\~/~w|/~\r\ndew   ~~~~~~~~~~~~~~~~~~~~~~~\\\\W~~~~~~~~~~~~\\|/~~");

                WriteLine($"Gimili: Well here we are,{CurrentPlayer.playerName} let's see if the key is anywhere to be found");
                Sleep();
                WriteLine("Gimili: What's that shiny thing in that bush?");
                Sleep();
                WriteLine(".....");
                Sleep();
                WriteLine("Gimili: It's just another gem, let's look back at the map");
                Sleep();
                Clear();
                LookatMap();
            }

        }

        public void CaveLevel()
        {
            Clear();
            if (hasvisited.Contains(cave))
            {
                WriteLine($"Gimili: We've checked this area already {CurrentPlayer.playerName}. Let's look at a different location");
                LookatMap();
            }
            else
            {
                hasvisited.Add(cave);
                //ascii art from http://ascii-art.de/ascii/mno/mountain.txt
                WriteLine("       ,sdPBbs.\r\n                      ,d$$$$$$$$b.\r\n                     d$P'`Y'`Y'`?$b\r\n                    d'    `  '  \\ `b\r\n                   /    |        \\  \\\r\n                  /    / \\       |   \\\r\n             _,--'        |      \\    |\r\n           /' _/          \\   |        \\\r\n        _/' /'             |   \\        `-.__\r\n    __/'       ,-'    /    |    |     \\      `--...__\r\n  /'          /      |    / \\     \\     `-.           `\\\r\n /    /;;,,__-'      /   /    \\            \\            `-.\r\n/    |;;;;;;;\\                                             \\");
                WriteLine($"Gimili: Well here we are,{CurrentPlayer.playerName} let's see if the key is anywhere to be found");
                Sleep();
                WriteLine("Gimili: What's that shiny thing over there? ");
                ReadKey();
                WriteLine(".....");
                Sleep();
                WriteLine("Gimili: It's just a coin, let's look back at the map");
                ReadKey();
                Clear();
                LookatMap();
            }
        }
        public void CreekLevel()
        {
            Clear();
            if (hasvisited.Contains(creek))
            {
                WriteLine($"Gimili: We've checked this area already {CurrentPlayer.playerName}. Let's look at a different location");
                LookatMap();
            }
            else
            {
                hasvisited.Add(creek);
                //ascii art from http://ascii-art.de/ascii/def/fish.txt
                WriteLine("\r\n\r\n\r\n\r\n\r\n                                              _J\"\"-.\r\n                  .-\"\"L_                     /o )   \\ ,';\r\n             ;`, /   ( o\\                    \\ ,'    ;  /\r\n             \\  ;    `, /                     \"-.__.'\"\\_;\r\n             ;_/\"`.__.-\"");
                WriteLine($"Gimili: Well here we are,{CurrentPlayer.playerName} let's see if the key is anywhere to be found");
                Sleep();
                WriteLine("Gimili: What's that shiny thing down there?");
                Sleep();
                WriteLine(".....");
                Sleep();
                Clear();
                Finish();
            }
        }
        public void Finish()
        {
            //ascii art from https://www.asciiart.eu/miscellaneous/keys
            WriteLine("ooo,    .---.\r\n o`  o   /    |\\________________\r\no`   'oooo()  | ________   _   _)\r\n`oo   o` \\    |/        | | | |\r\n  `ooo'   `---'         \"-\" |_|");
            WriteLine($"Gimili: Congratulations {CurrentPlayer.playerName}, you found the Lost Key! Now you can restore the kingdom to what it used to be!");
            PressanyKey();
            ReadKey();
            Clear();
            //asciiart from http://ascii-art.de/ascii/c/castle.txt
            WriteLine("  ,.=,,==. ,,_\r\n                      _ ,====, _    |I|`` ||  `|I `|\r\n                     |`I|    || `==,|``   ^^   ``  |\r\n                     | ``    ^^    ||_,===TT`==,,_ |\r\n                     |,==Y``Y==,,__| \\L=_-`'   +J/`\r\n                      \\|=_  ' -=#J/..-|=_-     =|\r\n                       |=_   -;-='`. .|=_-     =|----T--,\r\n                       |=/\\  -|=_-. . |=_-/^\\  =||-|-|::|____\r\n                       |=||  -|=_-. . |=_-| |  =|-|-||::\\____\r\n                       |=LJ  -|=_-. . |=_-|_| =||-|-|:::::::\r\n                       |=_   -|=_-_.  |=_-     =|-|-||:::::::\r\n                       |=_   -|=//^\\. |=_-     =||-|-|:::::::\r\n                   ,   |/&_,_-|=||  | |=_-     =|-|-||:::::::\r\n                ,--``8%,/    ',%||  | |=_-     =||-|-|%::::::\r\n            ,---`_,888`  ,.'''''`-.,|,|/!,--,.&\\|&\\-,|&#:::::\r\n           |;:;K`__,...;=\\_____,=``           %%%&     %#,---\r\n           |;::::::::::::|       `'.________+-------\\   ``\r\n          /8M%;:::;;:::::|                  |        `-------\r\n");
            WriteLine($"{CurrentPlayer.playerName} has collected {CurrentPlayer.ItemsCollected} items throughout their adventure!");
            Sleep();
            WriteLine("Press any key to exit the game");
            ReadKey();
            Environment.Exit(0);
        }
    }
}
