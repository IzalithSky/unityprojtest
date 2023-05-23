using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour 
{
    public float duration = 1f;

    float startTime = 0f;
    bool isActive = true;

    void Start() {
        startTime = Time.time;
    }

    void FixedUpdate() {
        if (Time.time - startTime < duration) {
            Apply();
        } else {
            isActive = false;
        }
    }

    public bool IsActive() {
        return isActive;
    }

    public virtual void Apply() {}
    public virtual void RemoveStatus() {}
}
