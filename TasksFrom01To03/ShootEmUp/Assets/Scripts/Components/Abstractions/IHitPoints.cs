﻿using System;
using UnityEngine;


namespace ShootEmUp
{
    public interface IHitPoints
    {
        event Action<GameObject> HpEmpty;

        public int HitPoints {  get; set; }
        bool IsHitPointsExists();
        void TakeDamage(int damage);
    }
}