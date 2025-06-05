using Oculus.Interaction;
using System.Collections;
using UnityEngine;

public class ReiniciarPosicionLlave : MonoBehaviour
{
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    private Rigidbody rb;
    [SerializeField] private ConectorALlave conectorALlave;
    [SerializeField] private GameObject cabeza;
    [SerializeField] private GameObject final;
    private Grabbable cabezaGrab;
    private Grabbable finalGrab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = cabeza.GetComponent<Rigidbody>();

        posicionInicial = cabeza.transform.position;
        rotacionInicial = cabeza.transform.rotation;

        cabezaGrab = cabeza.GetComponent<Grabbable>();
        finalGrab = final.GetComponent<Grabbable>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            if (GameManager.controladorAplicacion.modoJuego == gameMode.Expert)
            {
                GameManager.controladorAplicacion.FailedSimulation();
            }
            else
            {
                resetPosition();
            }
        }
    }

    private void resetPosition()
    {
        cabeza.GetComponent<Grabbable>().enabled = false;
        final.GetComponent<Grabbable>().enabled = false;
        StartCoroutine(EsperarUnSegundo());
        conectorALlave.deleteJoint();
        cabeza.transform.position = posicionInicial;
        cabeza.transform.rotation = rotacionInicial;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    IEnumerator EsperarUnSegundo()
    {
        yield return new WaitForSeconds(1f);
        cabezaGrab.enabled = true;
        finalGrab.enabled = true;
    }
}
