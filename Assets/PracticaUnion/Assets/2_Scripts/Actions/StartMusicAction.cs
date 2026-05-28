using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicAction : MonoBehaviour
{
    [SerializeField] AudioSource musicClip;

    public void Start()
    {
        LeanTween.delayedCall(1f, PlayMusic);
    }

    public void PlayMusic()
    {
        musicClip.Play();
    }
}
