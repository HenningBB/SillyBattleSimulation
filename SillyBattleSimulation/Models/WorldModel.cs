// <copyright file="WorldModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that creates a List of <see cref="CellModel"/>.
    /// </summary>
    public class WorldModel : BaseModel
    {
        private ObservableCollection<CellModel> world;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldModel"/> class.
        /// </summary>
        public WorldModel()
        {
            this.World = new ObservableCollection<CellModel>();
            for (int i = 0; i < 10; i++)
            {
                CellModel model = new CellModel();
                this.World.Add(model);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldModel"/> class.
        /// </summary>
        /// <param name="size">How many <see cref="CellModel"/> there are in the List.</param>
        public WorldModel(int size)
        {
            this.World = new ObservableCollection<CellModel>();
            for (int i = 0; i < size; i++)
            {
                CellModel model = new CellModel();
                this.World.Add(model);
            }
        }

        /// <summary>
        /// Gets or sets the World.
        /// </summary>
        public ObservableCollection<CellModel> World
        {
            get => this.world;
            set => this.SetProperty(ref this.world, value);
        }
    }
}
