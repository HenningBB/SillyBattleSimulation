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
        private VisualTeamModel team1;
        private VisualTeamModel team2;
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
        /// <param name="team1"><see cref="Team1"/>.</param>
        /// <param name="team2"><see cref="Team2"/>.</param>
        /// <param name="king1"><see cref="King1"/>.</param>
        /// <param name="king2"><see cref="King2"/>.</param>
        public VisualSimulationViewModel(TeamModel team1, TeamModel team2, WarriorModel king1, WarriorModel king2)
        {
            // Initialisierung
            this.Team1 = new VisualTeamModel(team1, Brushes.Red);
            this.Team2 = new VisualTeamModel(team2, Brushes.Blue);
            this.Team2.MoveTeamVorward(250);
            this.Team2.TurnTeam(true);
            this.Team2.TurnTeam(true);

            this.King1 = new VisualWarriorModel(king1);
            this.King2 = new VisualWarriorModel(king2);

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
        public VisualTeamModel Team1
        {
            get => this.team1;
            set => this.SetProperty(ref this.team1, value);
        }

        /// <summary>
        /// Gets or sets the second Team.
        /// </summary>
        public VisualTeamModel Team2
        {
            get => this.team2;
            set => this.SetProperty(ref this.team2, value);
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

            if (this.Team1.VisualTeamMembers[0].PositionX < this.Team2.VisualTeamMembers[0].PositionX)
            {
                switch (this.ticker)
                {
                    case 0:
                        steps = 2;
                        this.Team1.MoveTeamVorward(steps);
                        this.Team2.MoveTeamVorward(steps);
                        break;
                    case 1:
                        steps = 4;
                        this.Team1.MoveTeamVorward(steps);
                        this.Team2.MoveTeamVorward(steps);
                        break;
                    case 2:
                        steps = 8;
                        this.Team1.MoveTeamVorward(steps);
                        this.Team2.MoveTeamVorward(steps);
                        break;
                    default:
                        this.Team1.MoveTeamVorward();
                        this.Team2.MoveTeamVorward();
                        this.ticker = -1;
                        break;
                }
            }
            else if (this.Team1.VisualTeamMembers[0].PositionX > this.Team2.VisualTeamMembers[0].PositionX)
            {
                steps = 6;
                this.Team1.MoveTeamBackward(steps);
                this.Team2.MoveTeamBackward(steps);
            }
            else
            {
                this.visualBattle.Battle(this.Team1, this.Team2);

                VisualTeamModel delete1 = new VisualTeamModel();
                VisualTeamModel delete2 = new VisualTeamModel();
                foreach (var dead in this.Team1.VisualTeamMembers)
                {
                    if (dead.CurrentHealth <= 0)
                    {
                        delete1.AddVisualWarrior(dead);
                    }
                }

                foreach (var dead in this.Team2.VisualTeamMembers)
                {
                    if (dead.CurrentHealth <= 0)
                    {
                        delete2.AddVisualWarrior(dead);
                    }
                }

                foreach (var item in delete1.VisualTeamMembers)
                {
                    this.Team1.RemoveVisualWarrior(item);
                }

                foreach (var item in delete2.VisualTeamMembers)
                {
                    this.Team2.RemoveVisualWarrior(item);
                }

                if (this.Team1.TeamSize > 0)
                {
                    this.Team1.PlaceWarriors();
                }
                else
                {
                    this.timer.Stop();
                }

                if (this.Team2.TeamSize > 0)
                {
                    this.Team2.PlaceWarriors();
                }
                else
                {
                    this.timer.Stop();
                }

                steps = 6;
                this.Team1.MoveTeamVorward(steps);
                this.Team2.MoveTeamVorward(steps);
            }

            this.ticker++;
        }
    }
}
