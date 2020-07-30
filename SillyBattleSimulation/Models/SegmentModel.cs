// <copyright file="SegmentModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Class that represents an Line on a Graph.
    /// </summary>
    public class SegmentModel : BaseModel
    {
        private Point from;
        private Point to;

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentModel"/> class.
        /// </summary>
        /// <param name="from">The starting Point.</param>
        /// <param name="to">The end Point.</param>
        public SegmentModel(Point from, Point to)
        {
            this.From = from;
            this.To = to;
        }

        /// <summary>
        /// Gets or sets the starting Point.
        /// </summary>
        public Point From
        {
            get => this.from;
            set => this.SetProperty(ref this.from, value);
        }

        /// <summary>
        /// Gets or sets the end Point.
        /// </summary>
        public Point To
        {
            get => this.to;
            set => this.SetProperty(ref this.to, value);
        }
    }
}
