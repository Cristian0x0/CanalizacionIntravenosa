using Oculus.Interaction;
using UnityEngine;

public class CanulaController : MonoBehaviour
{
    private Grabbable myGrab;
    private Transform parent;
    private bool rightStep = false;

    void Start()
    {
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
            rightStep = parent.GetComponent<ChildSpawner>().canRemoveNeedle; //Comprobamos si estamos en el paso correcto para eliminar la aguja llamando a una variable publica del objeto padre que nunca se elimina.

            if (collision.gameObject.CompareTag("Deposito") && rightStep)
            {
                GameManager.controladorAplicacion.stepCompleted();
                GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.RecogerMaterial);
            }

                foreach (Transform child in parent)
                {
                    if (child != transform)
                    {
                        Destroy(child.gameObject);
                    }
                }
            Destroy(gameObject);
        }
    }

}
