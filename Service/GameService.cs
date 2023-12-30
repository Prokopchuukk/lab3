using System;
using System.Collections.Generic;

namespace lab3
{

    interface IGameService
    {
        void CreateGame(Game game);
        List<Game> GetAllGames();
        List<Game> GetPlayerGames(string playerId);
        void UpdateGame(Game game);
        void DeleteGame(int gameId);
    }

    class GameService : IGameService
    {
        private readonly IGameRepository repository;

        public GameService(IGameRepository repository) => this.repository = repository;

        public void CreateGame(Game game) => repository.CreateGame(game);
        public List<Game> GetAllGames() => repository.ReadAllGames();
        public List<Game> GetPlayerGames(string playerId) => repository.ReadPlayerGamesByPlayerId(playerId);
        public void UpdateGame(Game game) => repository.UpdateGame(game);
        public void DeleteGame(int gameId) => repository.DeleteGame(gameId);
    }
}
