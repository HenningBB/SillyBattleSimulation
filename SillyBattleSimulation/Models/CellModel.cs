// <copyright file="CellModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that represents a Worldcell.
    /// </summary>
    public class CellModel : BaseModel
    {
        private bool isActive;
        private char letter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CellModel"/> class.
        /// </summary>
        public CellModel()
        {
            this.Letter = '_';
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the cell is Active.
        /// </summary>
        public bool IsActive
        {
            get => this.isActive;
            set => this.SetProperty(ref this.isActive, value);
        }

        /// <summary>
        /// Gets or sets the letter.
        /// </summary>
        public char Letter
        {
            get => this.letter;
            set => this.SetProperty(ref this.letter, value);
        }
    }
}
