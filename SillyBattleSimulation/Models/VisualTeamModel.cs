// <copyright file="VisualTeamModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// Class that allows a <see cref="TeamModel"/> to be visualized.
    /// </summary>
    public class VisualTeamModel : TeamModel
    {
        private ObservableCollection<VisualWarriorModel> visualTeamMembers;
        private Brush colour;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTeamModel"/> class.
        /// </summary>
        /// <param name="model">The <see cref="TeamModel"/> to be visualized.</param>
        /// <param name="brush">The colour of the Team.</param>
        public VisualTeamModel(TeamModel model, Brush brush)
        {
            this.visualTeamMembers = new ObservableCollection<VisualWarriorModel>();
            this.TeamSize = model.TeamSize;

            this.AddVisualWarrior(model.TeamMembers[0]);
            this.VisualTeamMembers[0].Colour = brush;

            for (int i = 1; i < this.TeamSize; i++)
            {
                this.AddVisualWarrior(model.TeamMembers[i]);
                this.VisualTeamMembers[i].Colour = brush;
            }

            this.PlaceWarriors();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTeamModel"/> class.
        /// </summary>
        public VisualTeamModel()
        {
            this.visualTeamMembers = new ObservableCollection<VisualWarriorModel>();
        }

        /// <summary>
        /// Gets or sets the List of Visual Warriors.
        /// </summary>
        public ObservableCollection<VisualWarriorModel> VisualTeamMembers
        {
            get => this.visualTeamMembers;
            set => this.SetProperty(ref this.visualTeamMembers, value);
        }

        /// <summary>
        /// Gets or sets the Colour of the Team.
        /// </summary>
        public Brush Colour
        {
            get => this.colour;
            set => this.SetProperty(ref this.colour, value);
        }

        /// <summary>
        /// Adds an existing <see cref="WarriorModel"/> to the List.
        /// </summary>
        /// <param name="model">The <see cref="WarriorModel"/> to add.</param>
        public void AddVisualWarrior(WarriorModel model)
        {
            VisualWarriorModel visualWarrior = new VisualWarriorModel(model);
            this.VisualTeamMembers.Add(visualWarrior);
        }

        /// <summary>
        /// Adds an existing <see cref="VisualWarriorModel"/> to the List.
        /// </summary>
        /// <param name="visualModel">The <see cref="VisualWarriorModel"/> to add.</param>
        public void AddVisualWarrior(VisualWarriorModel visualModel)
        {
            this.VisualTeamMembers.Add(visualModel);
        }

        /// <summary>
        /// Removes a specific VisualWarrior from the Team.
        /// </summary>
        /// <param name="warrior">The VisualWarrior to remove.</param>
        public void RemoveVisualWarrior(VisualWarriorModel warrior)
        {
            this.VisualTeamMembers.Remove(warrior);
            this.TeamSize = this.VisualTeamMembers.Count;
        }

        /// <summary>
        /// Moves all in Outlook direction.
        /// </summary>
        public void MoveTeamVorward()
        {
            foreach (var item in this.VisualTeamMembers)
            {
                item.MoveVorward();
            }
        }

        /// <summary>
        /// Moves all in Outlook direction.
        /// </summary>
        /// <param name="steps">How far to move.</param>
        public void MoveTeamVorward(short steps)
        {
            foreach (var item in this.VisualTeamMembers)
            {
                item.MoveVorward(steps);
            }
        }

        /// <summary>
        /// Moves all opposite to Outlook direction.
        /// </summary>
        public void MoveTeamBackward()
        {
            foreach (var item in this.VisualTeamMembers)
            {
                item.MoveBackward();
            }
        }

        /// <summary>
        /// Moves all in Outlook direction.
        /// </summary>
        /// <param name="steps">How far to move.</param>
        public void MoveTeamBackward(short steps)
        {
            foreach (var item in this.VisualTeamMembers)
            {
                item.MoveBackward(steps);
            }
        }

        /// <summary>
        /// <see cref="VisualWarriorModel.Turn(bool)"/> for all Members.
        /// </summary>
        /// <param name="direction">Whether to turn left or right.</param>
        public void TurnTeam(bool direction)
        {
            foreach (var item in this.VisualTeamMembers)
            {
                item.Turn(direction);
            }
        }

        /// <summary>
        /// Places the Warriors in a Line.
        /// </summary>
        public void PlaceWarriors()
        {
            this.VisualTeamMembers[0].PositionY = 250;
            for (int i = 1; i < this.TeamSize; i++)
            {
                if (i % 2 == 0)
                {
                    this.VisualTeamMembers[i].PositionY = (short)(this.VisualTeamMembers[i - 1].PositionY + (i * 10));
                }
                else
                {
                    this.VisualTeamMembers[i].PositionY = (short)(this.VisualTeamMembers[i - 1].PositionY - (i * 10));
                }
            }
        }
    }
}
