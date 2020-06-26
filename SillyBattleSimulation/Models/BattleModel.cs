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
        /// <param name="attackingWarrior">Attacking Warrior.</param>
        /// <param name="defendingWarrior">Defending Warrior.</param>
        /// <returns>Winner if the Battle.</returns>
        public WarriorModel Battle(WarriorModel attackingWarrior, WarriorModel defendingWarrior)
        {
            WarriorModel winner;

            if (attackingWarrior.Strength > defendingWarrior.Defence)
            {
                winner = attackingWarrior;
            }
            else
            {
                winner = defendingWarrior;
            }

            return winner;
        }
    }
}
