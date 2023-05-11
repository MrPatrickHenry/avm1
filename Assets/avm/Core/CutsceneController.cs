using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public Image cutsceneImage;
    public TextMeshProUGUI cutsceneText;
    public float typingSpeed = 0.05f;

    // Add your cutscene text for each level in this array
    public string[] cutscenes;

    private void Start()
    {
        ShowCutscene(0); // Show the cutscene for the first level
    }

    public void ShowCutscene(int level)
    {
        if (level >= 0 && level < cutscenes.Length)
        {
            cutsceneImage.gameObject.SetActive(true);
            cutsceneText.gameObject.SetActive(true);
            StartCoroutine(TypeText(cutscenes[level]));
        }
    }

    private IEnumerator TypeText(string text)
    {
        cutsceneText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            cutsceneText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void HideCutscene()
    {
        cutsceneImage.gameObject.SetActive(false);
        cutsceneText.gameObject.SetActive(false);
    }
}