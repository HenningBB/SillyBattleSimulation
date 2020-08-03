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
    using Microsoft.VisualBasic.FileIO;
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
        private bool world;
        private TeamModel team1;
        private TeamModel team2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.team1 = new TeamModel();
            this.team2 = new TeamModel();
            this.LoadTeam(this.team1, this.team2);
            this.CurrentViewModel = new SimulationViewModel(this.team1, this.team2);

            this.ChangeViewmodelCommand = new Command(this.ChangeViewModel);
            this.DeployWorldCommand = new Command(this.DeployWorld);
            this.GraphCommand = new Command(this.Graph);
            this.CityCommand = new Command(this.City);

            this.change = false;
            this.world = false;
        }

        /// <summary>
        /// Gets the Command to change the current Viewmodel.
        /// </summary>
        public ICommand ChangeViewmodelCommand { get; private set; }

        /// <summary>
        /// Gets the Command to show/unshow the WorldViewmodel.
        /// </summary>
        public ICommand DeployWorldCommand { get; private set; }

        /// <summary>
        /// Gets the Command to show/unshow the GraphViewModel.
        /// </summary>
        public ICommand GraphCommand { get; private set; }

        /// <summary>
        /// Gets the Command to show/unshow the CityViewModel.
        /// </summary>
        public ICommand CityCommand { get; private set; }

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

            this.world = false;
            this.change = !this.change;
        }

        private void DeployWorld(object commandParameter)
        {
            if (!this.world)
            {
                this.SaveTeams(this.team1, this.team2);
                this.CurrentViewModel = new WorldViewModel();
            }
            else
            {
                if (this.change)
                {
                    this.CurrentViewModel = new VisualSimulationViewModel(this.team1, this.team2);
                }
                else
                {
                    this.CurrentViewModel = new SimulationViewModel(this.team1, this.team2);
                }
            }

            this.world = !this.world;
        }

        private void Graph(object commandParameter)
        {
            this.CurrentViewModel = new CoolGraphViewModel();
        }

        private void City(object commandParameter)
        {
            this.CurrentViewModel = new CityViewModel();
        }

        private void SaveTeams(TeamModel team1, TeamModel team2)
        {
            try
            {
                var fs1 = File.Open("../../Files/Team1.txt", FileMode.Create, FileAccess.Write);
                var fs2 = File.Open("../../Files/Team2.txt", FileMode.Create, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs1);
                foreach (var item in team1.TeamMembers)
                {
                    sw.WriteLine(item.MaxHealth + " " + item.CurrentHealth + " " + item.Strength + " " + item.Defence + " " + item.Awarenes);
                }

                sw.Close();

                sw = new StreamWriter(fs2);
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
            var fs1 = File.Open("../../Files/Team1.txt", FileMode.Open, FileAccess.Read);
            var fs2 = File.Open("../../Files/Team2.txt", FileMode.Open, FileAccess.Read);
            try
            {
                var textFieldParser = new TextFieldParser(fs1)
                { Delimiters = new string[] { " " } };

                while (!textFieldParser.EndOfData)
                {
                    var entry = textFieldParser.ReadFields();
                    WarriorModel warrior = new WarriorModel();
                    warrior.MaxHealth = Convert.ToInt16(entry[0]);
                    warrior.CurrentHealth = Convert.ToInt16(entry[1]);
                    warrior.Strength = Convert.ToInt16(entry[2]);
                    warrior.Defence = Convert.ToInt16(entry[3]);
                    warrior.Awarenes = Convert.ToInt16(entry[4]);
                    team1.AddWarrior(warrior);
                }

                textFieldParser.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                var textFieldParser = new TextFieldParser(fs2)
                { Delimiters = new string[] { " " } };

                while (!textFieldParser.EndOfData)
                {
                    var entry = textFieldParser.ReadFields();
                    WarriorModel warrior = new WarriorModel();
                    warrior.MaxHealth = Convert.ToInt16(entry[0]);
                    warrior.CurrentHealth = Convert.ToInt16(entry[1]);
                    warrior.Strength = Convert.ToInt16(entry[2]);
                    warrior.Defence = Convert.ToInt16(entry[3]);
                    warrior.Awarenes = Convert.ToInt16(entry[4]);
                    team2.AddWarrior(warrior);
                }

                textFieldParser.Close();
            }
            catch
            {
            }
        }
    }
}
