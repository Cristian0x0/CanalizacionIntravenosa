using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject GameModeButtons;
    [SerializeField] private GameObject MainButtons;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject AchievementsPanel;
    [SerializeField] TextMeshProUGUI infoModeText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainMenu.SetActive(true);
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
        Settings.SetActive(false);
        InGameMenu.SetActive(false);
        AchievementsPanel.SetActive(false);
    }

    public void startButton()
    {
        GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PrimeraHigieneDeManos);
        MainMenu.SetActive(false);
        InGameMenu.SetActive(true);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void gameModeSelectionButton()
    {
        GameModeButtons.SetActive(true);
        MainButtons.SetActive(false);
    }

    public void settingsButton()
    {
        MainButtons.SetActive(false);
        Settings.SetActive(true);
    }

    public void normalButton()
    {
        GameManager.controladorAplicacion.modoJuego = gameMode.Normal;
        infoModeText.text = "Normal Mode: Visual aids, unlimited time, no penalties";
        //GameModeButtons.SetActive(false);
        //MainButtons.SetActive(true);
    }

    public void advancedButton()
    {
        GameManager.controladorAplicacion.modoJuego = gameMode.Advanced;
        infoModeText.text = "Advanced Mode: No visual aids, unlimited time, no penalties";
        //GameModeButtons.SetActive(false);
        //MainButtons.SetActive(true);
    }

    public void expertButton()
    {
        GameManager.controladorAplicacion.modoJuego = gameMode.Expert;
        infoModeText.text = "Expert Mode: No visual aids, against the clock every step, no object can fall to the ground or you will lose";
        //GameModeButtons.SetActive(false);
        //MainButtons.SetActive(true);
    }

    public void BackButton()
    {
        MainButtons.SetActive(true);
        Settings.SetActive(false);
        GameModeButtons.SetActive(false);
    }

    public void endButton()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void AchievementsButton()
    {
        AchievementsPanel.SetActive(!AchievementsPanel.activeSelf);
    }

    public void CloseButton()
    {
        AchievementsPanel.SetActive(false);
    }
}
