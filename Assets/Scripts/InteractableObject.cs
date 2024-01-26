using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public static GameObject selected=null;
    public bool pickUpAble=true;
    public string objectName = "Ball";

    private Vector3 mousePosition;
    private Vector3 backUpPosition;

    void Start()
    {
        backUpPosition=transform.position;
    }

    void Update()
    {
        if (selected != gameObject) {return;}
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        if (newPos.y < 1) {
            newPos.y =1;
        }
        transform.position = newPos  - Vector3.up*100;
    }

    void OnMouseOver() {
        Debug.Log(objectName);
        if (Input.GetMouseButtonDown(0))
        {
            if (selected == null)
            {
                GetSelected();
            }
            else
            {
                TryInteraction();
            }
        }
    }

    private void GetSelected()
    {
        selected = gameObject;
        mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.GetChild(0).transform.localPosition = new Vector3(0,100,0);
        transform.position = transform.position - Vector3.up*100;
    }

    private void TryInteraction()
    {
        // ToDO try Interaction Between this and the selected Object
        selected.GetComponent<InteractableObject>().ResetPosition();
        selected = null;
    }

    public void ResetPosition()
    {
        transform.GetChild(0).transform.localPosition = new Vector3(0,0,0);
        transform.position = backUpPosition;
    }

    


}
