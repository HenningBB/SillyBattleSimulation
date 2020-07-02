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
        private string succes;
        private BaseViewModel currentView;
        private bool switchero;
        private TeamModel team1;
        private TeamModel team2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            // TODO: Load Teams from File
            this.CurrentView = new SimulationViewModel(this.team1, this.team2);
            this.switchero = false;
            this.ChangeViewCommand = new Command(this.ChangeView);

            this.Succes = "HI";
            this.team1 = new TeamModel();
            this.team2 = new TeamModel();
            this.LoadTeam(this.team1);
            this.LoadTeam(this.team2);
        }

        /// <summary>
        /// Gets or sets a string to show Succes.
        /// </summary>
        public string Succes
        {
            get => this.succes;
            set => this.SetProperty(ref this.succes, value);
        }

        /// <summary>
        /// Gets the Command to change the View.
        /// </summary>
        public ICommand ChangeViewCommand { get; private set; }

        /// <summary>
        /// Gets or sets the currently selected Viewmodel.
        /// </summary>
        public BaseViewModel CurrentView
        {
            get => this.currentView;
            set => this.SetProperty(ref this.currentView, value);
        }

        private void ChangeView(object commandParameter)
        {
            if (this.switchero)
            {
                this.team1 = this.CurrentView.Unload(1);
                this.team2 = this.CurrentView.Unload(2);
                this.SaveTeam(this.team1);
                this.SaveTeam(this.team2);

                // TODO: Get current Teams and save them to file
                this.CurrentView = new SimulationViewModel(this.team1, this.team2);
                this.switchero = false;
            }
            else
            {
                this.team1 = this.CurrentView.Unload(1);
                this.team2 = this.CurrentView.Unload(2);
                this.SaveTeam(this.team1);
                this.SaveTeam(this.team2);

                // TODO: Get current Teams and save them to file
                this.CurrentView = new VisualSimulationViewModel(this.team1, this.team2);
                this.switchero = true;
            }
        }

        private void LoadTeam(TeamModel team)
        {
            string file;
            if (team == this.team1)
            {
                file = "../../Files/Team1.txt";
            }
            else
            {
                file = "../../Files/Team2.txt";
            }

            try
            {
                var fs = File.Open(file, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
            }
            catch
            {
                this.Succes = team.ToString();
            }
        }

        private void SaveTeam(TeamModel team)
        {
            string file;
            if (team == this.team1)
            {
                file = "../../Files/Team1.txt";
            }
            else
            {
                file = "../../Files/Team2.txt";
            }

            try
            {
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(file);
                sw.Close();
            }
            finally
            {
                this.Succes = "hallo";
            }
        }
    }
}
