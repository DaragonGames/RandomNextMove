using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject puzzlePieces;
    [SerializeField] private GameObject collectiblePuzzleItem;
    [SerializeField] private GameObject postIt;
    
    public static GameManager Instance;
    
    private AudioSource _audioSource;
    private int puzzleCount;
    
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
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        EventManager.Instance.onAllPuzzlesCollected += () =>
        {
            if (postIt != null)
            {
                Destroy(postIt);
            }
            cameraController.SetActive(true);
            puzzlePieces.SetActive(true);
        };
    }

    public void InstantiatePuzzlePiece(Transform pos)
    {
        Instantiate(collectiblePuzzleItem, pos.position, collectiblePuzzleItem.transform.rotation);
    }

    public void PlayCollectMusic()
    {
        _audioSource.Play();
    }

    public void UpdatePuzzleCount()
    {
        puzzleCount++;

        if (puzzleCount >= 9)
        {
            StartCoroutine(EndSceneCoroutine());
        }
    }

    private IEnumerator EndSceneCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
