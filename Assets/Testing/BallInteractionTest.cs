using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallInteractionTest : InteractableObject
{
    public GameObject prefab;

    protected override void TryInteraction(InteractableObject obj)
    {
        if (obj.objectName == "BlueBall" && objectName == "RedBall")
        {
            Merge(obj);
        }
        if (objectName == "BlueBall" && obj.objectName == "RedBall")
        {
            Merge(obj);
        }
    }

    private void Merge(InteractableObject obj)
    {
        Instantiate(prefab, obj.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(obj.gameObject);        
    }

    protected override void TryUsage() 
    {

    }
}
