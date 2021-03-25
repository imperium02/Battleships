using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using Battleships.App.Core;
using Battleships.App.Utils;

namespace Battleships.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.ShowWelcomeScreen();

            //restart game on ENTER, end game on any other key
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                //new game
                var game = new Game {Ships = ShipCreator.CreateShips(2, 1)};
                
                //game loop
                bool allDestroyed = false;
                while (!allDestroyed)
                {
                    var shot = Console.ReadLine();
                    game.MakeShot(shot);

                    if (game.Ships.All(s => s.IsDestroyed())) 
                        allDestroyed = true;
                }
            
                //user won
                ConsoleHelper.ShowYouWinScreen(); 
            }
            
        }

        // private static void DrawBoard(int size)
        // {
        //     Console.Clear();
        //     for (int i = 0; i < size; i++)
        //     {
        //         // column names
        //         Console.SetCursorPosition(4 * i + 5,0);
        //         Console.Write((char) ('A' + i));
        //
        //         // rows with numbering
        //         Console.SetCursorPosition(0, i + 2);
        //         Console.Write($"{i}");
        //         Console.SetCursorPosition(3,i + 2);
        //         Console.Write($"|{"".PadRight(size * 4)}|");
        //     }
        //     // top divider
        //     Console.SetCursorPosition(4,1);
        //     Console.WriteLine("".PadRight(size * 4,'-'));
        //     
        //     // bottom divider
        //     Console.SetCursorPosition(4, size + 2);
        //     Console.WriteLine("".PadRight(size * 4, '-'));
        //     
        //     // Console.Clear();
        //     // Console.SetCursorPosition(0,0);
        //     // Console.WriteLine("    A   B   C   D   E   F   G   H   I   J");
        //     // Console.WriteLine("   ---------------------------------------");
        //     // Console.WriteLine("0 |                                       |");
        //     // Console.WriteLine("1 |                                       |");
        //     // Console.WriteLine("2 |                                       |");
        //     // Console.WriteLine("3 |                                       |");
        //     // Console.WriteLine("4 |                                       |");
        //     // Console.WriteLine("5 |                                       |");
        //     // Console.WriteLine("6 |                                       |");
        //     // Console.WriteLine("7 |                                       |");
        //     // Console.WriteLine("8 |                                       |");
        //     // Console.WriteLine("9 |                                       |");
        //     // Console.WriteLine("   ---------------------------------------");
        // }
        
    }
}