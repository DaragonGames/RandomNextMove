using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puzzleText;
    [SerializeField] private GameObject postItRender;
    private int puzzleAmount = 0;
    private void Start()
    {
        EventManager.Instance.onPuzzleCollected += UpdatePuzzleText;
        EventManager.Instance.onPostItPickUp += GetPostIt;
    }

    private void UpdatePuzzleText()
    {
        puzzleAmount++;
        if (puzzleAmount >= 6)
        {
            postItRender.SetActive(false);
            EventManager.Instance.onAllPuzzlesCollected?.Invoke();
        }
        puzzleText.text = $"{puzzleAmount}/6";
    }

    private void GetPostIt()
    {
        postItRender.SetActive(true);
    }
}
