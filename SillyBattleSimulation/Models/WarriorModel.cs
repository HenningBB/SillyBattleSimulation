// <copyright file="WarriorModel.cs" company="PlaceholderCompany">
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
    /// Class that represents a Fighting asset.
    /// </summary>
    public class WarriorModel
    {
        private int strength;
        private int health;
        private int defence;

        /// <summary>
        /// Initializes a new instance of the <see cref="WarriorModel"/> class.
        /// </summary>
        public WarriorModel()
        {
            Random r = new Random();
            this.strength = r.Next(11);
            this.health = r.Next(11);
            this.defence = r.Next(11);
        }
    }
}
