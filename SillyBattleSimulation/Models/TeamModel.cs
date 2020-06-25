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
        private int teamSize;

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
        /// Gets or sets the Size of the Team.
        /// </summary>
        public int TeamSize
        {
            get => this.teamSize;
            set => this.SetProperty(ref this.teamSize, value);
        }

        /// <summary>
        /// Generates a new Warrior for the Team.
        /// </summary>
        public void AddRandomWarrior()
        {
            WarriorModel warrior = new WarriorModel();
            this.TeamMembers.Add(warrior);
            this.TeamSize = this.TeamMembers.Count;
        }

        /// <summary>
        /// Removes the first Warrior from the Team.
        /// </summary>
        public void RemoveWarrior()
        {
            this.TeamMembers.Remove(this.TeamMembers[0]);
        }
    }
}
