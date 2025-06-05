using UnityEngine;

public class ControladorGuantes : MonoBehaviour
{
    [SerializeField] private Renderer manoIzquierda;
    [SerializeField] private Renderer manoDerecha;

    [SerializeField] private Material mano;
    [SerializeField] private Material guanteIzquierdo;
    [SerializeField] private Material guanteDerecho;

    private bool Paso6 = false;
    private bool Paso18 = false;

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
        if (state == GameState.PonerseGuantes)
        {
            Paso6 = true;
        }
        else if(state == GameState.RetirarGuantes)
        {
            Paso18 = true;
        }
        else
        {
            Paso6 = false;
            Paso18 = false;
        }
    }

    private void Update()
    {
        if (Paso6 && manoIzquierda.sharedMaterial == guanteIzquierdo && manoDerecha.sharedMaterial == guanteDerecho)
        {
            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.DesenfundarCateter);
        }
        else if (Paso18 && manoIzquierda.sharedMaterial == mano && manoDerecha.sharedMaterial == mano)
        {
            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.SegundaHigieneDeManos);
        }
    }
}
