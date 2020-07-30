// <copyright file="TeamModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that Represents a Team to which a <see cref="WarriorModel"/> belongs.
    /// </summary>
    public class TeamModel : BaseModel
    {
        private ObservableCollection<WarriorModel> teamMembers;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamModel"/> class.
        /// </summary>
        public TeamModel()
        {
            this.teamMembers = new ObservableCollection<WarriorModel>();
        }

        /// <summary>
        /// Gets or sets the List of Warriors.
        /// </summary>
        public ObservableCollection<WarriorModel> TeamMembers
        {
            get => this.teamMembers;
            set => this.SetProperty(ref this.teamMembers, value);
        }

        /// <summary>
        /// Generates a new Warrior for the Team.
        /// </summary>
        public void AddRandomWarrior()
        {
            WarriorModel warrior = new WarriorModel();
            warrior.Index = Convert.ToInt16(this.TeamMembers.Count);
            this.TeamMembers.Add(warrior);
        }

        /// <summary>
        /// Generates a new Warrior for the Team.
        /// </summary>
        /// <param name="warrior">The Warrior to be added.</param>
        public void AddWarrior(WarriorModel warrior)
        {
            this.TeamMembers.Add(warrior);
        }

        /// <summary>
        /// Removes the first Warrior from the Team.
        /// </summary>
        public void RemoveWarrior()
        {
            WarriorModel warrior = this.TeamMembers[0];

            this.TeamMembers.Remove(warrior);
        }

        /// <summary>
        /// Removes a specific Warrior from the Team.
        /// </summary>
        /// <param name="warrior">the warrior to remove.</param>
        public void RemoveWarrior(WarriorModel warrior)
        {
            this.TeamMembers.Remove(warrior);
        }
    }
}
