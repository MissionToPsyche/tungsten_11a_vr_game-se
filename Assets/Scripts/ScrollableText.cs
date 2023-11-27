using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScrollableText : MonoBehaviour
{
    public string textFilePath;
    public Text textComponent;

    void Start()
    {
        string fullPath = "Assets/Resources/" + textFilePath;
        if (File.Exists(fullPath))
        {
            string narratorScript = File.ReadAllText(fullPath);
            SetText(narratorScript);
        }
        else
        {
            Debug.LogError("File not found: " + fullPath);
        }
    }

    void SetText(string content)
    {
        textComponent.text = content;
    }
}
