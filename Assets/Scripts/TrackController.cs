using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class TrackController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] AudioSource mAudio;
    [SerializeField] Slider mAudioVolumen;

    [SerializeField] VideoPlayer mVideo;
    Slider tracking;
    bool slide = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        slide = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float frame = (float)tracking.value * (float)mVideo.frameCount;
        mVideo.frame = (long)frame;
        slide = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        tracking = GetComponent<Slider>();
    }

   

    

    // Update is called once per frame
    void Update()
    {
        if (!slide)
        {
            tracking.value = mVideo.frame / (float)mVideo.frameCount;
        }
    }


    public void Volume()
    {
        //mAudio.volume = mAudioVolumen.value;
        
        mVideo.SetDirectAudioVolume(0, mAudioVolumen.value);
    }
}
