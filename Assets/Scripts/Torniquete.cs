using UnityEngine;

public class Torniquete : MonoBehaviour
{
    private Transform hijo;
    private bool ScriptActivo = false;

    private void Awake()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacionTorniquete;
    }
    private void ComprobarActivacionTorniquete(GameState state)
    {
        if (state == GameState.ColocarCompresor)
        {
            ScriptActivo = true;
        }
    }
    private void Start()
    {
        hijo = transform.Find("Visual");
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

            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PalparVena);
        }
    }

}
