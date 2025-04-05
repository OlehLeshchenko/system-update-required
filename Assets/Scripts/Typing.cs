using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typing : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    [TextArea]
    public string predefinedText = "   struct FileNode *parent;\n    struct FileNode *children[MAX_CHILDREN];\n    int child_co";
    private int currentIndex = 0;

    void Update()
    {
        if (Input.anyKeyDown && currentIndex < predefinedText.Length)
        {
            uiText.text += predefinedText[currentIndex];
            currentIndex++;
        }
    }
}