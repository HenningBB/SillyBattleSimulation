// <copyright file="WorldViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Input;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;

    /// <summary>
    /// Class of the World View.
    /// </summary>
    public class WorldViewModel : BaseViewModel
    {
        private int size = 15;
        private ObservableCollection<WorldModel> lines;
        private PlayerModel player;
        private PlayerModel mob;
        private string debug;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldViewModel"/> class.
        /// </summary>
        public WorldViewModel()
        {
            this.Player = new PlayerModel();
            this.Mob = new PlayerModel();

            this.Mob.Letter = 'd';
            this.Mob.LocationX = 2;
            this.Mob.LocationY = 2;

            this.Lines = new ObservableCollection<WorldModel>();

            this.UpCommand = new Command(this.Up);
            this.DownCommand = new Command(this.Down);
            this.LeftCommand = new Command(this.Left);
            this.RightCommand = new Command(this.Right);

            for (int i = 0; i < this.size; i++)
            {
                this.Lines.Add(new WorldModel(this.size));
            }

            this.Lines[this.Mob.LocationX].World[this.Mob.LocationY].Letter = this.Mob.Letter;
        }

        /// <summary>
        /// Gets or sets an Matrix of <see cref="CellModel"/>.
        /// </summary>
        public ObservableCollection<WorldModel> Lines
        {
            get => this.lines;
            set => this.SetProperty(ref this.lines, value);
        }

        /// <summary>
        /// Gets the Command to go Forward.
        /// </summary>
        public ICommand UpCommand { get; private set; }

        /// <summary>
        /// Gets the Command to go Backward.
        /// </summary>
        public ICommand DownCommand { get; private set; }

        /// <summary>
        /// Gets the Command to turn Left.
        /// </summary>
        public ICommand LeftCommand { get; private set; }

        /// <summary>
        /// Gets the Command to turn Right.
        /// </summary>
        public ICommand RightCommand { get; private set; }

        /// <summary>
        /// Gets or sets the Player Figure.
        /// </summary>
        public PlayerModel Player
        {
            get => this.player;
            set => this.SetProperty(ref this.player, value);
        }

        /// <summary>
        /// Gets or sets an Mob Figure.
        /// </summary>
        public PlayerModel Mob
        {
            get => this.mob;
            set => this.SetProperty(ref this.mob, value);
        }

        /// <summary>
        /// Gets or sets an string that helps while debugging.
        /// </summary>
        public string Debug
        {
            get => this.debug;
            set => this.SetProperty(ref this.debug, value);
        }

        private void Up(object commandParameter)
        {
            this.Player.Up();
            this.UpdateWorld();
        }

        private void Down(object commandParameter)
        {
            this.Player.Down(this.size);
            this.UpdateWorld();
        }

        private void Left(object commandParameter)
        {
            this.Player.Left();
            this.UpdateWorld();
        }

        private void Right(object commandParameter)
        {
            this.Player.Right(this.size);
            this.UpdateWorld();
        }

        private void UpdateWorld()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.Lines[i].World[j].Letter = 'a';
                }
            }

            if (this.Mob.LocationX == this.Player.LocationX && this.Mob.LocationY == this.Player.LocationY)
            {
                MessageBox.Show("YOU DIED!");
            }
            else if (this.Mob.LocationX == this.size - 1 && this.Mob.LocationY == 0)
            {
                MessageBox.Show("The Sheep Escaped!");
            }

            this.Debug = this.Distance(this.Mob, this.Player).ToString();
            if (this.Distance(this.Mob, this.Player) < 5)
            {
                if (this.Distance(this.Mob, this.Player) % 2 == 0)
                {
                    this.Mob.Right(this.size);
                }
                else
                {
                    this.Mob.Up();
                }
            }
            else
            {
                if (this.Distance(this.Mob, this.Player) % 2 == 0)
                {
                    this.Mob.Left();
                }
                else
                {
                    this.Mob.Down(this.size);
                }
            }

            this.Lines[this.Mob.LocationX].World[this.Mob.LocationY].Letter = this.Mob.Letter;

            this.lines[this.Player.LocationX].World[this.Player.LocationY].Letter = this.Player.Letter;
        }

        private int Distance(PlayerModel m1, PlayerModel m2)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow(m1.LocationX - m2.LocationX, 2) + Math.Pow(m1.LocationY - m2.LocationY, 2)));
        }
    }
}
