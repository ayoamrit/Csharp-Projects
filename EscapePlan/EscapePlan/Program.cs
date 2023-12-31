﻿using EscapePlan.Game;
using System.Runtime.CompilerServices;

namespace EscapePlan
{
    internal class Program
    {
        private static GameLoop gameLoop;

        public static void Main(string[] args)
        {
            gameLoop = new GameLoop();

            while (gameLoop != null)
            {
                //Get pressed key without displaying it in the console
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                GameBoard.UpdateBoard(keyInfo);
            }


        }
    }
}