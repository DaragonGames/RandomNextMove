using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractableObject
{
    public Light myLight;

    protected override void TryInteraction(InteractableObject obj) {}
    protected override void TryUsage() {
        myLight.intensity -=2;
    }
}

