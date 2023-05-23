using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Tool {
    public int damage = 40;
    public int multiplier = 1;

    public int DealDamage() {
        return damage * multiplier;
    }

    public int GetMultiplier() {
        return multiplier;
    }

    public void SetMultiplier(int multiplier) {
        this.multiplier = multiplier;
    }
}
