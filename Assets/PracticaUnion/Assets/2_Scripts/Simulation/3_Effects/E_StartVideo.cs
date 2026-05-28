using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class E_StartVideo : MonoBehaviour, IEffect
{
    [SerializeField] VideoPlayer player;
    [SerializeField] GameObject videoUI;
    public void ActivateEffect()
    {
        videoUI.SetActive(true);
        PlayVideo();
    }

    public void PlayVideo()
    {
        player.Play();
    }

}
