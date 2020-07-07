﻿using UnityEngine;

namespace Cannon
{
    internal sealed class CannonBase
    {
        private Transform @base;

        public CannonBase(Transform @base)
        {
            this.@base = @base;
        }

        public void Rotate(float degrees)
        {
            @base.Rotate(0f, degrees * Time.deltaTime, 0f);
        }
    }
}