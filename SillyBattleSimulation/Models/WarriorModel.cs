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
        private int index;
        private int strength;
        private int health;
        private int defence;
        private int awarenes;

        /// <summary>
        /// Initializes a new instance of the <see cref="WarriorModel"/> class.
        /// </summary>
        public WarriorModel()
        {
            Random r = new Random();
            this.Strength = r.Next(11);
            this.Health = r.Next(11);
            this.Defence = r.Next(11);
            this.Awarenes = r.Next(1, 11);
        }

        /// <summary>
        /// Gets or sets the Index of the Warrior.
        /// </summary>
        public int Index
        {
            get => this.index;
            set => this.SetProperty(ref this.index, value);
        }

        /// <summary>
        /// Gets or sets the Strength of an Warrior.
        /// </summary>
        public int Strength
        {
            get => this.strength;
            set => this.SetProperty(ref this.strength, value);
        }

        /// <summary>
        /// Gets or sets the Health of an Warrior.
        /// </summary>
        public int Health
        {
            get => this.health;
            set => this.SetProperty(ref this.health, value);
        }

        /// <summary>
        /// Gets or sets the Defence of an Warrior.
        /// </summary>
        public int Defence
        {
            get => this.defence;
            set => this.SetProperty(ref this.defence, value);
        }

        /// <summary>
        /// Gets or sets the Awarenes of an Warrior.
        /// </summary>
        public int Awarenes
        {
            get => this.awarenes;
            set => this.SetProperty(ref this.awarenes, value);
        }
    }
}
