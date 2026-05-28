using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLoopSize : MonoBehaviour
{
    [SerializeField] RectTransform mainBtn;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.size(mainBtn, mainBtn.sizeDelta * 1.1f, 0.5f).setDelay(2f).setRepeat(6).setLoopPingPong(-1);
    }
}
