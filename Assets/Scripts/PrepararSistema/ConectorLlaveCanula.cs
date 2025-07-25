using Oculus.Interaction;
using System.Collections;
using UnityEngine;

public class ConectorLlaveCanula : MonoBehaviour
{
    [SerializeField] private GameObject colliders;
    [SerializeField] private AudioSource conexionSound;
    private Grabbable myGrab;
    private ReiniciarPosicion reiniciarPosicion;
    private Rigidbody rb;
    private FixedJoint fixedJoint;
    private ConfigurableJoint OriginalJoint;
    private Rigidbody connectedBody;
    private bool done = false;

    private bool ICanEnter = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myGrab = GetComponent<Grabbable>();
        reiniciarPosicion = GetComponent<ReiniciarPosicion>();
        OriginalJoint = GetComponent<ConfigurableJoint>();
        connectedBody = OriginalJoint.connectedBody;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("ConectorCateter") || other.CompareTag("Gancho")) && ICanEnter)
        {
            if (conexionSound != null)
            {
                conexionSound.Play();
            }

            if (fixedJoint != null) Destroy(fixedJoint);

            myGrab.enabled = false;
            StartCoroutine(EsperarUnSegundo());

            ICanEnter = false;

            // Opcional: bloquear rotaci�n si quieres que no gire m�s
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;

            rb.isKinematic = true;
            //Ubicarlo en la posicion del cateter
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            rb.isKinematic = false;


            // Crear joint fijo entre este objeto y el conector
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = other.attachedRigidbody;

            done = false;

            if (other.CompareTag("Gancho")) return;

            if (reiniciarPosicion != null)
                reiniciarPosicion.enabled = false;

            if (colliders != null)
                colliders.SetActive(false);

            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.FijarCateter);
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gancho") && myGrab.Agarrado)
        {
            if (fixedJoint != null) Destroy(fixedJoint);
        }
    }
    */

    private void Update()
    {
        if (fixedJoint != null && myGrab.Agarrado)
        {
            Destroy(fixedJoint);
            ICanEnter = true;

        }
    }

    IEnumerator EsperarUnSegundo()
    {
        yield return new WaitForSeconds(1f);
        myGrab.enabled = true; 
    }
}
