using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_MoveObject : MonoBehaviour, IEffect
{
    [SerializeField] GameObject objectToMove;
    [SerializeField] Transform moveTo;

    public void ActivateEffect()
    {
        LeanTween.move(objectToMove, moveTo.localPosition, 0.7f);
        LeanTween.rotate(objectToMove,moveTo.eulerAngles, 0.7f);
    }

}
