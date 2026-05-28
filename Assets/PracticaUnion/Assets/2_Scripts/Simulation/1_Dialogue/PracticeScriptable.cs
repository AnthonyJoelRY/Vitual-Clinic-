using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableData/Practice")]
public class PracticeScriptable : ScriptableObject
{
    [TextArea(5, 10)]
    public string[] sentence;
}
