// <copyright file="VisualWarriorModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// Class that allows for an easier visualisation.
    /// </summary>
    public class VisualWarriorModel : WarriorModel
    {
        private short positionX;
        private short positionY;
        private short outlook;
        private Brush colour;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualWarriorModel"/> class.
        /// </summary>
        /// <param name="model">The <see cref="WarriorModel"/> to visualize.</param>
        public VisualWarriorModel(WarriorModel model)
        {
            this.MaxHealth = model.MaxHealth;
            this.CurrentHealth = model.CurrentHealth;
            this.Strength = model.Strength;
            this.Defence = model.Defence;
            this.Awarenes = model.Awarenes;
        }

        /// <summary>
        /// Gets or sets the X-axis coordination.
        /// </summary>
        public short PositionX
        {
            get => this.positionX;
            set => this.SetProperty(ref this.positionX, value);
        }

        /// <summary>
        /// Gets or sets the y-axis coordination.
        /// </summary>
        public short PositionY
        {
            get => this.positionY;
            set => this.SetProperty(ref this.positionY, value);
        }

        /// <summary>
        /// Gets or sets a value for the direction of looking.
        /// </summary>
        public short Outlook
        {
            get => this.outlook;
            set => this.SetProperty(ref this.outlook, value);
        }

        /// <summary>
        /// Gets or sets the Teamcolour.
        /// </summary>
        public Brush Colour
        {
            get => this.colour;
            set => this.SetProperty(ref this.colour, value);
        }

        /// <summary>
        /// Moves in Outlook direction.
        /// </summary>
        public void MoveVorward()
        {
            if (this.Outlook == 0)
            {
                this.PositionX++;
            }
            else if (this.Outlook == 1)
            {
                this.PositionY++;
            }
            else if (this.Outlook == 2)
            {
                this.PositionX--;
            }
            else
            {
                this.PositionY--;
            }
        }

        /// <summary>
        /// Moves in Outlook direction.
        /// </summary>
        /// <param name="steps">How far to Move.</param>
        public void MoveVorward(short steps)
        {
            if (this.Outlook == 0)
            {
                this.PositionX += steps;
            }
            else if (this.Outlook == 1)
            {
                this.PositionY += steps;
            }
            else if (this.Outlook == 2)
            {
                this.PositionX -= steps;
            }
            else
            {
                this.PositionY -= steps;
            }
        }

        /// <summary>
        /// Moves opposite to Outlook direction.
        /// </summary>
        public void MoveBackward()
        {
            if (this.Outlook == 0)
            {
                this.PositionX--;
            }
            else if (this.Outlook == 1)
            {
                this.PositionY--;
            }
            else if (this.Outlook == 2)
            {
                this.PositionX++;
            }
            else
            {
                this.PositionY++;
            }
        }

        /// <summary>
        /// Moves opposite to Outlook direction.
        /// </summary>
        /// <param name="steps">How far to Move.</param>
        public void MoveBackward(short steps)
        {
            if (this.Outlook == 0)
            {
                this.PositionX -= steps;
            }
            else if (this.Outlook == 1)
            {
                this.PositionY -= steps;
            }
            else if (this.Outlook == 2)
            {
                this.PositionX += steps;
            }
            else
            {
                this.PositionY += steps;
            }
        }

        /// <summary>
        /// Changes the <see cref="Outlook"/>.
        /// </summary>
        /// <param name="direction">Whether to turn left or right.</param>
        public void Turn(bool direction)
        {
            if (direction)
            {
               switch (this.Outlook)
                {
                    case 0:
                        this.Outlook++;
                        break;
                    case 1:
                        this.Outlook++;
                        break;
                    case 2:
                        this.Outlook++;
                        break;
                    case 3:
                        this.Outlook = 0;
                        break;
                }
            }
            else
            {
                switch (this.Outlook)
                {
                    case 0:
                        this.Outlook = 3;
                        break;
                    case 1:
                        this.Outlook--;
                        break;
                    case 2:
                        this.Outlook--;
                        break;
                    case 3:
                        this.Outlook--;
                        break;
                }
            }
        }
    }
}
