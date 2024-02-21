using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableCrate : BurnableBase
{
    [SerializeField] private GameObject fireParticle;
    [SerializeField] private GameObject crate, burntCrate;

    protected override void UpdateBurnView()
    {
        // possibly animate crate prior to igniting
    }

    protected override EmitterBase CreateEmitter()
    {
        return gameObject.AddComponent(typeof(Emitter3D)) as Emitter3D;
    }

    public override void Ignite()
    {
        base.Ignite();
        fireParticle.SetActive(true);
        crate.SetActive(false);
        burntCrate.SetActive(true);
    }
}
