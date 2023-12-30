using System;
using System.Collections.Generic;

namespace lab3
{

    interface IPlayerService
    {
        void CreateAccount(GameAccount player);
        GameAccount GetPlayerById(string playerId);
        void UpdateAccount(GameAccount player);
        void DeleteAccount(string playerId);
    }

    class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository repository;

        public PlayerService(IPlayerRepository repository) => this.repository = repository;

        public void CreateAccount(GameAccount player) => repository.CreatePlayer(player);
        public GameAccount GetPlayerById(string playerId) => repository.ReadPlayerById(playerId);
        public void UpdateAccount(GameAccount player) => repository.UpdatePlayer(player);
        public void DeleteAccount(string playerId) => repository.DeletePlayer(playerId);
    }
}
