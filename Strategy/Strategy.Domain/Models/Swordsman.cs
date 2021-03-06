﻿using System;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman : Unit
    {
        public Swordsman(Player player) : base (player)
        {

        }

        protected override string PathToImage { get => "Resources/Ground/Swordsman.png"; }

        private int hp = 100;
        protected override int Hp { get => hp; set => hp = value; }
        protected override int MaximumAttackDistance => 1;

        protected override int MaximumMoveDistance => 5;

        public override int DamageValue(int tx, int ty)
        {
            return 50;
        }

    }
}