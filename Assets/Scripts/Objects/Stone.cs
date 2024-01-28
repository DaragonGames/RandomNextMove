using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : InteractableObject
{
    public GameObject brokenStone;

    protected override void TryInteraction(InteractableObject obj) {
        if (obj.objectName == "Window")
        {
            StartCoroutine(DelayedAction());
            GetComponent<Animator>();
        }

    }
    protected override void TryUsage() {}

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(brokenStone, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
