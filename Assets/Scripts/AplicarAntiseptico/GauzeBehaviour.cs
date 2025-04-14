using Oculus.Interaction;
using UnityEngine;

public class GauzeBehaviour : MonoBehaviour
{

    //Este script viene controlado por el GameManager, solo se activa en en paso oportuno.

    private DokoDemoPainterPen CanDraw;

    private void Start()
    {
        CanDraw = GetComponent<DokoDemoPainterPen>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Alcohol") && CanDraw != null)
        {
            CanDraw.penDown = true;
        }
    }
}
