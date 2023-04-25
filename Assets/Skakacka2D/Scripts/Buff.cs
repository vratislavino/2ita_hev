using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    protected float duration;
    protected float remainingTime;
    protected int stacks;

    private float buffForce = 1.5f;

    public float GetMultiplier() {
        return Mathf.Pow(buffForce, stacks);
    }

    public void Init(float duration) {
        this.duration = duration;
        Collect();
    }

    public void Collect() {
        stacks++;
        remainingTime = duration;
    }

    protected virtual void Update() {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0) {
            stacks--;
            remainingTime = duration;
            if (stacks <= 0) {
                Destroy(this);
            }
        }
    }
}
