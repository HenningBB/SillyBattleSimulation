// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;

    /// <summary>
    /// Class of the Main View.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        private TeamModel teamA;
        private TeamModel teamB;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.teamA = new TeamModel();
            this.teamB = new TeamModel();
            this.AddWarriorACommand = new Command(this.AddWarriorA);
            this.AddWarriorBCommand = new Command(this.AddWarriorB);
        }

        /// <summary>
        /// Gets the Command to add an Warrior to TeamA.
        /// </summary>
        public ICommand AddWarriorACommand { get; private set; }

        /// <summary>
        /// Gets the Command to add an Warrior to Teamb.
        /// </summary>
        public ICommand AddWarriorBCommand { get; private set; }

        /// <summary>
        /// Gets or sets the Model of the first Team.
        /// </summary>
        public TeamModel TeamA
        {
            get => this.teamA;
            set => this.SetProperty(ref this.teamA, value);
        }

        /// <summary>
        /// Gets or sets the Model of the second Team.
        /// </summary>
        public TeamModel TeamB
        {
            get => this.teamB;
            set => this.SetProperty(ref this.teamB, value);
        }

        private void AddWarriorA(object commandParameter)
        {
            this.TeamA.AddRandomWarrior();
        }

        private void AddWarriorB(object commandParameter)
        {
            this.TeamB.AddRandomWarrior();
        }
    }
}
