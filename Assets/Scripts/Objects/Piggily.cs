using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggily : MonoBehaviour
{
    private int jellyCounter = 0;
    private bool canJiggle = true;
    private bool isCollectedPuzzle;
    
    public void Jiggle()
    {
        if (canJiggle)
        {
            canJiggle = false;
            StartCoroutine(JiggleCounter());
            jellyCounter++;
        }

        if (jellyCounter >= 5 && !isCollectedPuzzle)
        {
            canJiggle = false;
            isCollectedPuzzle = true;

            gameObject.SetActive(false);
            GameManager.Instance.InstantiatePuzzlePiece(transform);
        }
    }

    private IEnumerator JiggleCounter()
    {
        yield return new WaitForSeconds(.5f);
        canJiggle = true;
    }
}
