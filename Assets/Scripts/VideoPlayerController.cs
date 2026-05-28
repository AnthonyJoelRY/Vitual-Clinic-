using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour,IAction
{

    [SerializeField] GameObject mVideoCamera;
  GameObject mPlayer;
    [SerializeField] GameObject mUiVideo;
    [SerializeField] GameObject btnPlay;
    [SerializeField] GameObject btnPause;
    CursorController cc;

    [SerializeField] GameObject mUiGeneral;
    Vector3 lastMouseCoordinate = Vector3.zero;

    float timeLeft=3.0f;
    float visibleCursorTimer = 5.0f;
    float cursorPosition;
    bool catchCursor = true;
    void Update()
    {
        if (mUiVideo.activeSelf)
        {
            if (catchCursor)
            {
                catchCursor = false;
                cursorPosition = Input.GetAxis("Mouse X");
            }
            if (Input.GetAxis("Mouse X") == cursorPosition)
            {
                
                timeLeft -= Time.deltaTime;
                
                if (timeLeft < 0)
                {
                    mUiVideo.GetComponentInChildren<CanvasGroup>().LeanAlpha(0,2.0f);
                    timeLeft = visibleCursorTimer;
                    Cursor.visible = false;
                    catchCursor = true;
                }
            }
            else
            {
                timeLeft = visibleCursorTimer;
                Cursor.visible = true;
                mUiVideo.GetComponentInChildren<CanvasGroup>().alpha = 1;
            }
        }



        
    }
    public void Activate()
    {
        
        cc.ShowCursor();
        mVideoCamera.SetActive(true);
        mVideoCamera.GetComponent<VideoPlayer>().Play();
        mPlayer.SetActive(false);
        mUiVideo.SetActive(true);
        mUiGeneral.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        cc = GameObject.FindObjectOfType<CursorController>();
    }

    public void Deactivate()
    {
        //cc.HideCursor();
        mVideoCamera.SetActive(false);
        mVideoCamera.GetComponent<VideoPlayer>().Stop();
        mPlayer.SetActive(true);
        mUiVideo.SetActive(false);
        btnPlay.SetActive(false);
        btnPause.SetActive(true);
        mUiGeneral.SetActive(true);
    }


    public void ChangePlayButtonState()
    {

        btnPlay.SetActive(!btnPlay.activeSelf);
        btnPause.SetActive(!btnPause.activeSelf);
    }

   
}
