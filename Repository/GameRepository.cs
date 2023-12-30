using System;
using System.Collections.Generic;

namespace lab3
{

    interface IGameRepository
    {
        void CreateGame(Game game);
        List<Game> ReadAllGames();
        List<Game> ReadPlayerGamesByPlayerId(string playerId);
        void UpdateGame(Game game);
        void DeleteGame(int gameId);
    }

    class GameRepository : IGameRepository
    {
        private readonly List<Game> games = new List<Game>();

        public void CreateGame(Game game) => games.Add(game);
        public List<Game> ReadAllGames() => games;
        public List<Game> ReadPlayerGamesByPlayerId(string playerId) => games.FindAll(game => game.Player1 == playerId || game.Player2 == playerId);
        public void UpdateGame(Game game) => games[games.FindIndex(g => g.GameId == game.GameId)] = game;
        public void DeleteGame(int gameId) => games.RemoveAll(g => g.GameId == gameId);
    }
}
