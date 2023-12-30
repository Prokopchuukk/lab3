using System;
using System.Collections.Generic;

namespace lab3
{
    class PlayerDbContext : IPlayerRepository
    {
        private readonly List<GameAccount> players = new List<GameAccount>();

        public void CreatePlayer(GameAccount player) => players.Add(player);
        public GameAccount ReadPlayerById(string playerId) => players.Find(player => player.UserName == playerId);
        public void UpdatePlayer(GameAccount player)
        {
            GameAccount existingPlayer = players.Find(p => p.UserName == player.UserName);
            if (existingPlayer != null)
            {
                int index = players.IndexOf(existingPlayer);
                players[index] = player;
            }
        }
        public void DeletePlayer(string playerId) => players.RemoveAll(p => p.UserName == playerId);
    }
}
