using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    private bool canFinish;
    
    private void Update()
    {
        if (credits.transform.position.y >= 470 && !canFinish)
        {
            canFinish = true;
            StartCoroutine(EndCoroutine());
        }
    }

    private IEnumerator EndCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
