using System;

namespace Battleships.App.Utils
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Writes information under playing board.
        /// </summary>
        /// <param name="content">Information to view</param>
        public static void WriteInfo(string content, int size)
        {
            if(Console.IsOutputRedirected) return;
            
            //clear info rows
            ClearInfoRows(size);

            //write new info to console
            Console.SetCursorPosition(0,size + 4);
            Console.WriteLine($"[INFO]: {content}");
            Console.Write("Your shot: ");
        }

        /// <summary>
        /// Writes character on playing board.
        /// </summary>
        /// <param name="character">Character to write</param>
        /// <param name="col">Column of the board</param>
        /// <param name="row">Row of the board</param>
        public static void WriteChar(char character, int col, int row)
        {
            if(Console.IsOutputRedirected) return;
            
            Console.SetCursorPosition(col * 4 + 5, row + 2);
            Console.Write(character);
        }
        
        /// <summary>
        /// Shows welcome screen with playing instructions.
        /// </summary>
        public static void ShowWelcomeScreen()
        {
            if(Console.IsOutputRedirected) return;
            
            Console.WriteLine("Welcome to the game of battleships!");
            Console.WriteLine(); //break line
            Console.WriteLine("INSTRUCTIONS \n" +
                              "Your goal is to destroy the enemy ships in as little shots as possible. \n" +
                              "After every shot you will get feedback and the coordinates will change into O if you missed \n" +
                              "or X if you hit a ship \n" +
                              "To make a shot you need to enter proper coordinates starting with column. For example: \"A5\" \n" +
                              "Good luck!");
            Console.WriteLine(); //break line
            Console.Write("Enter size of the map:");
        }

        /// <summary>
        /// Shows you win information under playing board.
        /// </summary>
        public static void ShowYouWinScreen(int size)
        {
            if(Console.IsOutputRedirected) return;
            
            //clear info rows
            ClearInfoRows(size);
            
            //write you win info
            Console.SetCursorPosition(0,14);
            Console.WriteLine("Congratulations you won!");
            Console.Write("To play another game press ENTER to leave press any other button: ");
        }
        
        /// <summary>
        /// Draws the playing board in a console.
        /// </summary>
        public static void DrawBoard(int size)
        {
            if(Console.IsOutputRedirected) return;
            
            Console.Clear();
            for (int i = 0; i < size; i++)
            {
                // column names
                Console.SetCursorPosition(4 * i + 5,0);
                Console.Write((char) ('A' + i));
        
                // rows with numbering
                Console.SetCursorPosition(0, i + 2);
                Console.Write($"{i}");
                Console.SetCursorPosition(3,i + 2);
                Console.Write($"|{"".PadRight(size * 4)}|");
            }
            // top divider
            Console.SetCursorPosition(4,1);
            Console.WriteLine("".PadRight(size * 4,'-'));
            
            // bottom divider
            Console.SetCursorPosition(4, size + 2);
            Console.WriteLine("".PadRight(size * 4, '-'));
        }

        public static string GetOption(string optionString)
        {
            Console.Clear();
            Console.Write(optionString);
            return Console.ReadLine();
        }
        
        /// <summary>
        /// Clears information rows.
        /// </summary>
        private static void ClearInfoRows(int size)
        {
            if(Console.IsOutputRedirected) return;
            
            Console.SetCursorPosition(0, size + 4);
            Console.Write("".PadRight(Console.WindowWidth, ' '));
            Console.SetCursorPosition(0, size + 5);
            Console.Write("".PadRight(Console.WindowWidth, ' '));
        }
    }
}