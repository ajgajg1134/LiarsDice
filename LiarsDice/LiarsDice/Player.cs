using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiarsDice
{
    class Player
    {
        int numDice;
        private int[] diceRoll;
        private string name;
        public Player(int maxDice, string id)
        {
            numDice = maxDice;
            name = id;
            diceRoll = new int[numDice];
        }
        /// <summary>
        /// Randomly rolls the players numDice
        /// </summary>
        public void shakeDice()
        {
            Random rand = new Random();
            for (int i = 0; i < diceRoll.Length; i++)
            {
                diceRoll[i] = rand.Next(1, 7);
            }

        }
        public void setMaxDice(int maxDice)
        {
            numDice = maxDice;
            diceRoll = new int[numDice];
        }
        /// <summary>
        /// Gets all the dice rolled
        /// </summary>
        /// <returns>an int array where each number is a die</returns>
        public int[] getAllDice()
        {
            return diceRoll;
        }
        /// <summary>
        /// Removes a die from the player and reinitializes roll to new array (empty)
        /// </summary>
        public void removeDie()
        {
            numDice--;
            diceRoll = new int[numDice];
        }
        /// <summary>
        /// Gets the number of occurrances of a specific roll value
        /// </summary>
        /// <param name="val">specific roll value to look for</param>
        /// <returns>number of occurrances of that value</returns>
        public int getDieNum(int val)
        {
            int sum = 0;
            foreach (int i in diceRoll)
            {
                if (i == val)
                {
                    sum++;
                }
            }
            return sum;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string newName)
        {
            name = newName;
        }
        public override bool Equals(System.Object obj)
        {
            Player otherPlayer = (Player)obj;
            if (this.name.Equals(otherPlayer.name))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifys if a player has dice remaining.
        /// </summary>
        /// <returns>true if player has non-zero amount of dice.</returns>
        public bool hasDice()
        {
            if (numDice > 0)
                return true;
            else
                return false;
        }
    }
}
