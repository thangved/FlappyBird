using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _score;

    public Player player;
    public GameObject playButton;
    public GameObject gameOver;
    public Text scoreText;
    public Text highScore;
    public Spawner spawner;
    public GameObject bullets;
    private Text _text;


    private void Start()
    {
        _score = 0;
        _text = bullets.GetComponentInChildren<Text>();
    }

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

    private void Pause()
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
        _score = 0;
        scoreText.text = _score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        
        player.enabled = true;
        player.GetComponent<Wave>().enabled = false;
        spawner.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        foreach (var t in pipes)
        {
            Destroy(t.gameObject);
        }
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        SetHighScore(_score);
        Pause();
    }

    private void SetHighScore(int currentScore)
    {
        if (currentScore > GetHighScore())
            PlayerPrefs.SetInt("HighScore", currentScore);
    }

    private static int GetHighScore()
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

        _text.text = spawner.GetBulletsCount().ToString();
    }
}