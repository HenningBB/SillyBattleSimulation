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
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;

    /// <summary>
    /// Class of the Main View.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        private bool ticking;
        private TeamModel teamA;
        private TeamModel teamB;
        private BattleModel battleModel;
        private DispatcherTimer timer = new DispatcherTimer();
        private TimeSpan span = new TimeSpan(0, 0, 0, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.ticking = false;
            this.timer.Interval = this.span;
            this.timer.Tick += this.Timer_Tick;
            this.teamA = new TeamModel();
            this.teamB = new TeamModel();
            this.battleModel = new BattleModel();
            this.AddWarriorACommand = new Command(this.AddWarriorA);
            this.AddWarriorBCommand = new Command(this.AddWarriorB);
            this.BattleCommand = new Command(this.Battle);
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
        /// Gets the Command to do Battle.
        /// </summary>
        public ICommand BattleCommand { get; private set; }

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

        private void Battle(object commandParameter)
        {
            if (this.ticking)
            {
                this.timer.Stop();
            }
            else
            {
                this.timer.Start();
            }

            this.ticking = !this.ticking;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                WarriorModel warriorAAttacks, warriorBAttacks;
                warriorAAttacks = this.battleModel.Battle(this.TeamA.TeamMembers[0], this.TeamB.TeamMembers[0]);
                warriorBAttacks = this.battleModel.Battle(this.TeamB.TeamMembers[0], this.TeamA.TeamMembers[0]);
                if (warriorAAttacks == null)
                {
                    if (warriorBAttacks == null)
                    {
                        this.TeamA.RemoveWarrior();
                        this.TeamB.RemoveWarrior();
                    }
                    else if (warriorBAttacks == this.TeamB.TeamMembers[0])
                    {
                        this.TeamA.RemoveWarrior();
                    }
                    else
                    {
                        this.TeamB.RemoveWarrior();
                    }
                }
                else if (warriorAAttacks == this.TeamA.TeamMembers[0])
                {
                    this.TeamB.RemoveWarrior();
                }
                else
                {
                    this.TeamA.RemoveWarrior();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                this.TeamA.AddRandomWarrior();
                this.TeamB.AddRandomWarrior();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
