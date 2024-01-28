using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour
{
    private bool isLocked;
    private float posY;
    private bool isSelected;
    
    void Start()
    {
        posY = transform.position.y;
    }

    void Update()
    {
        if(isLocked || isSelected == false) return;
        
        // Catch the Moment when Mouse Button is lifted
        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
        {
            transform.position = new Vector3(raycastHit.point.x, posY, raycastHit.point.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            transform.position = other.gameObject.transform.position;
            isLocked = true;
            GameManager.Instance.UpdatePuzzleCount();
        }
    }
    
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            if (isSelected == false)
            {
                isSelected = true;
            }
        }
    }
}
