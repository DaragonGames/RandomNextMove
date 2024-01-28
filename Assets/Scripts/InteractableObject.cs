using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public static GameObject selected=null;
    public bool pickUpAble=true;
    public bool Useable=false;
    public string objectName = "Ball";

    public Vector3 backUpPosition;

    void Start()
    {
        backUpPosition=transform.position;
    }

    void Update()
    {
        if (selected != gameObject) {return;}

        // Move with the Mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
        {
            Vector3 target = new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
            Vector3 direction = target -Camera.main.transform.position;
            transform.position = target -Vector3.up*100 - direction*0.2f;
        }

        // Catch the Moment when Mouse Button is lifted
        if (Input.GetMouseButtonUp(0))
        {
            InteractableObject obj = raycastHit.transform.GetComponent<InteractableObject>();
            EndSelection();
            if (obj != null)
            {
                TryInteraction(obj);
            }
            
        }
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            if (selected == null)
            {
                if (pickUpAble)
                {
                    GetSelected();
                }
                if (Useable)
                {
                    TryUsage();
                }
            }
            
        }
    }

    private void GetSelected()
    {
        selected = gameObject;        
        transform.GetChild(0).transform.localPosition = new Vector3(0,100,0);
        transform.position = transform.position - Vector3.up*100;
    }

    private void EndSelection()
    {
        selected = null;
        transform.GetChild(0).transform.localPosition = new Vector3(0,0,0);
        transform.position = backUpPosition;
    }

    protected abstract void TryInteraction(InteractableObject obj);

    protected abstract void TryUsage(); 

}
