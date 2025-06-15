using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private NeedleVibration needleVibration;
    private Vector3 localPosition = Vector3.zero;
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;


    private bool ActiveScript = false;
    private bool keepNeedle = true;
    private bool Done = false;

    [HideInInspector] public bool canRemoveNeedle = false; //Este parametro lo controlamos para el canula controller, ya que necesitamos saber si estamos en el paso correcto en un objeto que no puede predecirlo siempre.

    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;

    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        ActiveScript = state == GameState.DesenfundarCateter;

        canRemoveNeedle = state == GameState.DesecharAguja;

        if (state == GameState.RecogerMaterial)
        {
            keepNeedle = false;
        }
    }

    void Update()
    {
        if (transform.childCount == 0 && keepNeedle)
        {
            transform.position = posicionInicial;
            transform.rotation = rotacionInicial;
            GameObject newChild = Instantiate(prefab, transform);
            newChild.transform.localPosition = localPosition;
            needleVibration.elapsedTime = 0f;
        }
        
        if (ActiveScript && !Done && transform.childCount >= 3)
        {
            Done = true;
            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.FijarPielIntroducirAguja);
        }
    }
}
