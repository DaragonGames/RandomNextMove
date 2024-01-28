using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NopeSound : MonoBehaviour
{
    public AudioClip[] clips;

    void Start()
    {
        GetComponent<AudioSource>().clip = clips[(int)(Random.value*clips.Length)];
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 7f);
    }

}
