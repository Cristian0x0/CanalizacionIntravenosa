using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Vector3 localPosition = Vector3.zero;

    private bool ActiveScript = false;
    private bool Done = false;

    private void Awake()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        ActiveScript = state == GameState.DesenfundarCateter;
    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            GameObject newChild = Instantiate(prefab, transform);
            newChild.transform.localPosition = localPosition;
        }
        
        if (ActiveScript && !Done && transform.childCount >= 3)
        {
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.FijarPiel);
        }
    }
}
