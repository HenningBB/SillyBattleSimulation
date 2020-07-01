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
    public class WarriorModel : BaseModel
    {
        private static Random r = new Random();
        private short index;
        private short strength;
        private short maxHealth;
        private short currentHealth;
        private short defence;
        private short awarenes;

        /// <summary>
        /// Initializes a new instance of the <see cref="WarriorModel"/> class.
        /// </summary>
        public WarriorModel()
        {
            this.Strength = Convert.ToInt16(r.Next(11));
            this.MaxHealth = Convert.ToInt16(r.Next(1, 11));
            this.CurrentHealth = this.MaxHealth;
            this.Defence = Convert.ToInt16(r.Next(11));
            this.Awarenes = Convert.ToInt16(r.Next(1, 11));
        }

        /// <summary>
        /// Gets or sets the Index of the Warrior.
        /// </summary>
        public short Index
        {
            get => this.index;
            set => this.SetProperty(ref this.index, value);
        }

        /// <summary>
        /// Gets or sets the Strength of an Warrior.
        /// </summary>
        public short Strength
        {
            get => this.strength;
            set => this.SetProperty(ref this.strength, value);
        }

        /// <summary>
        /// Gets or sets the maximum Health of an Warrior.
        /// </summary>
        public short MaxHealth
        {
            get => this.maxHealth;
            set => this.SetProperty(ref this.maxHealth, value);
        }

        /// <summary>
        /// Gets or sets the current Health of an Warrior.
        /// </summary>
        public short CurrentHealth
        {
            get => this.currentHealth;
            set => this.SetProperty(ref this.currentHealth, value);
        }

        /// <summary>
        /// Gets or sets the Defence of an Warrior.
        /// </summary>
        public short Defence
        {
            get => this.defence;
            set => this.SetProperty(ref this.defence, value);
        }

        /// <summary>
        /// Gets or sets the Awarenes of an Warrior.
        /// </summary>
        public short Awarenes
        {
            get => this.awarenes;
            set => this.SetProperty(ref this.awarenes, value);
        }
    }
}
