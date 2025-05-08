using Unity.VisualScripting;
using UnityEngine;

public class SoapCollision : MonoBehaviour
{
    [HideInInspector] public bool stepDone = false;

    [SerializeField] private Collider soapCollider;

    private void Awake()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        if (state == GameState.PrimeraHigieneDeManos || state == GameState.SegundaHigieneDeManos)
        {
            soapCollider.enabled = true;
        }
        else
        {
            stepDone = false;
            soapCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && !stepDone)
        {
            stepDone = true;
        }
    }
}
