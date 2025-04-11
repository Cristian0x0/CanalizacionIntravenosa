using Oculus.Interaction;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ConectorALlave : MonoBehaviour
{
    [SerializeField] private Transform NuevaPosicion;
    [SerializeField] private GameObject Padre;
    [SerializeField] private GameObject colliders; //Estos hay que quitarlos para que el conector del sistema de suero no pueda ser cogido
    [SerializeField] private SoltarConectorSistema soltarConectorSistema;
    private SoltarConectorSistema soltarConectorSistema2;
    private Grabbable grabbable;
    private Grabbable myGrab;
    private ReiniciarPosicion reiniciarPosicion;
    private Rigidbody rb;

    [SerializeField] private ColisionSistemaSuero colisionSistemaSuero;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myGrab = GetComponent<Grabbable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Llave3Pasos") && colisionSistemaSuero.pinchoConectado)
        {
            rb.LockKinematic();
            grabbable = other.GetComponent<Grabbable>();
            if (grabbable != null)
            {
                myGrab.enabled = false;
                grabbable.enabled = false; // Desactivar el Grabbable
                StartCoroutine(EsperarUnSegundo());
            }
            
            other.transform.SetParent(Padre.transform);
            other.transform.position = NuevaPosicion.position;
            other.transform.rotation = NuevaPosicion.rotation;
            transform.SetParent(other.transform);

            // Desactivar el script ReiniciarPosicion y activar el limite del cable
            reiniciarPosicion = other.GetComponent<ReiniciarPosicion>();
            if (reiniciarPosicion != null)
            {
                reiniciarPosicion.enabled = false;
            }
            if (soltarConectorSistema != null)
            {
                soltarConectorSistema.enabled = true;
            }
            soltarConectorSistema2 = other.GetComponent<SoltarConectorSistema>();
            if (soltarConectorSistema2 != null)
            {
                soltarConectorSistema2.enabled = true;
            }


            colliders.SetActive(false);

            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.ColocarCompresor);
        }
    }



    IEnumerator EsperarUnSegundo()
    {
        // Esperamos 1 segundo
        yield return new WaitForSeconds(1f);

        // Después de 1 segundo, se ejecuta este código
        grabbable.enabled = true;
        myGrab.enabled = true;
    }
}

