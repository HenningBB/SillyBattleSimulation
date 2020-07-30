// <copyright file="CoolGraphViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using SillyBattleSimulation.Commands;
    using SillyBattleSimulation.Models;

    /// <summary>
    /// Class of the CollGraphView.
    /// </summary>
    public class CoolGraphViewModel : BaseViewModel
    {
        private string test;
        private int updateX;
        private int updateY;
        private ObservableCollection<SegmentModel> polo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolGraphViewModel"/> class.
        /// </summary>
        public CoolGraphViewModel()
        {
            this.GraphHeigth = 200; // inversed
            this.GraphWidth = 200;
            this.Polo = new ObservableCollection<SegmentModel>();
            this.Polo.Add(new SegmentModel(new Point(0, this.GraphHeigth), new Point(10, this.GraphHeigth)));
            this.updateX = 10;
            this.updateY = this.GraphHeigth;
            this.Test = "Hallo Welt";
            this.MathCommand = new Command(this.Mather);
            this.MathicCommand = new Command(this.Mathic);
            this.MathixCommand = new Command(this.Mathix);
            this.MathoxCommand = new Command(this.Mathox);
        }

        public int GraphWidth { get; private set; }

        public int GraphHeigth { get; private set; }

        public string Test
        {
            get => this.test;
            set => this.SetProperty(ref this.test, value);
        }

        public ObservableCollection<SegmentModel> Polo
        {
            get => this.polo;
            set => this.SetProperty(ref this.polo, value);
        }

        public ICommand MathCommand { get; private set; }

        public ICommand MathicCommand { get; private set; }

        public ICommand MathixCommand { get; private set; }

        public ICommand MathoxCommand { get; private set; }

        private void Mather(object commandParameter)
        {
            this.UpdateGraph(10);
        }

        private void Mathic(object commandParameter)
        {
            this.UpdateGraph(20);
        }

        private void Mathix(object commandParameter)
        {
            this.UpdateGraph(-10);
        }

        private void Mathox(object commandParameter)
        {
            this.UpdateGraph(-20);
        }

        private void UpdateGraph(int yChange)
        {
            // int minX = 0; not needed, because it is the starting Point
            int maxX = this.GraphWidth;
            int minY = 0;
            int maxY = this.GraphHeigth;

            this.updateX += 10;
            this.updateY += yChange;

            if (this.updateX > maxX)
            {
                this.Polo.Remove(this.Polo[0]);
                foreach (var item in this.Polo)
                {
                    item.From = new Point(item.From.X - 10, item.From.Y);
                    item.To = new Point(item.To.X - 10, item.To.Y);
                }

                this.updateX = maxX;
            }

            if (this.updateY < minY && yChange < 0)
            {
                this.updateY = minY;
            }

            if (this.updateY > maxY && yChange > 0)
            {
                this.updateY = maxY;
            }

            this.Polo.Add(new SegmentModel(this.Polo[this.Polo.Count - 1].To, new Point(this.updateX, this.updateY)));

            // this.Test = this.updateY.ToString();
        }
    }
}
