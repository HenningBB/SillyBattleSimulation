// <copyright file="Command.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Class that implements the <see cref="ICommand"/> Interface.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<object> executeAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="execute">Which Command to execute.</param>
        public Command(Action<object> execute)
        {
            this.executeAction = execute;
        }

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}
