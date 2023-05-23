using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupQuadDamage : MonoBehaviour
{
    public int multiplier = 4;
    public float duration = 10f;

    private void OnTriggerEnter(Collider other) {
        StatusController sc = other.GetComponentInChildren<StatusController>();
        if (sc != null) {
            Weapon weapon = other.GetComponentInChildren<Weapon>();
            if (weapon != null) {
                StatusExtraDamage qd = other.gameObject.AddComponent<StatusExtraDamage>();
                qd.duration = duration;
                qd.multiplier = multiplier;
                qd.weapon = weapon;

                sc.ApplyStatus(qd);

                Destroy(gameObject);
            }
        }
    }
}
