using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableTile : BurnableBase, EmissionReceiver, Burnable, Killable
{
    private Color baseColour;

    private void Awake()
    {
        baseColour = GetComponent<SpriteRenderer>().color;
    }

    protected override void UpdateBurnView()
    {
        Color c = Color.Lerp(baseColour, Color.red, (float)(maxBurnHP - burnHP) / 200);
        GetComponent<SpriteRenderer>().color = c;
    }

    protected override EmitterBase CreateEmitter()
    {
        return gameObject.AddComponent(typeof(Emitter2D)) as Emitter2D;
    }

    public override void Ignite()
    {
        base.Ignite();
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
