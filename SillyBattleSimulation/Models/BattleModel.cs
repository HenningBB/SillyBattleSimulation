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
        /// Method to have two <see cref="WarriorModel"/> do Battle.
        /// </summary>
        /// <param name="attackingWarrior">Attacking Warrior.</param>
        /// <param name="defendingWarrior">Defending Warrior.</param>
        public void Battle(WarriorModel attackingWarrior, WarriorModel defendingWarrior)
        {
            if (attackingWarrior.Strength > defendingWarrior.Defence)
            {
                defendingWarrior.CurrentHealth -= (short)(attackingWarrior.Strength - defendingWarrior.Defence);
            }
            else if (attackingWarrior.Strength < defendingWarrior.Defence)
            {
                attackingWarrior.CurrentHealth -= (short)(defendingWarrior.Defence - attackingWarrior.Strength);
            }
            else
            {
                if (defendingWarrior.Strength > attackingWarrior.Defence)
                {
                    attackingWarrior.CurrentHealth -= (short)(defendingWarrior.Strength - attackingWarrior.Defence);
                }
                else if (defendingWarrior.Strength < attackingWarrior.Defence)
                {
                    defendingWarrior.CurrentHealth -= (short)(attackingWarrior.Defence - defendingWarrior.Strength);
                }
                else
                {
                    attackingWarrior.CurrentHealth--;
                    defendingWarrior.CurrentHealth--;
                }
            }
        }
    }
}
