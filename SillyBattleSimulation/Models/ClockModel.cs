// <copyright file="ClockModel.cs" company="PlaceholderCompany">
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
    /// Class tht represents the clock.
    /// </summary>
    public class ClockModel : BaseModel
    {
        private double angle;

        /// <summary>
        /// Gets or sets the Angle for the Transformation.
        /// </summary>
        public double Angle
        {
            get => this.angle;
            set => this.SetProperty(ref this.angle, value);
        }
    }
}
