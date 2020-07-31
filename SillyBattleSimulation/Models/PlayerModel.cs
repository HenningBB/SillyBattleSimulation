// <copyright file="PlayerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    /// <summary>
    /// Class that represents the player on the Lines.
    /// </summary>
    public class PlayerModel : CellModel
    {
        private int locationX;
        private int locationY;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerModel"/> class.
        /// </summary>
        public PlayerModel()
        {
            this.Letter = 'P';
        }

        /// <summary>
        /// Gets or sets the x-Value of the Location.
        /// </summary>
        public int LocationX
        {
            get => this.locationX;
            set => this.SetProperty(ref this.locationX, value);
        }

        /// <summary>
        /// Gets or sets the y-Value of the Location.
        /// </summary>
        public int LocationY
        {
            get => this.locationY;
            set => this.SetProperty(ref this.locationY, value);
        }

        /// <summary>
        /// Moves the Model up.
        /// </summary>
        public void Up()
        {
            if (this.LocationX != 0)
            {
                this.LocationX--;
            }
        }

        /// <summary>
        /// Moves the Model down.
        /// </summary>
        /// <param name="maxSize">Indicates the Value that cant be stepped over.</param>
        public void Down(int maxSize)
        {
            if (this.LocationX != maxSize - 1)
            {
                this.LocationX++;
            }
        }

        /// <summary>
        /// Moves the Model left.
        /// </summary>
        public void Left()
        {
            if (this.LocationY != 0)
            {
                this.LocationY--;
            }
        }

        /// <summary>
        /// Moves the Model right.
        /// </summary>
        /// <param name="maxSize">Indicates the Value that cant be stepped over.</param>
        public void Right(int maxSize)
        {
            if (this.LocationY != maxSize - 1)
            {
                this.LocationY++;
            }
        }
    }
}
