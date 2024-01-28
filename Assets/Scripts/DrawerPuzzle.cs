using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerPuzzle : MonoBehaviour
{
    public GameObject[] drawers;
    public float[] extension = new float[3];
    public void InteractWithDrawer(int id)
    {
        switch (id) {
            case 0:
                if (extension[0] >0)
                {                    
                    drawers[0].transform.position -= Vector3.forward*extension[0]; 
                    extension[0]=0f; 
                    if (extension[1] == 0) 
                    {
                        extension[1]=0.6f;  
                        drawers[1].transform.position += Vector3.forward*extension[1]; 
                    }     
                }
                else
                {
                    extension[0]=0.6f;
                    drawers[0].transform.position += Vector3.forward*extension[0];  
                    if (extension[2]>0)
                    {
                        drawers[2].transform.position -= Vector3.forward*extension[2];    
                        extension[2]=0f; 
                    }
                }
            break;
            case 1:
                if (extension[1] >0)
                {                    
                    drawers[1].transform.position -= Vector3.forward*extension[1]; 
                    extension[1]=0f; 
                    if (extension[2] < 0.6f) 
                    {
                        extension[2]+=0.2f;  
                        drawers[2].transform.position += Vector3.forward*0.2f; 
                    }
                    
                     
                }
                else
                {
                    extension[1]=0.6f;
                    drawers[1].transform.position += Vector3.forward*extension[1];  
                    if (extension[2]>0)
                    {
                        drawers[2].transform.position -= Vector3.forward*extension[2];    
                        extension[2]=0f; 
                    }
                }
            break;
            case 2:
                if (extension[2] >0)
                {
                    for (int i=0; i<3; i++)
                    {
                        drawers[i].transform.position -= Vector3.forward*extension[i];    
                        extension[i]=0f; 
                    }
                }
                else
                {
                    extension[2]=0.2f;
                    drawers[2].transform.position += Vector3.forward*0.2f;
                    if (extension[0]==0f)
                    {
                        extension[0]=0.6f;
                        drawers[0].transform.position += Vector3.forward*extension[0];  
                    }
                }
            break;
        }
        
        
    }
}
