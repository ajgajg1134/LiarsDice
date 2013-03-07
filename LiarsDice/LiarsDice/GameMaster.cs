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
        private List<Player> outPlayers = new List<Player>();
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

        /// <summary>
        /// Removes player from currently playing players
        /// </summary>
        /// <param name="p">Player to remove</param>
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
        /// Removes a die from the appropriate player 
        /// </summary>
        /// <param name="numDice">Number of dice player guessed</param>
        /// <param name="valDie">value of die guessed on</param>
        public void callBull(int numDice, int valDie)
        {
            int total = getDieNumAll(valDie);
            if (total < numDice)
            {
                //Bull-poop was correct, not enough dice on table
                getPrevPlayer().removeDie();
            }
            else
            {
                //bull-poop wrong, enough dice on table.
                getCurrentPlayer().removeDie();
            }

            //This last line must be called on this and spot on function
            endRound();
            
        }
        /// <summary>
        /// Gets the previous player (one who last made a bet)
        /// </summary>
        /// <returns>the player who made a bet</returns>
        private Player getPrevPlayer()
        {
            if (currentPlayer > 0)
                return players.ElementAt(currentPlayer - 1);
            else
                return players.ElementAt(players.Count - 1);
        }
        /// <summary>
        /// Call this when a player says Spot On
        /// Removes a die from the appropriate player 
        /// </summary>
        /// <param name="numDice">Number of dice player guessed</param>
        /// <param name="valDie">value of die guessed on</param>
        public void callSpotOn(int numDice, int valDie)
        {
            int total = getDieNumAll(valDie);
            if (total == numDice)
            {
                //Spot on call was correct, exactly that many dice on table
                getPrevPlayer().removeDie();
            }
            else
            {
                //spot on was wrong, not enough or too many dice on table
                getCurrentPlayer().removeDie();
            }
            //This last line must be called on this and bs function
            endRound();
        }
        /// <summary>
        /// Ends current round of play, rerolls all dice and checks for players without dice and moves them to the out players list
        /// </summary>
        private void endRound()
        {
            List<Player> temp = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                if (!players.ElementAt(i).hasDice())
                {
                    temp.Add(players.ElementAt(i));
                    outPlayers.Add(players.ElementAt(i));
                }
                else
                {
                    players.ElementAt(i).shakeDice();
                }

            }

            foreach (Player p in temp)
            {
                players.Remove(p);
            }

            if (players.Count == 1)
            {
                //End game things should go here
                //Declare winner and add players in outPlayers back to players
                //Ask players if they want to play again.
            }
        }

    }
}
