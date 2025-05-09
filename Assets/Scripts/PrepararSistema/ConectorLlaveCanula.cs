using Oculus.Interaction;
using System.Collections;
using UnityEngine;

public class ConectorLlaveCanula : MonoBehaviour
{
    [SerializeField] private GameObject colliders;
    private Grabbable myGrab;
    private ReiniciarPosicion reiniciarPosicion;
    private Rigidbody rb;
    private FixedJoint fixedJoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myGrab = GetComponent<Grabbable>();
        reiniciarPosicion = GetComponent<ReiniciarPosicion>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConectorCateter"))
        {
            // Asegurarse de que no tenga un joint previo
            if (fixedJoint != null) Destroy(fixedJoint);

            myGrab.enabled = false;
            StartCoroutine(EsperarUnSegundo());

            // Opcional: bloquear rotación si quieres que no gire más
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;

            //Ubicarlo en la posicion del cateter
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            // Crear joint fijo entre este objeto y el conector
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = other.attachedRigidbody;

            if (reiniciarPosicion != null)
                reiniciarPosicion.enabled = false;

            if (colliders != null)
                colliders.SetActive(false);
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.FijarCateter);
        }
    }

    IEnumerator EsperarUnSegundo()
    {
        yield return new WaitForSeconds(1f);
        myGrab.enabled = true;
    }
}
