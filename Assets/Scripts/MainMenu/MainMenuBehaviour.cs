using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject GameModeButtons;
    [SerializeField] private GameObject MainButtons;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void startButton()
    {
        GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PrimeraHigieneDeManos);
        MainMenu.SetActive(false);
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

    public void normalButton()
    {
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void advancedButton()
    {
        GameManager.controladorAplicacion.BlackScreen = true;
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void expertButton()
    {
        GameManager.controladorAplicacion.BlackScreen = true;
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
    }
}
