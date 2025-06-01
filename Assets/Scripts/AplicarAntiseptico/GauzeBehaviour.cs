using Oculus.Interaction;
using UnityEngine;

public class GauzeBehaviour : MonoBehaviour
{

    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    private DokoDemoPainterPen CanDraw;
    private bool isActive = false;

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacionAposito;
    }
    private void ComprobarActivacionAposito(GameState state)
    {
        if (state == GameState.AplicarAntiseptico)
        {
            isActive = true;
        }
    }

    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacionAposito;
        CanDraw = GetComponent<DokoDemoPainterPen>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Alcohol") && CanDraw != null && isActive)
        {
            CanDraw.penDown = true;
        }
    }
}
