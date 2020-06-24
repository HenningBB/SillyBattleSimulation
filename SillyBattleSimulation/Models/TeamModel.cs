// <copyright file="TeamModel.cs" company="PlaceholderCompany">
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
    /// Class that Represents a Team to which a <see cref="WarriorModel"/> belongs.
    /// </summary>
    public class TeamModel
    {
        private List<WarriorModel> teamMembers;

        /// <summary>
        /// Gets the Size of the Team.
        /// </summary>
        public int TeamSize
        {
            get { return this.teamMembers.Count; }
        }

        /// <summary>
        /// Generates a new Warrior for the Team.
        /// </summary>
        public void AddRandomWarrior()
        {
            WarriorModel warrior = new WarriorModel();
            this.teamMembers.Add(warrior);
        }
    }
}
