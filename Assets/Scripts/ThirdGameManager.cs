using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThirdGameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip background, glitchSound, clickSound;
    public GameObject Explorer, glitch, textFile; 

    public bool isFirstOpened = true;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // public void openTextFile() 
    // {
    //     sfxSource.PlayOneShot(clickSound);
    //     Explorer.SetActive(false);
    //     textFile.SetActive(true);
    //     glitch.SetActive(true);    
    // }

    public void openTextFile ()
    {
        sfxSource.PlayOneShot(clickSound);
        StartCoroutine(waitTime());
        
    }

    private System.Collections.IEnumerator waitTime()
    {
        Explorer.SetActive(false);
        textFile.SetActive(true);
        glitch.SetActive(true); 
        sfxSource.PlayOneShot(glitchSound);   
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(8);
    }
}
