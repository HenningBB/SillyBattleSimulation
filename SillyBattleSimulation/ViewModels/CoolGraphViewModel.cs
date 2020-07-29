// <copyright file="CoolGraphViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Class of the CollGraphView.
    /// </summary>
    public class CoolGraphViewModel : BaseViewModel
    {
        private string test;
        private PointCollection polo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolGraphViewModel"/> class.
        /// </summary>
        public CoolGraphViewModel()
        {
            this.Polo = new PointCollection();
            this.Polo.Add(new Point(10, 10));
            this.Polo.Add(new Point(20, 20));
            this.Test = "Hallo Welt";
        }

        public string Test
        {
            get => this.test;
            set => this.SetProperty(ref this.test, value);
        }

        public PointCollection Polo
        {
            get => this.polo;
            set => this.SetProperty(ref this.polo, value);
        }
    }
}
