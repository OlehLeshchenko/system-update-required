using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutlookManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip clickSound;

    public GameObject AllMessages, AllMessagesCorrupted, MachinistMessage, CorruptedMessage, FindMeMessage;

    private bool hasOpenedCorruptedFile = false;

    private bool hasOutlookOpened = false;

    public void goToMachinistMessage ()
    {
        sfxSource.PlayOneShot(clickSound);
        AllMessages.SetActive(false);
        AllMessagesCorrupted.SetActive(false);
        MachinistMessage.SetActive(true);
    }  

    public void closeMessage ()
    {
        sfxSource.PlayOneShot(clickSound);
        if (hasOpenedCorruptedFile) AllMessagesCorrupted.SetActive(true);
        else AllMessages.SetActive(true);
        MachinistMessage.SetActive(false);
    }

    public void openCorruptedFileMessage ()
    {
        hasOpenedCorruptedFile = true;
        sfxSource.PlayOneShot(clickSound);
        CorruptedMessage.SetActive(true);
        AllMessages.SetActive(false);
        AllMessagesCorrupted.SetActive(false);
        MachinistMessage.SetActive(false);
    }


    public void closeCorruptedFileMessage ()
    {
        sfxSource.PlayOneShot(clickSound);
        CorruptedMessage.SetActive(false);
        MachinistMessage.SetActive(false);
        AllMessages.SetActive(false);
        AllMessagesCorrupted.SetActive(true);
    }

    public void init () 
    {
        if(hasOutlookOpened) return;
        sfxSource.PlayOneShot(clickSound);
        hasOutlookOpened = true;
        AllMessages.SetActive(true);
    }

    public void openFindMeMessage() 
    {
        sfxSource.PlayOneShot(clickSound);
        FindMeMessage.SetActive(true);
        AllMessagesCorrupted.SetActive(false);
    }

    public void closeFindMeMessage() 
    {
        sfxSource.PlayOneShot(clickSound);
        FindMeMessage.SetActive(false);
        AllMessagesCorrupted.SetActive(true);
    }

    public void openFile ()
    {
        sfxSource.PlayOneShot(clickSound);
        SceneManager.LoadScene("2DFlow/TopDownGameScene");
    }

}
