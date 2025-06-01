using UnityEngine;

public class ColocarAposito : MonoBehaviour
{
    private Transform hijo;

    [SerializeField] private Collider detectorCollider;
    private void ComprobarActivacionAposito(GameState state)
    {
        if (state == GameState.FijarCateter)
        {
            detectorCollider.enabled = true;
        }
        else
        {
            detectorCollider.enabled = false;
        }
    }
    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacionAposito;
        hijo = transform.Find("ApositoEnPiel");
    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacionAposito;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Aposito"))
        {
            if (hijo != null)
            {
                hijo.gameObject.SetActive(true);
            }
            Destroy(other.transform.gameObject);

            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.FijarLlave3Pasos);
        }
    }
}
