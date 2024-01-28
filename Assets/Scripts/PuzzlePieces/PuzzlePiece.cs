using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 20f * Time.deltaTime);
    }
    
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            Collect();
        }
    }

    private void Collect()
    {
        EventManager.Instance.onPuzzleCollected.Invoke();
        Destroy(gameObject);
    }
}