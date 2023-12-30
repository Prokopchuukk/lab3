//Переробила трошки класи, збільшила їх кількість та порозприділяла



using System;
using System.Collections.Generic;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IPlayerRepository playerRepository = new PlayerDbContext();
            IGameRepository gameRepository = new GameDbContext();
            IPlayerService playerService = new PlayerService(playerRepository);
            IGameService gameService = new GameService(gameRepository);

            string[] gameTypes = { "Standard", "ReducedPenalty", "Training" };

            Random random = new Random();

            GameAccount player1 = GameFactory.CreateGameAccount("Гравець1", gameTypes[random.Next(gameTypes.Length)]);
            GameAccount player2 = GameFactory.CreateGameAccount("Гравець2", gameTypes[random.Next(gameTypes.Length)]);
            GameAccount player3 = GameFactory.CreateGameAccount("Гравець3", gameTypes[random.Next(gameTypes.Length)]);

            playerService.CreateAccount(player1);
            playerService.CreateAccount(player2);
            playerService.CreateAccount(player3);

            for (int i = 0; i < 5; i++)
            {
                string gameType = gameTypes[random.Next(gameTypes.Length)];

                Game game1 = GameFactory.CreateGame(player1, player2, gameType);
                if (game1.Player1Wins)
                {
                    player1.WinGame(game1, player2);
                    player2.LoseGame(game1, player1);
                }
                else
                {
                    player1.LoseGame(game1, player2);
                    player2.WinGame(game1, player1);
                }

                string gameType2 = gameTypes[random.Next(gameTypes.Length)];

                Game game2 = GameFactory.CreateGame(player1, player3, gameType2);
                if (game2.Player1Wins)
                {
                    player1.WinGame(game2, player3);
                    player3.LoseGame(game2, player1);
                }
                else
                {
                    player1.LoseGame(game2, player3);
                    player3.WinGame(game2, player1);
                }
                string gameType3 = gameTypes[random.Next(gameTypes.Length)];

                Game game3 = GameFactory.CreateGame(player2, player3, gameType3);
                if (game3.Player1Wins)
                {
                    player2.WinGame(game3, player3);
                    player3.LoseGame(game3, player2);
                }
                else
                {
                    player2.LoseGame(game3, player3);
                    player3.WinGame(game3, player2);
                }
            }

            player1.GetStats(playerService);
            player2.GetStats(playerService);
            player3.GetStats(playerService);
        }
    }
}
