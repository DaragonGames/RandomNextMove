using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggily : MonoBehaviour
{
    private int jellyCounter = 0;
    private bool canJiggle = true;
    private bool isCollectedPuzzle;
    private AudioSource _audioSource;
    [SerializeField] private List<GameObject> posList;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
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
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
            _audioSource.Play();
        }

        if (jellyCounter < posList.Count)
        {
            transform.position = posList[jellyCounter].transform.position;
            transform.rotation = posList[jellyCounter].transform.rotation;
        }
        
        yield return new WaitForSeconds(.5f);
        canJiggle = true;
    }
}
