using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : InteractableObject
{
    public GameObject prefab;

    protected override void TryInteraction(InteractableObject obj)
    {
        if (obj.objectName == "BrokenFurniture")
        {
            Instantiate(prefab, obj.transform.position, Quaternion.identity);
            Destroy(obj.gameObject);  
        }

    }
    protected override void TryUsage() {}
}