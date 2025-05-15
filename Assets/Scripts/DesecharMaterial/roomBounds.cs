using Oculus.Interaction;
using System.Collections;
using UnityEngine;

public class roomBounds : MonoBehaviour
{
    private Grabbable myGrab;
    private Rigidbody rb;
    private float fuerzaRetroceso = 0.1f; //Hace que el objeto se desplace un poco en dirección contraria a la colisiion para que pueda volver a chocar
    private bool estaEsperando = false;

    void Start()
    {
        myGrab = GetComponent<Grabbable>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paredes"))
        {
            myGrab.enabled = false;

            Vector3 miPos = transform.position;
            Vector3 direccionRetroceso = Vector3.zero;

            float distanciaX = Mathf.Abs(miPos.x);
            float distanciaZ = Mathf.Abs(miPos.z);

            if (distanciaX > distanciaZ)
            {
                direccionRetroceso = new Vector3(-Mathf.Sign(miPos.x), 0, 0);
            }
            else
            {
                direccionRetroceso = new Vector3(0, 0, -Mathf.Sign(miPos.z));
            }

            //transform.position += direccionRetroceso * fuerzaRetroceso;

            rb.MovePosition(rb.position + direccionRetroceso * fuerzaRetroceso);

            if (!estaEsperando)
            {
                StartCoroutine(EsperarUnSegundo());
            }
        }
    }

    IEnumerator EsperarUnSegundo()
    {
        estaEsperando = true;
        yield return new WaitForSeconds(1f);
        myGrab.enabled = true;
        estaEsperando = false;
    }
}
