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
        public Player getCurrentPlayer()
        {
            return players.ElementAt(currentPlayer);
        }
        /// <summary>
        /// Moves turn to next player in circle in order added to game.
        /// </summary>
        public void advanceTurn()
        {
            if (currentPlayer >= players.Count - 1)
                currentPlayer = 0;
            else
                currentPlayer++;
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
        /// <summary>
        /// Goes through every player and totals the occurrences of val
        /// </summary>
        /// <param name="val">value on dice to count</param>
        /// <returns>number of occurrences</returns>
        public int getDieNumAll(int val)
        {
            int sum = 0;
            foreach (Player p in players)
            {
                sum += p.getDieNum(val);
            }
            return sum;
        }
        /// <summary>
        /// Call this when a player says bull-poop. 
        /// </summary>
        /// <param name="numDice">Number of dice player guessed</param>
        /// <param name="valDie">value of die guessed on</param>
        /// <returns>True if the call was correct, false otherwise</returns>
        public bool callBull(int numDice, int valDie)
        {
            int total = getDieNumAll(valDie);
            if (total < numDice)
                return true;//Bull-poop was correct, not enough dice on table
            else
                return false;//bull-poop wrong, enough dice on table.
        }
        /// <summary>
        /// Call this when a player says Spot On
        /// </summary>
        /// <param name="numDice">Number of dice player guessed</param>
        /// <param name="valDie">value of die guessed on</param>
        /// <returns>True if the call was correct, false otherwise</returns>
        public bool callSpotOn(int numDice, int valDie)
        {
            int total = getDieNumAll(valDie);
            if (total == numDice)
                return true;//Spot on call was correct, exactly that many dice on table
            else
                return false;//spot on was wrong, not enough or too many dice on table
        }

    }
}
