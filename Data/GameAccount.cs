using System;
using System.Collections.Generic;

namespace lab3
{
    abstract class GameAccount
    {
        public string UserName { get; set; }
        private int Rating = 1;
        public int CurrentRating { get { return Rating; } set { Rating = value < 1 ? 1 : value; } }
        public int GamesCount { get { return gameHistory.Count; } }
        private List<string> gameHistory = new List<string>();

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 500;
        }

        public abstract int CalculatePoints(int rating, bool isWin);

        public void WinGame(Game game, GameAccount opponent)
        {
            if (game == null || opponent == null)
            {
                throw new ArgumentNullException("Гра або опонент не можуть бути пустими.");
            }

            int points = CalculatePoints(game.Rating1, true);

            CurrentRating += points;
            gameHistory.Add($"      {opponent.UserName}      | Перемога  |   +{points}   | №{game.GameId}");
        }

        public void LoseGame(Game game, GameAccount opponent)
        {
            if (game == null || opponent == null)
            {
                throw new ArgumentNullException("Гра або опонент не можуть бути пустими.");
            }

            int points = CalculatePoints(game.Rating1, false);

            CurrentRating -= points;

            gameHistory.Add($"      {opponent.UserName}      | Поразка   |   -{points}   | №{game.GameId}");


        }

        public void GetStats(IPlayerService playerService)
        {
            GameAccount player = playerService.GetPlayerById(UserName);
            Console.WriteLine($"Статистика для гравця {UserName}:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Проти кого була гра | Результат | Рейтинг | Індекс гри");
            foreach (var game in player.gameHistory)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Поточний рейтинг: {player.CurrentRating}");
            Console.WriteLine($"Загальна кількість ігор: {player.GamesCount}");
            Console.WriteLine();
        }
    }
}
