using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    
    private bool canFinish;
    private float scrollSpeed = 50f;
    private float endOffset = 100f;

    private void Update()
    {
        credits.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        
        //Check if the text is out of the screen
        if (credits.transform.position.y > Screen.height + endOffset)
        {
            SceneManager.LoadScene(0);
        }
    }
}
