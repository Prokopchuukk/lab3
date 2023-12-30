using System;
using System.Collections.Generic;

namespace lab3
{
    class GameDbContext : IGameRepository
    {
        private readonly List<Game> games = new List<Game>();

        public void CreateGame(Game game) => games.Add(game);
        public List<Game> ReadAllGames() => games;
        public List<Game> ReadPlayerGamesByPlayerId(string playerId) => games.FindAll(game => game.Player1 == playerId || game.Player2 == playerId);
        public void UpdateGame(Game game)
        {
            Game existingGame = games.Find(g => g.GameId == game.GameId);
            if (existingGame != null)
            {
                int index = games.IndexOf(existingGame);
                games[index] = game;
            }
        }
        public void DeleteGame(int gameId) => games.RemoveAll(g => g.GameId == gameId);
    }
}