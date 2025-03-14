using Oculus.Interaction;
using UnityEngine;

public class ColisionSueroSoporte : MonoBehaviour
{
    public Transform[] puntosColocacion; // Lista de puntos de colocación
    private GameObject boteEnZona;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suero"))
        {
            boteEnZona = other.gameObject; // Guardamos referencia al bote
            rb = boteEnZona.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.LockKinematic();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Suero") && boteEnZona == other.gameObject)
        {
            if (rb != null)
            {
                rb.UnlockKinematic();
            }
            boteEnZona = null; // Si el bote sale, lo olvidamos
        }
    }

    public void SoltarBote()
    {
        if (boteEnZona != null)
        {

            //Transform puntoMasCercano = ObtenerPuntoMasCercano(boteEnZona.transform.position);
            Debug.Log(boteEnZona.transform.position);
            boteEnZona.transform.position = puntosColocacion[0].position;
            Debug.Log(boteEnZona.transform.position);
            boteEnZona.transform.rotation = puntosColocacion[0].rotation;
            Debug.Log("Bote soltado");
        }
    }

    private Transform ObtenerPuntoMasCercano(Vector3 posicionBote)
    {
        Transform puntoCercano = puntosColocacion[0];
        float distanciaMinima = Vector3.Distance(posicionBote, puntoCercano.position);

        foreach (Transform punto in puntosColocacion)
        {
            float distancia = Vector3.Distance(posicionBote, punto.position);
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                puntoCercano = punto;
            }
        }

        return puntoCercano;
    }
}