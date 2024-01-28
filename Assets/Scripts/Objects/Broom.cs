using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : InteractableObject
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    protected override void TryInteraction(InteractableObject obj) {
        if (obj.objectName == "LeafPile")
        {
            // Broom in Position
            transform.position = obj.transform.position + Vector3.up*1.5f;

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            // Start sucking Leaves
            obj.GetComponent<LeafPile>().done=true;
            
            StartCoroutine(DelayedAction(obj.transform)); 
            Destroy(obj.gameObject, 4f);
        }
        else
        {
            Instantiate(nopeSound, Vector3.one, Quaternion.identity);
        }
    }
    protected override void TryUsage() {}

    IEnumerator DelayedAction(Transform pos)
    {
        yield return new WaitForSeconds(3f);
        var objectPos = pos;
        objectPos.position += Vector3.up;

        transform.position = backUpPosition;
        GameManager.Instance.InstantiatePuzzlePiece(objectPos);
    }
}
