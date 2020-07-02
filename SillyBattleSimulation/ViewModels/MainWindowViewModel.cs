// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;
    using SillyBattleSimulation.Views;

    /// <summary>
    /// Class of the Main View.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private bool change;
        private TeamModel team1;
        private TeamModel team2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.team1 = new TeamModel();
            this.team2 = new TeamModel();
            this.CurrentViewModel = new SimulationViewModel(this.team1, this.team2);

            this.ChangeViewmodelCommand = new Command(this.ChangeViewModel);

            this.change = false;
        }

        /// <summary>
        /// Gets the Command to change the current Viewmodel.
        /// </summary>
        public ICommand ChangeViewmodelCommand { get; private set; }

        /// <summary>
        /// Gets or sets the currently selected Viewmodel.
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get => this.currentViewModel;
            set => this.SetProperty(ref this.currentViewModel, value);
        }

        private void ChangeViewModel(object commandParameter)
        {
            if (!this.change)
            {
                this.SaveTeams(this.team1, this.team2);
                this.CurrentViewModel = new VisualSimulationViewModel(this.team1, this.team2);
            }
            else
            {
                this.SaveTeams(this.team1, this.team2);
                this.CurrentViewModel = new SimulationViewModel(this.team1, this.team2);
            }

            this.change = !this.change;
        }

        private void SaveTeams(TeamModel team1, TeamModel team2)
        {
            var fs1 = File.Open("../../Files/Team1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var fs2 = File.Open("../../Files/Team2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                StreamWriter sw = new StreamWriter(fs1);
                foreach (var item in team1.TeamMembers)
                {
                    sw.WriteLine(item.MaxHealth + " " + item.CurrentHealth + " " + item.Strength + " " + item.Defence + " " + item.Awarenes);
                }

                sw.Close();
            }
            catch
            {
            }

            try
            {
                StreamWriter sw = new StreamWriter(fs2);
                foreach (var item in team2.TeamMembers)
                {
                    sw.WriteLine(item.MaxHealth + " " + item.CurrentHealth + " " + item.Strength + " " + item.Defence + " " + item.Awarenes);
                }

                sw.Close();
            }
            catch
            {
            }
        }

        private void LoadTeam(TeamModel team1, TeamModel team2)
        {
            var fs1 = File.Open("../../Team1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var fs2 = File.Open("../../Team2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                StreamWriter sw = new StreamWriter(fs1);
                foreach (var item in team1.TeamMembers)
                {
                    sw.WriteLine(item.MaxHealth + " " + item.CurrentHealth + " " + item.Strength + " " + item.Defence + " " + item.Awarenes);
                }

                sw.Close();
            }
            catch
            {
            }

            try
            {
                StreamWriter sw = new StreamWriter(fs2);
                foreach (var item in team2.TeamMembers)
                {
                    sw.WriteLine(item.MaxHealth + " " + item.CurrentHealth + " " + item.Strength + " " + item.Defence + " " + item.Awarenes);
                }

                sw.Close();
            }
            catch
            {
            }
        }
    }
}
