using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : InteractableObject
{
    public GameObject prefab;
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    protected override void TryInteraction(InteractableObject obj)
    {
        if (obj.objectName == "BrokenFurniture")
        {
            Instantiate(prefab, obj.transform.position, Quaternion.identity);
            
            var objectPos = obj.transform;
            objectPos.position += Vector3.up*2;
            
            GameManager.Instance.InstantiatePuzzlePiece(objectPos);
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            Destroy(obj.gameObject);  
        }
        else
        {
            Instantiate(nopeSound, Vector3.one, Quaternion.identity);
        }

    }
    protected override void TryUsage() {}
}
