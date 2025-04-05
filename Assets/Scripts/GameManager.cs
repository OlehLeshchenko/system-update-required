using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip background, startSound, errorSound, successSound, loadingSound, glitchSound, directorySound, clickSound;
    public GameObject errorImage;
    public GameObject updateMessage;
    public GameObject glitchImage, labelImage, directoryImage; // drag in Inspector
    public Image progressBar;

    private bool hasKey = false;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        sfxSource.PlayOneShot(startSound);
        ErrorMessage();
    }

    public void ErrorMessage()
    {
        StartCoroutine(ShowError(errorImage));
    }

    public void handleErrorMessage()
    {
        sfxSource.PlayOneShot(clickSound);
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
        StartCoroutine(ShowGlitchEffect());
    }

    private System.Collections.IEnumerator ShowGlitchEffect()
    {
        glitchImage.SetActive(true);
        sfxSource.PlayOneShot(glitchSound);
        yield return new WaitForSeconds(2f);
        sfxSource.PlayOneShot(glitchSound);
        yield return new WaitForSeconds(2f);
        glitchImage.SetActive(false);
        labelImage.SetActive(true);
        directoryImage.SetActive(true);
    }

    public void handleDirectory() 
    {
        if (!hasKey)
        {
            sfxSource.PlayOneShot(directorySound);
        }
        else {

        }
    }
    public void SetDirectoryKey(bool state)
    {
        hasKey = state;
    }
}
