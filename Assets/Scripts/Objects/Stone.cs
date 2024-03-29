using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : InteractableObject
{
    public GameObject brokenStone;    


    protected override void TryInteraction(InteractableObject obj) {
        if (obj.objectName == "Window")
        {
            transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>().Play("Play");
            StartCoroutine(DelayedAction());            
        }
        else
        {
            Instantiate(nopeSound, Vector3.one, Quaternion.identity);
        }

    }
    protected override void TryUsage() {}

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(brokenStone, transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
        Destroy(gameObject);
        var objectPos = transform;
        objectPos.position += Vector3.up;
        GameManager.Instance.InstantiatePuzzlePiece(objectPos);
    }
}
