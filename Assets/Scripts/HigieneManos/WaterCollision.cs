using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class WaterCollision : MonoBehaviour
{
    private bool firstStep = true;
    private bool lastStep = false;

    [SerializeField] private Collider waterCollider;
    [SerializeField] private SoapCollision soap;
    [SerializeField] private ParticleSystem waterSystem;
    [SerializeField] private AudioSource waterSound;

    private void Awake()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        if (state == GameState.PrimeraHigieneDeManos)
        {
            firstStep = true;
            waterCollider.enabled = true;
            waterSystem.Play();
            waterSound.Play();
        }
        else if (state == GameState.SegundaHigieneDeManos)
        {
            lastStep = true;
            waterCollider.enabled = true;
            waterSystem.Play();
            waterSound.Play();
        }
        else
        {
            firstStep = false;
            lastStep = false;
            waterCollider.enabled = false;
            waterSound.Stop();
            waterSystem.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmitting);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!soap.stepDone) return;

        if (other.CompareTag("Hands") && firstStep)
        {
            Debug.Log("Colision con agua");
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.BuscarObjetos);
        }
        else if (other.CompareTag("Hands") && lastStep)
        {
            Debug.Log("TODO EL PROCESO TERMINADO");
        }
    }
}
