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
            var fs1 = File.Open("../../Files/Team1.txt", FileMode.Open, FileAccess.Write);
            var fs2 = File.Open("../../Files/Team2.txt", FileMode.Open, FileAccess.Write);
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
            var fs1 = File.Open("../../Team1.txt", FileMode.Open, FileAccess.Read);
            var fs2 = File.Open("../../Team2.txt", FileMode.Open, FileAccess.Read);
            try
            {
                StreamReader sr = new StreamReader(fs1);
                string filePath = sr.ReadToEnd();
                sr.Close();
                var textFieldParser = new TextFieldParser(filePath)
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
            catch
            {
            }

            try
            {
                StreamReader sr = new StreamReader(fs2);
                string filePath = sr.ReadToEnd();
                sr.Close();
                var textFieldParser = new TextFieldParser(filePath)
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
