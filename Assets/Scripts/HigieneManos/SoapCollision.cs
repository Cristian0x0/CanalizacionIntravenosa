using Unity.VisualScripting;
using UnityEngine;

public class SoapCollision : MonoBehaviour
{
    [HideInInspector] public bool stepDone = false;

    [SerializeField] private Collider soapCollider;
    [SerializeField] private AudioSource soapSound;

    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
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
            if (soapSound != null)
            {
                soapSound.Play();
            }
            stepDone = true;
        }
    }
}
