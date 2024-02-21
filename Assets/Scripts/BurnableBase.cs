using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableBase : MonoBehaviour, EmissionReceiver, Burnable, Killable
{
    protected float maxBurnHP = 30;
    protected float burnHP = 30;
    protected bool isBurning;

    public virtual void Die()
    {
        Destroy(gameObject, 5);
    }

    public virtual void Ignite()
    {
        isBurning = true;

        EmitterBase em = CreateEmitter();
        em.SetParameters(0.1f, 0.75f, "fire");
        Invoke(nameof(Die), 5);
    }

    public void ReceiveMessage(string channel)
    {
        if (channel.Equals("fire"))
            TakeFireDamage(1);
    }

    public void TakeFireDamage(int d)
    {
        if(!isBurning)
        {
            burnHP = Mathf.Clamp(burnHP - d, 0, 100);
            if (burnHP == 0)
                Ignite();
            else
            {
                UpdateBurnView();
            }
        }
    }

    protected virtual void UpdateBurnView()
    {
        // customize the appearance of burning for particular GameObject in subclasses
    }

    protected virtual EmitterBase CreateEmitter()
    {
        // override in subclass and return specific emitter
        return null;
    }
}
