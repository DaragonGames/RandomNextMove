using System;
using UnityEngine;
using System.Collections.Generic;
 
public class DragThrow : MonoBehaviour
{
    private Vector3 mousePosition;
    private float posY;
    public LayerMask layerMask;
    private void Start()
    {
        posY = 1.5f;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y + 0.5f, raycastHit.point.z);
        }
    }
}