using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textChange : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Assign your TMP text in Inspector
    public List<string> texts = new List<string>(); // Add your texts here in Inspector
    public float changeInterval = 10f; // Seconds between text changes

    private int currentIndex = 0;

    private void Start()
    {
        if (texts.Count == 0 || displayText == null)
        {
            Debug.LogWarning("Texts list is empty or displayText is not assigned.");
            return;
        }

        displayText.text = texts[currentIndex];
        StartCoroutine(LoopTexts());
    }

    IEnumerator LoopTexts()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            currentIndex = (currentIndex + 1) % texts.Count;
            displayText.text = texts[currentIndex];
        }
    }
}
