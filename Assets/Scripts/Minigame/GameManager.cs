using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public string MainScene;



    private int currentScore = 0;

    UIManager uiManager;

    public UIManager UIManager {  get { return uiManager; } }

    private void Awake()
    {
        {
            instance = this;
            uiManager = FindObjectOfType<UIManager>();
        }
    }

    private void Start()
    {
       uiManager.UpdateScoreText(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // Implement game over logic here
        uiManager.SetRestartTextActive(true);
        if (!string.IsNullOrEmpty(MainScene))
        {
            SceneManager.LoadScene(MainScene);
        }
        else
        {
            Debug.LogError("���� �� �̸��� �������� �ʾҽ��ϴ�! ��ũ��Ʈ �ν����Ϳ��� 'Main Scene Name'�� �������ּ���.");
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Implement reset logic here
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScoreText(currentScore);
    }

}
