using UnityEngine;

public class GauzeBehaviour : MonoBehaviour
{
    private DokoDemoPainterPen CanDraw;

    private void Start()
    {
        CanDraw = GetComponent<DokoDemoPainterPen>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Alcohol") && CanDraw != null)
        {
            CanDraw.penDown = true;
        }
    }
}
