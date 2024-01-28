using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : InteractableObject
{
    public Light myLight;
    public Image darkness;

    protected override void TryInteraction(InteractableObject obj) {}
    protected override void TryUsage() {
        myLight.intensity -=2;
        if (myLight.intensity < 1)
        {
            if (darkness.color.a ==0)
            {
                darkness.color= new Color(1,1,1,0.5f);
            }
            darkness.color= new Color(1,1,1,darkness.color.a +0.15f);
        }
        if (darkness.color.a > 0.95f)
        {
            StartCoroutine(DelayedAction());  
            
        }
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        EventManager.Instance.onPuzzleCollected.Invoke();
    }
}

