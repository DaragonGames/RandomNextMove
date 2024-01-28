using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostIt : MonoBehaviour
{
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            TakePostIt();
        }
    }

    private void TakePostIt()
    {
        EventManager.Instance.onPostItPickUp.Invoke();
        Destroy(gameObject);
    }
}
