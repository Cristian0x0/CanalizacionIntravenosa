using UnityEngine;

public class DesinfectingArea : MonoBehaviour
{
    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    [SerializeField] private DokoDemoPainterPen CanDraw;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gauze") && CanDraw.penDown)
        {
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PonerseGuantes);
        }
    }
}
