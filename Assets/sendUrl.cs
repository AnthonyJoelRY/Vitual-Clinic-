using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class sendUrl : MonoBehaviour
{
    [SerializeField] string urlString;
    [SerializeField] VideoPlayer vp;
    private AudioSource[] allAudioSources;
    void Awake() {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }
    public void sendUrlToCamera()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }
        vp.url = urlString;

    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
