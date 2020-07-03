// <copyright file="VisualSimulationViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;

    /// <summary>
    /// Class of the Visual Simulation View.
    /// </summary>
    public class VisualSimulationViewModel : BaseViewModel
    {
        private VisualTeamModel teamA;
        private VisualTeamModel teamB;
        private VisualWarriorModel king1;
        private VisualWarriorModel king2;
        private VisualBattleModel visualBattle;
        private bool ticking;
        private DispatcherTimer timer = new DispatcherTimer();
        private TimeSpan time = new TimeSpan(0, 0, 0, 0, 50);
        private int ticker = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualSimulationViewModel"/> class.
        /// </summary>
        /// <param name="team1"><see cref="TeamA"/>.</param>
        /// <param name="team2"><see cref="TeamB"/>.</param>
        public VisualSimulationViewModel(TeamModel team1, TeamModel team2)
        {
            // Initialisierung
            this.TeamA = new VisualTeamModel(team1, Brushes.Red);
            this.TeamB = new VisualTeamModel(team2, Brushes.Blue);
            this.TeamB.MoveTeamVorward(250);
            this.TeamB.TurnTeam(true);
            this.TeamB.TurnTeam(true);

            this.BattleCommand = new Command(this.Battle);

            this.visualBattle = new VisualBattleModel();

            // Anfangspositionen
            // this.King1.PositionX = 5;
            // this.King1.PositionY = 5;

            // this.King2.PositionX = 55;
            // this.King2.PositionY = 5;

            // Timer
            this.ticking = false;
            this.timer.Interval = this.time;
            this.timer.Tick += this.Timer_Tick;
        }

        /// <summary>
        /// Gets the Command to do Battle.
        /// </summary>
        public ICommand BattleCommand { get; private set; }

        /// <summary>
        /// Gets or sets the first Team.
        /// </summary>
        public VisualTeamModel TeamA
        {
            get => this.teamA;
            set => this.SetProperty(ref this.teamA, value);
        }

        /// <summary>
        /// Gets or sets the second Team.
        /// </summary>
        public VisualTeamModel TeamB
        {
            get => this.teamB;
            set => this.SetProperty(ref this.teamB, value);
        }

        /// <summary>
        /// Gets or sets the King of the first Team.
        /// </summary>
        public VisualWarriorModel King1
        {
            get => this.king1;
            set => this.SetProperty(ref this.king1, value);
        }

        /// <summary>
        /// Gets or sets the King of the second Team.
        /// </summary>
        public VisualWarriorModel King2
        {
            get => this.king2;
            set => this.SetProperty(ref this.king2, value);
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
            short steps;

            if (this.TeamA.VisualTeamMembers[0].PositionX < this.TeamB.VisualTeamMembers[0].PositionX)
            {
                switch (this.ticker)
                {
                    case 0:
                        steps = 2;
                        this.TeamA.MoveTeamVorward(steps);
                        this.TeamB.MoveTeamVorward(steps);
                        break;
                    case 1:
                        steps = 4;
                        this.TeamA.MoveTeamVorward(steps);
                        this.TeamB.MoveTeamVorward(steps);
                        break;
                    case 2:
                        steps = 8;
                        this.TeamA.MoveTeamVorward(steps);
                        this.TeamB.MoveTeamVorward(steps);
                        break;
                    default:
                        this.TeamA.MoveTeamVorward();
                        this.TeamB.MoveTeamVorward();
                        this.ticker = -1;
                        break;
                }
            }
            else if (this.TeamA.VisualTeamMembers[0].PositionX > this.TeamB.VisualTeamMembers[0].PositionX)
            {
                steps = 6;
                this.TeamA.MoveTeamBackward(steps);
                this.TeamB.MoveTeamBackward(steps);
            }
            else
            {
                this.visualBattle.Battle(this.TeamA, this.TeamB);

                VisualTeamModel delete1 = new VisualTeamModel();
                VisualTeamModel delete2 = new VisualTeamModel();
                foreach (var dead in this.TeamA.VisualTeamMembers)
                {
                    if (dead.CurrentHealth <= 0)
                    {
                        delete1.AddVisualWarrior(dead);
                    }
                }

                foreach (var dead in this.TeamB.VisualTeamMembers)
                {
                    if (dead.CurrentHealth <= 0)
                    {
                        delete2.AddVisualWarrior(dead);
                    }
                }

                foreach (var item in delete1.VisualTeamMembers)
                {
                    this.TeamA.RemoveVisualWarrior(item);
                }

                foreach (var item in delete2.VisualTeamMembers)
                {
                    this.TeamB.RemoveVisualWarrior(item);
                }

                if (this.TeamA.TeamSize > 0)
                {
                    this.TeamA.PlaceWarriors();
                }
                else
                {
                    this.timer.Stop();
                }

                if (this.TeamB.TeamSize > 0)
                {
                    this.TeamB.PlaceWarriors();
                }
                else
                {
                    this.timer.Stop();
                }

                steps = 6;
                this.TeamA.MoveTeamVorward(steps);
                this.TeamB.MoveTeamVorward(steps);
            }

            this.ticker++;
        }
    }
}
