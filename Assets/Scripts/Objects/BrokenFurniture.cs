using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFurniture : InteractableObject
{
    protected override void TryInteraction(InteractableObject obj) {}
    protected override void TryUsage() {
        transform.GetChild(0).GetComponent<Animator>().Play("Play");
        EventManager.Instance.onPuzzleCollected.Invoke();
    }
}
