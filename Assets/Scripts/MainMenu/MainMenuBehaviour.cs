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
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] TextMeshProUGUI infoModeText;
    [SerializeField] TextMeshProUGUI AchievementTitleText;
    [SerializeField] TextMeshProUGUI AchievementDescriptionText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainMenu.SetActive(true);
        GameModeButtons.SetActive(false);
        MainButtons.SetActive(true);
        Settings.SetActive(false);
        InGameMenu.SetActive(false);
        AchievementsPanel.SetActive(false);
        InfoPanel.SetActive(false);
    }

    public void startButton()
    {
        GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PrimeraHigieneDeManos);
        MainMenu.SetActive(false);
        AchievementsPanel.SetActive(false);
        InfoPanel.SetActive(false);
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
        AchievementTitleText.text = "Choose achievement";
        AchievementDescriptionText.text = "";
        AchievementsPanel.SetActive(!AchievementsPanel.activeSelf);
    }

    public void InfoButton()
    {
        InfoPanel.SetActive(!InfoPanel.activeSelf);
    }

    public void CloseButton()
    {
        AchievementsPanel.SetActive(false);
    }

    public void CloseInfoButton()
    {
        InfoPanel.SetActive(false);
    }

    public void EverythingInPlaceButton()
    {
        AchievementTitleText.text = "Everything in its place";
        AchievementDescriptionText.text = "Place all the necessary items for the procedure on the medical cart";
    }

    public void SteadyHandsButton()
    {
        AchievementTitleText.text = "Steady hands";
        AchievementDescriptionText.text = "Successfully complete all phases without any object falling to the floor";
    }

    public void TrueProfessionalButton()
    {
        AchievementTitleText.text = "A true professional";
        AchievementDescriptionText.text = "Complete the entire practice in less than 3 minutes";
    }

    public void UnmatchedNurseButton()
    {
        AchievementTitleText.text = "Unmatched nurse";
        AchievementDescriptionText.text = "Find the correct vein on the first attempt";
    }

    public void GreatLearnerButton()
    {
        
        AchievementTitleText.text = "A great learner";
        AchievementDescriptionText.text = "Complete the practice for the first time";
    }

    public void AbsoluteDedicationButton()
    {
        AchievementTitleText.text = "Absolute dedication";
        AchievementDescriptionText.text = "Repeat the practice 3 times or more";
    }

    public void ReadyForActionButton()
    {
        AchievementTitleText.text = "Ready for action";
        AchievementDescriptionText.text = "Complete the practice without visual aids";
    }

    public void ABrightFutureButton()
    {
        AchievementTitleText.text = "A bright future";
        AchievementDescriptionText.text = "Complete the practice in expert mode";
    }
}
