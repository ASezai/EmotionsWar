using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int ActiveController;

    public Button RestartButton;
    public Button MainMenuButton;
    public Button PauseButton;
    public Button ResumeButton;
    public Text ScoreText;
    public Text PauseText;
    public Canvas UICanvas;

    [SerializeField]
    private Transform playerLocation;

    public int Score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
        Score = 0;
        UpdateScore(Score);
    }
    public Transform PlayerLoc
    {
        get { return playerLocation; }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void GameOver()
    {
        Debug.Log("gameover");
        Time.timeScale = 0f;
        RestartButton.gameObject.SetActive(true);
        MainMenuButton.gameObject.SetActive(true);
        UICanvas.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        RestartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ControllerForPhone.ProjectileSpeed = 30f;
        ControllerForPhone.FireRate = 0.5f;
        ControllerForPhone.MovementSpeed = 8f;
        ControllerForPC.ProjectileSpeed = 30f;
        ControllerForPC.FireRate = 0.5f;
        ControllerForPC.MovementSpeed = 8f;
        Bullet.Damage = 20f;
        if (ActiveController == 0)
        {
            UICanvas.gameObject.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public static void UpdateScore(int s)
    {
        instance.Score += s;
        instance.ScoreText.text = instance.Score.ToString("000,000");
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseText.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(true);
        if (ActiveController == 0)
        {
            UICanvas.gameObject.SetActive(false);
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseText.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        if (ActiveController == 0)
        {
            UICanvas.gameObject.SetActive(true);
        }
    }
}
