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
        private int updateX;
        private int updateY;
        private ObservableCollection<SegmentModel> segments;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolGraphViewModel"/> class.
        /// </summary>
        public CoolGraphViewModel()
        {
            this.GraphHeigth = 200; // inversed
            this.GraphWidth = 200;
            this.Segments = new ObservableCollection<SegmentModel>();
            this.Segments.Add(new SegmentModel(new Point(0, this.GraphHeigth), new Point(10, this.GraphHeigth)));
            this.updateX = 10;
            this.updateY = this.GraphHeigth;
            this.MathCommand = new Command(this.Mather);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolGraphViewModel"/> class.
        /// </summary>
        /// <param name="heigth">The value for <see cref="GraphHeigth"/>.</param>
        /// <param name="width">The value for <see cref="GraphWidth"/>.</param>
        public CoolGraphViewModel(int heigth, int width)
        {
            this.GraphHeigth = heigth * 10; // inversed
            this.GraphWidth = width;
            this.Segments = new ObservableCollection<SegmentModel>();
            this.Segments.Add(new SegmentModel(new Point(0, 0), new Point(10, 0)));
            this.updateX = 10;
            this.updateY = 0;
            this.MathCommand = new Command(this.Mather);
        }

        /// <summary>
        /// Gets the Maximum Width of the Graph.
        /// </summary>
        public int GraphWidth { get; private set; }

        /// <summary>
        /// Gets the Maximum Heigth of the Graph.
        /// </summary>
        public int GraphHeigth { get; private set; }

        /// <summary>
        /// Gets or sets an Group of <see cref="Models.SegmentModel"/>.
        /// </summary>
        public ObservableCollection<SegmentModel> Segments
        {
            get => this.segments;
            set => this.SetProperty(ref this.segments, value);
        }

        /// <summary>
        /// Gets the Command to update the Graph.
        /// </summary>
        public ICommand MathCommand { get; private set; }

        public void UpdatetGraph(int yChange)
        {
            yChange *= 10;
            int step = 10;
            int maxX = this.GraphWidth;
            int minY = 0;
            int maxY = this.GraphHeigth;

            this.updateX += step;
            this.updateY = this.GraphHeigth - yChange;

            if (this.updateX > maxX)
            {
                this.Segments.Remove(this.Segments[0]);
                foreach (var item in this.Segments)
                {
                    item.From = new Point(item.From.X - step, item.From.Y);
                    item.To = new Point(item.To.X - step, item.To.Y);
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

            this.Segments.Add(new SegmentModel(this.Segments[this.Segments.Count - 1].To, new Point(this.updateX, this.updateY)));
        }

        private void Mather(object commandParameter)
        {
            this.UpdateGraph(10);
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
                this.Segments.Remove(this.Segments[0]);
                foreach (var item in this.Segments)
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

            this.Segments.Add(new SegmentModel(this.Segments[this.Segments.Count - 1].To, new Point(this.updateX, this.updateY)));
        }
    }
}
