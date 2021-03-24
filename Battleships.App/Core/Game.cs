using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;

namespace Battleships.App.Core
{
    public class Game
    {
        private List<Ship> _ships = new List<Ship>();
        public void ShowWelcomeScreen()
        {
            Console.WriteLine("Welcome to the game of battleships!");
            Console.WriteLine(); //break line
            Console.WriteLine("INSTRUCTIONS \n" +
                              "Your goal is to destroy the enemy ships in as little shots as possible. \n" +
                              "After every shot you will get feedback and the coordinates will change into O if you missed \n" +
                              "or X if you hit a ship \n" +
                              "To make a shot you need to enter proper coordinates starting with column. For example: \"A5\" \n" +
                              "Good luck!");
            Console.WriteLine(); //break line
            Console.Write("To start a game press any button:");
            Console.ReadKey();
        }

        public void StartGame()
        {
            DrawBoard();
            CreateShips(2,1);
            WriteInfo("Make your shot!");
            bool allDestroyed = false;
            while (!allDestroyed)
            {
                var shot = Console.ReadLine();
                int column = shot[0] - 'A';
                int row = (int) char.GetNumericValue(shot[1]);
                if (_ships.Any(s => s.IsHit(column, row)))
                {
                    var ship = _ships.First(s => s.HasPosition(column, row));
                    WriteChar('X', column, row);
                    WriteInfo(ship.IsDestroyed()
                        ? $"Good shot! {ship.Name} destroyed!"
                        : $"Good shot! It's a {ship.Name}!");
                }
                else
                {
                    WriteChar('O', column, row);
                    WriteInfo("Miss! Make another shot!");
                }

                if (_ships.All(s => s.IsDestroyed())) 
                    allDestroyed = true;
            }
            WriteInfo("You won!");
        }

        private void CreateShips(int destroyers, int battleships)
        {
            bool allProper = false;
            while (!allProper)
            {
                _ships.Clear();
                for (int i = 0; i < destroyers; i++)
                {
                    _ships.Add(new Ship(4));
                }

                for (int i = 0; i < battleships; i++)
                {
                    _ships.Add(new Ship(5));
                }

                var shipPositions = _ships.SelectMany(s => s.Positions);

                if (shipPositions.Distinct().Count() != shipPositions.Count())
                {
                    continue;
                }

                allProper = true;
            }
        }

        private void DrawBoard()
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("    A   B   C   D   E   F   G   H   I   J");
            Console.WriteLine("   ---------------------------------------");
            Console.WriteLine("0 |                                       |");
            Console.WriteLine("1 |                                       |");
            Console.WriteLine("2 |                                       |");
            Console.WriteLine("3 |                                       |");
            Console.WriteLine("4 |                                       |");
            Console.WriteLine("5 |                                       |");
            Console.WriteLine("6 |                                       |");
            Console.WriteLine("7 |                                       |");
            Console.WriteLine("8 |                                       |");
            Console.WriteLine("9 |                                       |");
            Console.WriteLine("   ---------------------------------------");
        }

        private void WriteInfo(string content)
        {
            //clear info rows
            Console.SetCursorPosition(0,14);
            Console.WriteLine("".PadRight(Console.WindowWidth));
            Console.WriteLine("".PadRight(Console.WindowWidth));
            
            //write new info to console
            Console.SetCursorPosition(0,14);
            Console.WriteLine($"[INFO]: {content}");
            Console.Write("Your shot: ");
        }

        private void WriteChar(char character, int col, int row)
        {
            Console.SetCursorPosition(col * 4 + 4, row + 2);
            Console.Write(character);
        }
    }
}