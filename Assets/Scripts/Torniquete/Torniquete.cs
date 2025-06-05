using UnityEngine;

public class Torniquete : MonoBehaviour
{
    private Transform hijo;
    private bool ScriptActivo = false;

    private void ComprobarActivacionTorniquete(GameState state)
    {
        ScriptActivo = state == GameState.ColocarCompresor;
    }
    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacionTorniquete;
        hijo = transform.Find("Visual");
    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacionTorniquete;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torniquete") && ScriptActivo)
        {
            if (hijo != null)
            {
                hijo.gameObject.SetActive(true);
            }
            Destroy(other.transform.parent.gameObject);

            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PalparVena);
        }
    }

}
