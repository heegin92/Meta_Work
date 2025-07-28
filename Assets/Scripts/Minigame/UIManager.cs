using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure you have TextMeshPro package installed

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in the UIManager.");
        }
        if (restartText == null)
        {
            Debug.LogError("Restart Text is not assigned in the UIManager.");
        }

        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRestartTextActive(bool isActive)
    {
        restartText.gameObject.SetActive(isActive);
    }

    public void UpdateScoreText(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "" + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text is not assigned in the UIManager.");
        }
    }
}
