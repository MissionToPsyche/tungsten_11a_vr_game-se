using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScrollableText : MonoBehaviour
{
    public string textFileName;
    public Text textComponent;

    void Start()
    {
        if (string.IsNullOrEmpty(textFileName))
        {
            Debug.LogError("Text file name is empty.");
            return;
        }

        TextAsset textAsset = Resources.Load<TextAsset>(textFileName);

        if (textAsset != null)
        {
            string narratorScript = textAsset.text;
            SetText(narratorScript);
        }
        else
        {
            Debug.LogError("File not found: " + textFileName);
        }
    }

    void SetText(string content)
    {
        textComponent.text = content;
    }
}
