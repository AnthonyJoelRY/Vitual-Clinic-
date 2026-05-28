using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChager : MonoBehaviour
{
    public static CursorChager instance;

    public enum CursorStates
    {
        basicHand,
        selectionHand,
        normalCursor,
        instrumentCursor
    }

    public CursorStates cursorState = CursorStates.basicHand;
    public Texture2D[] cursors;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Texture2D tex = cursors[(int)cursorState];

        float xspot = tex.width / 2;
        float yspot = tex.height / 2;
        Vector2 hotSpot = new Vector2(xspot, yspot);

        Cursor.SetCursor(tex, hotSpot, CursorMode.Auto);

    }

    public void ChangeCursor(CursorStates state)
    {
        Cursor.SetCursor(cursors[(int)state], Vector2.zero, CursorMode.Auto);
    }

}
