using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject puzzlePieces;
    
    private static GameManager Instance;
    
    // Singleton Check
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        EventManager.Instance.onAllPuzzlesCollected += () =>
        {
            cameraController.SetActive(true);
            puzzlePieces.SetActive(true);
        };
    }
}
