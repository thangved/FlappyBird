using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    public Player player;
    public GameObject playButton;
    public GameObject gameOver;
    public Text scoreText;
    public Text highScore;
    public Spawner spawner;
    public GameObject bullets;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        Pause();
    }

    private void Update()
    {
        UpdateBullets();
    }

    public void Pause()
    {
        ShowHighScore();
        player.enabled = false;
        playButton.SetActive(true);
        spawner.enabled = false;
    }

    public void Play()
    {
        HideHighScore();
        Time.timeScale = 1f;
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        
        player.enabled = true;
        player.GetComponent<Wave>().enabled = false;
        spawner.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        SetHighScore(score);
        Pause();
    }

    private void SetHighScore(int score)
    {
        if (score > GetHighScore())
            PlayerPrefs.SetInt("HighScore", score);
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    private void ShowHighScore()
    {
        highScore.text = "High Score: " + GetHighScore().ToString();
        highScore.enabled = true;
    }

    private void HideHighScore()
    {
        highScore.enabled = false;
    }

    private void UpdateBullets()
    {

        bullets.GetComponentInChildren<Text>().text = spawner.GetBulletsCount().ToString();
    }
}
