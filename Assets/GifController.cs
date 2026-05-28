using UnityEngine;
using UnityEngine.UI;

public class GifController : MonoBehaviour
{
    public Texture2D gifTexture; // Asigna la textura del GIF en el inspector

    void Start()
    {
        if (gifTexture != null)
        {
            GetComponent<RawImage>().texture = gifTexture;
        }
    }
}
