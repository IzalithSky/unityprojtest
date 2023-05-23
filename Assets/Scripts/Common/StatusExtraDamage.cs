using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusExtraDamage : Status
{
    public int multiplier = 2;
    public Weapon weapon;

    int originalMultiplier;

    public override void Apply()
    {
        if (multiplier != weapon.GetMultiplier()) {
            originalMultiplier = weapon.GetMultiplier();
            weapon.SetMultiplier(multiplier);
        }
    }

    public override void RemoveStatus()
    {
        weapon.SetMultiplier(originalMultiplier);
    }
}
