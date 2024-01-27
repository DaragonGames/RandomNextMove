using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : InteractableObject
{
    protected override void TryInteraction(InteractableObject obj) {
        if (obj.objectName == "Window")
        {
            // TODO: Do the Thing
        }

    }
    protected override void TryUsage() {}
}
