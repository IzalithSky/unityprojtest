using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun0 : Tool {
    public GameObject projectilePrefab;
    public float fireForce = 20f;

    protected override void FireReady() {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, (null !=  lookPoint) ? lookPoint.rotation : firePoint.rotation);
        proj.GetComponent<Projectile>().launcher = owner;
        proj.GetComponent<Rigidbody>().AddForce(((null !=  lookPoint) ? lookPoint.forward : firePoint.forward) * fireForce, ForceMode.Impulse);
    }
}
