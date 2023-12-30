using System;
using System.Collections.Generic;

namespace lab3
{
    class Game
    {
        private static int gameCounter = 0;
        public int GameId { get; }
        public string Player1 { get; }
        public string Player2 { get; }
        public int Rating1 { get; }
        public bool Player1Wins { get; }
        public string GameType { get; }

        public Game(string player1, string player2, string gameType)
        {
            GameId = ++gameCounter;
            Player1 = player1;
            Player2 = player2;
            GameType = gameType;

            Random random = new Random();
            Rating1 = random.Next(10, 100);

            Player1Wins = random.Next(0, 2) == 0;
        }
    }
}
