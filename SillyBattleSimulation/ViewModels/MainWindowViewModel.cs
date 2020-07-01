// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Views;

    /// <summary>
    /// Class of the Main View.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        private object simulation;
        private object visualSimulation;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.Simulation = new SimulationViewModel();
            this.VisualSimulation = new VisualSimulationViewModel();
        }

        /// <summary>
        /// Gets or sets the currently selected Viewmodel.
        /// </summary>
        public object Simulation
        {
            get => this.simulation;
            set => this.SetProperty(ref this.simulation, value);
        }

        /// <summary>
        /// Gets or sets the currently selected Viewmodel.
        /// </summary>
        public object VisualSimulation
        {
            get => this.visualSimulation;
            set => this.SetProperty(ref this.visualSimulation, value);
        }
    }
}
