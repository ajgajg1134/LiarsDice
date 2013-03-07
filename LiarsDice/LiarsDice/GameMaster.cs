using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiarsDice
{
    class GameMaster
    {
        private int maxDice;
        private List<Player> players = new List<Player>();
        private int currentPlayer = 0;
        public GameMaster(int maxD)
        {
            maxDice = maxD;
        }
        /// <summary>
        /// Adds a new player to the game
        /// </summary>
        /// <param name="name">name of new player</param>
        public void addPlayer(string name)
        {
            players.Add(new Player(maxDice, name));
        }
        public void removePlayer(Player p)
        {
            players.Remove(p);
        }
        /// <summary>
        /// Removes all players from the game.
        /// Does not change maxDice
        /// </summary>
        public void resetGame()
        {
            players = new List<Player>();
        }
        /// <summary>
        /// changes maximum number of dice for all players. If in middle of game all players will get new max.
        /// </summary>
        /// <param name="newDie">new number of maximum dice</param>
        public void setMaxDice(int newDie)
        {
            maxDice = newDie;
            foreach (Player p in players)
            {
                p.setMaxDice(newDie);
            }
        }

    }
}
