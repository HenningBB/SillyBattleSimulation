// <copyright file="MainWindowView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation
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
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using SillyBattleSimulation.ViewModels;

    /// <summary>
    /// View for the <see cref="MainWindowViewModel"/>.
    /// </summary>
    public partial class MainWindowView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowView"/> class.
        /// </summary>
        public MainWindowView()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
}
