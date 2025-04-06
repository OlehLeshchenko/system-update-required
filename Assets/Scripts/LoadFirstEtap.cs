using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstEtap : MonoBehaviour
{
    // Delay time in seconds
    private float delay = 14.77f;

    void Start()
    {
        // Start the coroutine on scene load
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(10);
    }
}
