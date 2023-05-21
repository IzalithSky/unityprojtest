using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDot : Status
{
    public Damageable damageable;
    public float tickRate;
    public int damagePerTick;

    float nextTickTime = 0f;

    protected override void Apply()
    {
        if (Time.time >= nextTickTime)
        {            
            damageable.Hit(damagePerTick);
            nextTickTime = Time.time + tickRate;
        }
    }
}
