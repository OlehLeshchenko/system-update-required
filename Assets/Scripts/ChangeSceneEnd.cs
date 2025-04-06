using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangChangeSceneEndeScene: MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex = 12;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
    public void End()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
