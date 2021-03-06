﻿// <copyright file="VisualBattleModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SillyBattleSimulation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that allows a <see cref="BattleModel"/> to be taken Visual.
    /// </summary>
    public class VisualBattleModel : Models.BattleModel
    {
        /// <summary>
        /// Method that allows two <see cref="VisualWarriorModel"/> to do Battle.
        /// </summary>
        /// <param name="visualWarrior1">First <see cref="VisualWarriorModel"/>.</param>
        /// <param name="visualWarrior2">Second <see cref="VisualWarriorModel"/>.</param>
        public void Battle(VisualWarriorModel visualWarrior1, VisualWarriorModel visualWarrior2)
        {
            if (visualWarrior1.Strength > visualWarrior2.Defence)
            {
                visualWarrior2.CurrentHealth -= (short)(visualWarrior1.Strength - visualWarrior2.Defence);
            }
            else if (visualWarrior1.Strength < visualWarrior2.Defence)
            {
                visualWarrior1.CurrentHealth -= (short)(visualWarrior2.Defence - visualWarrior1.Strength);
            }
            else
            {
                if (visualWarrior2.Strength > visualWarrior1.Defence)
                {
                    visualWarrior1.CurrentHealth -= (short)(visualWarrior2.Strength - visualWarrior1.Defence);
                }
                else if (visualWarrior2.Strength < visualWarrior1.Defence)
                {
                    visualWarrior2.CurrentHealth -= (short)(visualWarrior1.Defence - visualWarrior2.Strength);
                }
                else
                {
                    visualWarrior1.CurrentHealth--;
                    visualWarrior2.CurrentHealth--;
                }
            }
        }

        /// <summary>
        /// Method that allows two <see cref="VisualTeamModel"/> to do Battle.
        /// </summary>
        /// <param name="visualTeam1">First <see cref="VisualWarriorModel"/>.</param>
        /// <param name="visualTeam2">Second <see cref="VisualWarriorModel"/>.</param>
        public void TeamBattle(VisualTeamModel visualTeam1, VisualTeamModel visualTeam2)
        {
            if (visualTeam1.VisualTeamMembers.Count <= visualTeam2.VisualTeamMembers.Count)
            {
                foreach (var item in visualTeam1.VisualTeamMembers)
                {
                    this.Battle(item, visualTeam2.VisualTeamMembers.SingleOrDefault(x => x.PositionY == item.PositionY));
                }
            }
            else if (visualTeam1.VisualTeamMembers.Count > visualTeam2.VisualTeamMembers.Count)
            {
                foreach (var item in visualTeam2.VisualTeamMembers)
                {
                    this.Battle(item, visualTeam1.VisualTeamMembers.SingleOrDefault(x => x.PositionY == item.PositionY));
                }
            }
        }
    }
}