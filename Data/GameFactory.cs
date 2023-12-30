using System;
using System.Collections.Generic;

namespace lab3
{
    class GameFactory
    {
        public static Game CreateGame(GameAccount player1, GameAccount player2, string gameType)
        {
            return new Game(player1.UserName, player2.UserName, gameType);
        }

        public static GameAccount CreateGameAccount(string userName, string gameType)
        {
            switch (gameType)
            {
                case "Standard":
                    return new StandardGameAccount(userName);
                case "ReducedPenalty":
                    return new ReducedPenaltyGameAccount(userName);
                case "Training":
                    return new TrainingGameAccount(userName);
                default:
                    throw new ArgumentException("Невідомий тип гри.");
            }
        }
    }
}
