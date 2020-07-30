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

    public class SegmentModel : BaseModel
    {
        private Point from;
        private Point to;

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentModel"/> class.
        /// </summary>
        public SegmentModel(Point from,Point to)
        {
            this.From = from;
            this.To = to;
        }

        public Point From
        {
            get => this.from;
            set => this.SetProperty(ref this.from, value);
        }

        public Point To
        {
            get => this.to;
            set => this.SetProperty(ref this.to, value);
        }
    }
}
