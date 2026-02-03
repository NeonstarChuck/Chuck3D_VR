using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public SpawnManagerAnimals spawnManager;   // Reference to your spawn script
    public Transform[] spawnPoints;            // Where animals can spawn


    public TextMeshProUGUI rescuedText;
    public TextMeshProUGUI deadText;
    public GameObject gameOverPanel;
    public GameObject gameOverWinPanel;
    public GameObject titleSreen;
    public GameObject InformationPanel;
    public GameObject Timer;
    public Button restartButton;
    public GameObject enemyHard;
    public GameObject Fence;

    public Timer timer;

    private int totalToRescue;
    private int maxDeaths = 3;

    private int rescuedCount = 0;
    private int deadCount = 0;

    private bool gameActive = false;

    // menu buttons med 3 funktioner
    public void StartEasy() { StartGame(5, 40f, false); }
    public void StartMedium() { StartGame(10, 60f, false); }
    public void StartHard() { StartGame(15, 80f, true); }

    private void Start()
    {

        Time.timeScale = 0f;
    }

    private void StartGame(int totalAnimals, float timeLimit, bool enableHardEnemy)
    {
        totalToRescue = totalAnimals;
        rescuedCount = 0;
        deadCount = 0;
        gameActive = true;

        UpdateUI();

        titleSreen.gameObject.SetActive(false);
        InformationPanel.gameObject.SetActive(false);
        deadText.gameObject.SetActive(true);
        rescuedText.gameObject.SetActive(true);
        Timer.gameObject.SetActive(true);
        Time.timeScale = 1f;


        spawnManager.SpawnAnimals(spawnPoints, 5f);
        timer.gameManager = this;
        timer.StartTimer(timeLimit);

        if (enableHardEnemy && enemyHard != null)
        {
            enemyHard.SetActive(true);
            Fence.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TimeIsOver()
    {
        GameOver("Time is up!");
    }

    public void AnimalRescued()
    {
        if (!gameActive) return;

        rescuedCount++;
        UpdateUI();
        CheckGameOverWin();
    }

    public void AnimalDead()
    {
        if (!gameActive) return;

        deadCount++;
        UpdateUI();
        CheckGameOver();
    }

    private void UpdateUI()
    {
        rescuedText.text = $"Rescued: {rescuedCount}/{totalToRescue}";
        deadText.text = $"Dead: {deadCount}/{maxDeaths}";
    }

    private void CheckGameOver()
    {
        if (deadCount >= maxDeaths)
        {
            GameOver("Too many animals died! Game Over!");
        }
    }

    private void CheckGameOverWin()
    {
        if (rescuedCount >= totalToRescue)
        {
            GameOverWin("All animals rescued! You win!");
        }
    }

    private void GameOverWin(string message)
    {
        gameActive = false;
        gameOverWinPanel.SetActive(true);
        Debug.Log(message);
        Time.timeScale = 0f;
    }

    private void GameOver(string message)
    {
        gameActive = false;
        gameOverPanel.SetActive(true);
        Debug.Log(message);
        Time.timeScale = 0f;
    }
}
