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

            // Crear joint fijo entre este objeto y el conector
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = other.attachedRigidbody;

            // Opcional: bloquear rotación si quieres que no gire más
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;

            myGrab.enabled = false;
            StartCoroutine(EsperarUnSegundo());

            if (reiniciarPosicion != null)
                reiniciarPosicion.enabled = false;

            if (colliders != null)
                colliders.SetActive(false);
        }
    }

    IEnumerator EsperarUnSegundo()
    {
        yield return new WaitForSeconds(1f);
        myGrab.enabled = true;
    }
}
