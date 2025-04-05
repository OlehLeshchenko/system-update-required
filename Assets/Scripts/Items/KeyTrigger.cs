using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Гравець зайшов у зону!");
        }
    }
}
