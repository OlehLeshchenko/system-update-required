using UnityEngine;

public class GlitchTrigger : MonoBehaviour
{
    public GameObject glitch;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            glitch.SetActive(true);
        }
    }
}
