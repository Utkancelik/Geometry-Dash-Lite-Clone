using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        // To keep the information about music to the next level
        DontDestroyOnLoad(this.gameObject);
    }

    public void AuidoON()
    {
        audioSource.volume = 1.0f;
    }

    public void AudioOFF()
    {
        audioSource.volume = 0.0f;
    }
}
