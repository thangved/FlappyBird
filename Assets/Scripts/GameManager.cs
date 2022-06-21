using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        private int score;

        public Player player;
        public GameObject playButton;
        public GameObject gameOver;
        public Text scoreText;
        public Text highScore;
        public Spawner spawner;
        public GameObject bullets;
        private Text text;


        private void Start()
        {
            score = 0;
            text = bullets.GetComponentInChildren<Text>();
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
            score = 0;
            scoreText.text = score.ToString();
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

            text.text = spawner.GetBulletsCount().ToString();
        }
    }
}
