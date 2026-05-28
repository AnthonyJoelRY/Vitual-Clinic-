using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer player;
    [SerializeField] GameObject videoButtons;
    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] GameObject nextButton;

    public void Start()
    {
        player.prepareCompleted += ChangeLoadText;
        player.started += HideUI;
        player.loopPointReached += ShowUI;
    }
    public void ChangeLoadText(VideoPlayer vp)
    {
        loadingText.text = "El video ha finalizado";
    }
    void HideUI(VideoPlayer vp)
    {
        videoButtons.SetActive(false);
        nextButton.SetActive(false);

    }
    public void ShowUI(VideoPlayer vp)
    {
        videoButtons.SetActive(true);
        nextButton.SetActive(true);
    }

    public void PlayVideo()
    {
        player.Play();
    }
}
