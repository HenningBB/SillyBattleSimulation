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
        private BaseViewModel currentViewModel;
        private bool change;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.CurrentViewModel = new SimulationViewModel();

            this.ChangeViewmodelCommand = new Command(this.ChangeViewModel);

            this.change = false;
        }

        /// <summary>
        /// Gets the Command to change the current Viewmodel.
        /// </summary>
        public ICommand ChangeViewmodelCommand { get; private set; }

        /// <summary>
        /// Gets or sets the currently selected Viewmodel.
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get => this.currentViewModel;
            set => this.SetProperty(ref this.currentViewModel, value);
        }

        private void ChangeViewModel(object commandParameter)
        {
            if (!this.change)
            {
                this.CurrentViewModel = new VisualSimulationViewModel();
            }
            else
            {
                this.CurrentViewModel = new SimulationViewModel();
            }

            this.change = !this.change;
        }
    }
}
