using Oculus.Interaction;
using UnityEngine;

public class secondExtension : MonoBehaviour
{
    private bool tubeIn = false;
    private bool tapeIn = false;
    private bool completedStep = false;
    private FixedJoint fixedJoint;
    private Grabbable tapeGrab;
    private Rigidbody rb;
    [SerializeField] private fixExtension firstTape;

    [SerializeField] private GameObject TrozoEsparadrapo;


    void Update()
    {
        if (tubeIn && tapeIn && !completedStep && firstTape.completedStep)
        {

            // Asegurarse de que no tenga un joint previo
            if (fixedJoint != null) Destroy(fixedJoint);

            if (tapeGrab == null || rb == null) return;

            tapeGrab.enabled = false;

            // Opcional: bloquear rotación si quieres que no gire más
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;

            //Ubicarlo en la posicion del cateter
            rb.position = transform.position;
            rb.rotation = transform.rotation;

            // Crear joint fijo entre este objeto y el conector
            fixedJoint = rb.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = GetComponent<Rigidbody>();

            completedStep = true;

            TrozoEsparadrapo.SetActive(true);
            //Destroy(tapeGrab.gameObject);
            tapeGrab.gameObject.SetActive(false);

            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.DesecharAguja);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TuboLlave"))
        {
            tubeIn = true;
            rb = other.GetComponent<Rigidbody>();
        }
        else if (other.CompareTag("TrozoEsparadrapo"))
        {
            tapeIn = true;
            tapeGrab = other.GetComponent<Grabbable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TuboLlave"))
        {
            tubeIn = false;
            rb = null;
        }
        else if (other.CompareTag("TrozoEsparadrapo"))
        {
            tapeIn = false;
            tapeGrab = null;
        }
    }
}
