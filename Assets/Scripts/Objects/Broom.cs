using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : InteractableObject
{


    protected override void TryInteraction(InteractableObject obj) {
        if (obj.objectName == "LeafPile")
        {
            // Broom in Position
            transform.position = obj.transform.position + Vector3.up*1.5f;

            // Start sucking Leaves
            obj.GetComponent<LeafPile>().done=true;
            StartCoroutine(DelayedAction()); 
            Destroy(obj.gameObject, 3f);
        }
    }
    protected override void TryUsage() {}

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(3f);
        transform.position = backUpPosition;
        GameManager.Instance.InstantiatePuzzlePiece(transform);
    }
}
