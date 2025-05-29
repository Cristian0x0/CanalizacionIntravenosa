using UnityEngine;

public class TimeImageChange : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject image;

    public void ChangeTimerImage()
    {
        if (GameManager.controladorAplicacion.modoJuego == gameMode.Expert) return;
        
        timer.SetActive(!timer.activeSelf);
        image.SetActive(!image.activeSelf);
    }
}
