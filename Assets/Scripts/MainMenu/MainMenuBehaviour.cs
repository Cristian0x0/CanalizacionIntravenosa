using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
