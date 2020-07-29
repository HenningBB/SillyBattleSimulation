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

    /// <summary>
    /// Class of the CollGraphView.
    /// </summary>
    public class CoolGraphViewModel : BaseViewModel
    {
        private string test;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolGraphViewModel"/> class.
        /// </summary>
        public CoolGraphViewModel()
        {
            this.Test = "Hallo Welt";
        }

        public string Test
        {
            get => this.test;
            set => this.SetProperty(ref this.test, value);
        }
    }
}
