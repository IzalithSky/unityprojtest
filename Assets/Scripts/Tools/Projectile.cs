using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float timeoutSec = 4;
    public GameObject impactFlash;
    public GameObject explosion;
    public Light lt;
    public GameObject bmark;
    public float bmarkTtl = 20f;
    public int bmarkLimit = 4;
    public int damage = 60;
    public GameObject launcher; 

    private void OnCollisionEnter (Collision c) {
        GameObject impfl = Instantiate(impactFlash, c.contacts[0].point, Quaternion.LookRotation(c.contacts[0].normal));
        Destroy(impfl, impfl.GetComponent<ParticleSystem>().main.duration);

        GameObject e1 = Instantiate(explosion, c.contacts[0].point, Quaternion.LookRotation(c.contacts[0].normal));
        Destroy(e1, 1f);
        
        Destroy(gameObject);
        TryHit(c.gameObject);
    }

    void Start() {
        int projLayer = LayerMask.NameToLayer("Projectiles");
        Physics.IgnoreLayerCollision(projLayer, projLayer);

        // Ignore collisions between the projectile and the character that launched it.
        if (null != launcher) {
            Physics.IgnoreCollision(GetComponent<Collider>(), launcher.GetComponent<Collider>());
        }

        Destroy(gameObject, timeoutSec);
    }

    protected virtual void TryHit(GameObject go) {
        Damageable d = go.GetComponent<Damageable>();

        if (d != null) {
            d.Hit(damage);
        }
    }
}
