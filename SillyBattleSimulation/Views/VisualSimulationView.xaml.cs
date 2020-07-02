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
    public partial class VisualSimulationView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualSimulationView"/> class.
        /// </summary>
        public VisualSimulationView()
        {
            this.InitializeComponent();
        }
    }
}
