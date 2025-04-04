using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip background, startSound, errorSound, successSound, loadingSound;
    public GameObject errorImage;
    public Image progressBar; // drag the UI Image with fillAmount here in the Inspector
    public GameObject updateMessage;
    private void Start()
    {
        // musicSource.clip = background;
        // musicSource.Play();
        sfxSource.PlayOneShot(startSound);
        ErrorMessage();
    }

    public void ErrorMessage()
    {
        StartCoroutine(ShowError(errorImage));
    }

    public void handleErrorMessage()
    {
        errorImage.SetActive(false);
        StartProgressBar();
    }

    private System.Collections.IEnumerator ShowError(GameObject errorImage)
    {
        yield return new WaitForSeconds(6f);
        errorImage.SetActive(true);
        sfxSource.PlayOneShot(errorSound);
    }

    public void StartProgressBar()
    {
        updateMessage.SetActive(true);
        sfxSource.PlayOneShot(loadingSound);
        StartCoroutine(FillProgressBar());
    }

    private System.Collections.IEnumerator FillProgressBar()
    {
        progressBar.fillAmount = 0f;
        float duration = 4f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            progressBar.fillAmount = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        progressBar.fillAmount = 1f;
        updateMessage.SetActive(false);
        sfxSource.PlayOneShot(successSound); 
    }

}
