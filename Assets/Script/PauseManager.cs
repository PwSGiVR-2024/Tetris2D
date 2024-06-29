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
        // Ukryj panel pauzy na pocz�tku
        pausePanel.SetActive(false);

        // Pod��cz metody do przycisk�w
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
        Time.timeScale = 0f; // Zatrzymaj gr�
        pausePanel.SetActive(true); // Poka� panel pauzy
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Wzn�w gr�
        pausePanel.SetActive(false); // Ukryj panel pauzy
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f; // Upewnij si�, �e czas gry jest wznowiony przed opuszczeniem gry
        SceneManager.LoadScene("MainMenu"); // Za�aduj scen� menu
    }
}
