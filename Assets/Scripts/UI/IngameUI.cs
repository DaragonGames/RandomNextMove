using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puzzleText;
    private int puzzleAmount = 0;
    private void Start()
    {
        EventManager.Instance.onPuzzleCollected += UpdatePuzzleText;
    }

    private void UpdatePuzzleText()
    {
        puzzleAmount++;
        if (puzzleAmount >= 5)
        {
            EventManager.Instance.onAllPuzzlesCollected?.Invoke();
        }
        puzzleText.text = $"{puzzleAmount}/5";
    }
}
