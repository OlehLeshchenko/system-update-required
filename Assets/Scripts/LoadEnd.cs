using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnd : MonoBehaviour
{
    // Delay time in seconds
    private float delay = 10.8f;
    private int scene = 13;

    void Start()
    {
        // Start the coroutine on scene load
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
