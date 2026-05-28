using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class E_StartSound : MonoBehaviour, IEffect
{
    [SerializeField] AudioSource musicClip;
    [SerializeField] bool stopMusic;

    public void ActivateEffect()
    {
        if (stopMusic)
        {
            musicClip.Stop();
        }
        else
        {
            musicClip.Play();
        }

    }
}
