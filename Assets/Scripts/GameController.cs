using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private GameObject lostScreen;
    [SerializeField]
    private Text lostScoreText;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Toggle soundToggle;

    private bool isPaused = false;
    private int score = 0;
    private Vector2 healthBarSize;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            soundToggle.isOn = true;
            AudioListener.volume = 1;
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                soundToggle.isOn = false;
                AudioListener.volume = 0;
            }
            else
            {
                soundToggle.isOn = true;
                AudioListener.volume = 1;
            }
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
        healthBarSize = healthBar.rectTransform.sizeDelta;
    }

    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            isPaused = true;
        }
    }

    public void ModifyHealthBar(float ratio)
    {
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarSize.x * ratio, healthBarSize.y);
    }

    public void IncreaseScore(int add)
    {
        score += add;
        scoreText.text = score.ToString();
    }

    public void ToggleSound()
    {
        if (soundToggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            AudioListener.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            AudioListener.volume = 0;
        }
        PlayerPrefs.Save();
    }

    public void Lost()
    {
        Time.timeScale = 0;
        lostScreen.SetActive(true);
        lostScoreText.text = "Your score: \n" + score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
