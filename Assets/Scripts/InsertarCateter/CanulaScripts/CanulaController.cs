using Oculus.Interaction;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CanulaController : MonoBehaviour
{
    private Grabbable myGrab;
    private Transform parent;
    private bool rightStep = false;

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        rightStep = state == GameState.DesecharAguja;
    }

    void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Tapones"), LayerMask.NameToLayer("Manos"), true);
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Canula"), LayerMask.NameToLayer("Manos"), true);
        myGrab = GetComponent<Grabbable>();
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (myGrab.Agarrado)
        {
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Tapones"), LayerMask.NameToLayer("Manos"), false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Deposito") || collision.gameObject.CompareTag("Papelera")) && parent != null)
        {
            if (collision.gameObject.CompareTag("Deposito") && rightStep)
            {
                GameManager.controladorAplicacion.stepCompleted();
                GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.RecogerMaterial);
            }
            foreach (Transform child in parent)
            {
                if(child != transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            Destroy(gameObject);
        }
    }

}
