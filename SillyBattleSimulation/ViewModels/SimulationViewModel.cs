// <copyright file="SimulationViewModel.cs" company="PlaceholderCompany">
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
    using System.Windows.Threading;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;

    /// <summary>
    /// The ViewModel for the SymulationView.
    /// </summary>
    public class SimulationViewModel : BaseViewModel
    {
        private bool ticking;
        private ClockModel clock;
        private WarriorModel kingA;
        private WarriorModel kingB;
        private TeamModel teamA;
        private TeamModel teamB;
        private BattleModel battleModel;
        private DispatcherTimer timer = new DispatcherTimer();
        private TimeSpan span = new TimeSpan(500);

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationViewModel"/> class.
        /// </summary>
        public SimulationViewModel()
        {
            this.ticking = false;
            this.timer.Interval = this.span;
            this.timer.Tick += this.Timer_Tick;
            this.clock = new ClockModel();
            this.clock.Angle = 0.0;
            this.teamA = new TeamModel();
            this.teamB = new TeamModel();
            this.battleModel = new BattleModel();
            this.AddWarriorACommand = new Command(this.AddWarriorA);
            this.AddWarriorBCommand = new Command(this.AddWarriorB);
            this.BattleCommand = new Command(this.Battle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationViewModel"/> class.
        /// </summary>
        /// <param name="team1">The first Team.</param>
        /// <param name="team2">The second Team.</param>
        public SimulationViewModel(TeamModel team1, TeamModel team2)
        {
            this.ticking = false;
            this.timer.Interval = this.span;
            this.timer.Tick += this.Timer_Tick;
            this.clock = new ClockModel();
            this.clock.Angle = 0.0;
            this.teamA = team1;
            this.teamB = team2;
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
        /// Gets or sets the Clock.
        /// </summary>
        public ClockModel Clock
        {
            get => this.clock;
            set => this.SetProperty(ref this.clock, value);
        }

        /// <summary>
        /// Gets or sets the King of Team A.
        /// </summary>
        public WarriorModel KingA
        {
            get => this.kingA;
            set => this.SetProperty(ref this.kingA, value);
        }

        /// <summary>
        /// Gets or sets the King of Team B.
        /// </summary>
        public WarriorModel KingB
        {
            get => this.kingB;
            set => this.SetProperty(ref this.kingB, value);
        }

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

        /// <summary>
        /// Method to call on Unloading to receive the Teams.
        /// </summary>
        /// <param name="team">Which Team to receive.</param>
        /// <returns>The returned Team.</returns>
        public TeamModel Unload(int team)
        {
            if (team == 1)
            {
                return this.TeamA;
            }
            else
            {
                return this.TeamB;
            }
        }

        private void AddWarriorA(object commandParameter)
        {
            if (!this.ticking)
            {
                for (int i = 0; i < 25; i++)
                {
                    this.TeamA.AddRandomWarrior();
                }
            }
        }

        private void AddWarriorB(object commandParameter)
        {
            if (!this.ticking)
            {
                for (int i = 0; i < 25; i++)
                {
                    this.TeamB.AddRandomWarrior();
                }
            }
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
            this.Clock.Angle++;
            if (this.Clock.Angle % 360 == 0)
            {
                try
                {
                    if (this.TeamA.TeamSize > 0 && this.KingA != null)
                    {
                        this.battleModel.Battle(this.TeamA.TeamMembers[0], this.KingA);
                        if (this.TeamA.TeamMembers[0].CurrentHealth <= 0)
                        {
                            this.TeamA.RemoveWarrior(this.TeamA.TeamMembers[0]);
                        }

                        if (this.KingA.CurrentHealth <= 0)
                        {
                            this.KingA = this.TeamA.TeamMembers[0];
                            this.TeamA.RemoveWarrior(this.TeamA.TeamMembers[0]);
                        }
                    }
                    else if (this.TeamA.TeamSize > 0 && this.KingA == null)
                    {
                        this.KingA = this.TeamA.TeamMembers[0];
                        this.TeamA.RemoveWarrior(this.TeamA.TeamMembers[0]);
                    }
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (this.TeamB.TeamSize > 0 && this.KingB != null)
                    {
                        this.battleModel.Battle(this.TeamB.TeamMembers[0], this.KingB);
                        if (this.TeamB.TeamMembers[0].CurrentHealth <= 0)
                        {
                            this.TeamB.RemoveWarrior(this.TeamB.TeamMembers[0]);
                        }

                        if (this.KingB.CurrentHealth <= 0)
                        {
                            this.KingB = this.TeamB.TeamMembers[0];
                            this.TeamB.RemoveWarrior(this.TeamB.TeamMembers[0]);
                        }
                    }
                    else if (this.TeamB.TeamSize > 0 && this.KingB == null)
                    {
                        this.KingB = this.TeamB.TeamMembers[0];
                        this.TeamB.RemoveWarrior(this.TeamB.TeamMembers[0]);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
