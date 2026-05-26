
   namespace Zork;

   class Program
   {
       static bool isGameOver = false;
       private static bool isLakeLocked = true;
       private static bool hasPotion = false;
       private static bool hasDaisy = false;
       private static bool shadowMonsterDead = false;


       private static RoomType currentRoom;

       private enum RoomType
       {
           StartRoom,
           Lake,
           LakeMonster,
           Clearing,
           Forest,
           BehindMonster
       }
       
       static void Main()
       {
           Console.BackgroundColor = ConsoleColor.DarkMagenta;
           string command = null;
           string argument = null;

           AutoReset();
           currentRoom = RoomType.StartRoom;
           
           while (!isGameOver)
           {
               ShowPrompt();
               
               (command, argument) = GetInput();
               
               // check to make sure input is okay
               if (InputIsValid(command, argument)) continue;

               // make sure commands have arguments
               if (IfCommandMissingArgument(argument, command)) continue;
               
               switch (command)
               {
                   case "move":
                       HandleMove(argument);
                       break;
                   case "take":
                       HandleTake(argument);
                       break;
                   case "use":
                       HandleUse(argument);
                       break;
                   case "kill":
                       HandleKill(argument);
                       break;
                   default:
                       Console.WriteLine("> Try typing something I know how to do: move, take, use, or kill :P");
                       break;
               }
           }
       }

       private static void AutoReset()
       {
           Console.BackgroundColor = ConsoleColor.DarkMagenta;

           currentRoom = RoomType.StartRoom;
           isGameOver = false;
           isLakeLocked = true;
           shadowMonsterDead = false;
           hasPotion = false;
           hasDaisy = false;
       }

       private static bool IfCommandMissingArgument(string? argument, string? command)
       {
           if (argument == null)
           {
               if (command == "move" || command == "take" || command == "use")
               {
                   Console.WriteLine("> you cannot just say " + command + " and expect me to fill in the rest, stupid human-bot");
                   Console.WriteLine("> try: move west, kill monster, use daisy, something that makes sense?");
                   return true;
               }
           }
           return false;
       }

       private static bool InputIsValid(string? command, string? argument)
       {
           if (command == null && argument == null)
           {
               Console.WriteLine("> GIMME WORDS HUMAN BOT");
               return true;
           }

           return false;
       }

       private static (string command, string argument) GetInput()
       {
           
           string rawInput = Console.ReadLine();
           rawInput = rawInput.Trim();
           rawInput = rawInput.ToLower();
           
           string [] words = rawInput.Split(' ');
           
           string command = words[0];
           string argument = null;
           if (words.Length > 1)
           {
               argument = words[1];
           }

           return (command, argument);
       }

       private static void ShowPrompt()
       {
           Console.WriteLine("\n");
           Console.WriteLine("> What shall you do?");
       }

       static void HandleMove(string direction)
       {
           RoomType nextRoom = currentRoom;
           bool isValidMove = true;

           switch (currentRoom)
           {
               case RoomType.StartRoom:
                   if (direction == "north")
                   {
                       nextRoom = RoomType.Lake;
                       Console.BackgroundColor = ConsoleColor.Cyan;
                   }
                   else if (direction == "south")
                   {
                       nextRoom = RoomType.BehindMonster; 
                       Console.BackgroundColor = ConsoleColor.DarkRed;
                   }

                   else if (direction == "east")
                   {
                        nextRoom = RoomType.Forest;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                   }
                   else if (direction == "west")
                   {
                        nextRoom = RoomType.Clearing;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                   }
                   else
                       isValidMove = false;
                   break;
               case RoomType.Lake:
                   if (direction == "north")
                   {
                       if (isLakeLocked)
                       {
                           Console.WriteLine("> You need a potion to go further");
                           return;
                       }
                       else
                       {
                           nextRoom = RoomType.LakeMonster;
                           Console.BackgroundColor = ConsoleColor.DarkBlue;
                       }
                   }
                   else if (direction == "south")
                   {
                       nextRoom = RoomType.StartRoom;
                       Console.BackgroundColor = ConsoleColor.DarkMagenta;
                   }

                   else
                        isValidMove = false;
                   break;
               case RoomType.LakeMonster:
                   if (direction == "south")
                       nextRoom = RoomType.Lake;
                   else
                       isValidMove = false;
                   break;
               case RoomType.Clearing:
                   if (direction == "east")
                   {
                       nextRoom = RoomType.StartRoom;
                       Console.BackgroundColor = ConsoleColor.DarkMagenta;
                   }
                   else
                       isValidMove = false;
                   break;
               case RoomType.Forest:
                   if (direction == "west")
                   {
                       nextRoom = RoomType.StartRoom;
                       Console.BackgroundColor = ConsoleColor.DarkMagenta;
                   }
                   else
                       isValidMove = false;
                   break;
               case RoomType.BehindMonster:
                   if (direction == "north")
                   {
                       nextRoom = RoomType.StartRoom;
                       Console.BackgroundColor = ConsoleColor.DarkMagenta;
                   }
                   else
                       isValidMove = false;
                   break;
           }

           if (!isValidMove)
           {
               Console.WriteLine("> There's an invisible wall there, stupid. You can't go " + direction + "from there");
               return;
           }
           
           currentRoom = nextRoom;
           DescribeRoom(currentRoom);
       }
       
       static void HandleTake(string item)
       {
           switch (item)
           {
               case "potion":
                   if (currentRoom != RoomType.BehindMonster)
                   {
                       Console.WriteLine("> Do you see a potion here? Oh wait, lol you're blind nvm. THERE ISN'T ONE HERE.");
                   }
                   else if (hasPotion = true)
                   {
                       Console.WriteLine("> ...you already have that");
                   }
                   else
                   {
                       hasPotion = true;
                       Console.WriteLine(
                           "> Congrats! You got a waterbreathing potion! Wonder where you could use this...?");
                   }
                   break;
               
               case "daisy":
                   if (currentRoom != RoomType.Clearing)
                   {
                       Console.WriteLine("> Do you see a pink daisy for the taking? I don't.");
                   }
                   else if (hasDaisy)
                   {
                       Console.WriteLine("> You already have one you greedy pig!");
                   }
                   else 
                   {
                       Console.WriteLine("> Congrats! You have a daisy");
                       hasDaisy = true;
                   }
                   break;
               default:
                   Console.WriteLine("> There is no " + item + "in this room, silly human boy");
                   break;
           }
       }
       
       static void HandleUse(string item)
       {
           switch (item)
           {
               case "potion":
                   if (hasPotion != true) 
                   {
                        Console.WriteLine("> You have no potion to use");
                   }
                   else if (!isLakeLocked)
                   {
                       Console.WriteLine("> You already drank your potion");
                   }
                   else if (currentRoom != RoomType.Lake)
                   {
                       Console.WriteLine("> You have no reason to use the potion right now. Try somewhere wetter");
                   }
                   else
                   {
                       isLakeLocked = false;
                       Console.WriteLine("> You drank the potion, you will now be able to go forth");
                   }
                   break;
               case "daisy":
                   if (hasDaisy != true)
                   {
                       Console.WriteLine("> You have no daisy to use");
                   }
                   else if (currentRoom != RoomType.LakeMonster)
                   {
                       Console.WriteLine("> Where would you use a daisy here?");
                   }
                   else
                   {
                       Console.WriteLine("> You offer the creature the flower, it looks at you and smiles.");
                       Console.BackgroundColor = ConsoleColor.Green;
                       Console.WriteLine("> Congrats...");
                       isGameOver = true;
                   }
                   break;
           }
       }
       
       static void HandleKill(string thing)
       {
           switch (thing)
           {
               case "creature":
                   Console.WriteLine("> You cannot kill this creature");
                   break;
               case "monster":
                   if (currentRoom != RoomType.BehindMonster)
                        Console.WriteLine("> This monster is not in the room with you");
                   else 
                   {
                       Console.WriteLine("> You killed the shadow monster and have recieved a potion!.");
                       hasPotion = true;
                   }
                   break;
           }
       }

       static void DescribeRoom(RoomType room)
       {
           Console.WriteLine();
           switch (room)
           {
               case RoomType.StartRoom:
                   Console.WriteLine("> You are in a flat, quiet land.");
                   Console.WriteLine("> The wind whispers against your bare, unkempt feet");
                   Console.WriteLine("> A clearing lies to the East, a forest to the West, a Lake to the North");
                   Console.WriteLine("> DONT go South, whatever you do...");
                   break;
               case RoomType.Clearing:
                   Console.WriteLine("> Grass curls to the top of your knobby, scarred knees");
                   Console.WriteLine("> There are invisible barriers all around you, except from where you came");
                   Console.WriteLine("> A wonderful, pink daisy, sits at the edge of the field. Take it if you dare.");
                   break;
               case RoomType.BehindMonster:
                   Console.WriteLine("> You fucking idiot this is the one place I said not to go");
                   Console.WriteLine("> Goddamnit here we go...");
                   Console.WriteLine("> All around you are shadows, the sun has turned from a golden yellow to a dripping orange");
                   Console.WriteLine("> The only exit is from wence you came, i suggest you take it.");
                   Console.WriteLine("> Too late.");
                   Console.WriteLine("> A Shadowy monster appears in front of you!");
                   Console.ForegroundColor = ConsoleColor.Cyan;
                   Console.WriteLine("> Monster: Who are you, to try and kill me?");
                   Console.ResetColor();
                   Console.BackgroundColor = ConsoleColor.DarkRed;
                   break;
               case RoomType.Forest:
                   Console.WriteLine("> You are at the edge of a forest, that is unenterable due to a wall of beavers");
                   Console.WriteLine("> Its kind of boring here.");
                   Console.WriteLine("> he only exit is the way from which you came");
                   break;
               case RoomType.Lake:
                   Console.WriteLine("> Your feet sink into a brimy, pure water");
                   Console.WriteLine("> Gentle waves lap against your feet");
                   Console.WriteLine("> it looks like you could go farther North, into the Lake. But you would need a potion to do so... wonder where you get one of those...");
                   Console.WriteLine("> The only way out is from whence you came");
                   break;
               case RoomType.LakeMonster:
                   Console.WriteLine("> You chug the potion, sinking deep into the waves below.");
                   Console.WriteLine("> You cannot see any light for a path to the East, West, or North of you");
                   Console.WriteLine("> What you can see is: another creature");
                   Console.WriteLine("> This one looks kinder than the last...");
                   Console.ForegroundColor = ConsoleColor.Magenta;
                   Console.WriteLine("> Creature: Did you bring something for me?");
                   Console.ResetColor();
                   Console.BackgroundColor = ConsoleColor.DarkBlue;
                   break;
           }
       }
   }