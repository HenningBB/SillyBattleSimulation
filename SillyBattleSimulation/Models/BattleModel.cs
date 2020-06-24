// <copyright file="BattleModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that represents an Battle between two <see cref="WarriorModel"/>.
    /// </summary>
    public class BattleModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BattleModel"/> class.
        /// </summary>
        public BattleModel()
        {
        }

        /// <summary>
        /// Method to determine the Winner of an Battle.
        /// </summary>
        /// <param name="warriorA">Attacking Warrior.</param>
        /// <param name="warriorB">Defending Warrior.</param>
        /// <returns>Winner if the Battle.</returns>
        public WarriorModel Battle(WarriorModel warriorA, WarriorModel warriorB)
        {
            int damage = warriorA.Strength - warriorB.Defence;
            WarriorModel winner;

            // Defending Warrior Defence Bigger
            if (damage < 0)
            {
                if (damage > warriorA.Health)
                {
                    winner = warriorB;
                }
                else
                {
                    winner = null;
                }
            }

            // Attacking Warrior Strength Bigger
            else if (damage > 0)
            {
                if (damage > warriorB.Health)
                {
                    winner = warriorA;
                }
                else
                {
                    winner = null;
                }
            }

            // Strength and Defence equal.
            else
            {
                winner = null;
            }

            return winner;
        }
    }
}
