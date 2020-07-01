// <copyright file="VisualSimulationView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using SillyBattleSimulation.Models;
    using SillyBattleSimulation.ViewModels;

    /// <summary>
    /// Interaction logic for VisualSimulationView.xaml.
    /// </summary>
    public partial class VisualSimulationView : UserControl
    {
        public VisualSimulationView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualSimulationView"/> class.
        /// </summary>
        /// <param name="team1"><see cref="VisualSimulationViewModel.Team1"/>.</param>
        /// <param name="team2"><see cref="VisualSimulationViewModel.Team2"/>.</param>
        /// <param name="king1"><see cref="VisualSimulationViewModel.King1"/>.</param>
        /// <param name="king2"><see cref="VisualSimulationViewModel.King2"/>.</param>
        public VisualSimulationView(TeamModel team1, TeamModel team2, WarriorModel king1, WarriorModel king2)
        {
            this.InitializeComponent();
            this.DataContext = new VisualSimulationViewModel(team1, team2, king1, king2);
        }
    }
}
