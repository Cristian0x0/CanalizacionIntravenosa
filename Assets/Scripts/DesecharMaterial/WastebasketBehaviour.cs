using Oculus.Interaction;
using UnityEngine;

public class WastebasketBehaviour : MonoBehaviour
{
    private Grabbable myGrab;
    private bool removeItems = false;
    private bool stepDone = false;

    private bool gauzeRemoved = false, tourniquetRemoved = false;
    private void ComprobarActivacionAposito(GameState state)
    {
        if (state == GameState.RecogerMaterial)
        {
            removeItems = true;
        }
        else
        {
            removeItems = false;
        }
    }
    void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacionAposito;
        myGrab = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myGrab.Agarrado)
        {
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Papelera"), true);
        }
        else
        {
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Papelera"), false);
        }

        if(tourniquetRemoved && gauzeRemoved && !stepDone)
        {
            stepDone = true;
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.RetirarGuantes);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Gauze") || collision.gameObject.CompareTag("Torniquete")) && removeItems)
        {
            if (collision.gameObject.CompareTag("Gauze")) gauzeRemoved = true;
            else if (collision.gameObject.CompareTag("Torniquete")) tourniquetRemoved = true;
            Destroy(collision.gameObject);
        }
        else
        {
            ReiniciarPosicion reiniciarPosicion = collision.gameObject.GetComponent<ReiniciarPosicion>();
            if (reiniciarPosicion != null)
            {
                reiniciarPosicion.resetPosition();
            }
        }
    }
}
