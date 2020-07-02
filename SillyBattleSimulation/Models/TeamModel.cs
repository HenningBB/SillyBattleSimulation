// <copyright file="TeamModel.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Class that Represents a Team to which a <see cref="WarriorModel"/> belongs.
    /// </summary>
    public class TeamModel : BaseModel
    {
        private ObservableCollection<WarriorModel> teamMembers;
        private int teamSize;

        private int strengthZero;
        private int strengthOne;
        private int strengthTwo;
        private int strengthThree;
        private int strengthFour;
        private int strengthFive;
        private int strengthSix;
        private int strengthSeven;
        private int strengthEight;
        private int strengthNine;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamModel"/> class.
        /// </summary>
        public TeamModel()
        {
            this.teamMembers = new ObservableCollection<WarriorModel>();
        }

        /// <summary>
        /// Gets or sets the List of Warriors.
        /// </summary>
        public ObservableCollection<WarriorModel> TeamMembers
        {
            get => this.teamMembers;
            set => this.SetProperty(ref this.teamMembers, value);
        }

        /// <summary>
        /// Gets or sets the Size of the Team.
        /// </summary>
        public int TeamSize
        {
            get => this.teamSize;
            set => this.SetProperty(ref this.teamSize, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Zero.
        /// </summary>
        public int StrengthZero
        {
            get => this.strengthZero;
            set => this.SetProperty(ref this.strengthZero, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength One.
        /// </summary>
        public int StrengthOne
        {
            get => this.strengthOne;
            set => this.SetProperty(ref this.strengthOne, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Two.
        /// </summary>
        public int StrengthTwo
        {
            get => this.strengthTwo;
            set => this.SetProperty(ref this.strengthTwo, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Three.
        /// </summary>
        public int StrengthThree
        {
            get => this.strengthThree;
            set => this.SetProperty(ref this.strengthThree, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Four.
        /// </summary>
        public int StrengthFour
        {
            get => this.strengthFour;
            set => this.SetProperty(ref this.strengthFour, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Five.
        /// </summary>
        public int StrengthFive
        {
            get => this.strengthFive;
            set => this.SetProperty(ref this.strengthFive, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Six.
        /// </summary>
        public int StrengthSix
        {
            get => this.strengthSix;
            set => this.SetProperty(ref this.strengthSix, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Seven.
        /// </summary>
        public int StrengthSeven
        {
            get => this.strengthSeven;
            set => this.SetProperty(ref this.strengthSeven, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Eight.
        /// </summary>
        public int StrengthEight
        {
            get => this.strengthEight;
            set => this.SetProperty(ref this.strengthEight, value);
        }

        /// <summary>
        /// Gets or sets the number of Warriors with Strength Nine.
        /// </summary>
        public int StrengthNine
        {
            get => this.strengthNine;
            set => this.SetProperty(ref this.strengthNine, value);
        }

        /// <summary>
        /// Generates a new Warrior for the Team.
        /// </summary>
        public void AddRandomWarrior()
        {
            WarriorModel warrior = new WarriorModel();
            warrior.Index = Convert.ToInt16(this.TeamMembers.Count);
            this.TeamMembers.Add(warrior);
            this.TeamSize = this.TeamMembers.Count;
            if (warrior.Strength == 0)
            {
                this.StrengthZero++;
            }
            else if (warrior.Strength == 1)
            {
                this.StrengthOne++;
            }
            else if (warrior.Strength == 2)
            {
                this.StrengthTwo++;
            }
            else if (warrior.Strength == 3)
            {
                this.StrengthThree++;
            }
            else if (warrior.Strength == 4)
            {
                this.StrengthFour++;
            }
            else if (warrior.Strength == 5)
            {
                this.StrengthFive++;
            }
            else if (warrior.Strength == 6)
            {
                this.StrengthSix++;
            }
            else if (warrior.Strength == 7)
            {
                this.StrengthSeven++;
            }
            else if (warrior.Strength == 8)
            {
                this.StrengthEight++;
            }
            else
            {
                this.StrengthNine++;
            }
        }

        /// <summary>
        /// Adds an <see cref="WarriorModel"/> to the Team.
        /// </summary>
        /// <param name="model">The <see cref="WarriorModel"/> to Add.</param>
        public void AddWarrior(WarriorModel model)
        {
            this.TeamMembers.Add(model);
        }

        /// <summary>
        /// Removes the first Warrior from the Team.
        /// </summary>
        public void RemoveWarrior()
        {
            WarriorModel warrior = this.TeamMembers[0];
            if (warrior.Strength == 0)
            {
                this.StrengthZero--;
            }
            else if (warrior.Strength == 1)
            {
                this.StrengthOne--;
            }
            else if (warrior.Strength == 2)
            {
                this.StrengthTwo--;
            }
            else if (warrior.Strength == 3)
            {
                this.StrengthThree--;
            }
            else if (warrior.Strength == 4)
            {
                this.StrengthFour--;
            }
            else if (warrior.Strength == 5)
            {
                this.StrengthFive--;
            }
            else if (warrior.Strength == 6)
            {
                this.StrengthSix--;
            }
            else if (warrior.Strength == 7)
            {
                this.StrengthSeven--;
            }
            else if (warrior.Strength == 8)
            {
                this.StrengthEight--;
            }
            else
            {
                this.StrengthNine--;
            }

            this.TeamMembers.Remove(warrior);
            this.TeamSize = this.TeamMembers.Count;
        }

        /// <summary>
        /// Removes a specific Warrior from the Team.
        /// </summary>
        /// <param name="warrior">the warrior to remove.</param>
        public void RemoveWarrior(WarriorModel warrior)
        {
            if (warrior.Strength == 0)
            {
                this.StrengthZero--;
            }
            else if (warrior.Strength == 1)
            {
                this.StrengthOne--;
            }
            else if (warrior.Strength == 2)
            {
                this.StrengthTwo--;
            }
            else if (warrior.Strength == 3)
            {
                this.StrengthThree--;
            }
            else if (warrior.Strength == 4)
            {
                this.StrengthFour--;
            }
            else if (warrior.Strength == 5)
            {
                this.StrengthFive--;
            }
            else if (warrior.Strength == 6)
            {
                this.StrengthSix--;
            }
            else if (warrior.Strength == 7)
            {
                this.StrengthSeven--;
            }
            else if (warrior.Strength == 8)
            {
                this.StrengthEight--;
            }
            else
            {
                this.StrengthNine--;
            }

            this.TeamMembers.Remove(warrior);
            this.TeamSize = this.TeamMembers.Count;
        }
    }
}
