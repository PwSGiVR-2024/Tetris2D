using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Referencja do panelu pauzy
    public Button exitToMenuButton; // Referencja do przycisku "ExitToMenu"
    public Button continueButton; // Referencja do przycisku "Continue"

    private bool isPaused = false;

    void Start()
    {
        // Ukryj panel pauzy na pocz¹tku
        pausePanel.SetActive(false);

        // Pod³¹cz metody do przycisków
        exitToMenuButton.onClick.AddListener(ExitToMenu);
        continueButton.onClick.AddListener(ContinueGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Zatrzymaj grê
        pausePanel.SetActive(true); // Poka¿ panel pauzy
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Wznów grê
        pausePanel.SetActive(false); // Ukryj panel pauzy
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f; // Upewnij siê, ¿e czas gry jest wznowiony przed opuszczeniem gry
        SceneManager.LoadScene("MainMenu"); // Za³aduj scenê menu
    }
}
