using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAction : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] AudioSource audioSource;


    private void Start()
    {
        audioSource.Play();
        LeanTween.alphaCanvas(canvasGroup.GetComponent<CanvasGroup>(), 0, 2.5f);
    }
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeTo(sceneName));
    }

    IEnumerator ChangeTo(string sceneName)
    {
        LeanTween.alphaCanvas(canvasGroup.GetComponent<CanvasGroup>(), 1, 1f);
        audioSource.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}
