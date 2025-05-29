using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject InGameMenu;
    [SerializeField] private GameObject GameModeButtons;
    [SerializeField] private GameObject MainButtons;
    [SerializeField] private GameObject Settings;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
        Settings.SetActive(false);
        InGameMenu.SetActive(false);
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
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void advancedButton()
    {
        GameManager.controladorAplicacion.modoJuego = gameMode.Advanced;
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void expertButton()
    {
        GameManager.controladorAplicacion.modoJuego = gameMode.Expert;
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void settingsBackButton()
    {
        MainButtons.SetActive(true);
        Settings.SetActive(false);
    }

    public void endButton()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
