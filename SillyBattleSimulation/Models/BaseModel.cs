// <copyright file="BaseModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class from which all Models should be derived.
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the PropertyChanged event to inform the View about the changed Property.
        /// </summary>
        /// <typeparam name="T">References the type of the caller.</typeparam>
        /// <param name="field">References the current value of th to be set field.</param>
        /// <param name="newValue">References the new value of ther to be set field.</param>
        /// <param name="propertyName">injects the name of the called property?.</param>
        /// <returns>Check if the new value is the old value.</returns>
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
