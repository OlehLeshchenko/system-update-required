using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondGameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip background, glitchSound, clickSound;
    public GameObject glitchImage, directoryExplorer; 

    public bool isFirstOpened = true;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


    private System.Collections.IEnumerator ShowGlitchEffect()
    {
        glitchImage.SetActive(true);
        sfxSource.PlayOneShot(glitchSound);
        yield return new WaitForSeconds(2f);
        sfxSource.PlayOneShot(glitchSound);
        yield return new WaitForSeconds(2f);
        glitchImage.SetActive(false);
    }

    public void handleDirectory() 
    {
        if(isFirstOpened)
        {
            isFirstOpened = false;
            sfxSource.PlayOneShot(clickSound);
            directoryExplorer.SetActive(true);
            
        }
        
    }

    public void executeExplorer ()
    {
        sfxSource.PlayOneShot(clickSound);
        StartCoroutine(waitTime());
        
    }

    private System.Collections.IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }

}
